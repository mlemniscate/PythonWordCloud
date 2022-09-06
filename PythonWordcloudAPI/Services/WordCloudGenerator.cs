using System.Diagnostics;

namespace RunPythonScriptFromCs;

public class WordCloudGenerator
{
    public void GenerateImage(string text)
    {
        // Create Process Info
        var processStartInfo = new ProcessStartInfo();
        processStartInfo.FileName = @"C:\Users\Milad\AppData\Local\Microsoft\WindowsApps\python.exe";

        // Provide Scripts and Arguments
        var script = @"wwwroot/py/wc.py";
        processStartInfo.Arguments = $"\"{script}\" \"{text}\"";

        // Process Configuration
        processStartInfo.UseShellExecute = false;
        processStartInfo.CreateNoWindow = true;
        processStartInfo.RedirectStandardOutput = true;
        processStartInfo.RedirectStandardError = true;

        // Execute process and get the output
        var errors = "";
        var results = "";

        using (var process = Process.Start(processStartInfo))
        {
            errors = process.StandardError.ReadToEnd();
            results = process.StandardOutput.ReadToEnd();

            Console.WriteLine(errors);
            Console.WriteLine(results);
        }
    }
}