using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Svg;
using System.Drawing;
using System.Drawing.Imaging;

namespace Firebase.Authentication.WinUI.UI;

/// <summary>
/// Contains SVG images for all providers
/// </summary>
public static class Icons
{
    /// <summary>
    /// Converts a SVG image to a bitmap
    /// </summary>
    /// <param name="svg">The svg data to convert</param>
    /// <param name="width">The width of the drawn bitmap</param>
    /// <param name="height">The height of the drawn bitmap</param>
    /// <returns>A new bitmap</returns>
    public static Bitmap ToBitmap(
        string svg,
        int width = 128,
        int height = 128) =>
        SvgDocument.FromSvg<SvgDocument>(svg).Draw(width, height);

    /// <summary>
    /// Converts a SVG image to a SvgImageSource
    /// </summary>
    /// <param name="svg">The svg data to convert</param>
    /// <param name="width">The width of the image source</param>
    /// <param name="height">The height of the image source</param>
    /// <returns>A new image source</returns>
    public static ImageSource ToImageSource(
        string svg,
        int width,
        int height)
    {
        using MemoryStream stream = new();

        ToBitmap(svg, width, height).Save(stream, ImageFormat.Png);
        stream.Seek(0, SeekOrigin.Begin);

        BitmapImage bitmapImage = new();
        bitmapImage.SetSourceAsync(stream.AsRandomAccessStream()).AsTask();
        return bitmapImage;

        //using MemoryStream stream = new(System.Text.Encoding.UTF8.GetBytes(svg));

        //stream.Seek(0, SeekOrigin.Begin);

        //SvgImageSource imageSource = new()
        //{
        //    RasterizePixelWidth = width,
        //    RasterizePixelHeight = height,
        //};
        //imageSource.SetSourceAsync(stream.AsRandomAccessStream()).AsTask(); // This may leak memory
        //return imageSource;
    }
    /// <summary>
    /// Converts a SVG image to a SvgImageSource
    /// </summary>
    /// <param name="svg">The svg data to convert</param>
    /// <returns>A new image source</returns>
    public static ImageSource ToImageSource(
        string svg) =>
        ToImageSource(svg, 128, 128);


    /// <summary>
    /// SVG image for Firebase
    /// </summary>
    public const string Firebase = "<svg xmlns=\"http://www.w3.org/2000/svg\" baseProfile=\"tiny\" viewBox=\"0 0 512 512\" overflow=\"visible\" xmlns:v=\"https://vecta.io/nano\"><g fill=\"#ffa712\"><path d=\"M69.6 413.3l3.1-4.4 146.6-278.2.3-2.9L154.9 6.4c-5.4-10.2-20.6-7.6-22.4 3.8L69.6 413.3z\"/><path d=\"M266.7 219.6l48.1-49.3-48.1-91.9c-4.5-8.7-17.3-8.7-21.8 0l-25.7 49.1v4.2l47.5 87.9z\"/></g><path fill=\"#f6820c\" d=\"M69.6 413.3l1.4-1.4 5-2.1 187.6-186.9 2.5-6.5-46.9-89.2z\"/><path fill=\"#fcca3f\" d=\"M272.7 507.5l169.8-94.7L394 114.2c-1.5-9.4-13-13-19.7-6.3L69.6 413.3l168.8 94.2c10.6 6 23.6 6 34.3 0\"/></svg>";

    /// <summary>
    /// SVG image for Email and Password
    /// </summary>
    public const string EmailAndPassword = "<svg xmlns=\"http://www.w3.org/2000/svg\" baseProfile=\"tiny\" viewBox=\"0 0 128 128\" overflow=\"visible\" xmlns:v=\"https://vecta.io/nano\"><path fill=\"#fff\" d=\"M115.2 12.8H12.8C5.8 12.8 0 18.6 0 25.6v76.8c0 7 5.8 12.8 12.8 12.8h102.4c7 0 12.8-5.8 12.8-12.8V25.6c0-7-5.8-12.8-12.8-12.8zm0 25.6L64 70.4l-51.2-32V25.6l51.2 32 51.2-32v12.8z\"/></svg>";

