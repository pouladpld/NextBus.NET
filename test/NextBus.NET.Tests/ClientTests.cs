using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NextBus.NET.Models;
using Xunit;

namespace NextBus.NET.Tests
{
    public class ClientTests
    {
        [Fact]
        public async Task ShouldGetAgencies()
        {
            var ttcAgency = new Agency
            {
                Tag = "ttc",
                Title = "Toronto Transit Commission",
                ShortTitle = "Toronto TTC",
                RegionTitle = "Ontario",

            };
            var xml = File.ReadAllText("xml/agencies.xml");

            var mockClient = new Mock<INextBusHttpClient>();
            mockClient.Setup(x => x.Get(It.IsAny<string>()))
                .ReturnsAsync(xml);

            var mockParser = new Mock<INextBusDataParser>();
            mockParser.Setup(x => x.ParseAgencies(It.IsAny<string>()))
                .Returns(new[] { ttcAgency });

            INextBusClient sut = new NextBusClient(mockClient.Object, mockParser.Object);

            var agencies = await sut.GetAgencies();

            Assert.Contains(ttcAgency, agencies);
        }

        [Fact]
        public async Task ShouldGetTtcRoutes()
        {
            var sut = new NextBusClient(new NextBusHttpClient(), new NextBusDataParser());
            var routes = await sut.GetRoutesForAgency("ttc");

            Assert.NotEmpty(routes);
        }

        // ToDo: RouteConfig with `&verbose` query string

        [Fact]
        public async Task ShouldGetRouteConfig()
        {
            var sut = new NextBusClient(new NextBusHttpClient(), new NextBusDataParser());
            var routeConfig = await sut.GetRouteConfig("ttc", "110");

            Assert.NotNull(routeConfig);
        }

        [Fact]
        public async Task ShouldGetRoutePredictions()
        {
            var sut = new NextBusClient(new NextBusHttpClient(), new NextBusDataParser());
            var routePredictions = await sut.GetRoutePredictionsByStopId("ttc", "14811", verbose: true);

            Assert.NotNull(routePredictions);
            Assert.NotEqual(0, routePredictions.First().Directions.First().Predictions.First().EpochTime);
        }
    }
}
