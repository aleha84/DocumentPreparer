using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DocumentPreparer.Common;
using DocumentPreparer.Models;
using DocumentPreparer.Processers;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using DocumentPreparer.Refs;

namespace DocumentPreparer.Blocks.Extractors
{
    public class PdfBlocksExtractor : IBlocksExtractor
    {
        private Dictionary<string, PropertyRetriever> _blocksRetrieversNamed;
        private IDictionary<string, string> _blockHeaders;

        public PdfBlocksExtractor()
        {
            _blockHeaders = new Dictionary<string, string>()
            {
                { BlockHeadersRefs.GeneralInfo, "общая информация" },
                { BlockHeadersRefs.ChangesHistory, "история изменений" },
                { BlockHeadersRefs.ExtractFromEGRUL, "выписка из егрюл" },
                { BlockHeadersRefs.Affiliation, "аффилированность" },
                { BlockHeadersRefs.EstablishedEnterprises, "информация об учрежденных предприятиях" },
                { BlockHeadersRefs.GovernmentContracts, "проверка наличия у объекта государственных контрактов" }
            };
        }

        public IDictionary<string, string> GetBlocks(string path)
        {
            PdfReader pdfReader;
            
            try
            {
                pdfReader = new PdfReader(path);
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

                    _blocksRetrieversNamed = new Dictionary<string, PropertyRetriever>();
                    foreach (var header in _blockHeaders)
                    {
                        var headerIndexInTableOfContents = tableOfContents.IndexOf(header.Value);
                        if (headerIndexInTableOfContents != -1)
                        {
                            _blocksRetrieversNamed.Add(header.Key, new PropertyRetriever()
                            {
                                Name = header.Key,
                                RegExPattern = string.Format(@"{0}\n(?<value>[\s\S]*?){1}",
                                    (header.Key != BlockHeadersRefs.GeneralInfo ? @"\d+" : "") + CommonHelper.PrepareSpacesInHeadersForRegEx(header.Value),
                                    headerIndexInTableOfContents == (tableOfContents.Count - 1) ? @"\Z" : CommonHelper.PrepareSpacesInHeadersForRegEx(tableOfContents[headerIndexInTableOfContents + 1] + @"\n"))
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

            return GetBlocksInternal(wholeDocText);
        }

        private IDictionary<string, string> GetBlocksInternal(string input)
        {
            var result = new Dictionary<string, string>();

            foreach (var blockRetriever in _blocksRetrieversNamed)
            {
                result.Add(blockRetriever.Key, CommonHelper.UseRetriever(input, blockRetriever.Value));
            }

            return result;
        }
    }
}
