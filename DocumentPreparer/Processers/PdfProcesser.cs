using DocumentPreparer.Extensions;
using DocumentPreparer.Models;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DocumentPreparer.Common;
using Org.BouncyCastle.Asn1.Mozilla;
using DocumentPreparer.Retrievers;

namespace DocumentPreparer.Processers
{
    public static class BlockHeadersRefs
    {
        public const string GeneralInfo = "GeneralInfo";
        public const string ChangesHistory = "ChangesHistory";
        public const string ExtractFromEGRUL = "ExtractFromEGRUL";
        public const string Affiliation = "Affiliation";
        public const string EstablishedEnterprises = "EstablishedEnterprises";
    }

    public static class PropertyRetrieversRefs
    {
        public static class GeneralInfo
        {
            public static string ShortName = "ShortName";
            public static string FullName = "FullName";
            public static string InitialRegistrationDate = "InitialRegistrationDate";
            public static string RegistrationNumber = "RegistrationNumber";
            public static string INN = "INN";
        }

        public static class Management
        {
            public static string Individual = "Individual";
            public static string IndividualAffiliations = "IndividualAffiliations";
            public static string Entity = "Entity";
        }

        public static class ExtractEGRUL
        {
            public static string AuthorizedCapital = "EGRULAuthorizedCapital";
        }

        public static class Founders
        {
            public static string LECommon = "LECommon";
            public static string NPCommon = "NPCommon";
        }
    }

    public class PdfProcesser : IProcesser
    {
        private Blocks.ManagementBlock _managementBlock;
        private Blocks.GeneralInfoBlock _generalInfoBlock;
        private Blocks.FoundersBlock _foundersBlock;
        private Blocks.EstablishedEnterprisesBlock _establishedEnterprisesBlock;

        private readonly IDictionary<string, string> BlockHeaders = new Dictionary<string, string>()
        {
            { BlockHeadersRefs.GeneralInfo, "общая информация" },
            { BlockHeadersRefs.ChangesHistory, "история изменений" },
            { BlockHeadersRefs.ExtractFromEGRUL, "выписка из егрюл" },
            { BlockHeadersRefs.Affiliation, "аффилированность" },
            { BlockHeadersRefs.EstablishedEnterprises, "информация об учрежденных предприятиях" },
        };

        private readonly Dictionary<string, PropertyRetriever> propertiesRetrieversNamed;
        private Dictionary<string, PropertyRetriever> blocksRetrieversNamed;

        private readonly IPropertiesRetrievers _propertiesRetrievers;

