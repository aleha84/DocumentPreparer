using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentPreparer.Models
{
    public class PropertyRetriever
    {
        public string Name { get; set; }
        public string RegExPattern { get; set; }
        public Func<string, string> Processer { get; set; }
    }
}
