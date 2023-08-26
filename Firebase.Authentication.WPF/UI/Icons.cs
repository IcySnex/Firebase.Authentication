using System.Windows.Media;

namespace Firebase.Authentication.WPF.UI;

/// <summary>
/// Contains geometry images for all providers
/// </summary>
public static class Icons
{
    /// <summary>
    /// Geometry image for Firebase
    /// </summary>
    public static DrawingImage Firebase
    {
        get
        {
            DrawingGroup drawing = new();
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 253, 166, 18)), null,
                Geometry.Parse("F1 M800,800z M0,0z M108.3,645L113.1,638.2 341.9,204 342.4,199.4 241.5,9.9C233,-6,209.3,-2,206.5,15.8L108.3,645z")
            ));
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 255, 165, 14)), null,
                Geometry.Parse("F1 M800,800z M0,0z M416,342.7L491.1,265.8 416,122.4C408.9,108.8,389,108.8,381.9,122.4L341.8,199 341.8,205.5 416,342.7z")
            ));
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 246, 130, 12)), null,
                Geometry.Parse("F1 M800,800z M0,0z M108.3,645L108.3,645 110.5,642.8 118.4,639.6 411.2,347.8 415,337.7 341.9,198.5z")
            ));
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 252, 202, 63)), null,
                Geometry.Parse("F1 M800,800z M0,0z M425.3,792.1L690.3,644.3 614.6,178.2C612.2,163.6,594.3,157.9,583.9,168.3L108.3,645 371.8,792.1C388.4,801.4,408.7,801.4,425.3,792.1")
            ));

            return new(drawing);
        }
    }

    /// <summary>
    /// Geometry image for Email and Password
    /// </summary>
    public static DrawingImage EmailAndPassword
    {
        get
        {
            GeometryDrawing drawing = new(
                new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)), null,
                Geometry.Parse("F1 M24,24z M0,0z M20,4L4,4C2.9,4,2,4.9,2,6L2,18C2,19.1,2.9,20,4,20L20,20C21.1,20,22,19.1,22,18L22,6C22,4.9,21.1,4,20,4z M20,8L12,13 4,8 4,6 12,11 20,6 20,8z"));

            return new(drawing);
        }
    }
    
    /// <summary>
    /// Geometry image for Phone Number
    /// </summary>
    public static DrawingImage PhoneNumber
    {
        get
        {
            GeometryDrawing drawing = new(
                new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)), null,
                Geometry.Parse("F1 M24,24z M0,0z M6.6,10.8C8,13.6,10.4,15.9,13.2,17.4L15.4,15.2C15.7,14.9 16.1,14.8 16.4,15 17.5,15.4 18.7,15.6 20,15.6 20.5,15.6 21,16 21,16.6L21,20C21,20.5 20.5,21 20,21 10.6,21 3,13.4 3,4 3,3.5 3.5,3 4,3L7.5,3C8.1,3 8.5,3.5 8.5,4 8.5,5.2 8.7,6.4 9.1,7.6 9.2,7.9 9.1,8.3 8.9,8.6L6.6,10.8z"));

            return new(drawing);
        }
    }
    
    /// <summary>
    /// Geometry image for Facebook
    /// </summary>
    public static DrawingImage Facebook
    {
        get
        {
            GeometryDrawing drawing = new(
                new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)), null,
                Geometry.Parse("F0 M120,120z M0,0z M113.4,0L6.6,0C3,0,0,3,0,6.6L0,113.4C0,117.1,3,120,6.6,120L64.1,120 64.1,73.5 48.5,73.5 48.5,55.4 64.1,55.4 64.1,42.1C64.1,26.6 73.6,18.2 87.4,18.2 94,18.2 99.7,18.7 101.4,18.9L101.4,35 91.8,35C84.3,35,82.8,38.6,82.8,43.8L82.8,55.4 100.7,55.4 98.4,73.5 82.8,73.5 82.8,120 113.4,120C117.1,120,120,117,120,113.4L120,6.6C120,3,117,0,113.4,0"));

            return new(drawing);
        }
    }

    /// <summary>
    /// Geometry image for Google
    /// </summary>
    public static DrawingImage Google
    {
        get
        {
            DrawingGroup drawing = new();
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 66, 133, 244)), null,
                Geometry.Parse("F0 M118,120z M0,0z M117.6,61.3636364C117.6,57.1090909,117.218182,53.0181818,116.509091,49.0909091L60,49.0909091 60,72.3 92.2909091,72.3C90.9,79.8,86.6727273,86.1545455,80.3181818,90.4090909L80.3181818,105.463636 99.7090909,105.463636C111.054545,95.0181818,117.6,79.6363636,117.6,61.3636364L117.6,61.3636364z")
            ));
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 52, 168, 83)), null,
                Geometry.Parse("F0 M118,120z M0,0z M60,120C76.2,120,89.7818182,114.627273,99.7090909,105.463636L80.3181818,90.4090909C74.9454545,94.0090909 68.0727273,96.1363636 60,96.1363636 44.3727273,96.1363636 31.1454545,85.5818182 26.4272727,71.4L6.38181818,71.4 6.38181818,86.9454545C16.2545455,106.554545,36.5454545,120,60,120L60,120z")
            ));
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 251, 188, 5)), null,
                Geometry.Parse("F0 M118,120z M0,0z M26.4272727,71.4C25.2272727,67.8 24.5454545,63.9545455 24.5454545,60 24.5454545,56.0454545 25.2272727,52.2 26.4272727,48.6L26.4272727,33.0545455 6.38181818,33.0545455C2.31818182,41.1545455 0,50.3181818 0,60 0,69.6818182 2.31818182,78.8454545 6.38181818,86.9454545L26.4272727,71.4 26.4272727,71.4z")
            ));
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 234, 67, 53)), null,
                Geometry.Parse("F0 M118,120z M0,0z M60,23.8636364C68.8090909,23.8636364,76.7181818,26.8909091,82.9363636,32.8363636L100.145455,15.6272727C89.7545455,5.94545455 76.1727273,0 60,0 36.5454545,0 16.2545455,13.4454545 6.38181818,33.0545455L26.4272727,48.6C31.1454545,34.4181818,44.3727273,23.8636364,60,23.8636364L60,23.8636364z")
            ));

            return new(drawing);
        }
    }

    /// <summary>
    /// Geometry image for Apple
    /// </summary>
    public static DrawingImage Apple
    {
        get
        {
            GeometryDrawing drawing = new(
                new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)), null,
                Geometry.Parse("F1 M814,1000z M0,0z M788.1,340.9C782.3,345.4 679.9,403.1 679.9,531.4 679.9,679.8 810.2,732.3 814.1,733.6 813.5,736.8 793.4,805.5 745.4,875.5 702.6,937.1 657.9,998.6 589.9,998.6 521.9,998.6 504.4,959.1 425.9,959.1 349.4,959.1 322.2,999.9 260,999.9 197.8,999.9 154.4,942.9 104.5,872.9 46.7,790.7 0,663 0,541.8 0,347.4 126.4,244.3 250.8,244.3 316.9,244.3 372,287.7 413.5,287.7 453,287.7 514.6,241.7 589.8,241.7 618.3,241.7 720.7,244.3 788.1,340.9L788.1,340.9z M554.1,159.4C585.2,122.5 607.2,71.3 607.2,20.1 607.2,13 606.6,5.79999999999999 605.3,-7.105427357601E-15 554.7,1.89999999999999 494.5,33.7 458.2,75.8 429.7,108.2 403.1,159.4 403.1,211.3 403.1,219.1 404.4,226.9 405,229.4 408.2,230 413.4,230.7 418.6,230.7 464,230.7 521.1,200.3 554.1,159.4L554.1,159.4z"));

            return new(drawing);
        }
    }
        
    /// <summary>
    /// Geometry image for Github
    /// </summary>
    public static DrawingImage Github
    {
        get
        {
            GeometryDrawing drawing = new(
                new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)), null,
                Geometry.Parse("F0 M120,120z M0,0z M0,60C0,71 2.7,81.1 8.1,90.1 13.5,99.4 20.8,106.7 30,112 39.2,117.3 49.2,120 60.1,120 71,120 81,117.3 90.3,112 99.5,106.6 106.8,99.3 112.1,90.1 117.4,80.9 120.1,70.8 120.1,60 120.1,49 117.4,38.9 112.1,29.8 106.6,20.6 99.3,13.3 90.1,8 80.9,2.7 70.8,0 60,0 49,0 38.9,2.7 29.9,8.1 20.6,13.4 13.3,20.7 8,29.9 2.7,39.1 0,49.2 0,60L0,60z M10,60C10,53.3 11.3,46.9 13.9,40.7 16.5,34.5 20.1,29.1 24.7,24.6 29.2,20.1 34.6,16.5 40.8,13.9 47,11.3 53.3,10 60,10 66.7,10 73.1,11.3 79.3,13.9 85.5,16.5 90.9,20.1 95.4,24.6 99.9,29.1 103.5,34.5 106.1,40.7 108.7,46.9 110,53.3 110,60 110,67.2 108.5,74 105.6,80.5 102.7,87 98.5,92.6 93.2,97.3 87.9,102 81.8,105.5 75,107.6L75,90C75,85.6 73.2,82.2 69.6,79.8 78.4,79 84.8,76.8 88.9,73.1 93,69.4 95,63.6 95,55.6 95,49.4 93.1,44.2 89.3,40 90.1,37.8 90.4,35.6 90.4,33.5 90.4,30.4 89.7,27.6 88.3,25 85.5,25 83,25.5 80.8,26.4 78.6,27.3 75.9,28.9 72.7,31.2 68.8,30.3 64.8,29.9 60.7,29.9 56,29.9 51.6,30.4 47.5,31.3 44.4,29 41.7,27.4 39.4,26.5 37.1,25.6 34.6,25.1 31.7,25.1 30.3,27.7 29.6,30.6 29.6,33.6 29.6,35.8 30,38 30.7,40.2 26.9,44.3 25,49.4 25,55.7 25,63.7 27,69.5 31.1,73.1 35.2,76.7 41.6,79 50.5,79.8 48.1,81.4 46.5,83.7 45.6,86.7 43.6,87.4 41.4,87.8 39.2,87.8 37.5,87.8 36.1,87.4 34.9,86.7 34.5,86.5 34.2,86.3 33.9,86 33.6,85.7 33.3,85.5 32.9,85.2 32.5,84.9 32.3,84.6 32.1,84.4 31.9,84.2 31.6,83.9 31.3,83.4 31,82.9 30.7,82.6 30.6,82.5 30.5,82.4 30.2,82 29.8,81.5 29.4,81 29.2,80.7 29.1,80.6 27.1,78 24.8,76.7 22.1,76.7 20.6,76.7 19.9,77 19.9,77.6 19.9,77.8 20.3,78.3 21,78.8 22.3,80 23,80.6 23.1,80.7 24.1,81.5 24.7,82 24.8,82.2 26,83.7 26.9,85.3 27.6,87.1 30,92.4 34,95 39.6,95 40.5,95 42.3,94.8 45,94.4L45,107.6C38.2,105.5 32.1,102 26.8,97.3 21.5,92.6 17.3,87 14.4,80.5 11.5,74 10,67.2 10,60L10,60z"));

            return new(drawing);
        }
    }

    /// <summary>
    /// Geometry image for Twitter
    /// </summary>
    public static DrawingImage Twitter
    {
        get
        {
            GeometryDrawing drawing = new(
                new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)), null,
                Geometry.Parse("F0 M120,98z M0,0z M120,24.9C115.6,26.9 110.8,28.2 105.9,28.8 111,25.8 114.9,20.9 116.7,15.2 111.9,18 106.7,20.1 101.1,21.2 96.6,16.4 90.2,13.4 83.1,13.4 69.5,13.4 58.5,24.4 58.5,38 58.5,39.9 58.7,41.8 59.1,43.6 38.6,42.6 20.5,32.8 8.40000000000001,17.9 6.2,21.5 5,25.7 5,30.2 5,38.7 9.3,46.3 16,50.7 12,50.6 8.2,49.5 4.8,47.6 4.8,47.7 4.8,47.8 4.8,47.9 4.8,59.8 13.3,69.8 24.5,72 22.4,72.6 20.3,72.9 18,72.9 16.4,72.9 14.9,72.7 13.4,72.5 16.5,82.3 25.6,89.4 36.4,89.6 28,96.2 17.4,100.1 5.8,100.1 3.8,100.1 1.9,100 -0.100000000000003,99.8 10.8,106.8 23.7,110.9 37.6,110.9 82.9,110.9 107.6,73.4 107.6,40.9 107.6,39.8 107.6,38.8 107.5,37.7 112.5,34.2 116.7,29.8 120,24.9"));

            return new(drawing);
        }
    }

    /// <summary>
    /// Geometry image for Microsoft
    /// </summary>
    public static DrawingImage Microsoft
    {
        get
        {
            DrawingGroup drawing = new();
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 242, 80, 34)), null,
                new RectangleGeometry(new(0, 0, 9, 9))
            ));
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 0, 164, 239)), null,
                new RectangleGeometry(new(0, 10, 9, 9))
            ));
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 126, 185, 0)), null,
                new RectangleGeometry(new(10, 0, 9, 9))
            ));
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 254, 184, 0)), null,
                new RectangleGeometry(new(10, 10, 9, 9))
            ));

            return new(drawing);
        }
    }

    /// <summary>
    /// Geometry image for Yahoo
    /// </summary>
    public static DrawingImage Yahoo
    {
        get
        {
            DrawingGroup drawing = new();
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)), null,
                Geometry.Parse("F1 M512,512z M0,0z M495.9,33.9L495.9,33.9 392.1,33.9 298.9,256.4 402.7,256.4z")
            ));
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)), null,
                Geometry.Parse("F1 M512,512z M0,0z M175.6,478.9L175.6,478.9 315.5,142.1 222.3,142.1 166.6,285 111,142.1 16.3,142.1 120,390.2 82.4,478.9z")
            ));
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)), null,
                new EllipseGeometry() { RadiusX = 57.1, RadiusY = 57.1, Center = new(326, 334.6)}
            ));

            return new(drawing);
        }
    }

    /// <summary>
    /// Geometry image for Anonymously
    /// </summary>
    public static DrawingImage Anonymously
    {
        get
        {
            DrawingGroup drawing = new();
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)), null,
                Geometry.Parse("F1 M64.1,62.6z M0,0z M32,32.1C40.9,32.1 48.1,24.9 48.1,16 48.1,7.2 40.9,0 32,0 23.1,0 16,7.2 16,16.1 16,24.9 23.2,32.1 32,32.1z M32,6.7C37.2,6.7 41.3,10.9 41.3,16 41.3,21.2 37.1,25.3 32,25.3 26.9,25.3 22.7,21.1 22.7,16 22.7,10.9 26.9,6.7 32,6.7z")
            ));
            drawing.Children.Add(new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)), null,
                Geometry.Parse("F1 M64.1,62.6z M0,0z M32,35.6C14.3,35.6,0,42.8,0,51.7L0,62.6 64.1,62.6 64.1,51.7C64.1,42.8,49.7,35.6,32,35.6z M57.8,53L57.8,55.3C57.8,56.3,56.9,57.1,55.8,57.1L8.3,57.1C7.2,57.1,6.3,56.3,6.3,55.3L6.3,53C6.3,52.9 6.3,52.8 6.3,52.7 6.3,52.6 6.3,52.4 6.3,52.3 6.3,46.5 17.8,41.8 32.1,41.8 46.3,41.8 57.9,46.5 57.9,52.3 57.9,52.4 57.9,52.6 57.9,52.7 57.8,52.9 57.8,53 57.8,53z")
            ));

            return new(drawing);
        }
    }

}