using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class ArrowShape : BaseShape
{
    public ArrowShape(Point location, bool snapToGrid) : base(location, snapToGrid)
    {
        ShapePanel.Paint += (s, e) =>
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Define the arrow points
            Point[] arrowPoints = {
                new Point(ShapePanel.Width / 2, 0),
                new Point(ShapePanel.Width, ShapePanel.Height / 2),
                new Point(ShapePanel.Width / 2 + 10, ShapePanel.Height / 2),
                new Point(ShapePanel.Width / 2 + 10, ShapePanel.Height),
                new Point(ShapePanel.Width / 2 - 10, ShapePanel.Height),
                new Point(ShapePanel.Width / 2 - 10, ShapePanel.Height / 2),
                new Point(0, ShapePanel.Height / 2)
            };

            g.FillPolygon(Brushes.DarkOrange, arrowPoints);
        };
    }

    public override Control GetControl() => ShapePanel;
}

