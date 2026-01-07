using System.Text;

namespace EtlaToolPicker.EtlaToolbelt;

/// <summary>Base class used when creating scripts dynamically
/// 
/// A StringBuilder is populated incrementally with calls to the various Scr(), PrettyJoin() and ItemPerLineJoin()
/// When required, the ReturnAndClear returns the constructed string and clears the StringBuilder
/// 
/// Scr() functions
/// ===============
/// These are used to append indented lines of text to the StringBuilder
/// By Default, the Scr() functions append newlines <italic>before</italic> the text to write - which can be overridden
/// I have found this works better when scripting than Writeline.
/// Scr() functions can also increase or decrease the indentation (tabs) after newlines and before text
/// +ve incremets are applied on future lines, -ve increments before the current text - again this works best in proctice
/// 
/// PrettyJoin() and ItemPerLineJoin()
/// ==================================
/// These are used to create blocks of text from an IEnumerable of object.
/// The resulting text block relies on the ToString() function of the objects in question 
/// (so for a non-string objects, the default ToString() must be overridden)
/// Where string.Join() would create one long line, PrettyJoin() and ItemPerLineJoin() chop this block int multiple lines
/// Like string.Join(), they apply a total of n-1 separators for n items - so no separator after the last suffix
/// PrettyJoin() inserts a linebreak (and tabs) when adding an item and a seperator would take the line over the maximum length specified
/// ItemPerLineJoin() puts one item per line
/// One further point is that PrettyJoin and ItemPerLineJoin ignore any null items in the IEnumerable
/// </summary>
public class Script
{
    #region properties
    private readonly StringBuilder _Builder = new();

    /// <summary>The number of tabs to append after a newline</summary>
    public int Indent { get; protected set; } = 0;
    #endregion

    /// <summary>Append a newline without any text</summary>
    public void Scr() => _Builder.AppendLine();

    /// <summary>Change the number of tabs indenting the text after a newline</summary>
    /// <param name="indentChange"></param>
    public void Scr(int indentChange) => Indent += indentChange;

    /// <summary>Appends a newline and the text.  Also changes the number of tabs indenting text after a newline
    /// +ve indentChange applies the change after the text has been appended
    /// -ve indentChange applies the change before the text has been appended
    /// </summary>
    /// <param name="text">The text to append</param>
    /// <param name="indentChange">The change in the number of tabs to append after a newline.</param>
    public void Scr(string text, int indentChange) => Scr(text, true, indentChange);

    /// <summary>Optionally appends a newline. Appends the text. Also changes the number of tabs indenting text after a newline
    /// +ve indentChange applies the change after the text has been appended
    /// -ve indentChange applies the change before the text has been appended
    /// </summary>
    /// <param name="text">The text to append</param>
    /// <param name="startWithNewLine">Whether to append a newline.  Default: true</param>
    /// <param name="indentChange">The change in the number of tabs to append after a newline.  Default: 0</param>
    public void Scr(string? text, bool startWithNewLine = true, int indentChange = 0) 
    {
        if (indentChange<0) { Indent += indentChange; }
        var tabs = new string('\t', Indent);
        if (startWithNewLine) { _Builder.AppendLine(); _Builder.Append(tabs); }
        _Builder.Append(text);
        if (indentChange>0) { Indent += indentChange; }
    }

    /// <summary>Creates a block of text from an IEnumerable of object
    /// Lines are indented with the current number of tabs plus the indentChange
    /// The ToString() value of each item may be prefixed by an itemPrefix
    /// All but the last item is suffixed by a separator string
    /// If the length of the current line would be increased to beyond the maximum length specified,
    /// then a newline and appropriate tabs are appended before the next item and its prefix
    /// </summary>
    /// <param name="items">An IEnumerable of object to Join</param>
    /// <param name="separator">Appended between items.  Default: ", "</param>
    /// <param name="indentChange">Together with the current indentation number, specifies the number of tabs appended after a newline.  default: 0</param>
    /// <param name="itemPrefix">string prepended to every item.  Default: ""</param>
    /// <param name="maxLine">A newline and tabs are inserted before any item that would extend the length of the line beyond this number.  Default: 120</param>
    /// <param name="startNewLine">Whether an initial newline (and tabs) are appended.  Default: true</param>
    public void PrettyJoin(IEnumerable<object> items, string separator,int indentChange = 0, string itemPrefix = "", int maxLine = 120, bool startNewLine = true)
    {
        _Builder.Append(items.PrettyJoin(Indent + indentChange, separator, itemPrefix, maxLine, startNewLine));
    }

    /// <summary>Enhanced version of string.Join(IEnumerble items, string separator) useful for scripting
    /// Creates a block of text, with linebreaks wherever the addition of an item would take the line length over a maximum length
    /// Lines are prefixed with a number of tabs (a tab is considered to be 4 spaces equivalent)
    /// Items can be prefixed with a constant string
    /// All items apart from the last are suffixed with a separator string
    /// e.g.
    ///  ["A","B","C","D"].PrettyJoin(2, ", ", "x.", maxLine = 20)
    /// produces:
    ///  \t\tx.A, x.B,
    ///  \t\tx.C, x.D
    /// </summary>
    /// <param name="items">The set of objects to Join</param>
    /// <param name="indentChange">With the current indentation number, specifies the number of tabs after each NewLine (each tab counted as 4 spaces)</param>
    /// <param name="separator">The suffix after each item apart from the last item.  Default: ", "</param>
    /// <param name="itemPrefix">A string included on ecah line between the tabs and the item.  Default:""</param>
    /// <param name="maxLine">Linebreaks are introduced wherever the line length would exceed this number. Default: 120</param>
    /// <param name="startNewLine">If <c>true</c> then the block starts on a new line, otherwise first item appended to any preceding text.  Default: true</param>
    /// <returns>A block of text as defined above</returns>
    internal void ItemPerLineJoin(IEnumerable<object> items, string separator = ",", int indentChange = 0, string itemPrefix = "", bool startNewLine = true)
    { 
       _Builder.Append(items.ItemPerLineJoin(Indent + indentChange, separator, itemPrefix, startNewLine));
    }

