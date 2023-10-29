﻿#nullable enable

using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.UWP.Helpers;
using Firebase.Authentication.Sample.UWP.Views;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Firebase.Authentication.Sample.UWP.ViewModels;

public partial class LinkViewModel : ObservableObject
{
    readonly ContentPresenter view = new()
    {
        HorizontalAlignment = HorizontalAlignment.Stretch,
        VerticalAlignment = VerticalAlignment.Center
    };

    readonly ILogger<LinkViewModel> logger;
    readonly Models.Configuration configuration;
    readonly LinkEmailViewModel linkEmailViewModel;
    readonly LinkPhoneViewModel linkPhoneViewModel;
    readonly IAuthenticationClient authentication;

    public ContentDialog Dialog { get; }
    Action? onDialogCloseClick;
    Func<Task>? onDialogPrimaryClick;

    public LinkViewModel(
        ILogger<LinkViewModel> logger,
        IOptions<Models.Configuration> configuration,
        LinkEmailViewModel linkEmailViewModel,
        LinkPhoneViewModel linkPhoneViewModel,
        IAuthenticationClient authentication)
    {
        this.logger = logger;
        this.configuration = configuration.Value;
        this.linkEmailViewModel = linkEmailViewModel;
        this.linkPhoneViewModel = linkPhoneViewModel;
        this.authentication = authentication;

        linkEmailViewModel.LinkViewModel = this;
        linkPhoneViewModel.LinkViewModel = this;

        Dialog = new() { Content = view };
        Dialog.CloseButtonClick += (s, e) =>
        {
            e.Cancel = true;
            onDialogCloseClick?.Invoke();
        };
        Dialog.PrimaryButtonClick += (s, e) =>
        {
            e.Cancel = true;
            onDialogPrimaryClick?.Invoke();
        };

        logger.LogInformation("[LinkViewModel-.ctor] LinkViewModel has been initialized.");
    }


    void SetDialogCloseButton(
        string? text,
        Action? action)
    {
        Dialog.CloseButtonText = text;
        onDialogCloseClick = action;
    }
    void SetDialogPrimaryButton(
        string? text,
        Func<Task>? action)
    {
        Dialog.PrimaryButtonText = text;
        onDialogPrimaryClick = action;
    }


    public void NavigateToProvider()
    {
        view.Content = new LinkProviderView();

        SetDialogCloseButton("Cancel", Dialog.Hide);
        SetDialogPrimaryButton(string.Empty, null);

        logger.LogInformation("[LinkViewModel-NavigateToProvider] Navigated to provider view and set up dialog.");
    }
    
    public void NavigateToEmail()
    {
        view.Content = new LinkEmailView();

        SetDialogCloseButton("Go Back", NavigateToProvider);
        SetDialogPrimaryButton("Link", linkEmailViewModel.LinkAsync);

        logger.LogInformation("[LinkViewModel-NavigateToEmail] Navigated to email view and set up dialog.");
    }
    
    public void NavigateToPhone()
    {
        view.Content = new LinkPhoneView();

        SetDialogCloseButton("Go Back", NavigateToProvider);
        SetDialogPrimaryButton("Link", linkPhoneViewModel.LinkAsync);

        logger.LogInformation("[LinkViewModel-NavigateToPhone] Navigated to phone view and set up dialog.");
    }


    CancellationTokenSource? cancelSource;

    public async Task<bool> LinkAsync(
        LinkRequest request)
    {
        try
        {
            cancelSource = new(configuration.Timeout);
            await authentication.LinkAsync(request, cancelSource.Token);

            Dialog.Hide();
            return true;
        }
        catch (TaskCanceledException) { }
        catch (Exception ex)
        {
            await Extensions.AlertErrorAsync(ex, "Linking failed", "LinkViewModel-LinkAsync", logger);
        }
        return false;
    }
}