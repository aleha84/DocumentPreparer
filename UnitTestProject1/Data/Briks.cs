using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentPreparer.Models;

namespace UnitTestProject1.Data
{
    public class Briks : ITestData
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

        public static Briks Instance
        {
            get
            {
                return new Briks
                {
                    DataName = "Briks",
                    AuthirizedCapital = 294000m,
                    PDfName = "иной-негатив-изменение-наименования АО БРИКС ИТ бизнес справка",
                    DocumentModel = new DocumentModel
                    {
                        GeneralInfoBlock = new GeneralInfoBlock
                        {
                            ShortName = @"АО ""БРИКС ИТ""",
                            FullName = @"АКЦИОНЕРНОЕ ОБЩЕСТВО ""БРИКС ИТ""",
                            INN = "7719206620",
                            InitialRegistrationDate = "19.09.2000"

                        },
                        FoundersLE = new FounderLE[]
                        {
                            new FounderLE()
                        },
                            FoundersNP = new FounderNP[]
                        {
                            new FounderNP()
                        },
                            Licenses = new []
                            {
                                new License
                                {
                                    Value = @"1. №ЛСЗ0012453 14907Н бессрочно, статус: Лицензия действующая, Лицензирующий орган: Центр по лицензированию, сертификации и защите государственной тайны, с 09.02.2016 по 01.01.0001, адрес: 115114, г. Москва, 1-й Дербеневский пер., д. 5"
                                },
                                new License
                                {
                                    Value = @"2. №77-Б/02005, статус: Лицензия действующая, Лицензирующий орган: ГУ МЧС России по г.Москве, с 20.04.2015 по 01.01.0001, адрес: 1151117, г. Москва, Дербеневская наб., д. 7, стр. 5, оф. 7"
                                },
                                new License
                                {
                                    Value = @"3. №ЛСЗ0012877 15352Н бессрочно, статус: Лицензия действующая, Лицензирующий орган: Центр по лицензированию, сертификации и защите государственной тайны, с 16.08.2016 по 01.01.0001, адрес: 115114, г. Москва, Дербеневская наб., д. 7, стр. 5, оф. 106"
                                },
                                new License
                                {
                                    Value = @"4. №77.99.15.002.Л.000110.11.16, статус: Лицензия действующая, Лицензирующий орган: Федеральная служба по надзору в сфере защиты прав потребителей и благополучия человека, с 07.11.2016 по 01.01.0001, адрес: 115114, г. Москва, Дербеневская набережная, д. 7, стр. 5, офис 106. Место нахождения территориально обособленных подразделений, используемых для осуществления лицензируемой деятельности: г. Москва, ул. Подольских Курсантов, д. 3, стр. 7А"
                                }
                            },
                            EstablishedEnterprise = new []
                            {
                                new EstablishedEnterprise
                                {
                                    Address = "620107,ОБЛАСТЬ СВЕРДЛОВСКАЯ, ГОРОД ЕКАТЕРИНБУРГ, УЛИЦА 3 ИНТЕРНАЦИОНАЛА,1,А,15",
                                    INN = "6659018610",
                                    Name = @"ЗАКРЫТОЕ АКЦИОНЕРНОЕ ОБЩЕСТВО ""МИКРОТЕСТ""",
                                    OGRN = "1026602955312", Share = string.Empty
                                },
                                new EstablishedEnterprise
                                {
                                    Name = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""ЛАНТРИ""",
                                    Address = "620000,ОБЛАСТЬ СВЕРДЛОВСКАЯ, ГОРОД ЕКАТЕРИНБУРГ, ПРОСПЕКТ ЛЕНИНА,60,А,210",
                                    OGRN = "1026604948171",
                                    INN = "6670003745", Share = string.Empty
                                },
                                new EstablishedEnterprise
                                {
                                    Name= @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""ДИЛ4ИТ""",
                                    Address = "115114,ГОРОД МОСКВА, ПЕРЕУЛОК ДЕРБЕНЕВСКИЙ 1-Й,5,СТР.2",
                                    OGRN = "1027708016786", INN= "7708212125", Share="100.00%"
                                },
                                new EstablishedEnterprise
                                {
                                    Name = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""СТРУКТУРИРОВАННЫЕ ИНФОРМАЦИОННЫЕ СИСТЕМЫ""",
                                    Address = "119607,ГОРОД МОСКВА, УЛИЦА РАМЕНКИ,17,1",
                                    OGRN = "1037729016632", INN = "7729428809"  , Share = string.Empty
                                },
                                new EstablishedEnterprise
                                {
                                    Name = @"НЕГОСУДАРСТВЕННОЕ ОБРАЗОВАТЕЛЬНОЕ УЧРЕЖДЕНИЕ ДОПОЛНИТЕЛЬНОГО ПРОФЕССИОНАЛЬНОГО ОБРАЗОВАНИЯ ""УЧЕБНЫЙ ЦЕНТР ""МИКРОТЕСТ""",
                                    Address = "115114,ГОРОД МОСКВА, ПЕРЕУЛОК ДЕРБЕНЕВСКИЙ 1-Й,5,СТР. 2",
                                    OGRN = "1067799027560", INN = "7714319902", Share = string.Empty
                                },
                                new EstablishedEnterprise
                                {
                                    Name = @"ЧАСТНОЕ ОБРАЗОВАТЕЛЬНОЕ УЧРЕЖДЕНИЕ ДОПОЛНИТЕЛЬНОГО ПРОФЕССИОНАЛЬНОГО ОБРАЗОВАНИЯ ""УЧЕБНЫЙ ЦЕНТР ""МИКРОТЕСТ""",
                                    Address = "620075,ОБЛАСТЬ СВЕРДЛОВСКАЯ, ГОРОД ЕКАТЕРИНБУРГ, УЛИЦА ГОГОЛЯ,36, 605",
                                    OGRN = "1056604451200", INN = "6672190716", Share = "25.00%"
                                },
                                new EstablishedEnterprise
                                {
                                    Name = @"АВТОНОМНАЯ НЕКОММЕРЧЕСКАЯ ОРГАНИЗАЦИЯ ДОПОЛНИТЕЛЬНОГО ПРОФЕССИОНАЛЬНОГО ОБРАЗОВАНИЯ УЧЕБНЫЙ ЦЕНТР МИКРОТЕСТ",
                                    Address = "115114,ГОРОД МОСКВА, НАБЕРЕЖНАЯ ДЕРБЕНЕВСКАЯ,ДОМ 7,СТРОЕНИЕ 5,ОФИС 501, ЭТАЖ 5",
                                    OGRN = "1177700000862", INN = "7725347620", Share = "0.00%"
                                },
                                new EstablishedEnterprise
                                {
                                    Name = @"ЗАКРЫТОЕ АКЦИОНЕРНОЕ ОБЩЕСТВО ""УЧЕБНЫЙ ЦЕНТР ""МИКРОТЕСТ""",
                                    Address = "620075,ОБЛАСТЬ СВЕРДЛОВСКАЯ, ГОРОД ЕКАТЕРИНБУРГ, УЛИЦА ГОГОЛЯ,36, ОФИС 607",
                                    OGRN = "1026605397367", INN = "6662083659", Share = string.Empty
                                },
                                new EstablishedEnterprise
                                {
                                    Name = @"ЗАКРЫТОЕ АКЦИОНЕРНОЕ ОБЩЕСТВО ""ИНТЭЛЛЕКС""",
                                    Address = "249000,ОБЛАСТЬ КАЛУЖСКАЯ, ГОРОД КАЛУГА, УЛИЦА САЛТЫКОВА-ЩЕДРИНА,50А",
                                    OGRN = "1037739191423", INN = "7709335715", Share = string.Empty
                                }
                            }
                    },
                    Blocks2 = null,
                };
            }
        }
    }
}
