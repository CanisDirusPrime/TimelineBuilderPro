// NewTimelineDialog.cs

using System;
using System.Windows.Forms;

public class NewTimelineDialog : Form
{
    public TimelineSettings TimelineSettings { get; private set; }

    public NewTimelineDialog()
    {
        Text = "New Timeline";
        Width = 400;
        Height = 300;

        // Title input
        var titleLabel = new Label { Text = "Title:", Top = 20, Left = 20, Width = 100 };
        var titleTextBox = new TextBox { Top = 20, Left = 120, Width = 200 };

        // Year range input
        var yearLabel = new Label { Text = "Years (e.g., 2000-2020):", Top = 60, Left = 20, Width = 150 };
        var yearTextBox = new TextBox { Top = 60, Left = 170, Width = 150 };

        // Orientation selection
        var orientationLabel = new Label { Text = "Orientation:", Top = 100, Left = 20, Width = 100 };
        var orientationComboBox = new ComboBox
        {
            Top = 100,
            Left = 120,
            Width = 200,
            Items = { "Horizontal", "Vertical" },
            SelectedIndex = 0
        };

        // Linked timeline input
        var linkLabel = new Label { Text = "Linked Timeline:", Top = 140, Left = 20, Width = 100 };
        var linkTextBox = new TextBox { Top = 140, Left = 120, Width = 200 };

        // OK button
        var okButton = new Button { Text = "OK", Top = 200, Left = 120, Width = 80 };
        okButton.Click += (sender, e) =>
        {
            TimelineSettings = new TimelineSettings
            {
                Title = titleTextBox.Text,
                YearRange = yearTextBox.Text,
                Orientation = orientationComboBox.Text,
                LinkedTimeline = linkTextBox.Text
            };
            DialogResult = DialogResult.OK;
            Close();
        };

        // Cancel button
        var cancelButton = new Button { Text = "Cancel", Top = 200, Left = 220, Width = 80 };
        cancelButton.Click += (sender, e) => Close();

        Controls.AddRange(new Control[] {
            titleLabel, titleTextBox, yearLabel, yearTextBox,
            orientationLabel, orientationComboBox, linkLabel, linkTextBox,
            okButton, cancelButton
        });
    }
}

public class TimelineSettings
{
    public string Title { get; set; }
    public string YearRange { get; set; }
    public string Orientation { get; set; }
    public string LinkedTimeline { get; set; }
}

