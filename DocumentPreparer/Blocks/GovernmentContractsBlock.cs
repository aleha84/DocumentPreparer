using DocumentPreparer.Extensions;
using DocumentPreparer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DocumentPreparer.Blocks
{
    public class GovernmentContractsBlock
    {
        private const string pattern = @"(\d+ .+ (?<year>\d+) ПРЕДМЕТ КОНТРАКТА СУММА КОНТРАКТА[\S\s]+?(?<sum>\d+(?>,\d+)?) руб\.)";

        public GovernmentContract[] Get(string gc)
        {
            if (gc.IsNullOrEmpty())
                return new GovernmentContract[0];

            var preResult = new List<GovernmentContract>();

            foreach(Match match in Regex.Matches(gc, pattern, RegexOptions.IgnoreCase))
            {
                if (!match.Success)
                    continue;

                var sum = 0m;
                decimal.TryParse(match.Groups["sum"].Value.Trim(), out sum);

                preResult.Add(new GovernmentContract
                {
                    Count = 1,
                    Total = sum,
                    Year = Convert.ToInt32(match.Groups["year"].Value)
                });
            }

            if(!preResult.Any())
                return new GovernmentContract[0];

            return preResult
                .GroupBy(
                    g => g.Year, 
                    g => g, 
                    (key, g) => new GovernmentContract { Year = key, Count = g.Count(), Total = g.Sum(gi => gi.Total) })
                .OrderBy(r => r.Year)
                .ToArray();
        }
    }
}
