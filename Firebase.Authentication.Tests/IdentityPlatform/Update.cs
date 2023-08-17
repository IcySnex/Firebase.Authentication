using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests.IdentityPlatform;
using Firebase.Authentication.Responses.IdentityPlatform;
using Firebase.Authentication.Types;

namespace Firebase.Authentication.Tests.IdentityPlatform;

internal class Update
{
    IIdentityPlatformClient identityPlatform;

    [OneTimeSetUp]
    public void Setup()
    {
        // Mock config/base
        HttpConfig httpConfig = new(TestData.Timeout, TestData.Proxy);
        AuthenticationConfig config = new(TestData.ApiKey, httpConfig);

        identityPlatform = new IdentityPlatformClient(config);
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
            response = await identityPlatform.UpdateAsync(request, TestData.Locale);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void LnkEmail_Success()
    {
        // Mock request/response
        LinkToPasswordRequest request = new(
            idToken: TestData.IdToken,
            email: TestData.Email,
            password: TestData.Password);
        UpdateResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.UpdateAsync(request, TestData.Locale);
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
            deleteProviders: new[] { Provider.PhoneNumber },
            deleteAttributes: new[] { UserAttributeName.Email });
        UpdateResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.UpdateAsync(request, TestData.Locale);
        });

        // Write result
        TestData.Write(response);
    }
}