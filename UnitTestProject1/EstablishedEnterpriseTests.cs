using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentPreparer.Blocks;
using DocumentPreparer.Blocks.Extractors;
using DocumentPreparer.Extensions;
using DocumentPreparer.Refs;
using NUnit.Framework;
using UnitTestProject1.Data;

namespace UnitTestProject1
{
    [TestFixture]
    public class EstablishedEnterpriseTests
    {
        private readonly string applicationDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        private IBlocksExtractor _blocksExtractor;

        private static object[] TestCaseSources =
        {
            new object[] {Megapolis.Instance.DataName, Megapolis.Instance},
        };

        [OneTimeSetUp]
        public void GlobalPrepare()
        {
            _blocksExtractor = new PdfBlocksExtractor();
            foreach (object[] testCaseSource in TestCaseSources)
            {
                var testData = (ITestData) testCaseSource[1];
                var pdfPath = Path.Combine(applicationDirectory, "PDFs", testData.PDfName + ".pdf");
                if (!File.Exists(pdfPath))
                    throw new FileNotFoundException(pdfPath);
                if(testData.Blocks2 == null || testData.Blocks2.Count == 0)
                    testData.Blocks2 =
                        _blocksExtractor.GetBlocks(pdfPath);
            }
        }

        [Test]
        [TestCaseSource("TestCaseSources")]
        public void Get(string DataName, ITestData testData)
        {
            var eeBlock = new EstablishedEnterprisesBlock();

            var result = eeBlock.Get(testData.Blocks2.GetByKeyOrEmpty(BlockHeadersRefs.EstablishedEnterprises));

            Assert.AreEqual(testData.DocumentModel.EstablishedEnterprise.Length, result.Length, "Count is wrong");

            for (var i = 0; i < testData.DocumentModel.EstablishedEnterprise.Length; i++)
            {
                var expected = testData.DocumentModel.EstablishedEnterprise[i];
                var actual = result[i];

                StringAssert.AreEqualIgnoringCase(expected.Address, actual.Address, "Address");
                StringAssert.AreEqualIgnoringCase(expected.INN, actual.INN, "INN");
                StringAssert.AreEqualIgnoringCase(expected.Name, actual.Name, "Name");
                StringAssert.AreEqualIgnoringCase(expected.OGRN, actual.OGRN, "OGRN");
                StringAssert.AreEqualIgnoringCase(expected.Share, actual.Share, "Share");
            }
        }
    }
}
