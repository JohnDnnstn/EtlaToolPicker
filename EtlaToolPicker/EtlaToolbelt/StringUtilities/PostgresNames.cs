using System.Text.RegularExpressions;

namespace EtlaToolPicker.EtlaToolbelt.StringUtilities;

public static partial class PostgresNames
{
    public static string MakePostgresName(this string str)
    {
        // Remove enclosing quotes
        str = str.Trim('"');

        // Replace non-word characters with underscore
        str = _NonWordChars().Replace(str, "_");

        // Remove trailing underscores
        str = str.TrimEnd('_');

        // Prefix a starting digit with an underscore
        str = _StartingDigit().Replace(str, "_$1");

        // Replace <not_upper><upper> with <not_upper>_<upper>
        str = _NonUpperFollowedByUpper().Replace(str, "$1_$2");

        // Dedupe multiple underscores
        str = _MultipleUnderscores().Replace(str, "_");

        // Make everything lower case
        str = str.ToLower();

        return str;
    }

    #region Regexes
    [GeneratedRegex(@"\W")]
    private static partial Regex _NonWordChars();

    [GeneratedRegex(@"^(\d)")]
    private static partial Regex _StartingDigit();

    [GeneratedRegex(@"(\P{Lu})(\p{Lu})")]
    private static partial Regex _NonUpperFollowedByUpper();

    [GeneratedRegex(@"_+")]
    private static partial Regex _MultipleUnderscores();
    #endregion
}

