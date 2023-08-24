using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Client;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Models;

namespace Firebase.Authentication.Tests.Client;

internal class RefreshUser
{
    IAuthenticationClient client;

    [OneTimeSetUp]
    public async Task SetupAsymc()
    {
        // Mock config/base
        HttpConfig httpConfig = new(TestData.Timeout, TestData.Proxy);
        AuthenticationConfig config = new(TestData.ApiKey, httpConfig);

        client = new AuthenticationClient(config);

        // Sign in
        SignInRequest signInRequest = SignInRequest.WithEmailPassword(TestData.Email, TestData.Password);
        await client.SignInAsync(signInRequest);
    }


    [Test]
    [Ignore("Takes too long: The default expiration time is 1 hour!")]
    public void Refresh_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            // Get new user
            UserInfo oldUser = client.CurrentUser!;
            if (!oldUser.ValidityPeriod.HasValue)
                throw new Exception("Current user will never expire");
            await Task.Delay(oldUser.ValidityPeriod.Value);
            UserInfo newUser = await client.GetFreshUserAsync(TimeSpan.FromHours(1));

            // Run Test: Expected behaviour: new user does not equal old user
            Assert.That(newUser, Is.Not.EqualTo(oldUser));

            // Write result
            TestData.Write(newUser);
        });
    }

    [Test]
    public void DontRefresh_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            // Get new user
            UserInfo oldUser = client.CurrentUser!;
            UserInfo newUser = await client.GetFreshUserAsync();

            // Run Test: Expected behaviour: new user equals old user
            Assert.That(newUser, Is.EqualTo(oldUser));

            // Write result
            TestData.Write(newUser);
        });
    }
}