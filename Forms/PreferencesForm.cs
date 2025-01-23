using System;
using System.Windows.Forms;

namespace TimelineBuilderPro
{
    public class PreferencesForm : Form
    {
        private TableLayoutPanel tableLayoutPanel;
        private Label themeLabel;
        private Label themeLightLabel;
        private Label themeDarkLabel;
        private CheckBox themeToggle;
        private Label fontSizeLabel;
        private NumericUpDown fontSizeNumericUpDown;
        private Label dateFormatLabel;
        private ComboBox dateFormatComboBox;
        private TextBox customDateFormatTextBox;
        private Label timelineOrientationLabel;
        private Label orientationHorizontalLabel;
        private Label orientationVerticalLabel;
        private CheckBox orientationToggle;
        private Label languageLabel;
        private ComboBox languageComboBox;
        private Label notificationsLabel;
        private CheckBox notificationsCheckBox;
        private Label autoSaveIntervalLabel;
        private ComboBox autoSaveIntervalComboBox;
        private Label defaultFilePathLabel;
        private TextBox defaultFilePathTextBox;
        private Button browseButton;
        private FlowLayoutPanel buttonPanel;
        private Button saveButton;
        private Button cancelButton;

        // New link color buttons
        private Button linkNewColorButton;
        private Button linkUsedColorButton;
        private Button linkVisitedColorButton;

        public PreferencesForm()
        {
            InitializeComponent();
            LoadPreferences();
        }

        private void InitializeComponent()
        {
            tableLayoutPanel = new TableLayoutPanel();
            themeLabel = new Label();
            themeLightLabel = new Label();
            themeDarkLabel = new Label();
            themeToggle = new CheckBox();
            fontSizeLabel = new Label();
            fontSizeNumericUpDown = new NumericUpDown();
            dateFormatLabel = new Label();
            dateFormatComboBox = new ComboBox();
            customDateFormatTextBox = new TextBox();
            timelineOrientationLabel = new Label();
            orientationHorizontalLabel = new Label();
            orientationVerticalLabel = new Label();
            orientationToggle = new CheckBox();
            languageLabel = new Label();
            languageComboBox = new ComboBox();
            autoSaveIntervalLabel = new Label();
            autoSaveIntervalComboBox = new ComboBox();
            defaultFilePathLabel = new Label();
            defaultFilePathTextBox = new TextBox();
            browseButton = new Button();
            buttonPanel = new FlowLayoutPanel();
            saveButton = new Button();
            cancelButton = new Button();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fontSizeNumericUpDown).BeginInit();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel.Controls.Add(themeLabel, 0, 0);
            tableLayoutPanel.Controls.Add(themeLightLabel, 1, 0);
            tableLayoutPanel.Controls.Add(themeDarkLabel, 2, 0);
            tableLayoutPanel.Controls.Add(fontSizeLabel, 0, 2);
            tableLayoutPanel.Controls.Add(fontSizeNumericUpDown, 1, 2);
            tableLayoutPanel.Controls.Add(dateFormatLabel, 0, 3);
            tableLayoutPanel.Controls.Add(dateFormatComboBox, 1, 3);
            tableLayoutPanel.Controls.Add(customDateFormatTextBox, 1, 4);
            tableLayoutPanel.Controls.Add(timelineOrientationLabel, 0, 5);
            tableLayoutPanel.Controls.Add(orientationHorizontalLabel, 1, 5);
            tableLayoutPanel.Controls.Add(orientationVerticalLabel, 2, 5);
            tableLayoutPanel.Controls.Add(orientationToggle, 1, 6);
            tableLayoutPanel.Controls.Add(languageLabel, 0, 7);
            tableLayoutPanel.Controls.Add(languageComboBox, 1, 7);
            tableLayoutPanel.Controls.Add(autoSaveIntervalLabel, 0, 9);
            tableLayoutPanel.Controls.Add(autoSaveIntervalComboBox, 1, 9);
            tableLayoutPanel.Controls.Add(defaultFilePathLabel, 0, 10);
            tableLayoutPanel.Controls.Add(defaultFilePathTextBox, 1, 10);
            tableLayoutPanel.Controls.Add(browseButton, 2, 10);
            tableLayoutPanel.Controls.Add(buttonPanel, 0, 11);
            tableLayoutPanel.Controls.Add(themeToggle, 1, 1);

            // Add new controls for link colors
            var linkNewLabel = new Label { Text = "New Link Color:", Top = 300, Left = 10, Width = 150 };
            linkNewColorButton = new Button { Text = "Select Color", Top = 300, Left = 170, Width = 100 };
            linkNewColorButton.Click += (s, e) => SelectColor("NewLink");

