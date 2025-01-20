using System.Drawing;
using System.Windows.Forms;

public class EllipseShape : BaseShape
{
    public EllipseShape(Point location, bool snapToGrid) : base(location, snapToGrid)
    {
        ShapePanel.Paint += (s, e) =>
        {
            var g = e.Graphics;
            g.FillEllipse(Brushes.LightPink, 0, 0, ShapePanel.Width, ShapePanel.Height);
        };
    }

    public override Control GetControl() => ShapePanel;
}
