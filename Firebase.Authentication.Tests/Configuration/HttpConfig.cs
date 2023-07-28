
namespace Firebase.Authentication.Tests.Configuration;

internal class HttpConfig
{
    [Test]
    public void Success()
    {
        // Create new Configuration
        Authentication.Configuration.HttpConfig httpConfig = new(TestData.Timeout, TestData.Proxy);

        // Run Test: Expected behaviour: Given timeout and proxy does equal to configuration values
        Assert.That(httpConfig.Timeout, Is.EqualTo(TestData.Timeout));
        Assert.That(httpConfig.Proxy, Is.EqualTo(TestData.Proxy));
    }
}