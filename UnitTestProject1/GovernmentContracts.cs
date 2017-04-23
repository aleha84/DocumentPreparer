using DocumentPreparer.Blocks;
using DocumentPreparer.Extensions;
using DocumentPreparer.Refs;
using NUnit.Framework;
using UnitTestProject1.Data;
using UnitTestProject1.DataProviders;

namespace UnitTestProject1
{
    /// <summary>
    /// Summary description for GovernmentContracts
    /// </summary>
    [TestFixture]
    public class GovernmentContracts
    {
        [Test]
        [TestCaseSource(typeof(TestDataProvider), "TestCaseSources")]
        public void Get(string DataName, ITestData testData)
        {
            var gcBlock = new GovernmentContractsBlock();

            var actual = gcBlock.Get(testData.Blocks2.GetByKeyOrEmpty(BlockHeadersRefs.GovernmentContracts));

            Assert.AreEqual(testData.DocumentModel.GovernmentContracts.Length, actual.Length, "Length");
            for(var i = 0; i < actual.Length; i++)
            {
                var actualItem = actual[i];
                var expectedItem = testData.DocumentModel.GovernmentContracts[i];

                Assert.AreEqual(expectedItem.Year, actualItem.Year, "Year {0}", i);
                Assert.AreEqual(expectedItem.Count, actualItem.Count, "Count {0}", i);
                Assert.AreEqual(expectedItem.Total, actualItem.Total, "Total {0}", i);
            }
        }
    }
}
