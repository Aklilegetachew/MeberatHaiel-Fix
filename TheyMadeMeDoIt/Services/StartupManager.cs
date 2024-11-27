using Microsoft.Win32;
using System;
using System.IO;

public class StartupManager
{
    private readonly string _appName;
    private readonly string _appPath;

    public StartupManager(string appName, string appPath)
    {
        _appName = appName;
        _appPath = appPath;
    }

    public void AddToStartup()
    {
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
        {
            if (key != null)
            {
                key.SetValue(_appName, _appPath);
            }
        }

        Console.WriteLine("Application added to startup.");
    }

    public void RemoveFromStartup()
    {
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
        {
            if (key != null)
            {
                key.DeleteValue(_appName, false);
            }
        }

        Console.WriteLine("Application removed from startup.");
    }
}
