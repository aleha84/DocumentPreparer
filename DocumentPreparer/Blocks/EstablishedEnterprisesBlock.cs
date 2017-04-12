using DocumentPreparer.Extensions;
using DocumentPreparer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            return new[]
                {
                    new EstablishedEnterprise()
                };
        }
    }
}