    /// <summary>
    /// SVG image for Phone Number
    /// </summary>
    public const string PhoneNumber = "<svg xmlns=\"http://www.w3.org/2000/svg\" baseProfile=\"tiny\" viewBox=\"0 0 128 128\" overflow=\"visible\" xmlns:v=\"https://vecta.io/nano\"><path fill=\"#fff\" d=\"M25.6 55.5c10 19.9 27 36.3 46.9 46.9l15.6-15.6c2.1-2.1 5-2.8 7.1-1.4 7.8 2.8 16.4 4.3 25.6 4.3 3.6 0 7.1 2.8 7.1 7.1V121c0 3.6-3.6 7.1-7.1 7.1C54 128 0 74 0 7.1 0 3.6 3.6 0 7.1 0H32c4.3 0 7.1 3.6 7.1 7.1 0 8.5 1.4 17.1 4.3 25.6.7 2.1 0 5-1.4 7.1L25.6 55.5z\"/></svg>";

    /// <summary>
    /// SVG image for Facebook
    /// </summary>
    public const string Facebook = "<svg xmlns=\"http://www.w3.org/2000/svg\" baseProfile=\"tiny\" viewBox=\"0 0 128 128\" overflow=\"visible\" xmlns:v=\"https://vecta.io/nano\"><path fill-rule=\"evenodd\" fill=\"#fff\" d=\"M121 0H7C3.2 0 0 3.2 0 7v114c0 3.9 3.2 7 7 7h61.3V78.4H51.7V59.1h16.6V44.9c0-16.5 10.1-25.5 24.9-25.5 7 0 13.1.5 14.9.7v17.2H97.9c-8 0-9.6 3.8-9.6 9.4v12.4h19.1L105 78.4H88.3V128H121c3.9 0 7-3.2 7-7V7c0-3.8-3.2-7-7-7\"/></svg>";

    /// <summary>
    /// SVG image for Google
    /// </summary>
    public const string Google = "<svg xmlns=\"http://www.w3.org/2000/svg\" baseProfile=\"tiny\" viewBox=\"0 0 128 128\" overflow=\"visible\" fill-rule=\"evenodd\" xmlns:v=\"https://vecta.io/nano\"><path fill=\"#4285f4\" d=\"M125.4 65.5c0-4.5-.4-8.9-1.2-13.1H64v24.8h34.4c-1.5 8-6 14.8-12.8 19.3v16.1h20.7c12.2-11.2 19.1-27.7 19.1-47.1h0z\"/><path fill=\"#34a853\" d=\"M64 128c17.3 0 31.8-5.7 42.4-15.5L85.7 96.4c-5.7 3.8-13.1 6.1-21.7 6.1-16.7 0-30.8-11.3-35.8-26.4H6.8v16.6C17.3 113.7 39 128 64 128h0z\"/><path fill=\"#fbbc05\" d=\"M28.2 76.2c-1.3-3.8-2-7.9-2-12.2s.7-8.3 2-12.2V35.3H6.8C2.5 43.9 0 53.7 0 64s2.5 20.1 6.8 28.7l21.4-16.5h0z\"/><path fill=\"#ea4335\" d=\"M64 25.5c9.4 0 17.8 3.2 24.5 9.6l18.4-18.4C95.7 6.3 81.3 0 64 0 39 0 17.3 14.3 6.8 35.3l21.4 16.6c5-15.2 19.1-26.4 35.8-26.4h0z\"/></svg>";

