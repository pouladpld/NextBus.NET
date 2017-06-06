using System.Collections.Generic;
using System.Net;

namespace NextBus.NET.Extensions
{
    internal static class DictionaryExtensions
    {
        internal static string ToQueryString(this Dictionary<string, object> dict)
        {
            var paramsList = new List<string>();
            foreach (var pair in dict)
            {
                var key = WebUtility.UrlEncode(pair.Key);
                var val = WebUtility.UrlEncode(pair.Value.ToString());
                paramsList.Add(key + '=' + val);
            }
            return string.Join("&", paramsList);
        }
    }
}
