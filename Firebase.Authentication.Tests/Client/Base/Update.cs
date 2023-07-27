using Firebase.Authentication.Client.Base;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests.Base;
using Firebase.Authentication.Responses.Base;
using Firebase.Authentication.Types;

namespace Firebase.Authentication.Tests.Client.Base;

internal class Update
{
    IAuthenticationBase client;

    [OneTimeSetUp]
    public void Setup()
    {
        // Mock config/base
        HttpConfig httpConfig = new(TestData.Timeout, TestData.Proxy);
        AuthenticationConfig config = new(TestData.ApiKey, httpConfig);
        client = new AuthenticationBase(config);
    }


    [Test]
    public void DisplayNamePhotoUrl_Success()
    {
        // Mock request/response
        UpdateRequest request = new(
            idToken: TestData.IdToken,
            displayName: TestData.DisplayName,
            photoUrl: TestData.PhotoUrl);
        UpdateResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.UpdateAsync(request, TestData.Locale);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void UnlinkEmail_Success()
    {
        // Mock request/response
        UpdateRequest request = new(
            idToken: TestData.IdToken,
            deleteProviders: new[] { Provider.EmailAndPassword },
            deleteAttributes: new[] { UserAttributeName.Email });
        UpdateResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.UpdateAsync(request, TestData.Locale);
        });

        // Write result
        TestData.Write(response);
    }
}