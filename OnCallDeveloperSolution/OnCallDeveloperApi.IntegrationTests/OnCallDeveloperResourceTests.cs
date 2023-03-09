
using Alba;

namespace OnCallDeveloperApi.IntegrationTests;

public class OnCallDeveloperResourceTests
{
    [Fact]
    public async Task CanGetOnCallDeveloper()
    {
        //Creates a "Host" for our API our API will be up and running.
        await using var host = await AlbaHost.For<Program>();

        // Scenarios - 
        await host.Scenario(api =>
        {
            api.Get.Url("/oncalldeveloper");
            api.StatusCodeShouldBeOk();

        });
    }
}
