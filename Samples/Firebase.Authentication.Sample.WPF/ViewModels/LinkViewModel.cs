using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.WPF.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class LinkViewModel : ObservableObject
{
    readonly ILogger<LinkViewModel> logger;
    readonly Models.Configuration configuration;
    readonly MainViewModel mainViewModel;
    readonly IAuthenticationClient authenticaion;

    public LinkViewModel(
        ILogger<LinkViewModel> logger,
        IOptions<Models.Configuration> configuration,
        MainViewModel mainViewModel,
        IAuthenticationClient authenticaion)
    {
        this.logger = logger;
        this.configuration = configuration.Value;
        this.mainViewModel = mainViewModel;
        this.authenticaion = authenticaion;

        logger.LogInformation("[LinkViewModel-.ctor] LinkViewModel has been initialized.");
    }

    [ObservableProperty]
    ObservableObject? currentViewModel;

    public bool Navigate<T>()
    {
        if (App.Provider.GetService<T>() is not ObservableObject viewModel)
            return false;

        CurrentViewModel = viewModel;
        logger.LogInformation("[HomeViewModel-Navigate] Navigated to view.");

        return true;
    }


    CancellationTokenSource? cancelSource;

    public async Task<bool> LinkAsync(
        LinkRequest request)
    {
        try
        {
            cancelSource = new(configuration.Timeout);
            await authenticaion.LinkAsync(request, cancelSource.Token);

            mainViewModel.CloseModal();
            return true;
        }
        catch (TaskCanceledException) { }
        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Linking failed", "LinkViewModel-LinkAsync");
        }
        return false;
    }
}