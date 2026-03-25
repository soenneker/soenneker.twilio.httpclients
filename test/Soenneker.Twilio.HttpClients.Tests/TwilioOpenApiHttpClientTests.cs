using Soenneker.Twilio.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Twilio.HttpClients.Tests;

[Collection("Collection")]
public sealed class TwilioOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly ITwilioOpenApiHttpClient _httpclient;

    public TwilioOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<ITwilioOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
