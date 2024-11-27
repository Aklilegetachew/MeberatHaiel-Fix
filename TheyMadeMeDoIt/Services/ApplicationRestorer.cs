using System;
using System.Diagnostics;
using System.IO;

public class ApplicationRestorer
{
    private readonly string _filePath;

    public ApplicationRestorer()
    {
        // Set the path to the saved list of applications
        _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RunningApps.txt");
    }

    public void ReopenApplications()
    {
        if (File.Exists(_filePath))
        {
            string[] apps = File.ReadAllLines(_filePath);
            foreach (string app in apps)
            {
                try
                {
                    Process.Start(app);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to start {app}: {ex.Message}");
                }
            }
        }
        else
        {
            Console.WriteLine("No saved applications to reopen.");
        }
    }
}
