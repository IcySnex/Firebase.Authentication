using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace Firebase.Authentication.UWP.UI;

/// <summary>
/// The base for all 3rd party Firebase Authentication provider buttons
/// </summary>
public sealed class FirebaseAuthenticationButton : Button
{
    /// <summary>
    /// Creates a new FirebaseAuthenticationButton
    /// </summary>
    public FirebaseAuthenticationButton()
    {
        DefaultStyleKey = typeof(FirebaseAuthenticationButton);
    }


    /// <summary>
    /// Brush that describes the background when pointer is over
    /// </summary>
    public SolidColorBrush BackgroundPointerOver
    {
        get => (SolidColorBrush)GetValue(BackgroundPointerOverProperty);
        set => SetValue(BackgroundPointerOverProperty, value);
    }

    /// <summary>
    /// Brush that describes the background when pointer is over
    /// </summary>
    public static readonly DependencyProperty BackgroundPointerOverProperty = DependencyProperty.Register(
        "BackgroundPointerOver", typeof(SolidColorBrush), typeof(FirebaseAuthenticationButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(21, 255, 255, 255))));


    /// <summary>
    /// Brush that describes the border when pointer is over
    /// </summary>
    public SolidColorBrush BorderBrushPointerOver
    {
        get => (SolidColorBrush)GetValue(BorderBrushPointerOverProperty);
        set => SetValue(BorderBrushPointerOverProperty, value);
    }

    /// <summary>
    /// Brush that describes the border when pointer is over
    /// </summary>
    public static readonly DependencyProperty BorderBrushPointerOverProperty = DependencyProperty.Register(
        "BorderBrushPointerOver", typeof(SolidColorBrush), typeof(FirebaseAuthenticationButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(24, 255, 255, 255))));


    /// <summary>
    /// Brush that describes the foreground when pointer is over
    /// </summary>
    public SolidColorBrush ForegroundPointerOver
    {
        get => (SolidColorBrush)GetValue(ForegroundPointerOverProperty);
        set => SetValue(ForegroundPointerOverProperty, value);
    }

    /// <summary>
    /// Brush that describes the foreground when pointer is over
    /// </summary>
    public static readonly DependencyProperty ForegroundPointerOverProperty = DependencyProperty.Register(
        "ForegroundPointerOver", typeof(SolidColorBrush), typeof(FirebaseAuthenticationButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 255, 255, 255))));
    

    /// <summary>
    /// Brush that describes the background when pressed
    /// </summary>
    public SolidColorBrush BackgroundPressed
    {
        get => (SolidColorBrush)GetValue(BackgroundPressedProperty);
        set => SetValue(BackgroundPressedProperty, value);
    }

    /// <summary>
    /// Brush that describes the background when pressed
    /// </summary>
    public static readonly DependencyProperty BackgroundPressedProperty = DependencyProperty.Register(
        "BackgroundPressed", typeof(SolidColorBrush), typeof(FirebaseAuthenticationButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(8, 255, 255, 255))));

    
    /// <summary>
    /// Brush that describes the border when pressed
    /// </summary>
    public SolidColorBrush BorderBrushPressed
    {
        get => (SolidColorBrush)GetValue(BorderBrushPressedProperty);
        set => SetValue(BorderBrushPressedProperty, value);
    }

    /// <summary>
    /// Brush that describes the border when pressed
    /// </summary>
    public static readonly DependencyProperty BorderBrushPressedProperty = DependencyProperty.Register(
        "BorderBrushPressed", typeof(SolidColorBrush), typeof(FirebaseAuthenticationButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(18, 255, 255, 255))));

    
    /// <summary>
    /// Brush that describes the foreground when pressed
    /// </summary>
    public SolidColorBrush ForegroundPressed
    {
        get => (SolidColorBrush)GetValue(ForegroundPressedProperty);
        set => SetValue(ForegroundPressedProperty, value);
    }

    /// <summary>
    /// Brush that describes the foreground when pressed
    /// </summary>
    public static readonly DependencyProperty ForegroundPressedProperty = DependencyProperty.Register(
        "ForegroundPressed", typeof(SolidColorBrush), typeof(FirebaseAuthenticationButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(197, 219, 219, 219))));


    /// <summary>
    /// The Icon next to the content
    /// </summary>
    public ImageSource Icon
    {
        get => (ImageSource)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    /// <summary>
    /// The Icon next to the content
    /// </summary>
    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        "Icon", typeof(ImageSource), typeof(FirebaseAuthenticationButton), new PropertyMetadata(Icons.ToImageSource(Icons.Firebase)));
}