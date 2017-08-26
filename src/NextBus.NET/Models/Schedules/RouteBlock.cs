using System.Collections.Generic;

namespace NextBus.NET.Models.Schedules
{
    public class RouteBlock
    {
        public string Id { get; set; }

        public IEnumerable<ScheduleStop> Stops { get; set; }
    }
}
