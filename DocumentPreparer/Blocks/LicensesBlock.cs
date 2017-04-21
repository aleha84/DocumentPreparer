using DocumentPreparer.Extensions;
using DocumentPreparer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DocumentPreparer.Common;

namespace DocumentPreparer.Blocks
{
    public class LicensesBlock
    {
        private class LicenseInternal
        {
            public int Index { get; set; }
            public string LicNum { get; set; }
            public string LicState { get; set; }
            public string LicAuthority { get; set; }
            public string LicStart { get; set; }
            public string LicEnd { get; set; }
            public string LicPlace { get; set; }

            public override string ToString()
            {
                return string.Format("{0}. №{1}{2}{3}{4}{5}{6}",
                    Index,
                    LicNum,
                    !LicState.IsNullOrEmpty() ? ", статус: " + LicState : string.Empty,
                    !LicAuthority.IsNullOrEmpty() ? ", лицензирующий орган: " + LicAuthority : string.Empty,
                    !LicStart.IsNullOrEmpty() ? ", с " + LicStart : string.Empty,
                    !LicEnd.IsNullOrEmpty() ? " по " + LicEnd : string.Empty,
                    !LicPlace.IsNullOrEmpty() ? ", адрес: " + LicPlace : string.Empty
                );
            }
        }

        private readonly string pattern =
                @"(Порядковый номер\s(?<index>\d+)[\S\s]+?Номер лицензии\s(?<licNum>.+)[\S\s]+?состояние лицензии\s(?<licState>.+)?[\S\s]+?лицензирующий.+лицензию(?>\s|\r?\n)(?<licAuthority>.+(?>\r?\n.+)*?(?=\r?\n\d+))?[\S\s]+?дата начала.+лицензии\s(?<licStart>.+)?[\S\s]+?дата окончания.+лицензии\s(?<licEnd>.+)?[\S\s]+?место действия[ ]?(?<licPlace>.*(?>\r?\n.+)*?(?=\r?\n\d+[\s\n]огрн))?)";

        public License[] GetLicenses(string ee)
        {
            if (ee.IsNullOrEmpty())
                return new License[] { new License() };

            var licensePartStartIndex = ee.IndexOf("СВЕДЕНИЯ О ЛИЦЕНЗИЯХ", StringComparison.CurrentCultureIgnoreCase);
            if (licensePartStartIndex == -1)
                return new License[] { new License() };

            var eePart = ee.Substring(licensePartStartIndex);

            var preResult = new List<LicenseInternal>();

            foreach (Match match in Regex.Matches(eePart, pattern, RegexOptions.IgnoreCase))
            {
                if(!match.Success)
                    continue;

                preResult.Add(new LicenseInternal
                {
                    Index = Convert.ToInt32(match.Groups["index"].Value),
                    LicAuthority = CommonHelper.MultiLineProcesser(match.Groups["licAuthority"].Value),
                    LicEnd = match.Groups["licEnd"].Value.Trim(),
                    LicNum = match.Groups["licNum"].Value.Trim(),
                    LicPlace = CommonHelper.MultiLineProcesser(match.Groups["licPlace"].Value),
                    LicStart = match.Groups["licStart"].Value.Trim(),
                    LicState = match.Groups["licState"].Value.Trim()
                });
            }

            if(!preResult.Any())
                return new License[] { new License() };


            return preResult.OrderBy(r => r.Index).Select(r => new License { Value = r.ToString()}).ToArray();
        }
    }
}
