using System.Linq;

namespace NextBus.NET.Models
{
    public class RoutePrediction
    {
        public string AgencyTitle { get; set; }

        public string RouteTag { get; set; }

        public string RouteTitle { get; set; }

        public string StopTitle { get; set; }

        public string StopTag { get; set; }

        public string DirectionTitleBecauseNoPredictions { get; set; }

        public bool HasPredictions =>
            string.IsNullOrWhiteSpace(DirectionTitleBecauseNoPredictions) && Directions?.Any() == true;

        public RouteDirection[] Directions { get; set; }

        public Message[] Messages { get; set; }
    }
}
