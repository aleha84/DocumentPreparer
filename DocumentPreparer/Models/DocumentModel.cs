using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentPreparer.Models
{
    public class DocumentModel
    {
        public DocumentModel()
        {
            Common = new Common();
            GeneralInfoBlock = new GeneralInfoBlock();
            ManagementBlock = new ManagementBlock();
            FoundersLE = new FounderLE[] {new FounderLE()};
            FoundersNP = new FounderNP[] { new FounderNP() };
            Licenses = new License[] { new License() };
        }

        public Common Common { get; set; }
        public GeneralInfoBlock GeneralInfoBlock { get; set; }
        public ManagementBlock ManagementBlock { get; set; }

        public FounderLE[] FoundersLE { get; set; }
        public FounderNP[] FoundersNP { get; set; }

        public EstablishedEnterprise[] EstablishedEnterprise { get; set; }

        public License[] Licenses { get; set; }
    }
}
