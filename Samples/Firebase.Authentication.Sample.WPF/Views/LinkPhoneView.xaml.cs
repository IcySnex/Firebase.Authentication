using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace Firebase.Authentication.Sample.WPF.Views;

public partial class LinkPhoneView : UserControl
{
    public LinkPhoneView() =>
        InitializeComponent();


    private void OnPhoneNumberTextBoxPreviewInput(object sender, TextCompositionEventArgs e)
    {
        if (!Regex.IsMatch(e.Text, @"^[0-9\+]$"))
        {
            e.Handled = true;
            return;
        }

        e.Handled = !Regex.IsMatch(((TextBox)sender).Text + e.Text, @"^\+[0-9]{0,14}$");
    }

    private void OnCodeKeyDown(object _, KeyEventArgs e)
    {
        if (e.Key == Key.Enter || e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Left || e.Key == Key.Right)
            return;

        e.Handled = (e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9);
    }
}