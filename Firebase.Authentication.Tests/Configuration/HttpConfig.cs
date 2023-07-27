using Firebase.Authentication.Configuration;

namespace Firebase.Authentication.Tests.Configuration;

internal class AuthenticationConfiguration
{
    [Test]
    public void Create_NewConfiguration_Success()
    {
        // Create new Configuration
        HttpConfig httpConfig = new(TestData.Timeout, TestData.Proxy);

        // Run Test: Expected behaviour: Given timeout and proxy does equal to configuration values
        Assert.That(httpConfig.Timeout, Is.EqualTo(TestData.Timeout));
        Assert.That(httpConfig.Proxy, Is.EqualTo(TestData.Proxy));
    }
}