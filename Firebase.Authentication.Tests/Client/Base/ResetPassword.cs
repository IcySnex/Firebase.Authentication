using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests.Base;
using Firebase.Authentication.Responses.Base;

namespace Firebase.Authentication.Tests.Client.Base;

internal class ResetPassword
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
            response = await client.ResetPasswordASync(request);
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
            response = await client.ResetPasswordASync(request);
        });

        // Write result
        TestData.Write(response);
    }
}