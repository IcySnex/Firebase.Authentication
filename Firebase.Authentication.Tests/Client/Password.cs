using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Client;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests;

namespace Firebase.Authentication.Tests.Client;

public class Password
{
    IAuthenticationClient client;

    [OneTimeSetUp]
    public void Setup()
    {
        // Mock config/base
        HttpConfig httpConfig = new(TestData.Timeout, TestData.Proxy);
        AuthenticationConfig config = new(TestData.ApiKey, httpConfig);

        client = new AuthenticationClient(config);
    }


    [Test]
    public async Task Change_SuccessAsync()
    {
        // Sign in
        SignInRequest signInRequest = SignInRequest.WithEmailPassword(TestData.Email, TestData.Password);
        await client.SignInAsync(signInRequest);

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await client.ChangePasswordAsync(TestData.PasswordSecondary, TestData.Password);
        });
    }

    [Test]
    public void Reset_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await client.ResetPasswordAsync(TestData.PasswordSecondary, TestData.OobCode);
        });
    }
}