        public PdfProcesser(IPropertiesRetrievers propertiesRetrievers)
        {
            if (propertiesRetrievers == null)
                throw new ArgumentNullException("propertiesRetrievers");

            _propertiesRetrievers = propertiesRetrievers;

            propertiesRetrieversNamed = _propertiesRetrievers.Get();
            //blocksRetrieversNamed = blocksRetrievers.ToDictionary(x => x.Name, x => x);

            _managementBlock = new Blocks.ManagementBlock(propertiesRetrieversNamed);
            _generalInfoBlock = new Blocks.GeneralInfoBlock(propertiesRetrieversNamed);
            _foundersBlock = new Blocks.FoundersBlock(propertiesRetrieversNamed);
            _establishedEnterprisesBlock = new Blocks.EstablishedEnterprisesBlock(propertiesRetrieversNamed);
        }

        
        public DocumentModel Process(string inputPath)
        {
            if (string.IsNullOrEmpty(inputPath))
                throw new ArgumentNullException("inputPath");

            if (!System.IO.File.Exists(inputPath))
                throw new ArgumentException(string.Format("Файл '{0}' не существует", inputPath));

            PdfReader pdfReader;

            try
            {
                pdfReader = new PdfReader(inputPath);
            }
            catch (Exception e)
            {
                throw new Exception("Некорректный входной файл ", e);
            }

            var tableOfContents = new List<string>();

            string wholeDocText = string.Empty;
            for (var pageNum = 1; pageNum <= pdfReader.NumberOfPages; pageNum++)
            {
                
                var strategy = new SimpleTextExtractionStrategy();
                if (pageNum == 1)
                {
                    
                    var contentsJoined = CommonHelper.UseRetriever(
                    PdfTextExtractor.GetTextFromPage(pdfReader, pageNum, strategy)
                    , new PropertyRetriever { Name = "TableOfContents", RegExPattern = @"(?=общая информация)(?<value>[\S\s]*)\Z" });

                    tableOfContents.AddRange(Regex.Matches(contentsJoined, @"(?<value>[\S\s]+?)[\s\n]\d+\n?", RegexOptions.IgnoreCase).Cast<Match>().Select(m => CommonHelper.MultiLineProcesser(m.Groups["value"].Value.ToLower())));

                    blocksRetrieversNamed = new Dictionary<string, PropertyRetriever>();
                    foreach(var header in BlockHeaders)
                    {
                        var headerIndexInTableOfContents = tableOfContents.IndexOf(header.Value);
                        if(headerIndexInTableOfContents!= -1)
                        {
                            blocksRetrieversNamed.Add(header.Key, new PropertyRetriever()
                            {
                                Name = header.Key,
                                RegExPattern = string.Format(@"{0}\n(?<value>[\s\S]*?){1}",
                                    (header.Key != BlockHeadersRefs.GeneralInfo ? @"\d+" : "") + CommonHelper.PrepareSpacesInHeadersForRegEx(header.Value), 
                                    headerIndexInTableOfContents == (tableOfContents.Count-1) ? @"\Z" : CommonHelper.PrepareSpacesInHeadersForRegEx(tableOfContents[headerIndexInTableOfContents+1] + @"\n"))
                            });
                        }
                    }
                }
                else
                {
                    var pageText = PdfTextExtractor.GetTextFromPage(pdfReader, pageNum, strategy);
                    pageText = Regex.Replace(pageText, @".+[\s\n]Настоящий[\s\n]отчет[\s\n]подготовлен[\s\n]при[\s\n]помощи[\s\n]Сервиса[\s\n]проверки[\s\n]контрагентов[\s\n]www\.prima-inform\.ru[\s\n]\d{2}\s.+\d{4}[\s\n]", string.Empty, RegexOptions.IgnoreCase);
                    wholeDocText += pageText;
                }
            }

            //wholeDocText = Regex.Replace(wholeDocText, @".+[\s\n]Настоящий[\s\n]отчет[\s\n]подготовлен[\s\n]при[\s\n]помощи[\s\n]Сервиса[\s\n]проверки[\s\n]контрагентов[\s\n]www\.prima-inform\.ru[\s\n]\d{2}\s.+\d{4}[\s\n]\d+[\s\n\w]", string.Empty, RegexOptions.IgnoreCase);

            var blocks = GetBlocks(wholeDocText);

            if (!blocks.ContainsKey(BlockHeadersRefs.GeneralInfo))
                throw new Exception("Не обнаружен блок общей информации в источнике");

            var generalInfoBlock = _generalInfoBlock.Get(blocks[BlockHeadersRefs.GeneralInfo]);

            if (blocks.ContainsKey(BlockHeadersRefs.ChangesHistory))
                generalInfoBlock.NameChange = CommonHelper.UseRetriever(blocks[BlockHeadersRefs.ChangesHistory], propertiesRetrieversNamed["NameChanges"]);

            var result = new DocumentModel
            {
                Common = new Models.Common() {
                    ShortDate = DateTime.Now.ToString("dd.MM.yyyy")
                },
                GeneralInfoBlock = generalInfoBlock
            };

            if (blocks.ContainsKey(BlockHeadersRefs.ExtractFromEGRUL))
            {
                result.ManagementBlock = _managementBlock.Get(
                    blocks[BlockHeadersRefs.ExtractFromEGRUL],
                    blocks.ContainsKey(BlockHeadersRefs.Affiliation) ? blocks[BlockHeadersRefs.Affiliation] : null);
            }

            _foundersBlock.SetBlocks(
                blocks.ContainsKey(BlockHeadersRefs.ExtractFromEGRUL) ? blocks[BlockHeadersRefs.ExtractFromEGRUL] : string.Empty,
                blocks.ContainsKey(BlockHeadersRefs.Affiliation) ? blocks[BlockHeadersRefs.Affiliation] : string.Empty);

            result.FoundersLE = _foundersBlock.GetLE();
            result.FoundersNP = _foundersBlock.GetNP();

            result.EstablishedEnterprise = _establishedEnterprisesBlock.Get(blocks.ContainsKey(BlockHeadersRefs.EstablishedEnterprises) ? blocks[BlockHeadersRefs.EstablishedEnterprises] : string.Empty);

            return result;
        }

        private IDictionary<string, string> GetBlocks(string input)
        {
            var result = new Dictionary<string, string>();

            foreach(var blockRetriever in blocksRetrieversNamed)
            {
                result.Add(blockRetriever.Key, CommonHelper.UseRetriever(input, blockRetriever.Value));
            }

            return result; 
        }
    }
}
