using System;
using System.Drawing;
using System.Windows.Forms;

public class TimelineEditor : Form
{
    private Panel timelinePanel;
    private ComboBox shapeSelector;
    private CheckBox snapToGridCheckbox;
    private Button toggleOrientationButton;
    private TrackBar zoomSlider;
    private bool isHorizontal = true;

    public TimelineEditor()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        this.Text = "Timeline Editor";
        this.Size = new Size(1200, 800);

        timelinePanel = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            AutoScroll = true
        };

        shapeSelector = new ComboBox
        {
            Dock = DockStyle.Top,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        shapeSelector.Items.AddRange(new string[] { "Circle", "Square", "Rectangle", "Ellipse", "Arrow" });
        shapeSelector.SelectedIndex = 0;

        snapToGridCheckbox = new CheckBox
        {
            Text = "Snap to Grid",
            Dock = DockStyle.Top,
            Checked = true
        };

        toggleOrientationButton = new Button
        {
            Text = "Toggle Orientation",
            Dock = DockStyle.Top
        };
        toggleOrientationButton.Click += ToggleOrientation;

        zoomSlider = new TrackBar
        {
            Dock = DockStyle.Top,
            Minimum = 1,
            Maximum = 5,
            Value = 2
        };
        zoomSlider.Scroll += (s, e) => UpdateZoom();

        var controlsPanel = new Panel
        {
            Dock = DockStyle.Top,
            Height = 100
        };
        controlsPanel.Controls.Add(shapeSelector);
        controlsPanel.Controls.Add(snapToGridCheckbox);
        controlsPanel.Controls.Add(toggleOrientationButton);
        controlsPanel.Controls.Add(zoomSlider);

        this.Controls.Add(timelinePanel);
        this.Controls.Add(controlsPanel);

        timelinePanel.MouseClick += TimelinePanel_MouseClick;
    }

    private void ToggleOrientation(object sender, EventArgs e)
    {
        isHorizontal = !isHorizontal;
        MessageBox.Show($"Orientation set to {(isHorizontal ? "Horizontal" : "Vertical")}");
    }

    private void UpdateZoom()
    {
        float zoomFactor = zoomSlider.Value * 0.5f;
        timelinePanel.Scale(new SizeF(zoomFactor, zoomFactor));
    }

    private void TimelinePanel_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var selectedShape = shapeSelector.SelectedItem.ToString();
            AddShape(selectedShape, e.Location);
        }
    }

    private void AddShape(string shapeType, Point location)
    {
        BaseShape shape;
        switch (shapeType)
        {
            case "Circle":
                shape = new CircleShape(location, snapToGridCheckbox.Checked);
                break;
            case "Square":
                shape = new SquareShape(location, snapToGridCheckbox.Checked);
                break;
            case "Rectangle":
                shape = new RectangleShape(location, snapToGridCheckbox.Checked);
                break;
            case "Ellipse":
                shape = new EllipseShape(location, snapToGridCheckbox.Checked);
                break;
            case "Arrow":
                shape = new ArrowShape(location, snapToGridCheckbox.Checked);
                break;
            default:
                throw new NotImplementedException();
        }

        timelinePanel.Controls.Add(shape.GetControl());
    }
}
