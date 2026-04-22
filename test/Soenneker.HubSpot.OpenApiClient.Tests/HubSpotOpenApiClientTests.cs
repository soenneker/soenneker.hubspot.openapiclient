using Soenneker.Tests.HostedUnit;

namespace Soenneker.HubSpot.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class HubSpotOpenApiClientTests : HostedUnitTest
{
    public HubSpotOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
