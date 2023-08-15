using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests.IdentityPlatform;
using Firebase.Authentication.Responses.IdentityPlatform;

namespace Firebase.Authentication.Tests.IdentityPlatform;

internal class SendVerificationCode
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
    public void Success()
    {
        // Mock request/response
        SendVerificationCodeRequest request = new(
            phoneNumber: TestData.PhoneNumber,
            recaptchaToken: TestData.ReCaptchaToken);
        SendVerificationCodeResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.SendVerificationCodeAsync(request, TestData.Locale);
        });

        // Write result
        TestData.Write(response);
    }
}