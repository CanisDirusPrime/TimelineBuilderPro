using System.Drawing;
using System.Windows.Forms;

public class CircleShape : BaseShape
{
    public CircleShape(Point location, bool snapToGrid) : base(location, snapToGrid)
    {
        ShapePanel.Paint += (s, e) =>
        {
            var g = e.Graphics;
            g.FillEllipse(Brushes.LightBlue, 0, 0, ShapePanel.Width, ShapePanel.Height);
        };
    }

    public override Control GetControl() => ShapePanel;
}
