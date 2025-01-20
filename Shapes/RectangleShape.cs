using System.Drawing;
using System.Windows.Forms;

public class RectangleShape : BaseShape
{
    public RectangleShape(Point location, bool snapToGrid) : base(location, snapToGrid)
    {
        ShapePanel.Paint += (s, e) =>
        {
            var g = e.Graphics;
            g.FillRectangle(Brushes.LightCoral, 0, 0, ShapePanel.Width, ShapePanel.Height);
        };
    }

    public override Control GetControl() => ShapePanel;
}
