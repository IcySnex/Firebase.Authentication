using Firebase.Authentication.Client.Base;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests.Base;
using Firebase.Authentication.Responses.Base;
using Firebase.Authentication.Types;

namespace Firebase.Authentication.Tests.Client.Base;

internal class SendOobCode
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
    public void VerifyEmail_Success()
    {
        // Mock request/response
        SendOobCodeRequest request = new(
            requestType: OobType.VerifyEmail,
            email: TestData.Email,
            idToken: TestData.IdToken);
        SendOobCodeResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.SendOobCodeAsync(request, TestData.Locale);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void ResetPassword_Success()
    {
        // Mock request/response
        SendOobCodeRequest request = new(
            requestType: OobType.ResetPassword,
            email: TestData.Email);
        SendOobCodeResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.SendOobCodeAsync(request, TestData.Locale);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void VerifyAndChangeEmail_Success()
    {
        // Mock request/response
        SendOobCodeRequest request = new(
            requestType: OobType.VerifyAndChangeEmail,
            email: TestData.Email,
            newEmail: TestData.EmailSecondary,
            idToken: TestData.IdToken);
        SendOobCodeResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.SendOobCodeAsync(request, TestData.Locale);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void SignInEmail_Success()
    {
        // Mock request/response
        SendOobCodeRequest request = new(
            requestType: OobType.SignInEmail,
            email: TestData.Email,
            continueUrl: TestData.ContinueUrl);
        SendOobCodeResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.SendOobCodeAsync(request, TestData.Locale);
        });

        // Write result
        TestData.Write(response);
    }
}