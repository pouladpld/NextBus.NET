using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NextBus.NET.Tests
{
    public class DataParserTests
    {
        [Fact]
        public void ShouldParseAgencies()
        {
            var xml = File.ReadAllText("xml/agencies.xml");
            INextBusDataParser sut = new NextBusDataParser();
            var agencies = sut.ParseAgencies(xml).ToArray();

            Assert.Equal(10, agencies.Length);
        }

        // [Fact]
        // public void A()
        // {
        //     INextBusClient client = new NextBusClient();

        //     try
        //     {
        //         var agencies = client.GetAgencies().Result;

        //         foreach (var agency in agencies)
        //         {
        //             var routes = client.GetRoutesForAgency(agency.Tag, true).Result;

        //             foreach (var route in routes)
        //             {
        //                 var config = client.GetRouteConfig(agency.Tag, route.Tag, true).Result;
        //             }
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e);
        //         throw;
        //     }
        // }
    }
}