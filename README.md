# NextBus.NET

NextBus.NET is a little project that defines a client to access the NextBus webservices. This project targets _.NET Standard 1.3_ so it could be used in .NET Core projects as well.

You can find detailed information about NextBus services [here](http://www.nextbus.com/xmlFeedDocs/NextBusXMLFeed.pdf).

Usage

```c#
var client = new NextbusClient();
INextBusClient client =
    new NextBusClient(new NextBusHttpClient(), new NextBusDataParser());
IEnumerable<Agency> agencies = await client.GetAgencies();
```