    /// <summary>
    /// SVG image for Apple
    /// </summary>
    public const string Apple = "<svg xmlns=\"http://www.w3.org/2000/svg\" baseProfile=\"tiny\" viewBox=\"0 0 128 128\" overflow=\"visible\" xmlns:v=\"https://vecta.io/nano\"><path fill=\"#fff\" d=\"M112.8 43.6c-.7.6-13.9 8-13.9 24.4 0 19 16.7 25.7 17.2 25.9-.1.4-2.6 9.2-8.8 18.2-5.5 7.9-11.2 15.8-19.9 15.8s-10.9-5.1-21-5.1c-9.8 0-13.3 5.2-21.2 5.2s-13.5-7.3-19.9-16.3c-7.4-10.5-13.4-26.9-13.4-42.4 0-24.9 16.2-38.1 32.1-38.1 8.5 0 15.5 5.6 20.8 5.6 5.1 0 12.9-5.9 22.6-5.9 3.6 0 16.8.4 25.4 12.7h0zm-30-23.2c4-4.7 6.8-11.3 6.8-17.8 0-.9-.1-1.8-.2-2.6-6.5.2-14.2 4.3-18.8 9.7-3.6 4.1-7.1 10.7-7.1 17.3 0 1 .2 2 .2 2.3a7.93 7.93 0 0 0 1.7.2c5.9 0 13.2-3.9 17.4-9.1h0z\"/></svg>";

    /// <summary>
    /// SVG image for Github
    /// </summary>
    public const string Github = "<svg xmlns=\"http://www.w3.org/2000/svg\" baseProfile=\"tiny\" viewBox=\"0 0 128 128\" overflow=\"visible\" xmlns:v=\"https://vecta.io/nano\"><path fill-rule=\"evenodd\" fill=\"#fff\" d=\"M0 64c0 11.7 2.9 22.5 8.6 32.1 5.8 9.9 13.5 17.7 23.3 23.3s20.5 8.5 32.1 8.5 22.3-2.9 32.2-8.5c9.8-5.8 17.6-13.5 23.2-23.3S128 75.5 128 64c0-11.7-2.9-22.5-8.5-32.2C113.6 22 105.8 14.3 96 8.6S75.5.1 63.9.1C52.2.1 41.5 3 31.9 8.7 22 14.4 14.2 22.1 8.5 31.9S0 52.5 0 64h0zm10.7 0c0-7.1 1.4-14 4.2-20.6S21.5 31 26.4 26.2c4.8-4.8 10.6-8.6 17.2-11.4s13.3-4.2 20.5-4.2c7.1 0 14 1.4 20.6 4.2s12.4 6.6 17.2 11.4 8.6 10.6 11.4 17.2 4.2 13.4 4.2 20.6c0 7.7-1.6 14.9-4.7 21.8s-7.6 12.9-13.2 17.9-12.1 8.7-19.4 11V96c0-4.7-1.9-8.3-5.8-10.9 9.4-.9 16.2-3.2 20.6-7.1s6.5-10.1 6.5-18.7c0-6.6-2-12.1-6.1-16.6.9-2.3 1.2-4.7 1.2-6.9 0-3.3-.7-6.3-2.2-9.1-3 0-5.6.5-8 1.5-2.3 1-5.2 2.7-8.6 5.1-4.2-1-8.4-1.4-12.8-1.4-5 0-9.7.5-14.1 1.5-3.3-2.5-6.2-4.2-8.6-5.1s-5.1-1.5-8.2-1.5c-1.5 2.8-2.2 5.9-2.2 9.1 0 2.3.4 4.7 1.2 7-4 4.4-6.1 9.8-6.1 16.5 0 8.5 2.1 14.7 6.5 18.5s11.2 6.3 20.7 7.1c-2.6 1.7-4.3 4.2-5.2 7.4-2.1.7-4.5 1.2-6.8 1.2-1.8 0-3.3-.4-4.6-1.2-.4-.2-.7-.4-1.1-.7-.3-.3-.6-.5-1.1-.9-.4-.3-.6-.6-.9-.9-.2-.2-.5-.5-.9-1.1s-.6-.9-.7-1-.4-.5-.9-1.1c-.4-.5-.6-.9-.7-1-2.1-2.8-4.6-4.2-7.5-4.2-1.6 0-2.3.3-2.3 1 0 .2.4.7 1.2 1.3l2.2 2c1.1.9 1.7 1.4 1.8 1.6 1.3 1.6 2.2 3.3 3 5.2 2.6 5.6 6.8 8.4 12.8 8.4 1 0 2.9-.2 5.8-.6v14.1c-7.2-2.2-13.7-6-19.4-11s-10.1-11-13.2-17.9-5-13.9-5-21.6h0z\"/></svg>";

