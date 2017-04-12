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
        private string pattern = @"(\d+\.\s(?<name>[\S\s]+?)(?<address>\d+\s?,\s?[\S\s]+?)огрн:\s(?<ogrn>\d+),\sинн:\s(?<inn>\d+)[\S\s]+?(доля:\s(?<share>\d+\.\d*%)|$))";

        private readonly IDictionary<string, PropertyRetriever> _propertiesRetrieversNamed;
        public EstablishedEnterprisesBlock(IDictionary<string, PropertyRetriever> propertiesRetrieversNamed)
        {
            _propertiesRetrieversNamed = propertiesRetrieversNamed;
        }

        public EstablishedEnterprise[] Get(string ee)
        {
            if (ee.IsNullOrEmpty())
                return new []
                {
                    new EstablishedEnterprise()
                };

            var result = Regex.Matches(ee, pattern, RegexOptions.IgnoreCase)
                .Cast<Match>()
                .Where(m => m.Success)
                .Select(m => new EstablishedEnterprise
                {
                    Address = CommonHelper.MultiLineProcesser(m.Groups["address"].Value),
                    INN = m.Groups["inn"].Value,
                    Name = CommonHelper.MultiLineJoiner(m.Groups["name"].Value),
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
