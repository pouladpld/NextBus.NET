using System.IO;
using System.Linq;
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
    }
}