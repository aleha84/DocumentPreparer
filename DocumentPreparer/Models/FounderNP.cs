using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentPreparer.Models
{
    public class FounderNP : Founder
    {
        public string FullName { get; set; }
        public string LeaderOf { get; set; }
        public string FounderOf { get; set; }
    }
}
