using DocumentPreparer.Common;
using DocumentPreparer.Extensions;
using DocumentPreparer.Models;
using DocumentPreparer.Processers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DocumentPreparer.Refs;

namespace DocumentPreparer.Blocks
{
    public class FoundersBlock
    {
        private readonly string ruLE = @"(Полное(?>\r?\n|\s)наименование(?>\r?\n|\s)учредителя(?>\r?\n|\s)\(участника\)(?>\r?\n|\s)-(?>\r?\n|\s)юр\.лица(?>\r?\n|\s)(?<name>[\S\s]*)\r?\n\d+\sРазмер вклада(?>\r?\n|\s)\(в(?>\r?\n|\s)рублях\)(?>\r?\n|\s)(?<ac>\d+([,\.]\d)?)[\S\s]+\(ОГРН\)(?>\r?\n|\s)учредителя(?>\r?\n|\s)?(?<ogrn>\d+)?\r?\n\d+\s[\S\s]+ИНН\s(?<inn>\d+)?[\S\s]+Адрес(?>\r?\n|\s)\(место(?>\r?\n|\s)нахождения\)(?>\r?\n|\s)учредителя(?>\r?\n|\s)-(?>\r?\n|\s)юридического(\r?\n|\s)лица(?>\r?\n|\s)(?<address>[\S\s]*?))";
        
        private readonly string foreignLE = @"(Полное(?>\r?\n|\s)наименование(?>\r?\n|\s)учредителя\(участника\)(?>\r?\n|\s)-(?>\r?\n|\s)юридического(?>\r?\n|\s)лица(?>\r?\n|\s)(?<name>[\S\s]*)\n\d+\sРазмер вклада\(в(?>\r?\n|\s)рублях\)(?>\r?\n|\s)(?<ac>\d+([,\.]\d)?)[\S\s]+Место(?>\r?\n|\s)нахождения[\S\s]+\(инкорпорации\)(?>\r?\n|\s)(?<address>[\S\s]*?)(?>\r?\n|\s)\d+\s)";
        //СВЕДЕНИЯ(?>\r?\n|\s)ОБ(?>\r?\n|\s)УЧРЕДИТЕЛЯХ(?>\r?\n|\s)?\(УЧАСТНИКАХ\)(?>\r?\n|\s)-(?>\r?\n|\s)ИНОСТРАННЫХ(?>\r?\n|\s)ЮЛ[\S\s]+
        private readonly string NP = @"(\d+\sФамилия\s(?<f>.+)?(?>\r?\n|\s)\d+\sИмя\s(?<i>.+)?(?>\r?\n|\s)\d+\sОтчество(?<o>.+)?(?>\r?\n|\s)\d+\sИНН\s(?<inn>\d+)?(?>\r?\n|\s)\d+\sРазмер(?>\r?\n|\s)вклада(?>\r?\n|\s)?\(в(?>\r?\n|\s)рублях\)(?>\r?\n|\s)(?<ac>.+)?(?>\r?\n|\s))";
        //СВЕДЕНИЯ(?>\r?\n|\s)ОБ(?>\r?\n|\s)УЧРЕДИТЕЛЯХ(?>\r?\n|\s)-(?>\r?\n|\s)ФИЗИЧЕСКИХ(?>\r?\n|\s)ЛИЦАХ[\S\s]+

        private readonly string NPAffiliationFormat = @"УЧРЕДИТЕЛИ(?>\r?\n|\s)АФФИЛИРОВАННОСТЬ[\S\s]+{0}[\S\s]+(?<affiliations>1\.\s[\S\s]+(?>\d+\.).+\r?\n.+\r?\n)";

        private string _extractFromEGRUL = "";
        private string _affiliations = "";

        private Decimal AuthorizedCapital = 0;

        private readonly IDictionary<string, PropertyRetriever> _propertiesRetrieversNamed;
        public FoundersBlock(IDictionary<string, PropertyRetriever> propertiesRetrieversNamed)
        {
            _propertiesRetrieversNamed = propertiesRetrieversNamed;
            
        }

        public void SetBlocks(string extractFromEGRUL, string affilations)
        {
            if (extractFromEGRUL.IsNullOrEmpty())
                return;

            _extractFromEGRUL = extractFromEGRUL;
            _affiliations = affilations;

            AuthorizedCapital = GetAuthorizedCapital();
        }

