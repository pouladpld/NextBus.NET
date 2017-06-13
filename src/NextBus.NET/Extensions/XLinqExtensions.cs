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
            decimal.TryParse(value, out decimal d);
            return d;
        }

        public static int ToInt(this string value)
        {
            int.TryParse(value, out int i);
            return i;
        }

        public static int? ToNullableInt(this string value)
        {
            return int.TryParse(value, out int n) ? (int?)n : null;
        }

        public static long ToLong(this string value)
        {
            long.TryParse(value, out long l);
            return l;
        }

        public static bool ToBool(this string value)
        {
            bool.TryParse(value, out bool b);
            return b;
        }
    }
}