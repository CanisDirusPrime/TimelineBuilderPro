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
}
