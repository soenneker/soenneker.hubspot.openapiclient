using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.HubSpot.OpenApiClient.Tests;

[Collection("Collection")]
public sealed class HubSpotOpenApiClientTests : FixturedUnitTest
{
    public HubSpotOpenApiClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
