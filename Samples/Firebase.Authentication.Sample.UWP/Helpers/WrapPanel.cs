using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.Diagnostics;
using Windows.Foundation;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Firebase.Authentication.Sample.UWP.Helpers;


// LICENSE:
// Windows Community Toolkit
// Copyright © .NET Foundation and Contributors
// MIT License (MIT)
//
// https://github.com/CommunityToolkit/Windows/blob/main/License.md
// https://github.com/CommunityToolkit/Windows/blob/main/components/Primitives/src/WrapPanel/WrapPanel.cs


/// <summary>
/// WrapPanel is a panel that position child control vertically or horizontally based on the orientation and when max width / max height is reached a new row (in case of horizontal) or column (in case of vertical) is created to fit new controls.
/// </summary>
public partial class WrapPanel : Panel
{
    /// <summary>
    /// Gets or sets a uniform Horizontal distance (in pixels) between items when <see cref="Orientation"/> is set to Horizontal,
    /// or between columns of items when <see cref="Orientation"/> is set to Vertical.
    /// </summary>
    public double HorizontalSpacing
    {
        get => (double)GetValue(HorizontalSpacingProperty);
        set => SetValue(HorizontalSpacingProperty, value);
    }

    /// <summary>
    /// Identifies the <see cref="HorizontalSpacing"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty HorizontalSpacingProperty =
        DependencyProperty.Register(nameof(HorizontalSpacing), typeof(double), typeof(WrapPanel), new PropertyMetadata(0d, LayoutPropertyChanged));

    /// <summary>
    /// Gets or sets a uniform Vertical distance (in pixels) between items when <see cref="Orientation"/> is set to Vertical,
    /// or between rows of items when <see cref="Orientation"/> is set to Horizontal.
    /// </summary>
    public double VerticalSpacing
    {
        get => (double)GetValue(VerticalSpacingProperty);
        set => SetValue(VerticalSpacingProperty, value);
    }

    /// <summary>
    /// Identifies the <see cref="VerticalSpacing"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty VerticalSpacingProperty =
        DependencyProperty.Register(nameof(VerticalSpacing), typeof(double), typeof(WrapPanel), new PropertyMetadata(0d, LayoutPropertyChanged));

    /// <summary>
    /// Gets or sets the orientation of the WrapPanel.
    /// Horizontal means that child controls will be added horizontally until the width of the panel is reached, then a new row is added to add new child controls.
    /// Vertical means that children will be added vertically until the height of the panel is reached, then a new column is added.
    /// </summary>
    public Orientation Orientation
    {
        get => (Orientation)GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }

