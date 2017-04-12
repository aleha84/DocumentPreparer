using DocumentPreparer.Retrievers;
using NUnit;
using NUnit.Framework;
using UnitTestProject1.Data;
using DocumentPreparer.Blocks;

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

        static object[] TestDataCaseSource =
        {
            new object[]{  Megapolis.Instance.DataName, Megapolis.Instance },
            new object[]{ KTSP.Instance.DataName, KTSP.Instance },
            new object[]{ OtelCity.Instance.DataName, OtelCity.Instance },
            new object[]{ Briks.Instance.DataName, Briks.Instance },
            new object[]{ Abisoft.Instance.DataName, Abisoft.Instance }
        };

        [Test]
        [TestCaseSource("TestDataCaseSource")]
        public void GeneralInfoBlock_Get(string DataName, ITestData testData)
        {
            var gib = new GeneralInfoBlock(_propertiesRetrievers.Get());
            
            var gi = gib.Get(testData.Blocks["GeneralInfo"]);

            StringAssert.AreEqualIgnoringCase(testData.GeneralInfo.INN, gi.INN, "INN");
            StringAssert.AreEqualIgnoringCase(testData.GeneralInfo.ShortName, gi.ShortName, "ShortName");
            StringAssert.AreEqualIgnoringCase(testData.GeneralInfo.FullName, gi.FullName, "FullName");
            StringAssert.AreEqualIgnoringCase(testData.GeneralInfo.InitialRegistrationDate, gi.InitialRegistrationDate, "InitialRegistrationDate");
        }
    }
}
