using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string appName = "ReopenApps";
        string appPath = Path.Combine(Environment.CurrentDirectory, "YourApp.exe");

        var tracker = new ApplicationTracker();
        var restorer = new ApplicationRestorer();
        var startupManager = new StartupManager(appName, appPath);

        if (args.Length > 0)
        {
            switch (args[0].ToLower())
            {
                case "save":
                    tracker.SaveRunningApplications();
                    break;

                case "restore":
                    restorer.ReopenApplications();
                    break;

                case "addstartup":
                    startupManager.AddToStartup();
                    break;

                case "removestartup":
                    startupManager.RemoveFromStartup();
                    break;

                default:
                    Console.WriteLine("Invalid command. Use 'save', 'restore', 'addstartup', or 'removestartup'.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("No command provided. Use 'save', 'restore', 'addstartup', or 'removestartup'.");
        }
    }
}