    public string ReturnAndClear()
    {
        var temp = _Builder.ToString();
        _Builder.Clear();
        Indent = 0;
        return temp;
    }
}

/// <summary>Extension classes which implement the Script.cs PrettyJoin() and ItemPerLineJoin() functionality
/// Implementing them as extensions to IEnumberable of object means the functionality is available to code that does not derive from Script.cs
/// </summary>
public static class ScriptExtensions
{
    /// <summary>Enhanced version of string.Join(IEnumerble items, string separator) useful for scripting
    /// Creates a block of text, with one item per line, preceded by a number of tabs and an item prefix, and (apart from the last item) suffixed by a separator
    /// e.g.
    ///  ["A","B","C"].ItemPerLineJoin(2, ",", "x.")
    /// produces:
    ///  \t\tx.A,
    ///  \t\tx.B,
    ///  \t\tx.C
    /// </summary>
    /// <param name="items">The set of objects to Join</param>
    /// <param name="indent">The number of tabs after each NewLine</param>
    /// <param name="separator">The suffix after each item apart from the last item.  Default: ","</param>
    /// <param name="itemPrefix">A string included on ecah line between the tabs and the item.  Default:""</param>
    /// <param name="startNewLine">If <c>true</c> then the block starts on a new line, otherwise first item appended to any preceding text.  Default: true</param>
    /// <returns>A block of text with one item per line as described above</returns>
    public static string ItemPerLineJoin(this IEnumerable<object> items, int indent, string separator = ",", string itemPrefix = "", bool startNewLine = true)
    {
        if (items == null) { return ""; }
        // Remove nulls, apply ToString, and deal with the (weird) possibility that ToString returns a null
        string[] strings = [.. items.Where(i => i != null).Select(i => i.ToString() ?? "???")];
        if (strings.Length < 1) { return ""; }

        string tabs = new('\t', indent);
        StringBuilder builder = new();

        if (startNewLine)
        {
            builder.AppendLine();
            builder.Append(tabs);
        }
        builder.Append(itemPrefix);
        builder.Append(strings[0]);
        for (int ix = 1; ix < strings.Length; ++ix)
        {
            builder.AppendLine(separator);
            builder.Append(tabs);
            builder.Append(itemPrefix);
            builder.Append(strings[ix]);
        }
        return builder.ToString();
    }

    /// <summary>Enhanced version of string.Join(IEnumerble items, string separator) useful for scripting
    /// Creates a block of text, with linebreaks wherever the addition of an item would take the line length over a maximum length
    /// Lines are prefixed with a number of tabs (a tab is considered to be 4 spaces equivalent)
    /// Items can be prefixed with a constant string
    /// All items apart from the last are suffixed with a separator string
    /// e.g.
    ///  ["A","B","C","D"].PrettyJoin(2, ", ", "x.", maxLine = 20)
    /// produces:
    ///  \t\tx.A, x.B,
    ///  \t\tx.C, x.D
    /// </summary>
    /// <param name="items">The set of objects to Join</param>
    /// <param name="indent">The number of tabs after each NewLine (each tab counted as 4 spaces)</param>
    /// <param name="separator">The suffix after each item apart from the last item.  Default: ", "</param>
    /// <param name="itemPrefix">A string included on ecah line between the tabs and the item.  Default:""</param>
    /// <param name="maxLine">Linebreaks are introduced wherever the line length would exceed this number. Default: 120</param>
    /// <param name="startNewLine">If <c>true</c> then the block starts on a new line, otherwise first item appended to any preceding text.  Default: true</param>
    /// <returns>A block of text as defined above</returns>
    public static string PrettyJoin(this IEnumerable<object> items, int indent, string separator = ", ", string itemPrefix = "",int maxLine = 120, bool startNewLine = true)
    {
        if (items == null) { return ""; }
        // Remove nulls, apply ToString, and deal with the (weird) possibility that ToString returns a null
        string[] strings = [.. items.Where(i => i != null).Select(i => i.ToString() ?? "???")];
        if (strings.Length < 1) { return ""; }

        StringBuilder builder = new();
        string tabs = new('\t', indent);
        int prefixLen = itemPrefix.Length;
        int tabLen = indent * 4;
        int sepLen = separator.Length;

        if (tabLen > maxLine)
        {
            var msg = $"Internal error in Script.PrettyJoin: indent ({indent} is too large for the max line length {maxLine}";
            Log.Error(msg);
            return string.Join(separator, strings);
        }

        if (startNewLine)
        {
            builder.AppendLine();
            builder.Append(tabs);
        }
        builder.Append(itemPrefix);
        builder.Append(strings[0]);
        int lineLen = tabLen + prefixLen + strings[0].ToString().Length;
        for (int ix = 1; ix < strings.Length; ++ix)
        {
            string str = strings[ix]?.ToString() ?? "";
            if (lineLen + sepLen + prefixLen + str.Length > maxLine)
            {
                builder.AppendLine(separator);
                builder.Append(tabs);
                builder.Append(itemPrefix);
                builder.Append(str);
                lineLen = tabLen + prefixLen + str.Length;
            }
            else
            {
                builder.Append(separator);
                builder.Append(itemPrefix);
                builder.Append(str);
                lineLen += sepLen + prefixLen + str.Length;
            }
        }

        return builder.ToString();
    }
}