namespace Firebase.Authentication.Tests.Configuration;

internal class AuthenticationConfig
{
    [Test]
    public void Create_NewConfiguration_Success()
    {
        // Create new Configuration
        Authentication.Configuration.AuthenticationConfig config = new(TestData.ApiKey);

        // Run Test: Expected behaviour: Given API key does equal to configuration values
        Assert.That(config.ApiKey, Is.EqualTo(TestData.ApiKey));
    }
}