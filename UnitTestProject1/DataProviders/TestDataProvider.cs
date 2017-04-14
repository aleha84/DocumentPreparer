using DocumentPreparer.Blocks.Extractors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Data;

namespace UnitTestProject1.DataProviders
{
    public class TestDataProvider
    {
        private static readonly string applicationDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        private static IBlocksExtractor _blocksExtractor;

        private static object[] TestCaseSources =
        {
            new object[] {Megapolis.Instance.DataName, Megapolis.Instance},
            new object[] {Abisoft.Instance.DataName, Abisoft.Instance},
            new object[] {Briks.Instance.DataName, Briks.Instance},
        };

        static TestDataProvider()
        {
            _blocksExtractor = new PdfBlocksExtractor();

            foreach (object[] testCaseSource in TestCaseSources)
            {
                var testData = (ITestData)testCaseSource[1];
                var pdfPath = Path.Combine(applicationDirectory, "PDFs", testData.PDfName + ".pdf");
                if (!File.Exists(pdfPath))
                    throw new FileNotFoundException(pdfPath);
                if (testData.Blocks2 == null || testData.Blocks2.Count == 0)
                    testData.Blocks2 =
                        _blocksExtractor.GetBlocks(pdfPath);
            }
        }


    }
}
