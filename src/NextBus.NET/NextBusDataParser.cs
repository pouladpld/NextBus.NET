using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NextBus.NET.Extensions;
using NextBus.NET.Models;
using NextBus.NET.Models.Schedules;

namespace NextBus.NET
{
    public class NextBusDataParser : INextBusDataParser
    {
        public IEnumerable<Agency> ParseAgencies(string xml)
        {
            var document = XDocument.Parse(xml);
            if (document.Root == null)
            {
                return new List<Agency>();
            }

            TryParseError(document.Root);

            var agencies = (from x in document.Root.Elements("agency")
                            select new Agency
                            {
                                Tag = x.Attr("tag"),
                                Title = x.Attr("title"),
                                ShortTitle = x.Attr("shortTitle"),
                                RegionTitle = x.Attr("regionTitle")
                            }).ToArray();
            return agencies;
        }

        public IEnumerable<Route> ParseRoutes(string xml)
        {
            var document = XDocument.Parse(xml);
            if (document.Root == null)
            {
                return new List<Route>();
            }

            TryParseError(document.Root);

            var routes = (from x in document.Root.Elements("route")
                          select new Route
                          {
                              Tag = x.Attr("tag"),
                              Title = x.Attr("title"),
                              ShortTitle = x.Attr("shortTitle"),

                          }).ToArray();

            return routes;
        }

        public RouteConfig ParseRouteConfig(string xml)
        {
            var document = XDocument.Parse(xml);

            if (document.Root == null)
            {
                return null;
            }

            TryParseError(document.Root);

            var routeElement = document.Root.Element("route");

            if (routeElement == null)
            {
                return null;
            }

            var stops = routeElement.Elements("stop")
                .Select(x => new Stop
                {
                    Tag = x.Attr("tag"),
                    Title = x.Attr("title"),
                    ShortTitle = x.Attr("shortTitle"),
                    Lat = x.Attr("lat").ToDecimal(),
                    Lon = x.Attr("lon").ToDecimal(),
                    StopId = x.Attr("stopId").ToNullableInt(),
                }).ToArray();

            var route = new RouteConfig
            {
                Tag = routeElement.Attr("tag"),
                Title = routeElement.Attr("title"),
                Color = routeElement.Attr("color"),
                OppositeColor = routeElement.Attr("oppositeColor"),
                LatMin = routeElement.Attr("latMin").ToDecimal(),
                LatMax = routeElement.Attr("latMax").ToDecimal(),
                LonMin = routeElement.Attr("lonMin").ToDecimal(),
                LonMax = routeElement.Attr("lonMax").ToDecimal(),
                Stops = stops,
                Directions = routeElement.Elements("direction")
                    .Select(x => new Direction
                    {
                        Tag = x.Attr("tag"),
                        Title = x.Attr("title"),
                        Name = x.Attr("name"),
                        UserForUi = x.Attr("useForUI").ToBool(),
                        StopTags = x.Elements("stop")
                            .Select(y => y.Attr("tag"))
                            .ToArray()
                    }).ToArray(),
                Paths = routeElement.Elements("path")
                    .Select(x => new Path
                    {
                        Points = x.Elements("point")
                            .Select(y => new Point
                            {
                                Lat = y.Attr("lat").ToDecimal(),
                                Lon = y.Attr("lon").ToDecimal(),
                            }).ToArray(),
                    }).ToArray(),
            };

            return route;
        }

