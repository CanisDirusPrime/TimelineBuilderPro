public class TimelineEditorDesigner : Panel
{
    public TimelineEditorDesigner(TimelineSettings settings)
    {
        Width = 200;
        BackColor = SystemColors.Control;

        var titleLabel = new Label { Text = $"Title: {settings.Title}", Top = 20, Left = 10, Width = 180 };
        var yearsLabel = new Label { Text = $"Years: {settings.YearRange}", Top = 50, Left = 10, Width = 180 };
        var orientationLabel = new Label { Text = $"Orientation: {settings.Orientation}", Top = 80, Left = 10, Width = 180 };

        Controls.AddRange(new Control[] { titleLabel, yearsLabel, orientationLabel });
    }
}
