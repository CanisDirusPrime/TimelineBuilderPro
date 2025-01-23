using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class TimelineCanvasForm : UserControl
{
    private List<BaseShape> shapes = new List<BaseShape>();
    private float zoomFactor = 1.0f;
    private bool isHorizontal = true;

    public TimelineCanvasForm()
    {
        this.DoubleBuffered = true;
        this.AutoScroll = true;
        this.MouseWheel += TimelineCanvas_MouseWheel;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.ScaleTransform(zoomFactor, zoomFactor);
        foreach (var shape in shapes)
        {
            // Use the shape's control for rendering
            var control = shape.GetControl();
            if (!this.Controls.Contains(control))
            {
                this.Controls.Add(control);
            }
        }
    }

    private void TimelineCanvas_MouseWheel(object sender, MouseEventArgs e)
    {
        if (e.Delta > 0)
        {
            zoomFactor *= 1.1f;
        }
        else
        {
            zoomFactor /= 1.1f;
        }
        this.Invalidate();
    }

    public void AddShape(BaseShape shape)
    {
        shapes.Add(shape);
        this.Invalidate();
    }

    public void ToggleOrientation()
    {
        isHorizontal = !isHorizontal;
        // Adjust layout based on orientation
        this.Invalidate();
    }

    // Other methods for shape manipulation, saving, exporting, etc.
}



