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
    public class ManagementBlock
    {
        private readonly IDictionary<string, PropertyRetriever> _propertiesRetrieversNamed;
        public ManagementBlock(IDictionary<string, PropertyRetriever> propertiesRetrieversNamed)
        {
            _propertiesRetrieversNamed = propertiesRetrieversNamed;
        }


        public Models.ManagementBlock Get(string extractFromEGRUL, string affiliation = null)
        {
            var result = new Models.ManagementBlock();
            var individualJoined = CommonHelper.UseRetriever(extractFromEGRUL, _propertiesRetrieversNamed[PropertyRetrieversRefs.Management.Individual]);
            if (!individualJoined.IsNullOrEmpty())
            {
                result.Individual = new Individual();
                foreach (var individualItem in individualJoined.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var individualItemParts = individualItem.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (individualItemParts.Length >= 3)
                    {
                        var value = string.Join(" ", individualItemParts.Where((x, i) => i > 1));
                        switch (individualItemParts[1].ToLower())
                        {
                            case "должность":
                                result.Individual.Position = value;
                                break;
                            case "фамилия":
                                result.Individual.LastName = value;
                                break;
                            case "имя":
                                result.Individual.FirstName = value;
                                break;
                            case "отчество":
                                result.Individual.MiddleName = value;
                                break;
                            case "инн":
                                result.Individual.INN = value;
                                break;
                        }
                    }
                }
            }

            var entityJoined = CommonHelper.UseRetriever(extractFromEGRUL, _propertiesRetrieversNamed[PropertyRetrieversRefs.Management.Entity]);
            if (!entityJoined.IsNullOrEmpty())
            {
                result.Entity = new Entity();

                foreach (
                    var entityItem in Regex.Matches(entityJoined, @"(?<value>\d+\s[\S\s]+?)(?=\n\d+\s|\Z)", RegexOptions.IgnoreCase)
                                        .Cast<Match>()
                                        .Where(m => m.Success)
                                        .Select(m => CommonHelper.MultiLineProcesser(m.Groups["value"].Value)))
                {

                    if (entityItem.IndexOf("наименование юр.лица - управляющей компании", StringComparison.CurrentCultureIgnoreCase) > -1)
                    {
                        result.Entity.Name = CommonHelper.GetAllAfter(entityItem,
                            "наименование юр.лица - управляющей компании");
                        continue;
                    }

                    if (entityItem.IndexOf("инн", StringComparison.CurrentCultureIgnoreCase) > -1)
                    {
                        result.Entity.INN = CommonHelper.GetAllAfter(entityItem,
                            "инн");
                        continue;
                    }

                    if (entityItem.IndexOf("адрес (место нахождения)", StringComparison.CurrentCultureIgnoreCase) > -1)
                    {
                        result.Entity.Address = CommonHelper.GetAllAfter(entityItem,
                            "адрес (место нахождения)");
                        continue;
                    }
                }
            }

            if (!string.IsNullOrEmpty(affiliation))
            {
                //var subBlockEndIndex = affiliation.IndexOf("УЧРЕДИТЕЛИ АФФИЛИРОВАННОСТЬ", StringComparison.CurrentCultureIgnoreCase);
                var subBlock = CommonHelper.UseRetriever(affiliation, _propertiesRetrieversNamed[PropertyRetrieversRefs.Management.IndividualAffiliations]);//subBlockEndIndex != -1 ? affiliation.Substring(0, subBlockEndIndex) : affiliation;
                var matches = Regex.Matches(subBlock, @"\d+\.\s(?<value>[\S\s]+?)(?=\d+\.\s)", RegexOptions.IgnoreCase).Cast<Match>().Where(m => m.Success).Select(m => CommonHelper.MultiLineProcesser(m.Groups["value"].Value));
                result.Individual.FounderOf = string.Join("\n", matches.Where(m => m.IndexOf("учредитель", StringComparison.CurrentCultureIgnoreCase) != -1).ToList());
                result.Individual.LeaderOf = string.Join("\n", matches.Where(m => m.IndexOf("имеет право действовать без доверенности", StringComparison.CurrentCultureIgnoreCase) != -1).ToList());
            }

            return result;
        }
    }
}
