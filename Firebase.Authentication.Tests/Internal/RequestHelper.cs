using Firebase.Authentication.Configuration;

namespace Firebase.Authentication.Tests.Internal;

internal class RequestHelper
{
    Authentication.Internal.RequestHelper helper;

    [OneTimeSetUp]
    public void Setup()
    {
        // Mock config/helper
        HttpConfig httpConfig = new(TestData.Timeout, TestData.Proxy);
        AuthenticationConfig config = new(TestData.ApiKey, httpConfig);
        helper = new(config);
    }


    [Test]
    public void Proxy_Success()
    {
        // Mock request/response
        string responseData = "";

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            var response = await helper.GetAsync("https://api.ipify.org");
            responseData = await response.Content.ReadAsStringAsync();
        });

        // Run Test: Expected behaviour: Proxy address is equal IP address
        if (TestData.Proxy is null)
        {
            Assert.Warn("No Proxy is set up");
            return;
        }

        Assert.That(TestData.Proxy.Address?.Host, Is.EqualTo(responseData));
    }
}