using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentPreparer.Extensions
{
    public static class DictionaryExtensions
    {
        public static string GetByKeyOrEmpty(this IDictionary<string, string> distionary, string key)
        {
            if (key.IsNullOrEmpty())
                return string.Empty;

            return distionary.ContainsKey(key) ? distionary[key] : string.Empty;
        }
    }
}
