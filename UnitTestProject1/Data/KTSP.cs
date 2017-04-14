using DocumentPreparer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Data
{
    public class KTSP : ITestData
    {
        public Dictionary<string, string> Blocks { get; set; }
        public IDictionary<string, string> Blocks2 { get; set; }
        public string DataName { get; set; }
        public string PDfName { get; set; }
        public GeneralInfoBlock GeneralInfo { get; set; }
        public FounderNP[] FoundersNP { get; set; }
        public FounderLE[] FoundersLE { get; set; }
        public decimal AuthirizedCapital { get; set; }
        public DocumentModel DocumentModel { get; set; }

        public static KTSP Instance
        {
            get
            {
                return new KTSP
                {
                    DataName = "KTSP",
                    AuthirizedCapital = 3600000m,
                    PDfName = "управляющая-компания ЗАО КТСП бизнес справка",
                    DocumentModel = new DocumentModel
                    {
                        GeneralInfoBlock = new GeneralInfoBlock
                        {
                            ShortName = @"ЗАО ""КТСП""",
                            FullName = @"ЗАКРЫТОЕ АКЦИОНЕРНОЕ ОБЩЕСТВО ""КОНТЕЙНЕРНЫЙ ТЕРМИНАЛ САНКТ-ПЕТЕРБУРГ""",
                            INN = "7805124273",
                            InitialRegistrationDate = "04.02.1999"
                        },
                        FoundersNP = new[]
                        {
                            new FounderNP
                            {
                                FullName = null,
                                INN = null,
                                Share = null
                            }
                        },
                            FoundersLE = new[] {
                            new FounderLE {
                                Name = "ОТКРЫТОЕ АКЦИОНЕРНОЕ ОБЩЕСТВО \"МОРСКОЙ ПОРТ САНКТ-ПЕТЕРБУРГ\"",
                                Address = "",
                                INN = "7805025346",
                                OGRN = "",
                                Share = "0,53"
                            },
                            new FounderLE {
                                Name = "DALEBORO TRADING LIMITED",
                                Address = "55, МАЧЕРА АВЕНЮ, АГИА ВАРВАРА, НИКОСИЯ, КИПР",
                                INN = null,
                                OGRN = null,
                                Share = "2,25"
                            }
                        }
                    },
                };
            }
        }
    }
}
