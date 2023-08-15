using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests.IdentityPlatform;
using Firebase.Authentication.Responses.IdentityPlatform;

namespace Firebase.Authentication.Tests.IdentityPlatform;

internal class ResetPassword
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
    public void OobCode_Success()
    {
        // Mock request/response
        ResetPasswordRequest request = new(
            newPassword: TestData.PasswordSecondary,
            oobCode: TestData.OobCode);
        ResetPasswordResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.ResetPasswordASync(request);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void EmailPassword_Success()
    {
        // Mock request/response
        ResetPasswordRequest request = new(
            newPassword: TestData.PasswordSecondary,
            oldPassword: TestData.Password,
            email: TestData.Email);
        ResetPasswordResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.ResetPasswordASync(request);
        });

        // Write result
        TestData.Write(response);
    }
}