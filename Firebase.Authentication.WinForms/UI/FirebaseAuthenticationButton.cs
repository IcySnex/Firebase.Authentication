using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace Firebase.Authentication.WinForms.UI;

/// <summary>
/// The base for all 3rd party Firebase Authentication provider buttons
/// </summary>
public class FirebaseAuthenticationButton : Button
{
    int cornerRadius = 2;

    /// <summary>
    /// Gets or sets the corner radius of the button
    /// </summary>
    [Category("Appearance")]
    public int CornerRadius
    {
        get => cornerRadius;
        set
        {
            cornerRadius = value;
            Invalidate();
        }
    }


    /// <summary>
    /// Creates a new FirebaseAuthenticationButton
    /// </summary>
    public FirebaseAuthenticationButton() : this(Color.FromArgb(255, 51, 51, 51), Color.FromArgb(255, 196, 196, 196)) { }

    /// <summary>
    /// Creates a new FirebaseAuthenticationButton
    /// </summary>
    /// <param name="backColor">The color of the background</param>
    /// <param name="foreColor">The color of the foreground</param>
    public FirebaseAuthenticationButton(
        Color backColor,
        Color foreColor)
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;

        Size = new Size(220, 40);
        CornerRadius = 2;
        Font = new("Segoe UI Variable Text Semibold", 10, FontStyle.Bold);
        TextImageRelation = TextImageRelation.ImageBeforeText;
        ImageAlign = ContentAlignment.MiddleLeft;
        TextAlign = ContentAlignment.MiddleLeft;
        Padding = new(12, 0, 12, 0);

        BackColor = backColor;
        ForeColor = foreColor;

        Resize += (s, e) => { if (CornerRadius > Height) CornerRadius = Height; };
    }


    GraphicsPath GetFigurePath(
        Rectangle rect,
        int radius)
    {
        GraphicsPath path = new();
        float curveSize = radius * 2f;

        path.StartFigure();
        path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
        path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
        path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
        path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
        path.CloseFigure();
        return path;
    }


    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        Rectangle rectSurface = ClientRectangle;

        if (CornerRadius < 2)
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.None;
            Region = new(rectSurface);

            return;
        }

        using GraphicsPath pathSurface = GetFigurePath(rectSurface, CornerRadius);
        using Pen penSurface = new(Parent.BackColor, 2);

        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        Region = new(pathSurface);
        pevent.Graphics.DrawPath(penSurface, pathSurface);
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        Parent.BackColorChanged += (s, e) => Invalidate();
    }
}