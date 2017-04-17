using DocumentPreparer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Data
{
    public class Galafor : ITestData
    {
        public IDictionary<string, string> Blocks2 { get; set; }
        public string DataName { get; set; }
        public string PDfName { get; set; }
        public decimal AuthirizedCapital { get; set; }
        public DocumentModel DocumentModel { get; set; }

        public static Galafor Instance
        {
            get
            {
                return new Galafor()
                {
                    PDfName = "дочерние компании ООО ГАЛАФОР бизнес справка",
                    DataName = "Galafor",
                    AuthirizedCapital = 1000000m,
                    DocumentModel = new DocumentModel
                    {
                        GeneralInfoBlock = new GeneralInfoBlock
                        {
                            ShortName = @"ООО ""ГАЛАФОР""",
                            FullName = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""ГАЛАФОР""",
                            INN = "7841468992",
                            AuthorizedCapital = "1 000 000,00",
                            Currency = "руб.",
                            InitialRegistrationDate = "16.08.2012"
                        },
                        FoundersNP = new []
                        {
                            new FounderNP
                            {
                                FullName = "ХРОМОЙ АНДРЕЙ ВАЛЕРЬЕВИЧ",
                                INN = "781119500468",
                                Share = "100"
                            }
                        },
                        EstablishedEnterprise = new[]
                        {
                            new EstablishedEnterprise
                            {
                                Name = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""ЗАВОД ПО ПРОИЗВОДСТВУ ЖЕЛЕЗОБЕТОННЫХ ИЗДЕЛИЙ И КОНСТРУКЦИЙ МОРСКОГО ГИДРОТЕХНИЧЕСКОГО СТРОИТЕЛЬСТВА САНКТ-ПЕТЕРБУРГА""",
                                Address = @"198096,ГОРОД САНКТ-ПЕТЕРБУРГ, ДОРОГА НА ТУРУХТАННЫЕ ОСТРОВА,26,4",
                                OGRN = "1117847260629", INN = "7805557380", Share = "25.00%"
                            },
                            new EstablishedEnterprise
                            {
                                Name = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""КОМПАНИЯ ЛКТ""",
                                Address = @"183010,ОБЛАСТЬ МУРМАНСКАЯ, ГОРОД МУРМАНСК, УЛИЦА ДЕКАБРИСТОВ,1",
                                OGRN = "1025100837178", INN = "5193410948",Share= "5.98%"
                            },
                            new EstablishedEnterprise
                            {
                                Name = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""МОРСКАЯ ЗВЕЗДА""",
                                Address = "236039,ОБЛАСТЬ КАЛИНИНГРАДСКАЯ, ГОРОД КАЛИНИНГРАД, УЛИЦА А.СУВОРОВА,57",
                                OGRN = "1023901862412", INN = "3903017709", Share = "6.05%"
                            },
                            new EstablishedEnterprise
                            {
                                Name = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""ЗЕМЛАНД-ЭКСИМА""",
                                Address = @"236039,ОБЛАСТЬ КАЛИНИНГРАДСКАЯ, ГОРОД КАЛИНИНГРАД, УЛИЦА А.СУВОРОВА,57",
                                OGRN = "1023900765019", INN = "3905010681", Share = string.Empty
                            },
                            new EstablishedEnterprise
                            {
                                Name = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""ИНВЕСТПРОЕКТ""",
                                Address = "125009,ГОРОД МОСКВА, ПЕРЕУЛОК БРЮСОВ,4",
                                OGRN = "1067746764029", INN = "7703598676", Share = string.Empty
                            }
                        }
                    },
                    Blocks2 = null,
                };
            }
        }
    }
}
