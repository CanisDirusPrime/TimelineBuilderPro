using System.Drawing;
using System.Windows.Forms;

public abstract class BaseShape
{
    public Panel ShapePanel { get; private set; }
    public string EventName { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    protected BaseShape(Point location, bool snapToGrid)
    {
        ShapePanel = new Panel
        {
            Location = snapToGrid ? SnapToGrid(location) : location,
            Size = new Size(100, 100),
            BackColor = Color.LightGray,
            BorderStyle = BorderStyle.FixedSingle
        };

        ShapePanel.MouseClick += (s, e) => ShowDetailsPopup();
    }

    private Point SnapToGrid(Point location)
    {
        int gridSize = 20;
        return new Point((location.X / gridSize) * gridSize, (location.Y / gridSize) * gridSize);
    }

    private void ShowDetailsPopup()
    {
        var detailsForm = new Form
        {
            Text = "Event Details",
            Size = new Size(300, 400)
        };

        var detailsText = new Label
        {
            Dock = DockStyle.Fill,
            Text = $"Name: {EventName}\nDescription: {Description}\nDate: {StartDate.ToShortDateString()}"
        };
        detailsForm.Controls.Add(detailsText);
        detailsForm.ShowDialog();
    }

    public abstract Control GetControl();
}