            var linkUsedLabel = new Label { Text = "Used Link Color:", Top = 330, Left = 10, Width = 150 };
            linkUsedColorButton = new Button { Text = "Select Color", Top = 330, Left = 170, Width = 100 };
            linkUsedColorButton.Click += (s, e) => SelectColor("UsedLink");

            var linkVisitedLabel = new Label { Text = "Visited Link Color:", Top = 360, Left = 10, Width = 150 };
            linkVisitedColorButton = new Button { Text = "Select Color", Top = 360, Left = 170, Width = 100 };
            linkVisitedColorButton.Click += (s, e) => SelectColor("VisitedLink");

            tableLayoutPanel.Controls.Add(linkNewLabel, 0, 12);
            tableLayoutPanel.Controls.Add(linkNewColorButton, 1, 12);
            tableLayoutPanel.Controls.Add(linkUsedLabel, 0, 13);
            tableLayoutPanel.Controls.Add(linkUsedColorButton, 1, 13);
            tableLayoutPanel.Controls.Add(linkVisitedLabel, 0, 14);
            tableLayoutPanel.Controls.Add(linkVisitedColorButton, 1, 14);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.Padding = new Padding(10);
            tableLayoutPanel.RowCount = 12;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(1784, 1561);
            tableLayoutPanel.TabIndex = 0;
            // 
            // themeLabel
            // 
            themeLabel.AutoSize = true;
            themeLabel.Location = new Point(13, 10);
            themeLabel.Name = "themeLabel";
            themeLabel.Size = new Size(100, 15);
            themeLabel.TabIndex = 0;
            themeLabel.Text = "Light/Dark Mode:";
            // 
            // themeLightLabel
            // 
            themeLightLabel.AutoSize = true;
            themeLightLabel.Location = new Point(718, 10);
            themeLightLabel.Name = "themeLightLabel";
            themeLightLabel.Size = new Size(34, 15);
            themeLightLabel.TabIndex = 1;
            themeLightLabel.Text = "Light";
            // 
            // themeDarkLabel
            // 
            themeDarkLabel.AutoSize = true;
            themeDarkLabel.Location = new Point(1423, 10);
            themeDarkLabel.Name = "themeDarkLabel";
            themeDarkLabel.Size = new Size(31, 15);
            themeDarkLabel.TabIndex = 2;
            themeDarkLabel.Text = "Dark";
            // 
            // themeToggle
            // 
            themeToggle.Appearance = Appearance.Button;
            themeToggle.Location = new Point(718, 28);
            themeToggle.Name = "themeToggle";
            themeToggle.Size = new Size(150, 40);
            themeToggle.TabIndex = 3;
            themeToggle.Text = "☀";
            themeToggle.TextAlign = ContentAlignment.MiddleCenter;
            themeToggle.CheckedChanged += ThemeToggle_CheckedChanged;
            // 
            // fontSizeLabel
            // 
            fontSizeLabel.AutoSize = true;
            fontSizeLabel.Location = new Point(13, 71);
            fontSizeLabel.Name = "fontSizeLabel";
            fontSizeLabel.Size = new Size(57, 15);
            fontSizeLabel.TabIndex = 4;
            fontSizeLabel.Text = "Font Size:";
            // 
            // fontSizeNumericUpDown
            // 
            fontSizeNumericUpDown.Location = new Point(718, 74);
            fontSizeNumericUpDown.Maximum = new decimal(new int[] { 48, 0, 0, 0 });
            fontSizeNumericUpDown.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
            fontSizeNumericUpDown.Name = "fontSizeNumericUpDown";
            fontSizeNumericUpDown.Size = new Size(150, 23);
            fontSizeNumericUpDown.TabIndex = 5;
            fontSizeNumericUpDown.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // dateFormatLabel
            // 
            dateFormatLabel.AutoSize = true;
            dateFormatLabel.Location = new Point(13, 100);
            dateFormatLabel.Name = "dateFormatLabel";
            dateFormatLabel.Size = new Size(75, 15);
            dateFormatLabel.TabIndex = 6;
            dateFormatLabel.Text = "Date Format:";
            // 
            // dateFormatComboBox
            // 
            dateFormatComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            dateFormatComboBox.Items.AddRange(new object[] { "MM/dd/yyyy", "dd/MM/yyyy", "yyyy-MM-dd", "Custom" });
            dateFormatComboBox.Location = new Point(718, 103);
            dateFormatComboBox.Name = "dateFormatComboBox";
            dateFormatComboBox.Size = new Size(250, 23);
            dateFormatComboBox.TabIndex = 7;
            dateFormatComboBox.SelectedIndexChanged += DateFormatComboBox_SelectedIndexChanged;
            // 
            // customDateFormatTextBox
            // 
            customDateFormatTextBox.Location = new Point(718, 132);
            customDateFormatTextBox.Name = "customDateFormatTextBox";
            customDateFormatTextBox.Size = new Size(250, 23);
            customDateFormatTextBox.TabIndex = 8;
            customDateFormatTextBox.Visible = false;
            // 
            // timelineOrientationLabel
            // 
            timelineOrientationLabel.AutoSize = true;
            timelineOrientationLabel.Location = new Point(13, 158);
            timelineOrientationLabel.Name = "timelineOrientationLabel";
            timelineOrientationLabel.Size = new Size(171, 15);
            timelineOrientationLabel.TabIndex = 9;
            timelineOrientationLabel.Text = "Timeline Orientation:";
            // 
            // orientationHorizontalLabel
            // 
            orientationHorizontalLabel.AutoSize = true;
            orientationHorizontalLabel.Location = new Point(718, 158);
            orientationHorizontalLabel.Name = "orientationHorizontalLabel";
            orientationHorizontalLabel.Size = new Size(62, 15);
            orientationHorizontalLabel.TabIndex = 10;
            orientationHorizontalLabel.Text = "Horizontal";
            // 
            // orientationVerticalLabel
            // 
            orientationVerticalLabel.AutoSize = true;
            orientationVerticalLabel.Location = new Point(1423, 158);
            orientationVerticalLabel.Name = "orientationVerticalLabel";
            orientationVerticalLabel.Size = new Size(45, 15);
            orientationVerticalLabel.TabIndex = 11;
            orientationVerticalLabel.Text = "Vertical";
            // 
            // orientationToggle
            // 
            orientationToggle.Appearance = Appearance.Button;
            orientationToggle.Location = new Point(718, 176);
            orientationToggle.Name = "orientationToggle";
            orientationToggle.Size = new Size(150, 40);
            orientationToggle.TabIndex = 12;
            orientationToggle.Text = "↔";
            orientationToggle.TextAlign = ContentAlignment.MiddleCenter;
            orientationToggle.CheckedChanged += OrientationToggle_CheckedChanged;
            // 
            // languageLabel
            // 
            languageLabel.AutoSize = true;
            languageLabel.Location = new Point(13, 219);
            languageLabel.Name = "languageLabel";
            languageLabel.Size = new Size(62, 15);
            languageLabel.TabIndex = 13;
            languageLabel.Text = "Language:";
            // 
            // languageComboBox
            // 
            languageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            languageComboBox.Items.AddRange(new object[] { "English", "Spanish", "French", "German" });
            languageComboBox.Location = new Point(718, 222);
            languageComboBox.Name = "languageComboBox";
            languageComboBox.Size = new Size(200, 23);
            languageComboBox.TabIndex = 14;
            //
            //autoSaveIntervalLabel
            // 
            autoSaveIntervalLabel.AutoSize = true;
            autoSaveIntervalLabel.Location = new Point(13, 268);
            autoSaveIntervalLabel.Name = "autoSaveIntervalLabel";
            autoSaveIntervalLabel.Size = new Size(161, 15);
            autoSaveIntervalLabel.TabIndex = 17;
            autoSaveIntervalLabel.Text = "Auto-Save Interval (minutes):";
            // 
            // autoSaveIntervalComboBox
            // 
            autoSaveIntervalComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            autoSaveIntervalComboBox.Items.AddRange(new object[] { "5", "10", "15", "20", "30", "60" });
            autoSaveIntervalComboBox.Location = new Point(718, 271);
            autoSaveIntervalComboBox.Name = "autoSaveIntervalComboBox";
            autoSaveIntervalComboBox.Size = new Size(150, 23);
            autoSaveIntervalComboBox.TabIndex = 18;
            // 
            // defaultFilePathLabel
            // 
            defaultFilePathLabel.AutoSize = true;
            defaultFilePathLabel.Location = new Point(13, 297);
            defaultFilePathLabel.Name = "defaultFilePathLabel";
            defaultFilePathLabel.Size = new Size(96, 15);
            defaultFilePathLabel.TabIndex = 19;
            defaultFilePathLabel.Text = "Default File Path:";
            // 
            // defaultFilePathTextBox
            // 
            defaultFilePathTextBox.Location = new Point(718, 300);
            defaultFilePathTextBox.Name = "defaultFilePathTextBox";
            defaultFilePathTextBox.Size = new Size(350, 35);
            defaultFilePathTextBox.TabIndex = 20;
            // 
            // browseButton
            // 
            browseButton.Location = new Point(1423, 300);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(85, 35);
            browseButton.TabIndex = 21;
            browseButton.Text = "Browse";
            browseButton.Click += BrowseButton_Click;
            // 
            // buttonPanel
            // 
            tableLayoutPanel.SetColumnSpan(buttonPanel, 3);
            buttonPanel.Controls.Add(saveButton);
            buttonPanel.Controls.Add(cancelButton);
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonPanel.Location = new Point(0, 520); // Adjusted location
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(800, 40); // Adjusted size
            buttonPanel.TabIndex = 22;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(722, 3); // Adjusted location
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 35);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(641, 3); // Adjusted location
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 35);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.Click += CancelButton_Click;
            // 
            // PreferencesForm
            // 
            ClientSize = new Size(600, 475);
            Controls.Add(tableLayoutPanel);
            Name = "PreferencesForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Preferences";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fontSizeNumericUpDown).EndInit();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void LoadPreferences()
        {
            themeToggle.Checked = Program.UserPreferences.Theme == "Dark";
            fontSizeNumericUpDown.Value = Program.UserPreferences.FontSize;
            dateFormatComboBox.SelectedItem = Program.UserPreferences.DateFormat;
            customDateFormatTextBox.Text = Program.UserPreferences.DateFormat;
            customDateFormatTextBox.Visible = dateFormatComboBox.SelectedItem?.ToString() == "Custom";
            orientationToggle.Checked = Program.UserPreferences.TimelineOrientation == "Vertical";
            languageComboBox.SelectedItem = Program.UserPreferences.Language;
            autoSaveIntervalComboBox.SelectedItem = Program.UserPreferences.AutoSaveInterval.ToString();
            defaultFilePathTextBox.Text = Program.UserPreferences.DefaultFilePath;
            notificationsCheckBox.Checked = Program.UserPreferences.EnableNotifications;

            // Load link colors
            if (linkNewColorButton != null)
                linkNewColorButton.BackColor = Program.UserPreferences.LinkNewColor;
            if (linkUsedColorButton != null)
                linkUsedColorButton.BackColor = Program.UserPreferences.LinkUsedColor;
            if (linkVisitedColorButton != null)
                linkVisitedColorButton.BackColor = Program.UserPreferences.LinkVisitedColor;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Program.UserPreferences.Theme = themeToggle.Checked ? "Dark" : "Light";
                Program.UserPreferences.FontSize = (int)fontSizeNumericUpDown.Value;
                Program.UserPreferences.DateFormat = dateFormatComboBox.SelectedItem?.ToString() == "Custom" ? customDateFormatTextBox.Text : dateFormatComboBox.SelectedItem?.ToString();
                Program.UserPreferences.TimelineOrientation = orientationToggle.Checked ? "Vertical" : "Horizontal";
                Program.UserPreferences.Language = languageComboBox.SelectedItem?.ToString();
                Program.UserPreferences.EnableNotifications = notificationsCheckBox.Checked;
                Program.UserPreferences.AutoSaveInterval = int.Parse(autoSaveIntervalComboBox.SelectedItem.ToString());
                Program.UserPreferences.DefaultFilePath = defaultFilePathTextBox.Text;

                // Save link colors
                if (linkNewColorButton != null)
                    Program.UserPreferences.LinkNewColor = linkNewColorButton.BackColor;
                if (linkUsedColorButton != null)
                    Program.UserPreferences.LinkUsedColor = linkUsedColorButton.BackColor;
                if (linkVisitedColorButton != null)
                    Program.UserPreferences.LinkVisitedColor = linkVisitedColorButton.BackColor;

                Program.SavePreferences();

                // Re-apply preferences to update the timer interval
                ((MainGUI)this.Owner).ApplyPreferences();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Saving preferences");
            }
        }



        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DateFormatTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DateTime.TryParseExact("01/01/2000", customDateFormatTextBox.Text, null, System.Globalization.DateTimeStyles.None, out _))
            {
                e.Cancel = true;
                customDateFormatTextBox.Select(0, customDateFormatTextBox.Text.Length);
                MessageBox.Show("Invalid date format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DateFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            customDateFormatTextBox.Visible = dateFormatComboBox.SelectedItem?.ToString() == "Custom";
        }

        private void ThemeToggle_CheckedChanged(object sender, EventArgs e)
        {
            themeToggle.Text = themeToggle.Checked ? "\u263D" : "\u2600"; // Moon symbol : Sun symbol
        }

        private void OrientationToggle_CheckedChanged(object sender, EventArgs e)
        {
            orientationToggle.Text = orientationToggle.Checked ? "\u2195" : "\u2194"; // Vertical arrow symbol : Horizontal arrow symbol
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    defaultFilePathTextBox.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void SelectColor(string linkType)
        {
            using (var colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    switch (linkType)
                    {
                        case "NewLink":
                            linkNewColorButton.BackColor = colorDialog.Color;
                            break;
                        case "UsedLink":
                            linkUsedColorButton.BackColor = colorDialog.Color;
                            break;
                        case "VisitedLink":
                            linkVisitedColorButton.BackColor = colorDialog.Color;
                            break;
                    }
                }
            }
        }
    }
}






