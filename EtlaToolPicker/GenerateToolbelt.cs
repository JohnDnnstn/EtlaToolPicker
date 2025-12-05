using EtlaToolPicker.BackingData;
using EtlaToolPicker.EtlaToolbelt;
using System.Diagnostics.CodeAnalysis;

namespace EtlaToolPicker;

internal static class GenerateToolbelt
{
    internal static void Generate(TopLevelData data)
    {
        var appDir = Path.GetDirectoryName(Application.ExecutablePath);
        if (!IsOk(data, appDir)) return;

        if (data.HasBlackAndWhite) { Process(appDir, "BlackAndWhite.cs", data.TargetDirectory,"", data.TargetNamespace); }
    }

    private static void Process(String appDir, String fileName, String targetDirectory, String subDirectory, String targetNamespace)
    {
        var sourceFilepath = Path.Combine(appDir, "EtlaToolbelt",fileName);
        if (!File.Exists(sourceFilepath))
        {
            var msg = $"Internal error: {sourceFilepath} does not exist";
            Log.Error(msg);
            MessageBox.Show(msg, "Internal error", MessageBoxButtons.OK);
        }

        var text = File.ReadAllText(sourceFilepath);
        text = text.Replace("namespace EtlaToolboxPicker", $"namespace {targetNamespace}");

        var targetDir = Path.Combine(targetDirectory, "EtlaToolbelt",subDirectory);
        if (!Directory.Exists(targetDir)) { Directory.CreateDirectory(targetDir); }
        var targetFilepath = Path.Combine(targetDir, fileName);

        File.WriteAllText(targetFilepath, text);
    }

    private static bool IsOk(TopLevelData data, [NotNullWhen(true)] string? appDir)
    {
        if (data == null) 
        {
            var msg = "Internal error: TopLevelData is null";
            Log.Fatal(msg);
            throw new Exception(msg);
        }
        if (data.TargetDirectory.IsWhite() || data.TargetNamespace.IsWhite())
        {
            var msg = "Target Directory and Target Namespace must not be blank";
            MessageBox.Show(msg,"User input required",MessageBoxButtons.OK);
            return false;
        }
        if (!Directory.Exists(data.TargetDirectory))
        {
            var msg = $"{data.TargetDirectory} does not exist";
            MessageBox.Show(msg, "User input required", MessageBoxButtons.OK);
            return false;
        }
        if (appDir.IsWhite() || !Directory.Exists(appDir))
        {
            var msg = "Internal error: Failed to find the directory of this application";
            Log.Fatal(msg);
            throw new Exception(msg);
        }
        return true;
    }
}
