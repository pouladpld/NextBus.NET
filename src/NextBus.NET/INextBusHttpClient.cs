using System.Threading.Tasks;

namespace NextBus.NET
{
    public interface INextBusHttpClient
    {
        Task<string> Get(string url);
    }
}