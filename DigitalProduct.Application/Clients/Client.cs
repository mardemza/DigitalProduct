using LazyCache;
using RestSharp;

namespace DigitalProduct.Application.Clients;

public class Client : IClient
{
    private readonly IAppCache _lazyCache;

    public Client(IAppCache lazyCache)
    {
        _lazyCache = lazyCache;
    }

    public async Task<string> Get(string url)
    {
        var key = url.Replace(":", "")
                     .Replace("/", "")
                     .Replace(".", "")
                     .Replace("%","")
                     .Replace("?","")
                     .Replace("_","")
                     .Replace("-", "");

        var result = _lazyCache.GetOrAdd(key, () => CallGet(url));
        return await Task.FromResult(result.Result);
    }

    private async Task<string> CallGet(string url)
    {
        var client = new RestClient(url);
        var request = new RestRequest();
        request.Method = Method.Get;
        var response = await client.ExecuteGetAsync(request);
        return response.Content;
    }
}