        public FounderNP[] GetNP()
        {
            if (_extractFromEGRUL.IsNullOrEmpty())
                return new[] { new FounderNP() };

            var result = new List<FounderNP>();
            var mathces = Regex.Matches(_extractFromEGRUL, NP, RegexOptions.IgnoreCase);

            foreach (Match match in mathces)
            {
                var np = new FounderNP()
                {
                    FullName = Common.CommonHelper.MultiLineProcesser(string.Format("{0} {1} {2}", match.Groups["f"].Value, match.Groups["i"].Value, match.Groups["o"].Value)),
                    INN = match.Groups["inn"].Value
                };

                if (AuthorizedCapital != 0)
                {
                    var ac = 0m;
                    decimal.TryParse(match.Groups["ac"].Value, out ac);
                    np.Share = ((ac * 100) / AuthorizedCapital).ToString("0.##");
                }

                //if (!_affiliations.IsNullOrEmpty())
                //{
                //    var affiliationMatch = Regex.Match(_affiliations, string.Format(NPAffiliationFormat, CommonHelper.ReplaceSpaces(np.FullName, @"(?>\r?\n|\s)")));
                //    if (affiliationMatch.Success)
                //    {
                //        var affiliationsRaw = affiliationMatch.Groups["affiliations"].Value;
                //        var matches = Regex.Matches(affiliationsRaw, @"\d+\.\s(?<value>[\S\s]+?)(?=\d+\.\s|\Z)", RegexOptions.IgnoreCase).Cast<Match>().Where(m => m.Success).Select(m => CommonHelper.MultiLineProcesser(m.Groups["value"].Value));
                //        np.FounderOf = string.Join("\n", matches.Where(m => m.IndexOf("учредитель", StringComparison.CurrentCultureIgnoreCase) != -1).ToList());
                //        np.LeaderOf = string.Join("\n", matches.Where(m => m.IndexOf("имеет право действовать без доверенности", StringComparison.CurrentCultureIgnoreCase) != -1).ToList());
                //    }
                //}

                result.Add(np);
            }

            if (!result.Any())
                return new[] { new FounderNP() };

            return result.ToArray(); 
        }

        private string processFS(string name)
        {
            if(name.IndexOf("ООО") != -1)
            {
                name = name.Replace("ООО", @"(ООО|ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ)");
            }

            return name;
        }

        public decimal GetAuthorizedCapital()
        {
            var capitalData = CommonHelper.UseRetriever(_extractFromEGRUL, _propertiesRetrieversNamed[PropertyRetrieversRefs.ExtractEGRUL.AuthorizedCapital]);

            Decimal result = 0m;

            if (capitalData.IsNullOrEmpty() || !decimal.TryParse(capitalData, out result))
                return 0m;

            return result;
        }

        public FounderLE[] GetLE()
        {
            if (_extractFromEGRUL.IsNullOrEmpty())
                return new[] { new FounderLE() };

            var result = new List<FounderLE>();
            var mathces = Regex.Matches(_extractFromEGRUL, ruLE, RegexOptions.IgnoreCase);
            
            foreach (Match match in mathces)
            {
                var le = new FounderLE()
                {
                    Name = CommonHelper.MultiLineProcesser(match.Groups["name"].Value),
                    Address = CommonHelper.MultiLineProcesser(match.Groups["address"].Value),
                    INN = match.Groups["inn"].Value,
                    OGRN = CommonHelper.MultiLineProcesser(match.Groups["ogrn"].Value).Trim(),
                };

                if(AuthorizedCapital != 0)
                {
                    var ac = 0m;
                    decimal.TryParse(match.Groups["ac"].Value, out ac);
                    le.Share = ((ac * 100) / AuthorizedCapital).ToString("0.##");
                }
                
                result.Add(le);
            }

            mathces = Regex.Matches(_extractFromEGRUL, foreignLE, RegexOptions.IgnoreCase);
            foreach (Match match in mathces)
            {
                var le = new FounderLE()
                {
                    Name = CommonHelper.MultiLineProcesser(match.Groups["name"].Value),
                    Address = CommonHelper.MultiLineProcesser(match.Groups["address"].Value),
                };

                var ac = 0m;
                decimal.TryParse(match.Groups["ac"].Value, out ac);
                le.Share = ((ac * 100) / AuthorizedCapital).ToString("0.##");
                result.Add(le);
            }

            if(!result.Any())
                return new[] { new FounderLE() };

            return result.ToArray();
        }
    }
}
