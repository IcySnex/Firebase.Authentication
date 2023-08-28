using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Requests;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class AnonymouslyViewModel : ObservableObject
{
    readonly HomeViewModel homeViewModel;

    public AnonymouslyViewModel(
        ILogger<AnonymouslyViewModel> logger,
        HomeViewModel homeViewModel)
    {
        this.homeViewModel = homeViewModel;

        logger.LogInformation("[AnonymouslyViewModel-.ctor] AnonymouslyViewModel has been initialized.");
    }


    [RelayCommand]
    void NavigateBack() =>
        homeViewModel.Navigate<ProviderViewModel>();


    [ObservableProperty]
    string? displayName;

    [RelayCommand]
    async Task ContinueAsync()
    {
        await homeViewModel.SignUpAsync(SignUpRequest.Anonymously(DisplayName));

        homeViewModel.Navigate<ProviderViewModel>();
    }
}