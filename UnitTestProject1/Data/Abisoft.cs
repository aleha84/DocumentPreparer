using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentPreparer.Models;

namespace UnitTestProject1.Data
{
    public class Abisoft : ITestData
    {
        public IDictionary<string, string> Blocks2 { get; set; }
        public string DataName { get; set; }
        public string PDfName { get; set; }
        public decimal AuthirizedCapital { get; set; }
        public DocumentModel DocumentModel { get; set; }

        public static Abisoft Instance
        {
            get
            {
                return new Abisoft
                {
                    PDfName = "недобросовестный-поставщик ООО АБИСОФТ бизнес справка",
                    DataName = "Abisoft",
                    AuthirizedCapital = 16000m,
                    DocumentModel = new DocumentModel
                    {
                        GeneralInfoBlock = new GeneralInfoBlock
                        {
                            ShortName = @"ООО ""АБИСОФТ""",
                            FullName = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""АБИСОФТ""",
                            INN = "7716212993",
                            InitialRegistrationDate = "08.01.2002"
                        },
                        FoundersLE = new FounderLE[]
                        {
                            new FounderLE()
                        },
                        FoundersNP = new FounderNP[]
                        {
                            new FounderNP
                            {
                                FullName = "ВОРОНИН СЕРГЕЙ ВИКТОРОВИЧ",
                                INN = "772729678426",
                                Share = "50"
                            },
                            new FounderNP
                            {
                                FullName = "ПЫЛЬЦОВ ВАДИМ ВЯЧЕСЛАВОВИЧ",
                                INN = "561441936069",
                                Share = "50",
                            }
                        },
                        EstablishedEnterprise = new[] {
                            new EstablishedEnterprise()
                            },
                        GovernmentContracts = new []
                        {
                            new GovernmentContract
                            {
                                Year = 2011,
                                Count = 4,
                                Total = 448228.58m
                            },
                            new GovernmentContract
                            {
                                Year = 2012,
                                Count = 17,
                                Total = 2269558.85m
                            },
                            new GovernmentContract
                            {
                                Year = 2013,
                                Count = 18,
                                Total = 8153691.07m
                            },
                            new GovernmentContract
                            {
                                Year = 2014,
                                Count = 14,
                                Total = 5494283.12m
                            },
                            new GovernmentContract
                            {
                                Year = 2015,
                                Count = 20,
                                Total = 6885544.17m
                            },
                            new GovernmentContract
                            {
                                Year = 2016,
                                Count = 10,
                                Total = 2375796.87m
                            },
                            new GovernmentContract
                            {
                                Year = 2017,
                                Count = 1,
                                Total = 398720m
                            }
                        }
                    }, 
                    Blocks2 = null,
                };
            }
        }
    }
}
