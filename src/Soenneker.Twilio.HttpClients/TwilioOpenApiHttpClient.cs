using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Twilio.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Twilio.HttpClients;

///<inheritdoc cref="ITwilioOpenApiHttpClient"/>
public sealed class TwilioOpenApiHttpClient : ITwilioOpenApiHttpClient
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly IConfiguration _config;

    private const string _prodBaseUrl = "https://api.twilio.com";

    public TwilioOpenApiHttpClient(IHttpClientCache httpClientCache, IConfiguration config)
    {
        _httpClientCache = httpClientCache;
        _config = config;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(TwilioOpenApiHttpClient), (config: _config, baseUrl: _config["Twilio:ClientBaseUrl"] ?? _prodBaseUrl),
            static state => new HttpClientOptions
            {
                BaseAddress = new Uri(state.baseUrl)
            }, cancellationToken);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(nameof(TwilioOpenApiHttpClient));
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(nameof(TwilioOpenApiHttpClient));
    }
}