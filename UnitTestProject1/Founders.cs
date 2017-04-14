using System;
using NUnit;
using NUnit.Framework;
using DocumentPreparer;
using DocumentPreparer.Blocks;
using DocumentPreparer.Retrievers;
using DocumentPreparer.Models;
using UnitTestProject1.Data;
using UnitTestProject1.DataProviders;
using DocumentPreparer.Extensions;
using DocumentPreparer.Refs;

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

        [Test]
        [TestCaseSource(typeof(TestDataProvider), "TestCaseSources")]
        public void GetAuthorizedCapital(string DataName, ITestData testData)
        {
            var fb = new FoundersBlock(_propertiesRetrievers.Get());
            fb.SetBlocks(testData.Blocks2.GetByKeyOrEmpty(BlockHeadersRefs.ExtractFromEGRUL), "");

            var ac = fb.GetAuthorizedCapital();

            Assert.AreEqual(testData.AuthirizedCapital, ac);
        }

        [Test(Description = "Учредители ЮЛ")]
        [TestCaseSource(typeof(TestDataProvider), "TestCaseSources")]
        public void GetLE(string DataName, ITestData testData)
        {
            var fb = new FoundersBlock(_propertiesRetrievers.Get());
            fb.SetBlocks(testData.Blocks2.GetByKeyOrEmpty(BlockHeadersRefs.ExtractFromEGRUL), "");

            var fle = fb.GetLE();
            var expectedLE = testData.DocumentModel.FoundersLE;
            Assert.AreEqual(expectedLE.Length, fle.Length, "Incorrect count of precessed counters, must be {0} but was {1}", expectedLE.Length, fle.Length);
            for(var i = 0; i < expectedLE.Length; i++)
            {
                var flei = fle[i];
                var foundersLEi = expectedLE[i];
                StringAssert.AreEqualIgnoringCase(foundersLEi.Address, flei.Address, "Incorrect address at index {0}, must be {1} but was {2}", i, foundersLEi.Address, flei.Address);
                StringAssert.AreEqualIgnoringCase(foundersLEi.INN, flei.INN, "Incorrect INN at index {0}, must be {1} but was {2}", i, foundersLEi.INN, flei.INN);
                StringAssert.AreEqualIgnoringCase(foundersLEi.Name, flei.Name, "Incorrect Name at index {0}, must be {1} but was {2}", i, foundersLEi.Name, flei.Name);
                StringAssert.AreEqualIgnoringCase(foundersLEi.OGRN, flei.OGRN, "Incorrect OGRN at index {0}, must be {1} but was {2}", i, foundersLEi.OGRN, flei.OGRN);
                StringAssert.AreEqualIgnoringCase(foundersLEi.Share, flei.Share, "Incorrect Share at index {0}, must be {1} but was {2}", i, foundersLEi.Share, flei.Share);
            }
        }

        [Test(Description = "Учредители ФЛ")]
        [TestCaseSource(typeof(TestDataProvider), "TestCaseSources")]
        public void GetNP(string DataName, ITestData testData)
        {
            var fb = new FoundersBlock(_propertiesRetrievers.Get());
            fb.SetBlocks(testData.Blocks2.GetByKeyOrEmpty(BlockHeadersRefs.ExtractFromEGRUL), testData.Blocks2.GetByKeyOrEmpty(BlockHeadersRefs.Affiliation));

            var fnp = fb.GetNP();
            var expectedNP = testData.DocumentModel.FoundersNP;
            Assert.AreEqual(expectedNP.Length, fnp.Length, "Incorrect count of precessed counters, must be {0} but was {1}", expectedNP.Length, fnp.Length);
            for (var i = 0; i < expectedNP.Length; i++)
            {
                var fnpi = fnp[i];
                var foundersNPi = expectedNP[i];
                StringAssert.AreEqualIgnoringCase(foundersNPi.FullName, fnpi.FullName, "Incorrect FullName at index {0}, must be {1} but was {2}", i, foundersNPi.FullName, fnpi.FullName);
                StringAssert.AreEqualIgnoringCase(foundersNPi.INN, fnpi.INN, "Incorrect INN at index {0}, must be {1} but was {2}", i, foundersNPi.INN, fnpi.INN);
                StringAssert.AreEqualIgnoringCase(foundersNPi.Share, fnpi.Share, "Incorrect Share at index {0}, must be {1} but was {2}", i, foundersNPi.Share, fnpi.Share);
                StringAssert.AreEqualIgnoringCase(foundersNPi.LeaderOf, fnpi.LeaderOf, "Incorrect LeaderOf at index {0}, must be {1} but was {2}", i, foundersNPi.LeaderOf, fnpi.LeaderOf);
                StringAssert.AreEqualIgnoringCase(foundersNPi.FounderOf, fnpi.FounderOf, "Incorrect FounderOf at index {0}, must be {1} but was {2}", i, foundersNPi.FounderOf, fnpi.FounderOf);
            }
        }
    }
}
