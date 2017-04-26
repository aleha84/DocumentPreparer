using DocumentPreparer.Extensions;
using DocumentPreparer.Models;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DocumentPreparer.Blocks;
using DocumentPreparer.Blocks.Extractors;
using DocumentPreparer.Common;
using DocumentPreparer.Refs;
using Org.BouncyCastle.Asn1.Mozilla;
using DocumentPreparer.Retrievers;

namespace DocumentPreparer.Processers
{
    public class PdfProcesser : IProcesser
    {
        private IBlocksExtractor _blocksExtractor;

        private Blocks.ManagementBlock _managementBlock;
        private Blocks.GeneralInfoBlock _generalInfoBlock;
        private Blocks.FoundersBlock _foundersBlock;
        private Blocks.EstablishedEnterprisesBlock _establishedEnterprisesBlock;
        private Blocks.LicensesBlock _licensesBlockBlock;
        private Blocks.GovernmentContractsBlock _governmentContractsBlock;

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

            _blocksExtractor = new PdfBlocksExtractor();

            _managementBlock = new Blocks.ManagementBlock(propertiesRetrieversNamed);
            _generalInfoBlock = new Blocks.GeneralInfoBlock(propertiesRetrieversNamed);
            _foundersBlock = new Blocks.FoundersBlock(propertiesRetrieversNamed);
            _establishedEnterprisesBlock = new Blocks.EstablishedEnterprisesBlock();
            _licensesBlockBlock = new Blocks.LicensesBlock();
            _governmentContractsBlock = new GovernmentContractsBlock();
        }

        
        public DocumentModel Process(string inputPath)
        {
            if (string.IsNullOrEmpty(inputPath))
                throw new ArgumentNullException("inputPath");

            if (!System.IO.File.Exists(inputPath))
                throw new ArgumentException(string.Format("Файл '{0}' не существует", inputPath));

            var blocks = _blocksExtractor.GetBlocks(inputPath);

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

            result.Licenses = _licensesBlockBlock.GetLicenses(blocks.GetByKeyOrEmpty(BlockHeadersRefs.ExtractFromEGRUL)).Reverse().ToArray();

            result.GovernmentContracts =
                _governmentContractsBlock.Get(blocks.GetByKeyOrEmpty(BlockHeadersRefs.GovernmentContracts));

            return result;
        }
    }
}
