using System;
using System.Drawing;
using System.Windows.Forms;

public class SquareShape : BaseShape
{
    public SquareShape(Point location, bool snapToGrid) : base(location, snapToGrid) { }

    public override Control GetControl()
    {
        // Custom drawing logic for SquareShape
        ShapePanel.Paint += (s, e) =>
        {
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, ShapePanel.Width, ShapePanel.Width);
        };
        return ShapePanel;
    }
}

