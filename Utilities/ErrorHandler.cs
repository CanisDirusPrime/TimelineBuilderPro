using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TimelineBuilderPro
{
    public static class ErrorHandler
    {
        private static readonly string logFilePath = "D:\\Documents\\Timelines\\TimelineBuilder\\Dev\\TimelineBuilderRepo\\Log_Files\\error_log.txt";

        public static void HandleException(Exception ex, string userAction)
        {
            // Log the exception
            LogException(ex, userAction);

            // Display a user-friendly message
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowUnsavedChangesDialog()
        {
            return MessageBox.Show("You have unsaved changes. Do you want to save before proceeding?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }

        public static void CheckMonitorResolution()
        {
            try
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
            catch (Exception ex)
            {
                HandleException(ex, "Checking monitor resolution");
            }
        }

        public static void ShowNotImplementedMessage()
        {
            MessageBox.Show("This feature has not been implemented yet.", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void LogException(Exception ex, string userAction)
        {
            try
            {
                string currentDate = DateTime.Now.ToString("dd-MMM-yyyy");
                string currentTime = DateTime.Now.ToString("HH:mm:ss");

                // Ensure the log file exists
                if (!File.Exists(logFilePath))
                {
                    using (File.Create(logFilePath)) { }
                }

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    // Check if the last log entry date is different from the current date
                    string lastLogDate = File.ReadLines(logFilePath).LastOrDefault(line => line.StartsWith("Date:"))?.Substring(6) ?? string.Empty;

                    if (lastLogDate != currentDate)
                    {
                        writer.WriteLine();
                        writer.WriteLine($"Date: {currentDate}");
                    }

                    writer.WriteLine($"Time: {currentTime}");
                    writer.WriteLine($"Action: {userAction}");
                    writer.WriteLine($"Error: {ex.Message}");
                    writer.WriteLine(ex.StackTrace);
                    writer.WriteLine();
                }
            }
            catch
            {
                // Ignore logging errors
            }
        }
    }
}
