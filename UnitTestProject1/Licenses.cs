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
            var lBlock = new LicensesBlock();

            var result = lBlock.GetLicenses(testData.Blocks2.GetByKeyOrEmpty(BlockHeadersRefs.ExtractFromEGRUL));

            Assert.AreEqual(testData.DocumentModel.Licenses.Length, result.Length, "Count is wrong");
            for (var i = 0; i < testData.DocumentModel.Licenses.Length; i++)
            {
                var expected = testData.DocumentModel.Licenses[i];
                var actual = result[i];

                StringAssert.AreEqualIgnoringCase(expected.Value, actual.Value, string.Format("Index [{0}]", i));
            }
        }
    }
}
