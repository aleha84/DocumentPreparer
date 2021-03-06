﻿using DocumentPreparer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Data
{
    public class Lanit : ITestData
    {
        public IDictionary<string, string> Blocks2 { get; set; }
        public string DataName { get; set; }
        public string PDfName { get; set; }
        public decimal AuthirizedCapital { get; set; }
        public DocumentModel DocumentModel { get; set; }

        public static Lanit Instance
        {
            get
            {
                return new Lanit {
                    PDfName = "ЗАО ЛАНИТ бизнес справка",
                    DataName = "Lanit",
                    AuthirizedCapital = 24000000m,
                    DocumentModel = new DocumentModel
                    {
                        GeneralInfoBlock = new GeneralInfoBlock
                        {
                            ShortName = @"ЗАО ""ЛАНИТ""",
                            FullName = @"ЗАКРЫТОЕ АКЦИОНЕРНОЕ ОБЩЕСТВО ЛАБОРАТОРИЯ НОВЫХ ИНФОРМАЦИОННЫХ ТЕХНОЛОГИЙ ""ЛАНИТ""",
                            INN = "7727004113",
                            InitialRegistrationDate = "10.01.1993"
                        },
                        FoundersNP = new[]
                        {
                            new FounderNP
                            {
                                FullName = "Конник Татьяна Иосифовна",
                                INN = "770484260410",
                                Share = "25"
                            },
                            new FounderNP
                            {
                                FullName = "Генс Георгий Владимирович",
                                INN = "773600406629",
                                Share = "75"
                            }
                        },
                        EstablishedEnterprise = new []
                        {
                            new EstablishedEnterprise
                            {
                                Name = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""СИСТЕМЫ КОМПЬЮТЕРНОГО ЗРЕНИЯ""",
                                Address = @"198504,ГОРОД САНКТ-ПЕТЕРБУРГ, ГОРОД ПЕТЕРГОФ, ПРОСПЕКТ УНИВЕРСИТЕТСКИЙ,28, ОФИС 1406",
                                INN = "7819313778", OGRN = "1117847164346", Share = "60.00%"
                            },
                            new EstablishedEnterprise
                            {
                                Name = @"НЕГОСУДАРСТВЕННОЕ ОБРАЗОВАТЕЛЬНОЕ ЧАСТНОЕ УЧРЕЖДЕНИЕ ДОПОЛНИТЕЛЬНОГО ПРОФЕССИОНАЛЬНОГО ОБРАЗОВАНИЯ УЧЕБНЫЙ ЦЕНТР ""СЕТЕВАЯ АКАДЕМИЯ""",
                                Address = @"105066,ГОРОД МОСКВА, УЛИЦА ДОБРОСЛОБОДСКАЯ,5,СТР.1",
                                INN = "7701110607", OGRN = "1037700080648", Share = "0.00%"
                            },
                            new EstablishedEnterprise
                            {
                                Name = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""ЭЛЕМЕНТ 22""",
                                Address = @"121170,ГОРОД МОСКВА, УЛИЦА ГЕНЕРАЛА ЕРМОЛОВА,2",
                                INN = "7730675070", OGRN = "1127747128321", Share = "99.94%"
                            },
                            new EstablishedEnterprise
                            {
                                Name = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""ИНФРАСТРУКТУРНЫЕ СПУТНИКОВЫЕ СИСТЕМЫ""",
                                Address = @"111033,ГОРОД МОСКВА, УЛИЦА ВОЛОЧАЕВСКАЯ,ДОМ 5,КОРПУС 3,ПОМЕЩЕНИЕ XIV, КОМНАТА 17",
                                INN = "7722821552", OGRN = "1137746929100", Share = "25.10%"
                            },
                            new EstablishedEnterprise
                            {
                                Name = @"ОТКРЫТОЕ АКЦИОНЕРНОЕ ОБЩЕСТВО ""ЛАНИТ-КОНСАЛТИНГ""",
                                Address = @"105066,ГОРОД МОСКВА, УЛИЦА ДОБРОСЛОБОДСКАЯ,5,1",
                                INN = "7701002432", OGRN = "1027739080984", Share = string.Empty
                            },
                            new EstablishedEnterprise
                            {
                                Name = @"НЕКОММЕРЧЕСКОЕ ПАРТНЕРСТВО СОДЕЙСТВИЯ РАЗВИТИЮ СВОБОДНОГО ПРОГРАММНОГО ОБЕСПЕЧЕНИЯ",
                                Address = @"109316,ГОРОД МОСКВА, УЛИЦА ТАЛАЛИХИНА,Д.28,СТР.2,ПОМ.42",
                                INN = "7709444217", OGRN = "1107799023200", Share = string.Empty
                            }
                        },
                        Licenses = new []
                        {
                            new License
                            {
                                Value = @"1. №ФС-99-04-002840, статус: Лицензия действующая, Лицензирующий орган: Федеральная служба по надзору в сфере здравоохранения, с 01.07.2015 по 01.01.0001, адрес: 105066, г. Москва, ул. Доброслободская, д.5, стр.1"
                            },
                            new License
                            {
                                Value = @"2. №77-Б/02392, статус: Лицензия действующая, Лицензирующий орган: ГУ МЧС России по г.Москве, с 13.07.2015 по 01.01.0001, адрес: 105066, г. Москва, ул. Доброслободская, д. 5, стр. 1"
                            },
                            new License
                            {
                                Value = @"3. №0076, статус: Лицензия действующая, Лицензирующий орган: Федеральная служба по техническому и экспортному контролю, с 05.05.2003 по 01.01.0001"
                            },
                            new License
                            {
                                Value = @"4. №0049, статус: Лицензия действующая, Лицензирующий орган: Федеральная служба по техническому и экспортному контролю, с 05.05.2003 по 01.01.0001"
                            },
                            new License
                            {
                                Value = @"5. №140577 1, статус: Лицензия действующая, Лицензирующий орган: Федеральная служба по надзору в сфере связи, информационных технологий и массовых коммуникаций, с 17.02.2016 по 17.02.2021"
                            },
                            new License
                            {
                                Value = @"6. №140579 1, статус: Лицензия действующая, Лицензирующий орган: Федеральная служба по надзору в сфере связи, информационных технологий и массовых коммуникаций, с 17.02.2016 по 17.02.2021"
                            },
                            new License
                            {
                                Value = @"7. №140578 1, статус: Лицензия действующая, Лицензирующий орган: Федеральная служба по надзору в сфере связи, информационных технологий и массовых коммуникаций, с 17.02.2016 по 17.02.2021"
                            },
                            new License
                            {
                                Value = @"8. №ЛСЗ0012580 15089Н бессрочно, статус: Лицензия действующая, Лицензирующий орган: Центр по лицензированию, сертификации и защите государственной тайны, с 26.04.2016 по 01.01.0001, адрес: 105066, г. Москва, ул. Доброслободская, д.5, стр. 1"
                            },
                            new License
                            {
                                Value = @"9. №77.01.13.002.Л.000223.08.11, статус: Лицензия действующая, Лицензирующий орган: Управление Федеральной службы по надзору в сфере защиты прав потребителей и благополучия человека по городу Москве, с 01.08.2011 по 01.01.0001, адрес: г. Москва, ул. Доброслободская, д.5, стр.1. Места осуществления лицензируемой деятельности: г. Москва, Мурманский проезд, д.14, корп.1"
                            }
                        }
                    }
                };
            }
        }
    }
}
