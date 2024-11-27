using System;
using System.Diagnostics;
using System.IO;

public class ApplicationTracker
{
    private readonly string _filePath;

    public ApplicationTracker()
    {
        // Set the path to save the list of running applications
        _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RunningApps.txt");
    }

    public void SaveRunningApplications()
    {
        using (StreamWriter writer = new StreamWriter(_filePath, false))
        {
            Process[] processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                try
                {
                    if (!string.IsNullOrEmpty(process.MainWindowTitle))
                    {
                        writer.WriteLine(process.MainModule.FileName);
                    }
                }
                catch
                {
                    // Ignore processes that throw exceptions
                }
            }
        }

        Console.WriteLine($"List of running applications saved to {_filePath}");
    }
}
