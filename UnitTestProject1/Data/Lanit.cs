using DocumentPreparer.Models;
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
                };
            }
        }
    }
}
