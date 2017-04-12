using DocumentPreparer.Common;
using DocumentPreparer.Extensions;
using DocumentPreparer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentPreparer.Blocks
{
    public class GeneralInfoBlock
    {
        private readonly IDictionary<string, PropertyRetriever> _propertiesRetrieversNamed;
        public GeneralInfoBlock(IDictionary<string, PropertyRetriever> propertiesRetrieversNamed)
        {
            _propertiesRetrieversNamed = propertiesRetrieversNamed;
        }

        public Models.GeneralInfoBlock Get(string input)
        {
            var result = new Models.GeneralInfoBlock();

            var properties = typeof(Models.GeneralInfoBlock).GetProperties();
            foreach (var property in properties)
            {
                if (_propertiesRetrieversNamed.ContainsKey(property.Name))
                {
                    var retriever = _propertiesRetrieversNamed[property.Name];
                    if (retriever == null)
                        continue;

                    var value = CommonHelper.UseRetriever(input, retriever);

                    property.SetValue(result, value, null);
                }
            }

            if (!result.AuthorizedCapital.IsNullOrEmpty())
            {
                var currencyPosition = result.AuthorizedCapital.LastIndexOf(" ");
                if (currencyPosition != -1)
                {
                    result.Currency = result.AuthorizedCapital.Substring(currencyPosition).Trim();
                    result.AuthorizedCapital = result.AuthorizedCapital.Substring(0, currencyPosition);
                }
            }

            return result;
        }
    }
}
