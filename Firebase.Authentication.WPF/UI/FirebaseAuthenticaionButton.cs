using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Firebase.Authentication.WPF.UI;

/// <summary>
/// The base for all 3rd party Firebase authenticaion provider buttons
/// </summary>
public class FirebaseAuthenticaionButton : Button
{
    static FirebaseAuthenticaionButton() =>
        DefaultStyleKeyProperty.OverrideMetadata(typeof(FirebaseAuthenticaionButton), new FrameworkPropertyMetadata(typeof(FirebaseAuthenticaionButton)));

    /// <summary>
    /// Creates a new FirebaseAuthenticaionButton
    /// </summary>
    public FirebaseAuthenticaionButton()
    {
    }


    private static void OnHasShadowChanged(
        DependencyObject sender,
        DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue == e.OldValue)
            return;

        FirebaseAuthenticaionButton owner = (FirebaseAuthenticaionButton)sender;
        ((Border)owner.GetTemplateChild("RootLayout")).Effect = (bool)e.NewValue ? new DropShadowEffect() { BlurRadius = 4, Opacity = 0.3, Direction = 270, ShadowDepth = 4 } : null;
    }


    /// <summary>
    /// Brush that describes the background when hovered
    /// </summary>
    public Brush BackgroundHover
    {
        get => (Brush)GetValue(BackgroundHoverProperty);
        set => SetValue(BackgroundHoverProperty, value);
    }

    /// <summary>
    /// Brush that describes the background when hovered
    /// </summary>
    public static readonly DependencyProperty BackgroundHoverProperty = DependencyProperty.Register(
        "BackgroundHover", typeof(Brush), typeof(FirebaseAuthenticaionButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 219, 219, 219))));


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
        "Icon", typeof(ImageSource), typeof(FirebaseAuthenticaionButton), new PropertyMetadata(Icons.Google));


    /// <summary>
    /// The degree to which the coreners are rounded
    /// </summary>
    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    /// <summary>
    /// The degree to which the coreners are rounded
    /// </summary>
    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        "CornerRadius", typeof(CornerRadius), typeof(FirebaseAuthenticaionButton), new PropertyMetadata(new CornerRadius(2)));


    /// <summary>
    /// Weither the Button throws a shadow
    /// </summary>
    public bool HasShadow
    {
        get => (bool)GetValue(HasShadowProperty);
        set => SetValue(HasShadowProperty, value);
    }

    /// <summary>
    /// Weither the Button throws a shadow
    /// </summary>
    public static readonly DependencyProperty HasShadowProperty = DependencyProperty.Register(
        "HasShadow", typeof(bool), typeof(FirebaseAuthenticaionButton), new PropertyMetadata(true, OnHasShadowChanged));

}