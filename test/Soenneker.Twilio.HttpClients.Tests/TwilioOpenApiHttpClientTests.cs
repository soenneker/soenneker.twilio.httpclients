using Soenneker.Twilio.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Twilio.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class TwilioOpenApiHttpClientTests : HostedUnitTest
{
    private readonly ITwilioOpenApiHttpClient _httpclient;

    public TwilioOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<ITwilioOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
