using System;
using System.Drawing;
using System.Windows.Forms;

public class ArrowShape : BaseShape
{
    public ArrowShape(Point location, bool snapToGrid) : base(location, snapToGrid) { }

    public override Control GetControl()
    {
        // Custom drawing logic for ArrowShape
        ShapePanel.Paint += (s, e) =>
        {
            e.Graphics.DrawLine(Pens.Black, 0, 0, ShapePanel.Width, ShapePanel.Height);
            e.Graphics.DrawLine(Pens.Black, ShapePanel.Width, 0, 0, ShapePanel.Height);
        };
        return ShapePanel;
    }
}

