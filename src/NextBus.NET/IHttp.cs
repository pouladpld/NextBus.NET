using System.Threading.Tasks;

namespace NextBus.NET
{
    internal interface IHttp
    {
        Task<string> Execute(Request request);
    }
}