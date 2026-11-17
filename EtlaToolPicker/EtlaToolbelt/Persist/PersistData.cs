using System.Text.Json;

namespace EtlaToolPicker.EtlaToolbelt.Persist;

/// <summary>This class persists objects to and from a file, in JSON formal
/// The standard location for a file for this user, for this application company, for this appication is
///     Environment.SpecialFolder.ApplicationData\
///     CompanyName\
///     Application
/// e.g.
///     c:\users\&lt;user&gt;\AppData\Roaming\SRUC\GenericFeedWizard
/// Optionally, an additional leafDir-directory and/or sub-directory (between the standard location and the leafDir can be specified
/// Null or empty-string leafDir-directories/sub-directories are ignored
/// </summary>
/// <typeparam name="T">The type of object being serialized or deserialised</typeparam>
public static class PersistData<T> where T : new()
{
    private static readonly JsonSerializerOptions _JsonSerialisationOptions = new() { WriteIndented = true };

    //private const string _FeedName = "persistence";
    //private const string _Env = "test";
    private static readonly string _Company = Context.Company ?? "ETLA Services Ltd";
    private static readonly string _App = Context.App;

    /// <summary>Deserialises an object from JSON text stored in a file</summary>
    /// <param name="fileBasename">Basename part of the file</param>
    /// <param name="leafDir">Optional. Use this leaf directory</param>
    /// <param name="twigDir">Optional. Use this sub-directory of the standard location</param>
    /// <returns>An object of type T if the file exists or a new object of type T otherwise</returns>
    public static T LoadData(string fileBasename, string? leafDir = null, string? twigDir = null)
    {
        twigDir ??= "";
        leafDir ??= "";
        var fileName = GetFilepath(fileBasename, leafDir, twigDir);
        if (File.Exists(fileName))
        {
            var jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<T>(jsonString) ?? new();
        }
        return new();
    }

    /// <summary>Serialises an object of type T and saves it to a file</summary>
    /// <param name="data">The object to be serialised and saved to file</param>
    /// <param name="fileBasename">Part of the name of the persisting file</param>
    /// <param name="leafDir">Optionally, a leafDir directory for the persisting path</param>
    /// <param name="twigDir">Optional. Use this sub-directory of the standard location</param>
    public static void SaveData(T data, string fileBasename, string? leafDir = null, string? twigDir = null)
    {
        twigDir ??= "";
        leafDir ??= "";
        var fileName = GetFilepath(fileBasename, leafDir, twigDir);
        var jsonString = JsonSerializer.Serialize(data, _JsonSerialisationOptions);
        File.WriteAllText(fileName, jsonString);
    }

    /// <summary>Gets a persisting file's filepath
    /// Guarantees directory extsts but not that the file exists
    /// </summary>
    /// <param name="fileBasename"></param>
    /// <param name="twigDir">Optional. Use this sub-directory of the standard location</param>
    /// <param name="leafDir">An optional leafDir directory.</param>
    /// <returns>A persisting file's filepath</returns>
    private static string GetFilepath(string feedBaseName, string? leafDir = null, string? twigDir = null)
    {
        twigDir ??= "";
        leafDir ??= "";
        var dir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            _Company,
            _App,
            twigDir,
            leafDir);
        if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

        return Path.Combine(dir, feedBaseName + ".json");
    }
}
