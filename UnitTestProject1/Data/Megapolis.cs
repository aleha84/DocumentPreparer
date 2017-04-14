using DocumentPreparer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Data
{
    public class Megapolis : ITestData
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

        public static Megapolis Instance {
            get
            {
                return new Megapolis
                {
                    DataName = "Megapolis",
                    PDfName = "ООО МЕГАПОЛИС СЕРВИС бизнес справка",
                    AuthirizedCapital = 1000000m,
                    DocumentModel = new DocumentModel
                    {
                        GeneralInfoBlock = new GeneralInfoBlock
                        {
                            ShortName = @"ООО ""МЕГАПОЛИС-СЕРВИС""",
                            FullName = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""МЕГАПОЛИС- СЕРВИС""",
                            INN = "7743579567",
                            InitialRegistrationDate = "13.12.2005"
                        },
                        FoundersNP = new[]
                        {
                            new FounderNP
                            {
                                FullName = "КУЗНЕЦОВА ОКСАНА ЮРЬЕВНА",
                                INN = "774360571868",
                                Share = "15"
                            }
                        },
                            FoundersLE = new[] {
                            new FounderLE {
                                Name = "ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ \"ТЕХНОИНВЕСТ\"",
                                Address = "",
                                INN = "7838475125",
                                OGRN = "1127847257691",
                                Share = "85"
                            }
                        },
                         EstablishedEnterprise = new[]
                         {
                             new DocumentPreparer.Models.EstablishedEnterprise()
                             {
                                 Address = @"630005,ОБЛАСТЬ НОВОСИБИРСКАЯ, ГОРОД НОВОСИБИРСК, УЛИЦА КАМЕНСКАЯ,53",
                                 INN = "5406510876",
                                 Name = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""МЕГАПОЛИС-СЕРВИС СИБИРЬ""",
                                 OGRN = "1085406046000",
                                 Share = string.Empty
                             }
                         }   
                    },
                    Blocks2 = null,
    };
            }
        }

        
    }
}
