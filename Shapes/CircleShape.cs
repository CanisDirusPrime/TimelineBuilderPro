using System;
using System.Drawing;
using System.Windows.Forms;

public class CircleShape : BaseShape
{
    public CircleShape(Point location, bool snapToGrid) : base(location, snapToGrid) { }

    public override Control GetControl()
    {
        // Custom drawing logic for CircleShape
        ShapePanel.Paint += (s, e) =>
        {
            e.Graphics.DrawEllipse(Pens.Black, 0, 0, ShapePanel.Width, ShapePanel.Height);
        };
        return ShapePanel;
    }
}