        public IEnumerable<RoutePrediction> ParseRoutePredictions(string xml)
        {
            var document = XDocument.Parse(xml);

            if (document.Root == null)
            {
                return new RoutePrediction[0];
            }

            TryParseError(document.Root);

            var routePredictions = document.Root.Elements("predictions")
                .Select(x => new RoutePrediction
                {
                    AgencyTitle = x.Attr("agencyTitle"),
                    RouteTitle = x.Attr("routeTitle"),
                    RouteTag = x.Attr("routeTag"),
                    StopTitle = x.Attr("stopTitle"),
                    StopTag = x.Attr("stopTag"),
                    DirectionTitleBecauseNoPredictions = x.Attr("dirTitleBecauseNoPredictions"),
                    Directions = x.Elements("direction")
                        .Select(y => new RouteDirection
                        {
                            Title = y.Attr("title"),
                            Predictions = y.Elements("prediction")
                                .Select(z => new Prediction
                                {
                                    EpochTime = z.Attr("epochTime").ToLong(),
                                    Seconds = z.Attr("seconds").ToInt(),
                                    Minutes = z.Attr("minutes").ToInt(),
                                    IsDeparture = z.Attr("isDeparture").ToBool(),
                                    AffectedByLayover = z.Attr("affectedByLayover").ToBool(),
                                    Branch = z.Attr("branch"),
                                    DirTag = z.Attr("dirTag"),
                                    Vehicle = z.Attr("vehicle"),
                                    Block = z.Attr("block"),
                                    TripTag = z.Attr("tripTag")
                                }).ToArray(),
                        }
                        ).ToArray(),
                    Messages = x.Elements("message")
                        .Select(y => new Message
                        {
                            Text = y.Attr("text"),
                        }).ToArray(),
                }).ToArray();

            return routePredictions;
        }

        public IEnumerable<RouteSchedule> ParseRouteSchedules(string xml)
        {
            var document = XDocument.Parse(xml);

            if (document.Root == null)
            {
                return new RouteSchedule[0];
            }

            TryParseError(document.Root);

            var routeSchedules = document.Root.Elements("route")
                .Select(x => new RouteSchedule
                {
                    Tag = x.Attr("tag"),
                    Title = x.Attr("title"),
                    ScheduleClass = x.Attr("scheduleClass"),
                    ServiceClass = x.Attr("serviceClass"),
                    Direction = x.Attr("direction"),
                    Header = new Header
                    {
                        Stops = x.Elements("stop")
                            .Select(y => new HeaderStop
                            {
                                Tag = y.Attr("tag"),
                                Title = y.Value,
                            }).ToArray(),
                    },
                    Blocks = x.Elements("tr")
                        .Select(y => new RouteBlock
                        {
                            Id = y.Attr("blockID"),
                            Stops = y.Elements("stop")
                                .Select(z => new ScheduleStop
                                {
                                    Tag = z.Attr("tag"),
                                    EpochTime = z.Attr("epochTime").ToLong(),
                                })
                                .ToArray(),
                        }).ToArray(),
                }).ToArray();

            return routeSchedules;
        }









        public VehicleList ParseVehicle(string xml)
        {
            XDocument document = XDocument.Parse(xml);
            if (document.Root == null)
            {
                return new VehicleList();
            }

            TryParseError(document.Root);

            List<Vehicle> vehicles = (from x in document.Root.Elements("vehicle")
                                      select new Vehicle
                                      {
                                          Id = x.Attr("id"),
                                          RouteTag = x.Attr("routeTag"),
                                          DirTag = x.Attr("dirTag"),
                                          Lat = x.Attr("lat").ToDecimal(),
                                          Lon = x.Attr("lon").ToDecimal(),
                                          SecsSinceReport = x.Attr("secsSinceReport").ToInt(),
                                          Predictable = x.Attr("predictable").ToBool(),
                                          Heading = x.Attr("heading")
                                      }).ToList();
            var vehicleList = new VehicleList
            {
                Vehicles = vehicles,
                LastTime = document.Root.Element("lastTime")?.Value.ToInt() ?? 0
            };
            return vehicleList;
        }

        private void TryParseError(XElement root)
        {
            XElement element = root.Element("Error");
            if (element != null)
            {
                throw new NextBusException(element.Value)
                {
                    ShouldRetry = element.Attr("shouldRetry").ToBool()
                };
            }
        }
    }
}