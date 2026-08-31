using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Twilio.HttpClients.Abstract;

/// <summary>
/// Provides an owned, cached <see cref="HttpClient"/> transport for Twilio's REST API.
/// </summary>
public interface ITwilioOpenApiHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the configured Twilio HTTP transport.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