    /// <summary>
    /// SVG image for Twitter
    /// </summary>
    public const string Twitter = "<svg xmlns=\"http://www.w3.org/2000/svg\" baseProfile=\"tiny\" viewBox=\"0 0 128 128\" overflow=\"visible\" xmlns:v=\"https://vecta.io/nano\"><path fill-rule=\"evenodd\" fill=\"#fff\" d=\"M128 26.5c-4.7 2.1-9.8 3.5-15 4.2 5.4-3.2 9.6-8.4 11.5-14.5-5.1 3-10.7 5.2-16.6 6.4-4.8-5.1-11.6-8.3-19.2-8.3-14.5 0-26.2 11.7-26.2 26.2 0 2 .2 4 .6 6C41.2 45.4 22 35 9.1 19.1c-2.3 3.8-3.6 8.3-3.6 13.1 0 9.1 4.6 17.2 11.7 21.8-4.3-.1-8.3-1.3-11.9-3.3v.3c0 12.7 9.1 23.3 21 25.7-2.2.6-4.5 1-6.9 1-1.7 0-3.3-.2-4.9-.4 3.3 10.4 13 18 24.5 18.2-9 7-20.2 11.2-32.6 11.2-2.1 0-4.2-.1-6.3-.3 11.6 7.5 25.4 11.8 40.2 11.8 48.3 0 74.6-40 74.6-74.6 0-1.2 0-2.2-.1-3.4 5.2-3.8 9.7-8.4 13.2-13.7\"/></svg>";

    /// <summary>
    /// SVG image for Microsoft
    /// </summary>
    public const string Microsoft = "<svg xmlns=\"http://www.w3.org/2000/svg\" baseProfile=\"tiny\" viewBox=\"0 0 128 128\" overflow=\"visible\" xmlns:v=\"https://vecta.io/nano\"><path fill=\"#f25022\" d=\"M0 0h60.6v60.6H0z\"/><path fill=\"#00a4ef\" d=\"M0 67.4h60.6V128H0z\"/><path fill=\"#7fba00\" d=\"M67.4 0H128v60.6H67.4z\"/><path fill=\"#ffb900\" d=\"M67.4 67.4H128V128H67.4z\"/></svg>";

    /// <summary>
    /// SVG image for Yahoo
    /// </summary>
    public const string Yahoo = "<svg xmlns=\"http://www.w3.org/2000/svg\" baseProfile=\"tiny\" viewBox=\"0 0 128 128\" overflow=\"visible\" fill=\"#fff\" xmlns:v=\"https://vecta.io/nano\"><path d=\"M128 4.6h-27.7L75.4 64h27.7zM42.5 123.4l37.4-89.9H55L40.1 71.6 25.3 33.5H0l27.7 66.2-10.1 23.7z\"/><circle cx=\"82.7\" cy=\"84.9\" r=\"15.2\"/></svg>";

    /// <summary>
    /// SVG image for Anonymously
    /// </summary>
    public const string Anonymously = "<svg xmlns=\"http://www.w3.org/2000/svg\" baseProfile=\"tiny\" viewBox=\"0 0 128 128\" overflow=\"visible\" fill=\"#fff\" xmlns:v=\"https://vecta.io/nano\"><path d=\"M63.9 65.6C81.7 65.6 96 51.2 96 33.4c0-17.6-14.4-32-32.1-32S32 15.9 32 33.6c0 17.6 14.3 32 31.9 32zm0-50.7c10.4 0 18.6 8.4 18.6 18.6 0 10.4-8.4 18.6-18.6 18.6s-18.6-8.4-18.6-18.6 8.4-18.6 18.6-18.6zm0 57.7C28.6 72.6 0 87 0 104.7v21.8h128v-21.8c0-17.7-28.8-32.1-64.1-32.1zm51.5 34.7v4.6c0 2-1.8 3.6-4 3.6H16.6c-2.2 0-4-1.6-4-3.6v-4.6-.6-.8c0-11.6 23-21 51.5-21 28.4 0 51.5 9.4 51.5 21v.8c-.2.4-.2.6-.2.6z\"/></svg>";
}