using System;
using System.Drawing;
using System.Windows.Forms;

public class TimelineEditor : UserControl
{
    private Button addArrowButton;
    private Button addCircleButton;
    private Button addEllipseButton;
    private Button addRectangleButton;
    private Button addSquareButton;
    private Button toggleOrientationButton;
    private TimelineCanvasForm canvas;

    public TimelineEditor(TimelineCanvasForm canvas)
    {
        this.canvas = canvas;
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        addArrowButton = new Button { Text = "Add Arrow", Top = 10, Left = 10, Width = 100 };
        addArrowButton.Click += (s, e) => canvas.AddShape(new ArrowShape(new Point(50, 50), true));

        addCircleButton = new Button { Text = "Add Circle", Top = 40, Left = 10, Width = 100 };
        addCircleButton.Click += (s, e) => canvas.AddShape(new CircleShape(new Point(50, 50), true));

        addEllipseButton = new Button { Text = "Add Ellipse", Top = 70, Left = 10, Width = 100 };
        addEllipseButton.Click += (s, e) => canvas.AddShape(new EllipseShape(new Point(50, 50), true));

        addRectangleButton = new Button { Text = "Add Rectangle", Top = 100, Left = 10, Width = 100 };
        addRectangleButton.Click += (s, e) => canvas.AddShape(new RectangleShape(new Point(50, 50), true));

        addSquareButton = new Button { Text = "Add Square", Top = 130, Left = 10, Width = 100 };
        addSquareButton.Click += (s, e) => canvas.AddShape(new SquareShape(new Point(50, 50), true));

        toggleOrientationButton = new Button { Text = "Toggle Orientation", Top = 160, Left = 10, Width = 100 };
        toggleOrientationButton.Click += (s, e) => canvas.ToggleOrientation();

        this.Controls.Add(addArrowButton);
        this.Controls.Add(addCircleButton);
        this.Controls.Add(addEllipseButton);
        this.Controls.Add(addRectangleButton);
        this.Controls.Add(addSquareButton);
        this.Controls.Add(toggleOrientationButton);
    }
}



