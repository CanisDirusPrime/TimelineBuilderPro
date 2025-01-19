using System;
using System.IO;
using System.Windows.Forms;

namespace TimelineBuilderPro
{
    public partial class MainGUI : Form
    {
        private bool isUnsavedChanges = false; // Tracks whether there are unsaved changes

        public MainGUI()
        {
            InitializeComponent();

            // Attach event handlers for File menu items
            this.newToolStripMenuItem.Click += NewToolStripMenuItem_Click;
            this.openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            this.saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            this.saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            this.closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
            this.exitToolStripMenuItem.Click += (s, e) => Application.Exit();

            // Attach event handlers for Edit menu items
            this.undoToolStripMenuItem.Click += (s, e) => MessageBox.Show("Undo action performed!");
            this.redoToolStripMenuItem.Click += (s, e) => MessageBox.Show("Redo action performed!");
            this.cutToolStripMenuItem.Click += (s, e) => MessageBox.Show("Cut action performed!");
            this.copyToolStripMenuItem.Click += (s, e) => MessageBox.Show("Copy action performed!");
            this.pasteToolStripMenuItem.Click += (s, e) => MessageBox.Show("Paste action performed!");
            this.findToolStripMenuItem.Click += (s, e) => MessageBox.Show("Find action performed!");
            this.replaceToolStripMenuItem.Click += (s, e) => MessageBox.Show("Replace action performed!");

            // Attach event handlers for View menu items
            this.zoomInToolStripMenuItem.Click += (s, e) => MessageBox.Show("Zoomed In!");
            this.zoomOutToolStripMenuItem.Click += (s, e) => MessageBox.Show("Zoomed Out!");
            this.resetZoomToolStripMenuItem.Click += (s, e) => MessageBox.Show("Zoom reset!");
            this.fullScreenToolStripMenuItem.Click += (s, e) => MessageBox.Show("Full Screen mode activated!");

            // Attach event handlers for Help menu items
            this.aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            this.documentationToolStripMenuItem.Click += (s, e) => MessageBox.Show("Documentation: Coming Soon!");
        }

        private void NewToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (ConfirmUnsavedChanges())
            {
                MessageBox.Show("New timeline created!");
                isUnsavedChanges = false; // Reset the unsaved changes flag
            }
        }

        private void OpenToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (ConfirmUnsavedChanges())
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Timeline Files (*.timeline)|*.timeline|All Files (*.*)|*.*";
                    openFileDialog.Title = "Open Timeline File";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            string fileContent = File.ReadAllText(openFileDialog.FileName);
                            MessageBox.Show("File loaded successfully!");
                            // Logic to handle the loaded file content
                            isUnsavedChanges = false; // Reset the unsaved changes flag
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error loading file: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            SaveFile(".timeline");
        }

        private void SaveAsToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            SaveFile(".timeline");
        }

        private void CloseToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (ConfirmUnsavedChanges())
            {
                MessageBox.Show("Timeline closed.");
                isUnsavedChanges = false; // Reset the unsaved changes flag
            }
        }

        private void SaveFile(string defaultExtension)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Timeline Files (*.timeline)|*.timeline|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save Timeline File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = saveFileDialog.FileName;

                        // Ensure the file has the default extension if not specified
                        if (Path.GetExtension(filePath).ToLower() != defaultExtension)
                        {
                            filePath += defaultExtension;
                        }

                        // Logic to save file content
                        File.WriteAllText(filePath, "File content goes here");
                        MessageBox.Show("File saved successfully!");
                        isUnsavedChanges = false; // Reset the unsaved changes flag
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}");
                    }
                }
            }
        }

        private void AboutToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            using (AboutForm aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog(); // Opens the About form as a modal dialog
            }
        }
        private bool ConfirmUnsavedChanges()
        {
            if (isUnsavedChanges)
            {
                var result = MessageBox.Show(
                    "You have unsaved changes. Do you want to save before closing?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SaveFile(".timeline");
                    return true; // Proceed after saving
                }
                else if (result == DialogResult.No)
                {
                    return true; // Proceed without saving
                }
                else
                {
                    return false; // Cancel the action
                }
            }

            return true; // No unsaved changes, proceed
        }
    }
}
