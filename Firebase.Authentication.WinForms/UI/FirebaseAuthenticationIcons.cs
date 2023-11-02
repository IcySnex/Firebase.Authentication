using System.ComponentModel;

namespace Firebase.Authentication.WinForms.UI;

/// <summary>
/// Contains an ImageList which contains all rendered provider icons in given resolution
/// </summary>
public class FirebaseAuthenticationIcons : Component
{
    /// <summary>
    /// Gets the ImageList which contains all rendered provider icons in given resolution
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ImageList List { get; }


    int oldWidth = 0;

    int width = 19;

    /// <summary>
    /// Gets or sets the width of the images 
    /// </summary>
    [Category("Image")]
    public int Width
    {
        get => width;
        set
        {
            width = value;
            Invalidate();
        }
    }


    int oldHeight = 0;

    int height = 19;

    /// <summary>
    /// Gets or sets the height of the images 
    /// </summary>
    [Category("Image")]
    public int Height
    {
        get => height;
        set
        {
            height = value;
            Invalidate();
        }
    }


    int oldspacingWidth = 0;

    int spacingWidth = 8;

    /// <summary>
    /// Gets or sets the spacing width of the images 
    /// </summary>
    [Category("Image")]
    public int SpacingWidth
    {
        get => spacingWidth;
        set
        {
            spacingWidth = value;
            Invalidate();
        }
    }


    int oldspacingHeight = 0;

    int spacingHeight = 0;

    /// <summary>
    /// Gets or sets the spacing height of the images 
    /// </summary>
    [Category("Image")]
    public int SpacingHeight
    {
        get => spacingHeight;
        set
        {
            spacingHeight = value;
            Invalidate();
        }
    }


    /// <summary>
    /// Creates a new FirebaseAuthenticationIcons
    /// </summary>
    public FirebaseAuthenticationIcons()
    {
        List = new()
        {
            ColorDepth = ColorDepth.Depth32Bit,
        };

        Invalidate();
    }


    void Invalidate()
    {
        if (oldWidth == Width && oldHeight == Height && oldspacingWidth == SpacingWidth && oldspacingHeight == SpacingHeight)
            return;

        (oldWidth, oldHeight, oldspacingWidth, oldspacingHeight) = (Width, Height, SpacingWidth, SpacingHeight);

        int canvasWidth = Width + SpacingWidth;
        int canvasHeight = Height + SpacingHeight;

        List.ImageSize = new(canvasWidth, canvasHeight);
        List.Images.Clear();

        List.Images.Add("Firebase", Icons.ToBitmap(Icons.Firebase, Width, Height, canvasWidth, canvasHeight));
        List.Images.Add("EmailAndPassword", Icons.ToBitmap(Icons.EmailAndPassword, Width, Height, canvasWidth, canvasHeight));
        List.Images.Add("PhoneNumber", Icons.ToBitmap(Icons.PhoneNumber, Width, Height, canvasWidth, canvasHeight));
        List.Images.Add("Facebook", Icons.ToBitmap(Icons.Facebook, Width, Height, canvasWidth, canvasHeight));
        List.Images.Add("Google", Icons.ToBitmap(Icons.Google, Width, Height, canvasWidth, canvasHeight));
        List.Images.Add("Apple", Icons.ToBitmap(Icons.Apple, Width, Height, canvasWidth, canvasHeight));
        List.Images.Add("Github", Icons.ToBitmap(Icons.Github, Width, Height, canvasWidth, canvasHeight));
        List.Images.Add("Twitter", Icons.ToBitmap(Icons.Twitter, Width, Height, canvasWidth, canvasHeight));
        List.Images.Add("Microsoft", Icons.ToBitmap(Icons.Microsoft, Width, Height, canvasWidth, canvasHeight));
        List.Images.Add("Yahoo", Icons.ToBitmap(Icons.Yahoo, Width, Height, canvasWidth, canvasHeight));
        List.Images.Add("Anonymously", Icons.ToBitmap(Icons.Yahoo, Width, Height, canvasWidth, canvasHeight));
    }

}