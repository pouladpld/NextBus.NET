﻿using System.Collections.Generic;
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

                if (pair.Value == null)
                {
                    paramsList.Add(key); // for cases like: &verbose
                }
                else
                {
                    var val = WebUtility.UrlEncode(pair.Value.ToString());
                    paramsList.Add(key + '=' + val);
                }
            }
            return string.Join("&", paramsList);
        }
    }
}
