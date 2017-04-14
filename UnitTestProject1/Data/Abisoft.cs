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
                    }, 
                    Blocks2 = null,
                };
            }
        }
    }
}
