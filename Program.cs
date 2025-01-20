using Microsoft.Extensions.Configuration;
using System.Configuration;
using TimelineBuilderPro;
using System.IO;
using Newtonsoft.Json;

namespace TimelineBuilderPro
{
    public static class Program
    {
        public static IConfiguration Configuration { get; private set; }
        public static Preferences UserPreferences { get; private set; }

        [STAThread]
        static void Main()
        {
            // Load configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();

            // Load user preferences
            UserPreferences = Configuration.GetSection("Preferences").Get<Preferences>();

            // Set default preferences if none exist
            if (UserPreferences == null)
            {
                UserPreferences = new Preferences
                {
                    Theme = "Light",
                    FontSize = 12,
                    DateFormat = "MM/dd/yyyy",
                    TimelineOrientation = "Horizontal",
                    Language = "English",
                    EnableNotifications = true,
                    AutoSaveInterval = 10,
                    DefaultFilePath = "C:\\Users\\Default\\Documents"
                };
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Add global exception handling
            Application.ThreadException += (sender, args) => ErrorHandler.HandleException(args.Exception, "Unhandled UI Exception");
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => ErrorHandler.HandleException(args.ExceptionObject as Exception, "Unhandled Non-UI Exception");

            // Run the main GUI application
            Application.Run(new MainGUI());
        }

        public static void SavePreferences()
        {
            var preferencesFilePath = "appsettings.json";

            var json = File.ReadAllText(preferencesFilePath);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);

            jsonObj["Preferences"]["Theme"] = UserPreferences.Theme;
            jsonObj["Preferences"]["FontSize"] = UserPreferences.FontSize;
            jsonObj["Preferences"]["DateFormat"] = UserPreferences.DateFormat;
            jsonObj["Preferences"]["TimelineOrientation"] = UserPreferences.TimelineOrientation;
            jsonObj["Preferences"]["Language"] = UserPreferences.Language;
            jsonObj["Preferences"]["EnableNotifications"] = UserPreferences.EnableNotifications;
            jsonObj["Preferences"]["AutoSaveInterval"] = UserPreferences.AutoSaveInterval;
            jsonObj["Preferences"]["DefaultFilePath"] = UserPreferences.DefaultFilePath;

            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(preferencesFilePath, output);
        }
    }
}
