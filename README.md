# NextBus.NET

NextBus.NET is a client for NextBus webservices in .NET. This project targets _.NET Standard 1.3_ so it could be used in .NET Core projects as well.

You can find detailed information about NextBus services [here](http://www.nextbus.com/xmlFeedDocs/NextBusXMLFeed.pdf).

Usage:

```c#
static async Task<IEnumerable<Agency>> GetSupportedAgencies()
{
    INextBusClient client = new NextBusClient();
    return await client.GetAgencies();
}
```
