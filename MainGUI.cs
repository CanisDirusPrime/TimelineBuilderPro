using System;
using System.IO;
using System.Windows.Forms;

namespace TimelineBuilderPro
{
    public partial class MainGUI : Form
    {
        private bool isUnsavedChanges = false; // Tracks whether there are unsaved changes
        private const string DefaultFileExtension = ".timeline"; // Default file extension

        public MainGUI()
        {
            InitializeComponent();

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
            // Initialize the timeline editor components
            // TODO: Add initialization code here
        }

        private void NewToolStripMenuItem_Click(object? sender, EventArgs e)
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

                var newTimelineDialog = new NewTimelineDialog();
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

        private void OpenToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void SaveToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void SaveAsToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void CloseToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void ExitToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void UndoToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void RedoToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void CutToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void CopyToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void PasteToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void FindToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void ReplaceToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void ZoomInToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void ZoomOutToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void ResetZoomToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void ShowGridLinesToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void ToggleSidebarToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void FullScreenToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void DocumentationToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void AboutToolStripMenuItem_Click(object? sender, EventArgs e)
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

            var canvas = new TimelineCanvas(settings) { Dock = DockStyle.Fill };
            Controls.Add(canvas);

            var editorMenu = new TimelineEditorMenu(settings) { Dock = DockStyle.Left };
            Controls.Add(editorMenu);
        }
    }
}
