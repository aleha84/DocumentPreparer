using System;
using NUnit;
using NUnit.Framework;
using DocumentPreparer;
using DocumentPreparer.Blocks;
using DocumentPreparer.Retrievers;
using DocumentPreparer.Models;
using UnitTestProject1.Data;

namespace UnitTestProject1
{
    [TestFixture]
    public class Founders
    {
        private IPropertiesRetrievers _propertiesRetrievers;

        [OneTimeSetUp]
        public void  GlobalPrepare()
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
        public void GetAuthorizedCapital(string DataName, ITestData testData)
        {
            var fb = new FoundersBlock(_propertiesRetrievers.Get());
            fb.SetBlocks(testData.Blocks["ExtractFromEGRUL"], "");

            var ac = fb.GetAuthorizedCapital();

            Assert.AreEqual(testData.AuthirizedCapital, ac);
        }

        [Test(Description = "Учредители ЮЛ")]
        [TestCaseSource("TestDataCaseSource")]
        public void GetLE(string DataName, ITestData testData)
        {
            var fb = new FoundersBlock(_propertiesRetrievers.Get());
            fb.SetBlocks(testData.Blocks["ExtractFromEGRUL"], "");

            var fle = fb.GetLE();

            Assert.AreEqual(testData.FoundersLE.Length, fle.Length, "Incorrect count of precessed counters, must be {0} but was {1}", testData.FoundersLE.Length, fle.Length);
            for(var i = 0; i < testData.FoundersLE.Length; i++)
            {
                var flei = fle[i];
                var foundersLEi = testData.FoundersLE[i];
                StringAssert.AreEqualIgnoringCase(foundersLEi.Address, flei.Address, "Incorrect address at index {0}, must be {1} but was {2}", i, foundersLEi.Address, flei.Address);
                StringAssert.AreEqualIgnoringCase(foundersLEi.INN, flei.INN, "Incorrect INN at index {0}, must be {1} but was {2}", i, foundersLEi.INN, flei.INN);
                StringAssert.AreEqualIgnoringCase(foundersLEi.Name, flei.Name, "Incorrect Name at index {0}, must be {1} but was {2}", i, foundersLEi.Name, flei.Name);
                StringAssert.AreEqualIgnoringCase(foundersLEi.OGRN, flei.OGRN, "Incorrect OGRN at index {0}, must be {1} but was {2}", i, foundersLEi.OGRN, flei.OGRN);
                StringAssert.AreEqualIgnoringCase(foundersLEi.Share, flei.Share, "Incorrect Share at index {0}, must be {1} but was {2}", i, foundersLEi.Share, flei.Share);
            }
        }

        [Test(Description = "Учредители ФЛ")]
        [TestCaseSource("TestDataCaseSource")]
        public void GetNP(string DataName, ITestData testData)
        {
            var fb = new FoundersBlock(_propertiesRetrievers.Get());
            fb.SetBlocks(testData.Blocks["ExtractFromEGRUL"], testData.Blocks["Affiliation"]);

            var fnp = fb.GetNP();

            Assert.AreEqual(testData.FoundersNP.Length, fnp.Length, "Incorrect count of precessed counters, must be {0} but was {1}", testData.FoundersNP.Length, fnp.Length);
            for (var i = 0; i < testData.FoundersNP.Length; i++)
            {
                var fnpi = fnp[i];
                var foundersNPi = testData.FoundersNP[i];
                StringAssert.AreEqualIgnoringCase(foundersNPi.FullName, fnpi.FullName, "Incorrect FullName at index {0}, must be {1} but was {2}", i, foundersNPi.FullName, fnpi.FullName);
                StringAssert.AreEqualIgnoringCase(foundersNPi.INN, fnpi.INN, "Incorrect INN at index {0}, must be {1} but was {2}", i, foundersNPi.INN, fnpi.INN);
                StringAssert.AreEqualIgnoringCase(foundersNPi.Share, fnpi.Share, "Incorrect Share at index {0}, must be {1} but was {2}", i, foundersNPi.Share, fnpi.Share);
                StringAssert.AreEqualIgnoringCase(foundersNPi.LeaderOf, fnpi.LeaderOf, "Incorrect LeaderOf at index {0}, must be {1} but was {2}", i, foundersNPi.LeaderOf, fnpi.LeaderOf);
                StringAssert.AreEqualIgnoringCase(foundersNPi.FounderOf, fnpi.FounderOf, "Incorrect FounderOf at index {0}, must be {1} but was {2}", i, foundersNPi.FounderOf, fnpi.FounderOf);
            }
        }
    }
}
