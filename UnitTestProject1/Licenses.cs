using DocumentPreparer.Blocks;
using DocumentPreparer.Extensions;
using DocumentPreparer.Refs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Data;
using UnitTestProject1.DataProviders;

namespace UnitTestProject1
{
    [TestFixture]
    public class Licenses
    {
        [Test]
        [TestCaseSource(typeof(TestDataProvider), "TestCaseSources")]
        public void Get(string DataName, ITestData testData)
        {
            if(DataName == "Lanit")
            {

                var lBlock = new LicensesBlock();

                var result = lBlock.GetLicenses(testData.Blocks2.GetByKeyOrEmpty(BlockHeadersRefs.ExtractFromEGRUL));

                Assert.Fail();
            }
            

            Assert.Pass();
        }
    }
}
