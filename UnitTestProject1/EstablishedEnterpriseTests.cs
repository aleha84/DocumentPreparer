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
using UnitTestProject1.DataProviders;

namespace UnitTestProject1
{
    [TestFixture]
    public class EstablishedEnterpriseTests
    {
        [Test]
        [TestCaseSource(typeof(TestDataProvider), "TestCaseSources")]
        public void Get(string DataName, ITestData testData)
        {
            var eeBlock = new EstablishedEnterprisesBlock();

            var result = eeBlock.Get(testData.Blocks2.GetByKeyOrEmpty(BlockHeadersRefs.EstablishedEnterprises));

            Assert.AreEqual(testData.DocumentModel.EstablishedEnterprise.Length, result.Length, "Count is wrong");

            for (var i = 0; i < testData.DocumentModel.EstablishedEnterprise.Length; i++)
            {
                var expected = testData.DocumentModel.EstablishedEnterprise[i];
                var actual = result[i];

                StringAssert.AreEqualIgnoringCase(expected.Address, actual.Address, string.Format("Address [{0}]", i));
                StringAssert.AreEqualIgnoringCase(expected.INN, actual.INN, "INN");
                StringAssert.AreEqualIgnoringCase(expected.Name, actual.Name, "Name");
                StringAssert.AreEqualIgnoringCase(expected.OGRN, actual.OGRN, "OGRN");
                StringAssert.AreEqualIgnoringCase(expected.Share, actual.Share, string.Format("Share [{0}]", i));
            }
        }
    }
}
