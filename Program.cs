namespace TimelineBuilderPro
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Comment and/or Uncomment one of the following lines to run the desired application:

            // Run the main GUI application
            //Application.Run(new MainGUI());

            // Run the Timeline Editor for testing or development
             Application.Run(new TimelineEditor());
        }
    }
}
