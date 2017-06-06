using System.Collections.Generic;
using System.Linq;

namespace NextBus.NET
{
    internal class Request
    {
        private readonly Dictionary<string, string> _parameters = new Dictionary<string, string>();

        public void AddParameter(string name, object value)
        {
            _parameters.Add(name, value.ToString());
        }

        public override string ToString()
        {
            IEnumerable<string> parameters = _parameters.Select(x => string.Format("{0}={1}", x.Key, x.Value));
            //return Settings.Default.BaseUrl + "?" + string.Join("&", parameters);
            return "";
        }
    }
}