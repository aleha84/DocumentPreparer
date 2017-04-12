using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentPreparer.Models
{
    public class GeneralInfoBlock
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string InitialRegistrationDate { get; set; }
        public string NameChange { get; set; }
        public string RegistrationNumber { get; set; }
        public string Jurisdiction { get; set; }
        public string MainAddress { get; set; }
        public string OtherAddresses { get; set; }
        public string Contacts { get; set; }
        public string AuthorizedCapital { get; set; }
        public string MainActivity { get; set; }
        public string State { get; set; }
        public string Currency { get; set; }
        public string INN { get; set; }
    }
}
