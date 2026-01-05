using EtlaToolPicker.BackingData;
using EtlaToolPicker.EtlaToolbelt;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EtlaToolPicker;

internal static class GenerateToolbelt
{
    private static TopLevelData _BackingData { get; set; } = new();
    private static string _AppDir { get; set; } = "";
    private static string _TargetDirectory { get; set; } = "";
    private static string _TargetNamespace { get; set; } = "";

    private static StringBuilder _Builder { get; set; } = new ();
    private static int _Indent { get; set; } = 0;

    internal static bool Generate(TopLevelData data)
    {
        var appDir = Path.GetDirectoryName(Application.ExecutablePath);
        if (!IsOk(data, appDir)) { return false; }

        _BackingData = data;
        _AppDir = appDir;
        _TargetDirectory = data.TargetDirectory;
        _TargetNamespace = data.TargetNamespace;

        if (data.HasBlackAndWhite && !ProcessFile("BlackAndWhite.cs", "")) { return false; }
        if (data.HasScripts && !ProcessFile("Script.cs", "")) { return false; }
        if (data.HasForms && !ProcessDirectory("Forms")) { return false; }

        if (data.HasFascias)
        { 
            if (data.HasContexts && !ProcessDirectory("Contexts")) { return false; }
        }

        if (data.HasAssemblyInfo)
        {
            if (!GenerateAssemblyDefinitions()) { return false; }
        }

        return true;
    }

    private static bool ProcessDirectory(string subDirectory)
    {
        try
        {
            var sourceDir = Path.Combine(_AppDir, "EtlaToolbelt", subDirectory);
            if (!Directory.Exists(sourceDir))
            {
                var msg = $"Internal error: directory {sourceDir} does not exist";
                Log.Error(msg);
                MessageBox.Show(msg, "Internal error", MessageBoxButtons.OK);
                return false;
            }
            foreach (var filepath in Directory.GetFiles(sourceDir))
            {
                var filename = Path.GetFileName(filepath);
                var ok = ProcessFile(filename, subDirectory);
                if (!ok) 
                {
                    var msg = $"Internal error: Failed to process directory '{subDirectory}'";
                    Log.Error(msg);
                    return false; 
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            var msg = $"Internal error: Failed to process directory '{subDirectory}'";
            Log.Error(msg, ex);
            MessageBox.Show(msg, "Internal error", MessageBoxButtons.OK);
            return false;
        }
    }

    private static bool ProcessFile(string fileName, string subDirectory)
    {
        try
        {
            var sourceFilepath = Path.Combine(_AppDir, "EtlaToolbelt", subDirectory, fileName);
            if (!File.Exists(sourceFilepath))
            {
                var msg = $"Internal error: file {sourceFilepath} does not exist";
                Log.Error(msg);
                MessageBox.Show(msg, "Internal error", MessageBoxButtons.OK);
                return false;
            }

            var text = File.ReadAllText(sourceFilepath);
            text = text.Replace("namespace EtlaToolPicker", $"namespace {_TargetNamespace}");
            text = text.Replace("using EtlaToolPicker", $"using {_TargetNamespace}");

            var targetDir = Path.Combine(_TargetDirectory, "EtlaToolbelt", subDirectory);
            if (!Directory.Exists(targetDir)) { Directory.CreateDirectory(targetDir); }
            var targetFilepath = Path.Combine(targetDir, fileName);

            File.WriteAllText(targetFilepath, text);
            return true;
        }
        catch (Exception ex)
        {
            var msg = $"Internal error: Failed to process file '{fileName}'";
            Log.Error(msg, ex);
            MessageBox.Show(msg, "Internal error", MessageBoxButtons.OK);
            return false;
        }
    }

    private static bool GenerateAssemblyDefinitions()
    {
        try
        {
            _Builder = new StringBuilder();
            _Indent = 0;

            Scr($"namespace {_TargetNamespace}.Properties");
            Scr();
            Scr("public static class AssemblyDefinitions");
            Scr("{", 1);
            Scr("public const string MajorVersion = \"0\";");
            Scr("public const string MinorVersion = \"1\";");
            Scr("public const string Version = MajorVersion + \".\" + MinorVersion;");
            Scr();
            Scr($"public const string ApplicationName = \"{_BackingData.ApplicationName}\";");
            Scr($"public const string StartYear = \"2019\";");
            Scr($"public const string Company = \"{_BackingData.CompanyName}\";");
            Scr($"public const string CompanyFullName = \"{_BackingData.CompanyName}\";");
            Scr("public const string Copyright = Company + \" \" + StartYear + \"-\";");
            Scr("}", -1);

            var targetDir = Path.Combine(_TargetDirectory, "Properties");
            if (!Directory.Exists(targetDir)) { Directory.CreateDirectory(targetDir); }
            var targetFilepath = Path.Combine(targetDir, "AssemblyDefintions.cs");

            File.WriteAllText(targetFilepath, _Builder.ToString());

            if (!ProcessFile("AssemblyInfo.gitwcrev", "..\\Properties")) { return false; }
            if (!ProcessFile("PreBuild.cmd", "..\\Properties")) { return false; }
            return true;
        }
        catch (Exception ex)
        {
            var msg = $"Internal error: Failed to generate AssemblyDefinitions";
            Log.Error(msg, ex);
            MessageBox.Show(msg, "Internal error", MessageBoxButtons.OK);
            return false;
        }
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

    private static void Scr() => _Builder.AppendLine();
    private static void Scr(string str)
    { 
        _Builder.AppendLine();
        var tabs = new string('\t', _Indent);
        _Builder.Append(tabs);
        _Builder.Append(str); 
    }
    private static void Scr(string str, int indent)    
    {
        if (indent<0) { _Indent += indent; }
        Scr(str);
        if (indent>0) { _Indent += indent; }
    } 
}
