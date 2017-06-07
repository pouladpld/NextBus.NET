using System.Collections.Generic;
using System.Threading.Tasks;
using NextBus.NET.Models;

namespace NextBus.NET
{
    public interface INextBusClient
    {
        Task<IEnumerable<Agency>> GetAgencies();

        Task<IEnumerable<Route>> GetRoutesForAgency(string agencyTag, bool verbose = false);

        Task<RouteConfig> GetRouteConfig(string agencyTag, string routeTag, bool includePaths = false);

        Task<IEnumerable<RoutePrediction>> GetRoutePredictionsByStopId
            (string agencyTag, string stopId, string routeTag = null, bool verbose = false);

        Task<IEnumerable<RoutePrediction>> GetRoutePredictionsByStopTag
            (string agencyTag, string stopTag, string routeTag, bool verbose = false);

        Task<IEnumerable<RoutePrediction>> GetRoutePredictionsForMultipleStops
            (string agencyTag, Dictionary<string, string[]> routeStoptags, bool useShortTitles = false);

        Task<IEnumerable<RouteSchedule>> GetRouteSchedule(string agencyTag, string routeTag);
    }
}
