using System.Collections.Generic;
using System.Threading.Tasks;
using NextBus.NET.Extensions;
using NextBus.NET.Models;

namespace NextBus.NET
{
    public class NextBusClient : INextBusClient
    {
        private readonly INextBusDataParser _parser;

        private readonly INextBusHttpClient _client;

        public NextBusClient()
            : this(new NextBusHttpClient(), new NextBusDataParser())
        {
            
        }

        public NextBusClient(INextBusHttpClient client, INextBusDataParser parser)
        {
            _client = client;
            _parser = parser;
        }

        public async Task<IEnumerable<Agency>> GetAgencies()
        {
            var parameters = new Dictionary<string, object>
            {
                {"command", "agencyList"}
            };
            var xml = await MakeRequest(parameters);
            var agencies = _parser.ParseAgencies(xml);
            return agencies;
        }

        /// <summary>
        /// Gets a list of all available routes for an agency
        /// </summary>
        /// <param name="agencyTag">Unique tag of an agency</param>
        /// <param name="verbose">Include more data</param>
        /// <returns>A Collection of agency routes</returns>
        public async Task<IEnumerable<Route>> GetRoutesForAgency(string agencyTag, bool verbose = false)
        {
            var parameters = new Dictionary<string, object>
            {
                {"command", "routeList"},
                {"a", agencyTag},
            };
            if (verbose)
            {
                parameters.Add("verbose", null);
            }
            var xml = await MakeRequest(parameters);
            var routes = _parser.ParseRoutes(xml);
            return routes;
        }

        public async Task<RouteConfig> GetRouteConfig(string agencyTag, string routeTag, bool includePaths = false)
        {
            var parameters = new Dictionary<string, object>
            {
                {"command", "routeConfig"},
                {"a", agencyTag},
                {"r", routeTag},
            };
            if (includePaths)
            {
                parameters.Add("terse", null);
            }

            var xml = await MakeRequest(parameters);
            var routeConfig = _parser.ParseRouteConfig(xml);
            return routeConfig;
        }

        public async Task<IEnumerable<RoutePrediction>> GetRoutePredictionsByStopId
            (string agencyTag, string stopId, string routeTag = null, bool verbose = false)
        {
            var parameters = new Dictionary<string, object>
            {
                {"command", "predictions"},
                {"a", agencyTag},
                {"stopId", stopId},
            };
            if (!string.IsNullOrWhiteSpace(routeTag))
            {
                parameters.Add("r", routeTag);
            }
            if (verbose)
            {
                parameters.Add("verbose", null);
            }

            var xml = await MakeRequest(parameters);
            var routePredictions = _parser.ParseRoutePredictions(xml);
            return routePredictions;
        }

        public async Task<IEnumerable<RoutePrediction>> GetRoutePredictionsByStopTag
            (string agencyTag, string stopTag, string routeTag, bool verbose = false)
        {
            var parameters = new Dictionary<string, object>
            {
                {"command", "predictions"},
                {"a", agencyTag},
                {"s", stopTag},
                {"r", routeTag},
            };
            if (verbose)
            {
                parameters.Add("verbose", null);
            }

            var xml = await MakeRequest(parameters);
            var routePredictions = _parser.ParseRoutePredictions(xml);
            return routePredictions;
        }

        public async Task<IEnumerable<RoutePrediction>> GetRoutePredictionsForMultipleStops
            (string agencyTag, Dictionary<string, string[]> routeStoptags, bool useShortTitles = false)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("command", "predictionsForMultiStops"),
                new KeyValuePair<string, object>("a", agencyTag),
            };

            foreach (var pair in routeStoptags)
            {
                foreach (var stopTag in pair.Value)
                {
                    parameters.Add(new KeyValuePair<string, object>("stops", pair.Key + '|' + stopTag));
                }
            }
            if (useShortTitles)
            {
                parameters.Add(new KeyValuePair<string, object>("useShortTitles", true));
            }

            var xml = await MakeRequest(parameters);
            var routePredictions = _parser.ParseRoutePredictions(xml);
            return routePredictions;
        }

        public async Task<IEnumerable<RouteSchedule>> GetRouteSchedule(string agencyTag, string routeTag)
        {
            var parameters = new Dictionary<string, object>
            {
                {"command", "schedule"},
                {"a", agencyTag},
                {"r", routeTag},
            };

            var xml = await MakeRequest(parameters);
            var schedules = _parser.ParseRouteSchedules(xml);
            return schedules;
        }

        private async Task<string> MakeRequest(Dictionary<string, object> parameters)
        {
            var xml = await _client.Get('?' + parameters.ToQueryString());

            return xml;
        }

        private async Task<string> MakeRequest(List<KeyValuePair<string, object>> parameters)
        {
            var xml = await _client.Get('?' + parameters.ToQueryString());

            return xml;
        }

    }






    //public Task<VehicleList> GetVehicles(string agency, string route, int epoch)
    //{
    //    var request = _factory.CreateVehiclesRequest(agency, route, epoch);
    //    //Task<VehicleList> task = ExecuteRequest(request).ContinueWith(x => _parser.ParseVehicle(x.Result));
    //    return task;
    //}

    //public Task<List<Prediction>> GetPredictions(string agencyTag, string stopTag, string routeTag)
    //{
    //    var request = _factory.CreatePredictionsRequest(agencyTag, stopTag, routeTag);
    //    return ExecuteRequest(request).ContinueWith(x => _parser.ParseRoutePredictions(x.Result));
    //}

    //public Task<List<RouteSchedule>> GetSchedule(string agencyTag, string routeTag)
    //{
    //    var request = _factory.CreateScheduleRequest(agencyTag, routeTag);
    //    return ExecuteRequest(request).ContinueWith(x => _parser.ParseSchedule(x.Result));
    //}

    //public Task<List<Prediction>> GetPredictionsForMultiStops(string agencyTag, params string[] routeTags)
    //{
    //    var request = _factory.CreatePredictionsForMultiStopsRequest(agencyTag, routeTags);
    //    return ExecuteRequest(request).ContinueWith(x => _parser.ParseRoutePredictions(x.Result));
    //}

    //    private Task<string> ExecuteRequest(Request request)
    //    {
    //        var http = new HttpClientAccessor();
    //        return http.Execute(request);
    //    }
}
