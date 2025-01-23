using System;
using System.Drawing;
using System.Windows.Forms;

public class RectangleShape : BaseShape
{
    public RectangleShape(Point location, bool snapToGrid) : base(location, snapToGrid) { }

    public override Control GetControl()
    {
        // Custom drawing logic for RectangleShape
        ShapePanel.Paint += (s, e) =>
        {
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, ShapePanel.Width, ShapePanel.Height);
        };
        return ShapePanel;
    }
}

