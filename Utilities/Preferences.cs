using System.Drawing;
using Microsoft.Extensions.Configuration;

public class Preferences
{
    //Theme Setting
    public string Theme { get; set; }

    //Font Size
    public int FontSize { get; set; }

    //Date Format
    public string DateFormat { get; set; }

    //Timeline Orientation    
    public string TimelineOrientation { get; set; }

    //Language
    public string Language { get; set; }

    //Notifications
    public bool EnableNotifications { get; set; }

    //AutoSave Interval
    public int AutoSaveInterval { get; set; }

    //Default File Path
    public string DefaultFilePath { get; set; }

    // Monitor Resolution
    public static string MonitorResolution { get; set; }

    // Colors
    public Color BackgroundColor { get; set; }
    public Color ForegroundColor { get; set; }
    public Color LinkNewColor { get; set; }
    public Color LinkUsedColor { get; set; }
    public Color LinkVisitedColor { get; set; }
    public Color? CustomBackgroundColor { get; set; }
    public void LoadDefaults()
    {
        // Load default colors from appsettings.json
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        if (Theme == "Dark")
        {
            BackgroundColor = ColorTranslator.FromHtml(config["DefaultColors:DarkMode:Background"]);
            ForegroundColor = ColorTranslator.FromHtml(config["DefaultColors:DarkMode:Foreground"]);
            LinkNewColor = ColorTranslator.FromHtml(config["DefaultColors:DarkMode:LinkNew"]);
            LinkUsedColor = ColorTranslator.FromHtml(config["DefaultColors:DarkMode:LinkUsed"]);
            LinkVisitedColor = ColorTranslator.FromHtml(config["DefaultColors:DarkMode:LinkVisited"]);
        }
        else
        {
            BackgroundColor = ColorTranslator.FromHtml(config["DefaultColors:LightMode:Background"]);
            ForegroundColor = ColorTranslator.FromHtml(config["DefaultColors:LightMode:Foreground"]);
            LinkNewColor = ColorTranslator.FromHtml(config["DefaultColors:LightMode:LinkNew"]);
            LinkUsedColor = ColorTranslator.FromHtml(config["DefaultColors:LightMode:LinkUsed"]);
            LinkVisitedColor = ColorTranslator.FromHtml(config["DefaultColors:LightMode:LinkVisited"]);
        }
    }
}


