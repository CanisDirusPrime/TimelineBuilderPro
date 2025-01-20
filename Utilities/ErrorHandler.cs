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

        public static void HandlePreferenceLoadException(Exception ex)
        {
            // Log the exception
            LogException(ex, "Loading preferences");

            // Display a user-friendly message
            MessageBox.Show("Failed to load preferences. Default settings will be used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    // Store the resolution in the Preferences class
                    Preferences.MonitorResolution = resolution;
                }
                else
                {
                    // Handle the case where there is no primary screen
                    Preferences.MonitorResolution = "No primary monitor detected.";
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

                // Ensure the directory exists
                var logDirectory = Path.GetDirectoryName(logFilePath);
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                // Ensure the log file exists
                if (!File.Exists(logFilePath))
                {
                    using (File.Create(logFilePath)) { }
                }

                using (var fileStream = new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                using (var writer = new StreamWriter(fileStream))
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
            catch (Exception logEx)
            {
                // Handle logging errors
                MessageBox.Show($"Failed to log error: {logEx.Message}", "Logging Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
