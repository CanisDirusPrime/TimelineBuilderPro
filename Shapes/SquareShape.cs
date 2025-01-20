using System.Drawing;
using System.Windows.Forms;

public class SquareShape : BaseShape
{
    public SquareShape(Point location, bool snapToGrid) : base(location, snapToGrid)
    {
        ShapePanel.Paint += (s, e) =>
        {
            var g = e.Graphics;
            g.FillRectangle(Brushes.LightGreen, 0, 0, ShapePanel.Width, ShapePanel.Width);
        };
    }

    public override Control GetControl() => ShapePanel;
}
