using System.Collections.Generic;

namespace NextBus.NET.Models.Schedules
{
    public class Header
    {
        public IEnumerable<HeaderStop> Stops { get; set; }
    }
}
