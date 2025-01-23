using System;
using System.Drawing;
using System.Windows.Forms;

public class EllipseShape : BaseShape
{
    public EllipseShape(Point location, bool snapToGrid) : base(location, snapToGrid) { }

    public override Control GetControl()
    {
        // Custom drawing logic for EllipseShape
        ShapePanel.Paint += (s, e) =>
        {
            e.Graphics.DrawEllipse(Pens.Black, 0, 0, ShapePanel.Width, ShapePanel.Height / 2);
        };
        return ShapePanel;
    }
}

