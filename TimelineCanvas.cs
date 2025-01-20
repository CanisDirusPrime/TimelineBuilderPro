// TimelineCanvas.cs

using System;
using System.Drawing;
using System.Windows.Forms;

public class TimelineCanvas : Panel
{
    private readonly TimelineSettings _settings;

    public TimelineCanvas(TimelineSettings settings)
    {
        _settings = settings;
        BackColor = Color.White;

        Paint += (sender, e) =>
        {
            DrawTimeline(e.Graphics);
        };
    }

    private void DrawTimeline(Graphics graphics)
    {
        var yearRange = _settings.YearRange.Split('-');
        int startYear = int.Parse(yearRange[0]);
        int endYear = int.Parse(yearRange[1]);
        int totalYears = endYear - startYear + 1;

        int spacing = Width / totalYears;
        int y = Height / 2;

        for (int i = 0; i < totalYears; i++)
        {
            int x = i * spacing;
            graphics.DrawLine(Pens.Black, x, y - 10, x, y + 10);
            graphics.DrawString((startYear + i).ToString(), DefaultFont, Brushes.Black, x - 10, y + 15);
        }
    }
}

