using Firebase.Authentication.WinUI.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using System.Drawing;
using System.Runtime.InteropServices;
using Windows.Graphics;
using WinRT.Interop;

namespace Firebase.Authentication.WinUI.Internal;

internal class WindowHelper
{
    readonly AppWindow window;
    readonly ILogger? logger;

    /// <summary>
    /// Creates a new WindowHelper with with optional logging functions
    /// </summary>
    /// <param name="window">The winodw which is used in the helper</param>
    /// <param name="logger">The logger which will be used for logging</param>
    public WindowHelper(
        Window window,
        ILogger? logger = null)
    {
        HWnd = GetHWnd(window);
        this.window = AppWindow.GetFromWindowId(Win32Interop.GetWindowIdFromWindow(HWnd));
        this.logger = logger;

        ((OverlappedPresenter)this.window.Presenter).IsResizable = false;
        ((OverlappedPresenter)this.window.Presenter).IsMinimizable = false;
        ((OverlappedPresenter)this.window.Presenter).IsMaximizable = false;
    }


    /// <summary>
    /// Gets the position and size of an owner window
    /// </summary>
    /// <param name="owner">The owner window</param>
    /// <returns>The position and size</returns>
    (PointInt32, SizeInt32) GetOwnerWindow(
        Window owner)
    {
        AppWindow ownerWindow = AppWindow.GetFromWindowId(Win32Interop.GetWindowIdFromWindow(GetHWnd(owner)));
        return (ownerWindow.Position, ownerWindow.Size);
    }

    /// <summary>
    /// Gets the HWND of an owner window
    /// </summary>
    /// <param name="owner">The owner window</param>
    /// <returns></returns>
    IntPtr GetHWnd(
        Window owner) =>
        WindowNative.GetWindowHandle(owner);


    private static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong) =>
        IntPtr.Size == 8 ? SetWindowLongPtr64(hWnd, nIndex, dwNewLong) : new(SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));

    [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
    private static extern int SetWindowLong32(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
    private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

    [DllImport("user32.dll", EntryPoint = "GetDpiForWindow")]
    private static extern int GetDpiForWindow(IntPtr hwnd);

    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);


    /// <summary>
    /// HWND of the current main window
    /// </summary>
    public readonly IntPtr HWnd;

    /// <summary>
    /// Position of the current main window
    /// </summary>
    public PointInt32 Position => window.Position;

    /// <summary>
    /// Size of the current main window
    /// </summary>
    public SizeInt32 Size => window.Size;

    /// <summary>
    /// Size of the current main screen
    /// </summary>
    public RectInt32 ScreenSize => DisplayArea.GetFromWindowId(Win32Interop.GetWindowIdFromWindow(HWnd), DisplayAreaFallback.Nearest).WorkArea;


    /// <summary>
    /// Makes the current main window a dialog window
    /// </summary>
    /// <param name="owner">The owner to set for the current main window</param>
    public void MakeDialog(
        Window owner)
    {
        SetWindowLongPtr(HWnd, -8, GetHWnd(owner));
        ((OverlappedPresenter)window.Presenter).IsModal = true;
    }


    /// <summary>
    /// Sets a custom icon on the current main window
    /// </summary>
    /// <param name="icon">The bitmap icon</param>
    public void SetIcon(
        Bitmap icon)
    {
        if (icon is null)
            return;

        IntPtr hicon = icon.GetHicon();

        SendMessage(HWnd, 128, (IntPtr)0, hicon);
        SendMessage(HWnd, 128, (IntPtr)1, hicon);

        logger?.LogInformation("[WindowHelper-SetIcon] Set app icon to bitmap");
    }

    /// <summary>
    /// Sets the size of the current main window
    /// </summary>
    /// <param name="width">The width of the new size</param>
    /// <param name="height">The height of the new size</param>
    public void SetSize(
        int width,
        int height)
    {
        double scaling = GetDpiForWindow(HWnd) / 96.0;
        window.Resize(new((int)((width + 16) * scaling), (int)((height + 39) * scaling)));

        logger?.LogInformation("[WindowHelper-SetSize] Set window size [{width}x{height}]", width, height);
    }


    /// <summary>
    /// Sets the position of the current main window
    /// </summary>
    /// <param name="x">The x coordinate of the new position</param>
    /// <param name="y">The y coordinate of the new position</param>
    public void SetPositionToPoint(
        int x,
        int y)
    {
        window.Move(new(x, y));
        logger?.LogInformation("[WindowHelper-SetPosition] Set window position [{x}, {y}]", x, y);
    }

    /// <summary>
    /// Sets the position of the current main window to the cetner of the main screen
    /// </summary>
    public void SetPositionToCenter() =>
        SetPositionToPoint((ScreenSize.Width - Size.Width) / 2, (ScreenSize.Height - Size.Height) / 2);

    /// <summary>
    /// Sets the position of the current main window to the cetner of the owner window
    /// </summary>
    /// <param name="owner">The owner of the current main window</param>
    public void SetPositionToOwnerCenter(
        Window owner)
    {
        (PointInt32 ownerPosition, SizeInt32 ownerSize) = GetOwnerWindow(owner);

        int left = ownerPosition.X + (ownerSize.Width / 2) - (Size.Width / 2);
        left = left < 0 ? 0 : left > ScreenSize.Width - Size.Width ? ScreenSize.Width - Size.Width : left;
        int top = ownerPosition.Y + (ownerSize.Height / 2) - (Size.Height / 2);
        top = top < 0 ? 0 : top > ScreenSize.Height - Size.Height ? ScreenSize.Height - Size.Height - 30 : top;

        SetPositionToPoint(left, top);
    }

    /// <summary>
    /// Sets the position of the current main window
    /// </summary>
    /// <param name="location">The default location of the window</param>
    /// <param name="x">The x coordinate of the new position</param>
    /// <param name="y">The y coordinate of the new position</param>
    /// <param name="owner">The owner of the current main window</param>
    public void SetPosition(
        WindowStartupLocation location,
        int x,
        int y,
        Window? owner)
    {

        switch (location)
        {
            case WindowStartupLocation.CenterScreen:
                SetPositionToCenter();
                return;
            case WindowStartupLocation.CenterOwner:
                if (owner is null)
                    break;

                SetPositionToOwnerCenter(owner);
                return;
        }

        SetPositionToPoint(x, y);
    }
}