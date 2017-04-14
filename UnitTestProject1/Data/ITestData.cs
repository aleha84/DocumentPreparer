using DocumentPreparer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Data
{
    public interface ITestData
    {
        IDictionary<string, string> Blocks2 { get; set; }
        string DataName { get; set; }
        string PDfName { get; set; }
        decimal AuthirizedCapital { get; set; }
        DocumentModel DocumentModel { get; set; }
    }
}
