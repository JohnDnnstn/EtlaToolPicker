namespace EtlaToolPicker.EtlaToolbelt.StringUtilities;

public static class Plurals
{
    public static string ToSingular(this string? str)
    {
        if (str.IsWhite()) { return ""; }
        var lower = str.ToLower();
        if (lower == "species") { return str; }
        if (lower.EndsWith("ies")) { return str[..^3] + "y"; }
        if (lower.EndsWith("statuses")) { return str[..^2]; }
        if (lower.EndsWith('s')) { return str[..^1]; }
        return str;
    }

    public static string ToPlural(this string? str)
    {
        if (str.IsWhite()) { return ""; }
        var lower = str.ToLower();
        if (lower == "species") { return str; }
        if (lower.EndsWith("status")) { return str + "es"; }
        if (lower.EndsWith('s')) { return str; }
        if (lower.EndsWith('y')) { return str[..^1] + "ies"; }
        return str + 's';
    }
}
