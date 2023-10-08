#nullable enable

using Firebase.Authentication.UWP.Configuration;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System;

namespace Firebase.Authentication.UWP.Internal;

/// <summary>
/// A popup which mimics a default window
/// </summary>
public sealed partial class WindowPopup : ContentControl
{
    readonly PopupConfig configuration;

    /// <summary>
    /// Creates a new ReCaptchaPopup
    /// </summary>
    /// <param name="content">The content the popup displays</param>
    /// <param name="configuration">The configuration the popup should be created with</param>
    public WindowPopup(
        UIElement content,
        PopupConfig configuration)
    {
        InitializeComponent();

        this.configuration = configuration;

        Window.Current.SizeChanged += OnWindowSizeChanged;


        BackgroundPresenter.Width = Window.Current.Content.ActualSize.X;
        BackgroundPresenter.Height = Window.Current.Content.ActualSize.Y;

        ContentPresenter.Content = content;

        Title.Text = configuration.Title ?? "Sign in";
        Icon.Source = configuration.Icon ?? new BitmapImage(new("ms-appx:///ReCaptcha.Desktop.UWP/UI/Assets/Icon.png"));
        RootLayout.CornerRadius = new(configuration.HasRoundedCorners.HasValue ? configuration.HasRoundedCorners.Value ? 8 : 0 : Environment.OSVersion.Version.Build >= 22000 ? 8 : 0);
        if (!configuration.HasTitleBar)
        {
            TitleBar.Visibility = Visibility.Collapsed;
            Grid.SetRow(ContentPresenter, 0);
        }
        if (!configuration.IsDimmed)
            Resources["SystemControlPageBackgroundMediumAltMediumBrush"] = new SolidColorBrush(Colors.Transparent);
        if (configuration.IsDragable)
        {
            TitleBarDrag.PointerPressed += OnTitleBarDragPressed;
            TitleBarDrag.PointerMoved += OnTitleBarDragMoved;
        }
    }

    private void OnLoaded(object _, RoutedEventArgs _1)
    {
        if (configuration.StartupLocation == PopupStartupLocation.Manual)
            MoveFromZero(configuration.Left, configuration.Top);
        else
            MoveFromCenter(0, 0);
    }

    private void OnUnloaded(object sender, RoutedEventArgs e)
    {
        Loaded -= OnLoaded;
        Unloaded -= OnUnloaded;
        CloseButton.Click -= OnCloseClicked;
        TitleBarDrag.PointerPressed -= OnTitleBarDragPressed;
        TitleBarDrag.PointerMoved -= OnTitleBarDragMoved;
        Window.Current.SizeChanged -= OnWindowSizeChanged;
    }


    private void OnWindowSizeChanged(object _, WindowSizeChangedEventArgs e)
    {
        RootLayout.Width = width > Window.Current.Content.ActualSize.X ? Window.Current.Content.ActualSize.X : width;
        RootLayout.Height = height > Window.Current.Content.ActualSize.Y - 32 ? Window.Current.Content.ActualSize.Y - 32.0 : height;

        BackgroundPresenter.Width = e.Size.Width;
        BackgroundPresenter.Height = e.Size.Height;

        MoveFromCenter(RootTransform.X, RootTransform.Y);
    }

    private void OnCloseClicked(object _, RoutedEventArgs _1) =>
        ((Popup)Parent).IsOpen = false;


    double x;
    double y;

    private void OnTitleBarDragPressed(object _, PointerRoutedEventArgs e)
    {
        Point currentposition = e.GetCurrentPoint(this).Position;
        x = currentposition.X - RootTransform.X;
        y = currentposition.Y - RootTransform.Y;
    }

    private void OnTitleBarDragMoved(object _, PointerRoutedEventArgs e)
    {
        if (e.Pointer.PointerDeviceType != PointerDeviceType.Mouse)
            return;

        PointerPoint currentPoint = e.GetCurrentPoint(this);
        if (!currentPoint.Properties.IsLeftButtonPressed)
            return;

        MoveFromCenter(currentPoint.Position.X - x, currentPoint.Position.Y - y);
    }


    double width = double.NaN;
    double height = double.NaN;

    /// <summary>
    /// Resizes the popup
    /// </summary>
    /// <param name="requestedWidth">The new requsted width</param>
    /// <param name="requestedHeight">The new requsted height</param>
    public void Resize(
        double requestedWidth,
        double requestedHeight)
    {
        width = requestedWidth;
        height = requestedHeight;

        RootLayout.Width = width > Window.Current.Content.ActualSize.X ? Window.Current.Content.ActualSize.X : width;
        RootLayout.Height = height > Window.Current.Content.ActualSize.Y - 32 ? Window.Current.Content.ActualSize.Y - 32.0 : height;
    }

    /// <summary>
    /// Moves the popup from the center point
    /// </summary>
    /// <param name="x">The new x position</param>
    /// <param name="y">The new y position</param>
    public void MoveFromCenter(
        double x,
        double y)
    {
        double minX = (Window.Current.Content.ActualSize.X - RootLayout.ActualWidth) / 2;
        double minY = (Window.Current.Content.ActualSize.Y - RootLayout.ActualHeight) / 2;

        RootTransform.X = x > -minX ? x < minX ? x : minX : -minX;
        RootTransform.Y = y > -minY + 32.0 ? y < minY ? y : minY : -minY + 32.0;
    }

    /// <summary>
    /// Moves the popup from the zero point
    /// </summary>
    /// <param name="x">The new x position</param>
    /// <param name="y">The new y position</param>
    public void MoveFromZero(
        double x,
        double y)
    {
        double minX = (Window.Current.Content.ActualSize.X - RootLayout.ActualWidth) / 2;
        double minY = (Window.Current.Content.ActualSize.Y - RootLayout.ActualHeight) / 2;

        RootTransform.X = x > 0 ? x < minX ? x - minX : minX : -minX;
        RootTransform.Y = y > 32.0 ? y < minX ? y - minY : minY : -minY + 32.0;
    }
}