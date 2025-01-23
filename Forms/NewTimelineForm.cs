using System;
using System.Windows.Forms;

public class NewTimelineForm : Form
{
    private TextBox titleTextBox;
    private TextBox yearRangeTextBox;
    private ComboBox orientationComboBox;
    private Button okButton;
    private Button cancelButton;

    public TimelineSettings TimelineSettings { get; private set; }

    public NewTimelineForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        this.Text = "New Timeline";
        this.Size = new System.Drawing.Size(300, 200);

        var titleLabel = new Label { Text = "Title:", Top = 20, Left = 10, Width = 80 };
        titleTextBox = new TextBox { Top = 20, Left = 100, Width = 150 };

        var yearRangeLabel = new Label { Text = "Year Range:", Top = 50, Left = 10, Width = 80 };
        yearRangeTextBox = new TextBox { Top = 50, Left = 100, Width = 150 };

        var orientationLabel = new Label { Text = "Orientation:", Top = 80, Left = 10, Width = 80 };
        orientationComboBox = new ComboBox { Top = 80, Left = 100, Width = 150 };
        orientationComboBox.Items.AddRange(new string[] { "Horizontal", "Vertical" });

        okButton = new Button { Text = "OK", Top = 120, Left = 50, Width = 80 };
        okButton.Click += OkButton_Click;

        cancelButton = new Button { Text = "Cancel", Top = 120, Left = 150, Width = 80 };
        cancelButton.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

        this.Controls.Add(titleLabel);
        this.Controls.Add(titleTextBox);
        this.Controls.Add(yearRangeLabel);
        this.Controls.Add(yearRangeTextBox);
        this.Controls.Add(orientationLabel);
        this.Controls.Add(orientationComboBox);
        this.Controls.Add(okButton);
        this.Controls.Add(cancelButton);
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
        TimelineSettings = new TimelineSettings
        {
            Title = titleTextBox.Text,
            YearRange = yearRangeTextBox.Text,
            Orientation = orientationComboBox.SelectedItem.ToString()
        };
        this.DialogResult = DialogResult.OK;
    }
}
