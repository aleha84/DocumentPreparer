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
                        },
                            Licenses = new []
                            {
                                new License
                                {
                                    Value = @"1. №78.01.10.002.Л.000014.04.12, статус: Лицензия действующая, Лицензирующий орган: Управление Федеральной службы по надзору в сфере защиты прав потребителей и благополучия человека по городу Санкт-Петербургу, с 04.04.2012 по 01.01.0001, адрес: 198096, САНКТ-ПЕТЕРБУРГ, УГОЛЬНАЯ ГАВАНЬ, ЭЛЕВАТОРНАЯ ПЛОЩАДКА, Д. 22, 101 ПРИЧАЛ"
                                },
                                new License
                                {
                                    Value = @"2. №ВП-00-011263, статус: Лицензия действующая, Лицензирующий орган: Федеральная служба по экологическому, технологическому и атомному надзору, с 20.06.2012 по 01.01.0001"
                                },
                                new License
                                {
                                    Value = @"3. №000586, статус: Лицензия действующая, Лицензирующий орган: СЕВЕРО-ЗАПАДНОЕ УПРАВЛЕНИЕ ГОСУДАРСТВЕННОГО МОРСКОГО И РЕЧНОГО НАДЗОРА ФЕДЕРАЛЬНОЙ СЛУЖБЫ ПО НАДЗОРУ В СФЕРЕ ТРАНСПОРТА, с 19.12.2016 по 01.01.0001, адрес: Морской порт Большой порт Санкт-Петербург на причалах"
                                }
                            },
                            EstablishedEnterprise = new []
                            {
                                new EstablishedEnterprise()
                            }
                    },
                };
            }
        }
    }
}
