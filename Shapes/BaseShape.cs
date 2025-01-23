using System;
using System.Drawing;
using System.Windows.Forms;

public abstract class BaseShape
{
    public Panel ShapePanel { get; set; }
    public string EventName { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    private bool isDragging = false;
    private Point dragStartPoint;
    private bool isResizing = false;
    private Point resizeStartPoint;

    protected BaseShape(Point location, bool snapToGrid)
    {
        ShapePanel = new Panel
        {
            Location = snapToGrid ? SnapToGrid(location) : location,
            Size = new Size(100, 100), // Default size, can be overridden by derived classes
            BackColor = Color.Transparent,
            BorderStyle = BorderStyle.FixedSingle
        };
        ShapePanel.MouseDown += ShapePanel_MouseDown;
        ShapePanel.MouseMove += ShapePanel_MouseMove;
        ShapePanel.MouseUp += ShapePanel_MouseUp;
        ShapePanel.Paint += ShapePanel_Paint;
    }

    private Point SnapToGrid(Point location)
    {
        int gridSize = 10; // Example grid size
        int x = (location.X / gridSize) * gridSize;
        int y = (location.Y / gridSize) * gridSize;
        return new Point(x, y);
    }

    private void ShowDetailsPopup()
    {
        // Show a popup with details about the shape
        MessageBox.Show($"Event: {EventName}\nDescription: {Description}\nStart Date: {StartDate}\nEnd Date: {EndDate}");
    }

    private void ShapePanel_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            if (e.Location.X >= ShapePanel.Width - 10 && e.Location.Y >= ShapePanel.Height - 10)
            {
                isResizing = true;
                resizeStartPoint = e.Location;
            }
            else
            {
                isDragging = true;
                dragStartPoint = e.Location;
            }
        }
    }

    private void ShapePanel_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            ShapePanel.Left += e.X - dragStartPoint.X;
            ShapePanel.Top += e.Y - dragStartPoint.Y;
        }
        else if (isResizing)
        {
            ShapePanel.Width += e.X - resizeStartPoint.X;
            ShapePanel.Height += e.Y - resizeStartPoint.Y;
            resizeStartPoint = e.Location;
        }
    }

    private void ShapePanel_MouseUp(object sender, MouseEventArgs e)
    {
        isDragging = false;
        isResizing = false;
    }

    private void ShapePanel_Paint(object sender, PaintEventArgs e)
    {
        // Draw resize handle
        e.Graphics.FillRectangle(Brushes.Black, ShapePanel.Width - 10, ShapePanel.Height - 10, 10, 10);
    }

    public abstract Control GetControl();
}


