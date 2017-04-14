using DocumentPreparer.Retrievers;
using NUnit;
using NUnit.Framework;
using UnitTestProject1.Data;
using DocumentPreparer.Blocks;
using UnitTestProject1.DataProviders;
using DocumentPreparer.Extensions;
using DocumentPreparer.Refs;

namespace UnitTestProject1
{
    [TestFixture]
    public class GeneralInfo
    {
        private IPropertiesRetrievers _propertiesRetrievers;

        [OneTimeSetUp]
        public void GlobalPrepare()
        {
            _propertiesRetrievers = new PropertiesRetrievers();
        }

        [Test]
        [TestCaseSource(typeof(TestDataProvider), "TestCaseSources")]
        public void GeneralInfoBlock_Get(string DataName, ITestData testData)
        {
            var gib = new GeneralInfoBlock(_propertiesRetrievers.Get());
            
            var gi = gib.Get(testData.Blocks2.GetByKeyOrEmpty(BlockHeadersRefs.GeneralInfo));
            var expectedGI = testData.DocumentModel.GeneralInfoBlock;

            StringAssert.AreEqualIgnoringCase(expectedGI.INN, gi.INN, "INN");
            StringAssert.AreEqualIgnoringCase(expectedGI.ShortName, gi.ShortName, "ShortName");
            StringAssert.AreEqualIgnoringCase(expectedGI.FullName, gi.FullName, "FullName");
            StringAssert.AreEqualIgnoringCase(expectedGI.InitialRegistrationDate, gi.InitialRegistrationDate, "InitialRegistrationDate");
        }
    }
}
