using DocumentPreparer.Extensions;
using DocumentPreparer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentPreparer.Blocks
{
    public class LicensesBlock
    {
        public License[] GetLicenses(string ee)
        {
            if (ee.IsNullOrEmpty())
                return new License[] { new License() };

            var licensePartStartIndex = ee.IndexOf("СВЕДЕНИЯ О ЛИЦЕНЗИЯХ", StringComparison.CurrentCultureIgnoreCase);
            if (licensePartStartIndex == -1)
                return new License[] { new License() };

            var eePart = ee.Substring(licensePartStartIndex);



            return null;
        }
    }
}
