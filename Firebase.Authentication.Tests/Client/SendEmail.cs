﻿using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Client;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests;

namespace Firebase.Authentication.Tests.Client;

internal class SendEmail
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
    public async Task Verify_SuccessAsync()
    {
        // Sign in
        SignInRequest signInRequest = SignInRequest.WithEmailPassword(TestData.Email, TestData.Password);
        await client.SignInAsync(signInRequest);

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            EmailRequest emailRequest = EmailRequest.Verify();
            string email = await client.SendEmailAsync(emailRequest, TestData.Locale);

            TestData.Write(email);
        });
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
            EmailRequest emailRequest = EmailRequest.Change(TestData.EmailSecondary);
            string email = await client.SendEmailAsync(emailRequest, TestData.Locale);

            TestData.Write(email);
        });
    }

    [Test]
    public void ResetPassword_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            EmailRequest emailRequest = EmailRequest.ResetPassword(TestData.Email);
            string email = await client.SendEmailAsync(emailRequest, TestData.Locale);

            TestData.Write(email);
        });
    }

    [Test]
    public void SignIn_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            EmailRequest emailRequest = EmailRequest.SignIn(TestData.Email, TestData.ContinueUrl);
            string email = await client.SendEmailAsync(emailRequest, TestData.Locale);

            TestData.Write(email);
        });
    }
}