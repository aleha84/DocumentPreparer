using DocumentPreparer.Extensions;
using DocumentPreparer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DocumentPreparer.Common
{
    public static class CommonHelper
    {
        public static string UseRetriever(string input, PropertyRetriever retriever)
        {
            var value = string.Empty;
            if (retriever.RegExPattern.IsNullOrEmpty() && retriever.Processer != null)
            {
                value = retriever.Processer(input);
            }
            else
            {
                var match = Regex.Match(input, retriever.RegExPattern, RegexOptions.IgnoreCase);
                if (match.Success && match.Groups.Count > 1 && match.Groups["value"].Success && !match.Groups["value"].Value.IsNullOrEmpty())
                {
                    value = match.Groups["value"].Value.Trim();
                    if (retriever.Processer != null)
                    {
                        value = retriever.Processer(value);
                    }
                }
            }

            return value;
        }

        public static string PrepareSpacesInHeadersForRegEx(string input)
        {
            return ReplaceSpaces(input);
        }

        public static string ReplaceSpaces(string input, string replaceBy = @"[\s\n]")
        {
            return input.Replace(" ", replaceBy);
        }

        public static Func<string, string> MultiLineJoiner = (input) =>
        {
            input = input.Replace("\n", ", ");
            return input.Trim();
        };

        public static Func<string, string> MultiLineProcesser = (input) =>
        {
            input = input.Replace("\n", " ");
            input = input.Replace("\r", " ");
            input = Regex.Replace(input, ",{2,}", ", ");
            input = Regex.Replace(input, @"\s{2,}", " ");
            return input.Trim();
        };

        public static Func<string, string, string[], string> ConditionalProcesser = (input, startKey, endKeys) =>
        {
            var sPos = input.IndexOf(startKey, StringComparison.CurrentCultureIgnoreCase);
            if (sPos == -1)
                return string.Empty;

            var ePos = -1;
            foreach (var endKey in endKeys)
            {
                ePos = input.IndexOf(endKey, StringComparison.CurrentCultureIgnoreCase);
                if (ePos != -1)
                    break;
            }

            if (ePos == -1)
                return string.Empty;

            return MultiLineProcesser(input.Substring(sPos + startKey.Length, ePos - (sPos + startKey.Length))).Trim();
        };

        public static string GetAllAfter(string input, string value)
        {
            var valueIndex = input.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
            var result = string.Empty;

            if (valueIndex > -1)
            {
                result = input.Substring(valueIndex + value.Length).Trim();
            }

            return result;
        }
    }
}
