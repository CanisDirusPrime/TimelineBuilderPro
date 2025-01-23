using System;
using System.IO;
using System.Windows.Forms;
using TimelineBuilderPro;

namespace TimelineBuilderPro
{
    public partial class MainGUI : Form
    {
        private bool isUnsavedChanges = false; // Tracks whether there are unsaved changes
        private const string DefaultFileExtension = ".timeline"; // Default file extension
        private System.Windows.Forms.Timer autoSaveTimer; // Declare the Timer
        private TimelineCanvasForm timelineCanvas;
        private TimelineEditorForm timelineEditorForm;

        public MainGUI()
        {
            InitializeComponent();

            // Initialize the Timer
            autoSaveTimer = new System.Windows.Forms.Timer();
            autoSaveTimer.Tick += AutoSaveTimer_Tick;

            // Apply user preferences
            ApplyPreferences();

            // Check and display the monitor resolution
            ErrorHandler.CheckMonitorResolution();

            // Set the form to launch maximized
            this.WindowState = FormWindowState.Maximized;

                        // Attach event handlers for File menu items
            this.newToolStripMenuItem.Click += NewToolStripMenuItem_Click;
            this.openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            this.saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            this.saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            this.closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
            this.preferencesToolStripMenuItem.Click += PreferencesToolStripMenuItem_Click;
            this.exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;

            // Attach event handlers for Edit menu items
            this.undoToolStripMenuItem.Click += UndoToolStripMenuItem_Click;
            this.redoToolStripMenuItem.Click += RedoToolStripMenuItem_Click;
            this.cutToolStripMenuItem.Click += CutToolStripMenuItem_Click;
            this.copyToolStripMenuItem.Click += CopyToolStripMenuItem_Click;
            this.pasteToolStripMenuItem.Click += PasteToolStripMenuItem_Click;
            this.findToolStripMenuItem.Click += FindToolStripMenuItem_Click;
            this.replaceToolStripMenuItem.Click += ReplaceToolStripMenuItem_Click;

            // Attach event handlers for View menu items
            this.zoomInToolStripMenuItem.Click += ZoomInToolStripMenuItem_Click;
            this.zoomOutToolStripMenuItem.Click += ZoomOutToolStripMenuItem_Click;
            this.resetZoomToolStripMenuItem.Click += ResetZoomToolStripMenuItem_Click;
            this.showGridLinesToolStripMenuItem.Click += ShowGridLinesToolStripMenuItem_Click;
            this.toggleSidebarToolStripMenuItem.Click += ToggleSidebarToolStripMenuItem_Click;
            this.fullScreenToolStripMenuItem.Click += FullScreenToolStripMenuItem_Click;

            // Attach event handlers for Help menu items
            this.aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            this.documentationToolStripMenuItem.Click += DocumentationToolStripMenuItem_Click;

            // Initialize the timeline editor
            InitializeTimelineEditor();
        }

        private void InitializeTimelineEditor()
        {
            var settings = new TimelineSettings { Title = "My Timeline", YearRange = "2000-2020", Orientation = "Horizontal" };

            timelineCanvas = new TimelineCanvasForm { Dock = DockStyle.Fill };
            timelineEditorForm = new TimelineEditorForm(timelineCanvas, settings);

            this.Controls.Add(timelineCanvas);
            this.Controls.Add(timelineEditorForm);
        }

        public void ApplyPreferences()
        {
            // Apply theme
            if (Program.UserPreferences.Theme == "Dark")
            {
                this.BackColor = System.Drawing.Color.DarkGray;
                // Apply other dark theme settings
            }
            else
            {
                this.BackColor = System.Drawing.Color.White;
                // Apply other light theme settings
            }

            // Apply font size
            this.Font = new System.Drawing.Font(this.Font.FontFamily, Program.UserPreferences.FontSize);

            // Apply language (this is a placeholder, actual implementation may vary)
            ApplyLanguage(Program.UserPreferences.Language);

            // Apply auto-save interval
            int intervalMinutes = Program.UserPreferences.AutoSaveInterval;
            autoSaveTimer.Interval = intervalMinutes * 60 * 1000; // Convert minutes to milliseconds
            autoSaveTimer.Start();

            // Apply other preferences as needed
        }

