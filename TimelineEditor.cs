using System;
using System.Drawing;
using System.Windows.Forms;

public class TimelineEditor : Form
{
	private Panel timelinePanel = new Panel(); // Inline initialization to resolve CS8618
	private ComboBox shapeSelector = new ComboBox(); // Inline initialization
	private CheckBox snapToGridCheckbox = new CheckBox(); // Inline initialization
	private Button toggleOrientationButton = new Button(); // Inline initialization
	private TrackBar zoomSlider = new TrackBar(); // Inline initialization
	private bool isHorizontal = true;

	public TimelineEditor()
	{
		InitializeComponents();
	}

	private void InitializeComponents()
	{
		this.Text = "Timeline Editor";
		this.Size = new Size(1200, 800);

		timelinePanel.Dock = DockStyle.Fill;
		timelinePanel.BackColor = Color.White;
		timelinePanel.AutoScroll = true;

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
		zoomSlider.Scroll += ZoomSlider_Scroll;

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

	private void ToggleOrientation(object? sender, EventArgs e)
	{
		isHorizontal = !isHorizontal;
		timelinePanel.SuspendLayout();
		timelinePanel.Controls.Clear(); // Reorganize controls for the new orientation
		timelinePanel.ResumeLayout();

		MessageBox.Show($"Orientation set to {(isHorizontal ? "Horizontal" : "Vertical")}");
	}

	private void ZoomSlider_Scroll(object? sender, EventArgs e)
	{
		UpdateZoom();
	}

	private void UpdateZoom()
	{
		float zoomFactor = zoomSlider.Value * 0.5f;
		timelinePanel.SuspendLayout();
		timelinePanel.Scale(new SizeF(zoomFactor, zoomFactor));
		timelinePanel.ResumeLayout();
	}

	private void TimelinePanel_MouseClick(object? sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right && shapeSelector.SelectedItem != null)
		{
			var selectedShape = shapeSelector.SelectedItem.ToString();
			AddShape(selectedShape!, e.Location);
		}
	}

	private void AddShape(string shapeType, Point location)
	{
		BaseShape shape = shapeType switch
		{
			"Circle" => new CircleShape(location, snapToGridCheckbox.Checked),
			"Square" => new SquareShape(location, snapToGridCheckbox.Checked),
			"Rectangle" => new RectangleShape(location, snapToGridCheckbox.Checked),
			"Ellipse" => new EllipseShape(location, snapToGridCheckbox.Checked),
			"Arrow" => new ArrowShape(location, snapToGridCheckbox.Checked),
			_ => throw new NotImplementedException()
		};

		timelinePanel.Controls.Add(shape.GetControl());
	}
}
