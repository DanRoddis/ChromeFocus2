using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{
    // Import the user32.dll to access the SetForegroundWindow function
    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    static void Main(string[] args)
    {
        var chromeProcesses = Process.GetProcessesByName("chrome");

        if (chromeProcesses.Length > 0)
        {
            var firstChromeProcess = chromeProcesses[0];
            SetForegroundWindow(firstChromeProcess.MainWindowHandle);
        }
        else
        {
            var programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            var chromePath = Path.Combine(programFilesPath, "Google", "Chrome", "Application", "chrome.exe");
            Process.Start(chromePath);
        }
    }
}