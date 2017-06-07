using System.Collections.Generic;
using NextBus.NET.Models;

namespace NextBus.NET
{
    public interface INextBusDataParser
    {
        IEnumerable<Agency> ParseAgencies(string xml);

        IEnumerable<Route> ParseRoutes(string xml);

        RouteConfig ParseRouteConfig(string xml);

        IEnumerable<RoutePrediction> ParseRoutePredictions(string xml);

        IEnumerable<RouteSchedule> ParseRouteSchedules(string xml);
    }
}