        private void ApplyLanguage(string language)
        {
            try
            {
                // Placeholder for applying language settings
                // Actual implementation may involve loading language resources, etc.
                if (language == "English")
                {
                    // Apply English language settings
                }
                else if (language == "Spanish")
                {
                    // Apply Spanish language settings
                }
                else if (language == "French")
                {
                    // Apply French language settings
                }
                else if (language == "German")
                {
                    // Apply German language settings
                }
                else
                {
                    throw new NotSupportedException($"Language '{language}' is not supported.");
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Applying language settings");
            }
        }

        private void PreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var preferencesForm = new PreferencesForm())
                {
                    preferencesForm.ShowDialog(this);
                    ApplyPreferences(); // Re-apply preferences after closing the form
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Opening preferences dialog");
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (isUnsavedChanges)
                {
                    var result = ErrorHandler.ShowUnsavedChangesDialog();
                    if (result == DialogResult.Yes)
                    {
                        SaveToolStripMenuItem_Click(sender, e);
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                var newTimelineDialog = new NewTimelineForm();
                if (newTimelineDialog.ShowDialog() == DialogResult.OK)
                {
                    CreateNewTimeline(newTimelineDialog.TimelineSettings);
                }
                isUnsavedChanges = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Creating a new timeline");
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (isUnsavedChanges)
                {
                    var result = ErrorHandler.ShowUnsavedChangesDialog();
                    if (result == DialogResult.Yes)
                    {
                        SaveToolStripMenuItem_Click(sender, e);
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = $"Timeline Files (*{DefaultFileExtension})|*{DefaultFileExtension}|All Files (*.*)|*.*";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // TODO: Add code to load the timeline from the file
                        isUnsavedChanges = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Opening a timeline file");
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveCurrentFile();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Saving the current file");
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = $"Timeline Files (*{DefaultFileExtension})|*{DefaultFileExtension}|All Files (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // TODO: Add code to save the timeline to the file
                        isUnsavedChanges = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Saving the file as a new file");
            }
        }

        private void AutoSaveTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Save the current file
                SaveCurrentFile();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Auto-saving preferences");
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (isUnsavedChanges)
                {
                    var result = ErrorHandler.ShowUnsavedChangesDialog();
                    if (result == DialogResult.Yes)
                    {
                        SaveToolStripMenuItem_Click(sender, e);
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                // TODO: Add logic to close the timeline and clear the editor
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Closing the timeline");
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (isUnsavedChanges)
                {
                    var result = ErrorHandler.ShowUnsavedChangesDialog();
                    if (result == DialogResult.Yes)
                    {
                        SaveToolStripMenuItem_Click(sender, e);
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                Application.Exit();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Exiting the application");
            }
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorHandler.ShowNotImplementedMessage();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Performing undo action");
            }
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorHandler.ShowNotImplementedMessage();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Performing redo action");
            }
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorHandler.ShowNotImplementedMessage();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Performing cut action");
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorHandler.ShowNotImplementedMessage();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Performing copy action");
            }
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorHandler.ShowNotImplementedMessage();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Performing paste action");
            }
        }

        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorHandler.ShowNotImplementedMessage();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Performing find action");
            }
        }

        private void ReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorHandler.ShowNotImplementedMessage();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Performing replace action");
            }
        }

        private void ZoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorHandler.ShowNotImplementedMessage();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Zooming in");
            }
        }

        private void ZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorHandler.ShowNotImplementedMessage();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Zooming out");
            }
        }

        private void ResetZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorHandler.ShowNotImplementedMessage();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Resetting zoom");
            }
        }

        private void ShowGridLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorHandler.ShowNotImplementedMessage();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Toggling grid lines");
            }
        }

        private void ToggleSidebarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorHandler.ShowNotImplementedMessage();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Toggling sidebar");
            }
        }

        private void FullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorHandler.ShowNotImplementedMessage();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Entering full screen mode");
            }
        }

        private void DocumentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorHandler.ShowNotImplementedMessage();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Opening documentation");
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var aboutForm = new AboutForm())
                {
                    aboutForm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Opening about dialog");
            }
        }

        private void SaveCurrentFile()
        {
            // Placeholder logic for saving a file
        }

        private void CreateNewTimeline(TimelineSettings settings)
        {
            Controls.Clear();

            // Determine the background color based on the theme and user preferences
            Color backgroundColor;
            if (Program.UserPreferences.CustomBackgroundColor.HasValue)
            {
                backgroundColor = Program.UserPreferences.CustomBackgroundColor.Value;
            }
            else if (Program.UserPreferences.Theme == "Dark")
            {
                backgroundColor = Color.DarkGray;
            }
            else
            {
                backgroundColor = Color.AntiqueWhite;
            }

            // Initialize the new canvas with the determined background color
            timelineCanvas = new TimelineCanvasForm
            {
                Dock = DockStyle.Fill,
                BackColor = backgroundColor,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Initialize the editor form
            timelineEditorForm = new TimelineEditorForm(timelineCanvas, settings)
            {
                Dock = DockStyle.Left,
                Width = 200,
                BackColor = SystemColors.Control
            };

            // Add the canvas and editor form to the main form
            this.Controls.Add(timelineCanvas);
            this.Controls.Add(timelineEditorForm);
        }

    }
}