    /// <summary>
    /// Identifies the <see cref="Orientation"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty OrientationProperty =
        DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(WrapPanel), new PropertyMetadata(Orientation.Horizontal, LayoutPropertyChanged));

    /// <summary>
    /// Gets or sets the distance between the border and its child object.
    /// </summary>
    /// <returns>
    /// The dimensions of the space between the border and its child as a Thickness value.
    /// Thickness is a structure that stores dimension values using pixel measures.
    /// </returns>
    public Thickness Padding
    {
        get => (Thickness)GetValue(PaddingProperty);
        set => SetValue(PaddingProperty, value);
    }

    /// <summary>
    /// Identifies the Padding dependency property.
    /// </summary>
    /// <returns>The identifier for the <see cref="Padding"/> dependency property.</returns>
    public static readonly DependencyProperty PaddingProperty =
        DependencyProperty.Register(nameof(Padding), typeof(Thickness), typeof(WrapPanel), new PropertyMetadata(default(Thickness), LayoutPropertyChanged));

    private static void LayoutPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is WrapPanel wp)
        {
            wp.InvalidateMeasure();
            wp.InvalidateArrange();
        }
    }

    private readonly List<Row> _rows = new List<Row>();

    protected override Size MeasureOverride(
        Size availableSize)
    {
        var childAvailableSize = new Size(
            availableSize.Width - Padding.Left - Padding.Right,
            availableSize.Height - Padding.Top - Padding.Bottom);
        foreach (var child in Children)
            child.Measure(childAvailableSize);

        var requiredSize = UpdateRows(availableSize);
        return requiredSize;
    }

    protected override Size ArrangeOverride(
        Size finalSize)
    {
        if ((Orientation == Orientation.Horizontal && finalSize.Width < DesiredSize.Width) || (Orientation == Orientation.Vertical && finalSize.Height < DesiredSize.Height))
            UpdateRows(finalSize);

        if (_rows.Count > 0)
        {
            var childIndex = 0;
            foreach (var row in _rows)
            {
                foreach (var rect in row.ChildrenRects)
                {
                    var child = Children[childIndex++];
                    while (child.Visibility == Visibility.Collapsed)
                        child = Children[childIndex++];

                    var arrangeRect = new UvRect
                    {
                        Position = rect.Position,
                        Size = new UvMeasure { U = rect.Size.U, V = row.Size.V },
                    };

                    var finalRect = arrangeRect.ToRect(Orientation);
                    child.Arrange(finalRect);
                }
            }
        }

        return finalSize;
    }

    private Size UpdateRows(
        Size availableSize)
    {
        _rows.Clear();

        var paddingStart = new UvMeasure(Orientation, Padding.Left, Padding.Top);
        var paddingEnd = new UvMeasure(Orientation, Padding.Right, Padding.Bottom);

        if (Children.Count == 0)
        {
            var emptySize = paddingStart.Add(paddingEnd).ToSize(Orientation);
            return emptySize;
        }

        var parentMeasure = new UvMeasure(Orientation, availableSize.Width, availableSize.Height);
        var spacingMeasure = new UvMeasure(Orientation, HorizontalSpacing, VerticalSpacing);
        var position = new UvMeasure(Orientation, Padding.Left, Padding.Top);

        var currentRow = new Row(new List<UvRect>(), default);
        var finalMeasure = new UvMeasure(Orientation, width: 0.0, height: 0.0);
        void Arrange(UIElement child, bool isLast = false)
        {
            if (child.Visibility == Visibility.Collapsed)
                return;

            var desiredMeasure = new UvMeasure(Orientation, child.DesiredSize);
            if ((desiredMeasure.U + position.U + paddingEnd.U) > parentMeasure.U)
            {
                position.U = paddingStart.U;
                position.V += currentRow.Size.V + spacingMeasure.V;

                _rows.Add(currentRow);
                currentRow = new Row(new List<UvRect>(), default);
            }

            if (isLast)
                desiredMeasure.U = parentMeasure.U - position.U;

            currentRow.Add(position, desiredMeasure);

            position.U += desiredMeasure.U + spacingMeasure.U;
            finalMeasure.U = Math.Max(finalMeasure.U, position.U);
        }

        var lastIndex = Children.Count - 1;
        for (var i = 0; i < lastIndex; i++)
            Arrange(Children[i]);

        Arrange(Children[lastIndex], false);
        if (currentRow.ChildrenRects.Count > 0)
            _rows.Add(currentRow);

        if (_rows.Count == 0)
        {
            var emptySize = paddingStart.Add(paddingEnd).ToSize(Orientation);
            return emptySize;
        }

        var lastRowRect = _rows.Last().Rect;
        finalMeasure.V = lastRowRect.Position.V + lastRowRect.Size.V;
        var finalRect = finalMeasure.Add(paddingEnd).ToSize(Orientation);
        return finalRect;
    }


    [DebuggerDisplay("U = {U} V = {V}")]
    private struct UvMeasure
    {
        internal static UvMeasure Zero => default;

        internal double U { get; set; }

        internal double V { get; set; }

        public UvMeasure(Orientation orientation, Size size) 
            : this(orientation, size.Width, size.Height) { }

        public UvMeasure(
            Orientation orientation,
            double width,
            double height)
        {
            if (orientation == Orientation.Horizontal)
            {
                U = width;
                V = height;
            }
            else
            {
                U = height;
                V = width;
            }
        }

        public UvMeasure Add(double u, double v) =>
            new UvMeasure { U = U + u, V = V + v };

        public UvMeasure Add(UvMeasure measure) =>
            Add(measure.U, measure.V);

        public Size ToSize(Orientation orientation) =>
            orientation == Orientation.Horizontal ? new Size(U, V) : new Size(V, U);
    }

    private struct UvRect
    {
        public UvMeasure Position { get; set; }

        public UvMeasure Size { get; set; }

        public Rect ToRect(
            Orientation orientation) =>
            orientation switch
        {
            Orientation.Vertical => new Rect(Position.V, Position.U, Size.V, Size.U),
            Orientation.Horizontal => new Rect(Position.U, Position.V, Size.U, Size.V),
            _ => ThrowArgumentException()
        };

        private static Rect ThrowArgumentException() =>
            throw new ArgumentException("The input orientation is not valid.");
    }

    private struct Row
    {
        public Row(
            List<UvRect> childrenRects,
            UvMeasure size)
        {
            ChildrenRects = childrenRects;
            Size = size;
        }

        public List<UvRect> ChildrenRects { get; }

        public UvMeasure Size { get; set; }

        public UvRect Rect => ChildrenRects.Count > 0 ? new UvRect { Position = ChildrenRects[0].Position, Size = Size } : new UvRect { Position = UvMeasure.Zero, Size = Size };

        public void Add(
            UvMeasure position,
            UvMeasure size)
        {
            ChildrenRects.Add(new UvRect { Position = position, Size = size });
            Size = new UvMeasure
            {
                U = position.U + size.U,
                V = Math.Max(Size.V, size.V),
            };
        }
    }
}