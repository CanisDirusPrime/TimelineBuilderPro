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
            CheckMonitorResolution();

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
            this.undoToolStripMenuItem.Click += (s, e) => MessageBox.Show("Undo action performed!");
            this.redoToolStripMenuItem.Click += (s, e) => MessageBox.Show("Redo action performed!");
            this.cutToolStripMenuItem.Click += (s, e) => MessageBox.Show("Cut action performed!");
            this.copyToolStripMenuItem.Click += (s, e) => MessageBox.Show("Copy action performed!");
            this.pasteToolStripMenuItem.Click += (s, e) => MessageBox.Show("Paste action performed!");
            this.findToolStripMenuItem.Click += (s, e) => MessageBox.Show("Find action performed!");
            this.replaceToolStripMenuItem.Click += (s, e) => MessageBox.Show("Replace action performed!");

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

        private void CheckMonitorResolution()
        {
            // Get the resolution of the primary monitor
            var resolution = Screen.PrimaryScreen?.Bounds.Width + " x " + Screen.PrimaryScreen?.Bounds.Height;

            if (resolution != null)
            {
                // Display the resolution in a message box
                MessageBox.Show($"Primary Monitor Resolution: {resolution}", "Monitor Resolution");
            }
            else
            {
                // Handle the case where there is no primary screen
                MessageBox.Show("No primary monitor detected.", "Monitor Resolution");
            }
        }


        private void InitializeTimelineEditor()
        {
            // Initialize the timeline editor components
            // TODO: Add initialization code here
        }

        private void NewToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (isUnsavedChanges)
            {
                var result = MessageBox.Show("You have unsaved changes. Do you want to save before creating a new timeline?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);
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

        private void OpenToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (isUnsavedChanges)
            {
                var result = MessageBox.Show("You have unsaved changes. Do you want to save before opening a new file?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);
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

        private void SaveToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            SaveCurrentFile();
        }

        private void SaveAsToolStripMenuItem_Click(object? sender, EventArgs e)
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

        private void CloseToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (isUnsavedChanges)
            {
                var result = MessageBox.Show("You have unsaved changes. Do you want to save before closing?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);
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

        private void FindReplaceToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            // TODO: Implement Find and Replace logic
        }

        private void ZoomInToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            // TODO: Implement Zoom In functionality
        }

        private void ZoomOutToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            // TODO: Implement Zoom Out functionality
        }

        private void ResetZoomToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            // TODO: Implement Reset Zoom functionality
        }

        private void ShowGridLinesToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            // TODO: Implement Show/Hide Grid Lines functionality
        }

        private void ToggleSidebarToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            // TODO: Implement Toggle Sidebar functionality
        }

        private void FullScreenToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            // TODO: Implement Full Screen functionality
        }

        private void AboutToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            using (var aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog(this);
            }
        }

        private void DocumentationToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            // TODO: Implement Documentation logic (open a help file or website)
        }

        private void ExitToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (isUnsavedChanges)
            {
                var result = MessageBox.Show("You have unsaved changes. Do you want to save before exiting?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);
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
