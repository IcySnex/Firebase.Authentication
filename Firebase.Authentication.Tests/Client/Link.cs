using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Client;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests;

namespace Firebase.Authentication.Tests.Client;

public class Link
{
    IAuthenticationClient client;

    [OneTimeSetUp]
    public async Task SetupAsync()
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
    public void ToEmailPassword_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            LinkRequest linkRequest = LinkRequest.ToEmailPassword(TestData.Email, TestData.Password);
            await client.LinkAsync(linkRequest);

            Assert.That(client.CurrentUser!.ProviderUserInfos.Any(info => info.Provider == Types.Provider.EmailAndPassword));
        });

        // Write result
        TestData.Write(client.CurrentCredential);
        TestData.Write(client.CurrentUser);
    }

    [Test]
    public void ToPhoneNumber_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            LinkRequest linkRequest = LinkRequest.ToPhoneNumber(TestData.SessionInfo, TestData.SmsCode);
            await client.LinkAsync(linkRequest);

            Assert.That(client.CurrentUser!.PhoneNumber, Is.Not.Null);
        });

        // Write result
        TestData.Write(client.CurrentCredential);
        TestData.Write(client.CurrentUser);
    }

    [Test]
    public void ToEmailLink_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            LinkRequest linkRequest = LinkRequest.ToEmailLink(TestData.Email, TestData.OobCode);
            await client.LinkAsync(linkRequest);

            Assert.That(client.CurrentUser!.ProviderUserInfos.Any(info => info.Provider == Types.Provider.EmailLink));
        });

        // Write result
        TestData.Write(client.CurrentCredential);
        TestData.Write(client.CurrentUser);
    }

    [Test]
    public void ToProviderRedirect_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            LinkRequest linkRequest = LinkRequest.ToProviderRedirect(TestData.RequestUri, TestData.SessionId);
            await client.LinkAsync(linkRequest);
        });

        // Write result
        TestData.Write(client.CurrentCredential);
        TestData.Write(client.CurrentUser);
    }

}