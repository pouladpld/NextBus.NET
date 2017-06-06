using System.Xml.Linq;

namespace NextBus.NET.Extensions
{
    internal static class XLinqExtensions
    {
        public static string Attr(this XElement element, string attrId)
        {
            var attribute = element.Attribute(attrId);
            return attribute?.Value ?? string.Empty;
        }

        public static decimal ToDecimal(this string value)
        {
            return decimal.Parse(value);
        }

        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }

        public static int? ToNullableInt(this string value)
        {
            return int.TryParse(value, out int n) ? (int?)n : null;
        }

        public static long ToLong(this string value)
        {
            return long.Parse(value);
        }

        public static bool ToBool(this string value)
        {
            return bool.Parse(value);
        }
    }
}