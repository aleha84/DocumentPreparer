using DocumentPreparer.Attributes;
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
            EstablishedEnterprise = new[] {new EstablishedEnterprise()};
            GovernmentContracts = new GovernmentContract[0];
        }

        public Common Common { get; set; }
        public GeneralInfoBlock GeneralInfoBlock { get; set; }
        public ManagementBlock ManagementBlock { get; set; }

        [ArrayItemAddition(ArrayItemAdditionType.AddAsTable)]
        public FounderLE[] FoundersLE { get; set; }
        [ArrayItemAddition(ArrayItemAdditionType.AddAsTable)]
        public FounderNP[] FoundersNP { get; set; }

        [ArrayItemAddition(ArrayItemAdditionType.AddAsTable)]
        public EstablishedEnterprise[] EstablishedEnterprise { get; set; }

        [ArrayItemAddition(ArrayItemAdditionType.AddAsTable)]
        public License[] Licenses { get; set; }

        [ArrayItemAddition(ArrayItemAdditionType.AddAsRow, new [] { "Year", "Count", "Total" })]
        public GovernmentContract[] GovernmentContracts { get; set; }
    }
}
