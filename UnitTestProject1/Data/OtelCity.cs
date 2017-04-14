using DocumentPreparer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Data
{
    public class OtelCity : ITestData
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

        public static OtelCity Instance
        {
            get
            {
                return new OtelCity
                {
                    DataName = "OtelCity",
                    AuthirizedCapital = 15000m,
                    PDfName = "ООО ОТЕЛЬ СИТИ бизнес справка",
                    DocumentModel = new DocumentModel
                    {
                        GeneralInfoBlock = new GeneralInfoBlock
                        {
                            ShortName = @"ООО ""ОТЕЛЬ СИТИ""",
                            FullName = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""ОТЕЛЬ СИТИ""",
                            INN = "7722345448",
                            InitialRegistrationDate = "09.11.2015"
                        },
                        FoundersLE = new FounderLE[]
                        {
                            new FounderLE()
                        },
                            FoundersNP = new FounderNP[]
                        {
                            new FounderNP
                            {
                                FullName = "ПАНИКАРОВСКАЯ СВЕТЛАНА ЛЕОНИДОВНА",
                                INN = "611801993362",
                                Share = "100"
                            }
                        }
                    },
                    Blocks2 = null,
                };
            }
        }
    }
}
