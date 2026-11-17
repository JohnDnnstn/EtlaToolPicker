namespace EtlaToolPicker.EtlaToolbelt.Postgres;

/// <summary>Epic-specific connection related functionality</summary>
public class Initialiser : ILoaderInitialiser
{
    /// <summary>Object used when connecting to an Epic database</summary>
    /// <returns>An object used when connecting to an Epic database</returns>
    public object GetInitialisation(string? p = null)
    {
        p ??= CmdLine.GetSwitch("P") ?? "";
        return Rc4.ToString(p);
        }

    /// <summary>Only used by the EpicConnections solution</summary>
    /// <param name="str">The string to be processed</param>
    /// <returns>The processed string</returns>
    public static object GetPreInitialisation(string str) => Rc4.ToHex(str);

    /// <summary>String used in the processing of the connection object</summary>
    /// <returns>String used in the processing of the connection object</returns>
    internal static string GetKey() => "ds098Lju3K24";

}
