using DocumentPreparer.Common;
using DocumentPreparer.Extensions;
using DocumentPreparer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DocumentPreparer.Blocks
{
    public class EstablishedEnterprisesBlock
    {
        private string pattern = @"(\d+\.\s)((?<name>.+?)(?<address>\d+\s?,\s?.+?)огрн:\s(?<ogrn>\d+),\sинн:\s(?<inn>\d+).*?(доля:\s(?<share>.*?)\n)?)(?=(\d+\.\s)|($))";

        public EstablishedEnterprisesBlock()
        {
        }

        public EstablishedEnterprise[] Get(string ee)
        {
            if (ee.IsNullOrEmpty())
                return new []
                {
                    new EstablishedEnterprise()
                };

            var result = Regex.Matches(ee, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline)
                .Cast<Match>()
                .Where(m => m.Success)
                .Select(m => new EstablishedEnterprise
                {
                    Address = CommonHelper.MultiLineProcesser(m.Groups["address"].Value),
                    INN = m.Groups["inn"].Value,
                    Name = CommonHelper.MultiLineProcesser(m.Groups["name"].Value),
                    OGRN = m.Groups["ogrn"].Value,
                    Share = m.Groups["share"].Value
                });

            if(!result.Any())
                return new[]
                {
                    new EstablishedEnterprise()
                };

            return result.ToArray();
        }
    }
}
