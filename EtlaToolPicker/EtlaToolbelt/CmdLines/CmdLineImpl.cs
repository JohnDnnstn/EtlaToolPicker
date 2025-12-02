using System.Text;

namespace EtlaToolPicker.EtlaToolbelt.CmdLines;

/// <summary>The default implementation of the EtlaToolbelt CmdLine API
/// Usage:
/// A list of the expected/understood switches is passed into the DefineCmdLine method
/// This list is pre-processed.
/// When any of the other methods are invoked, the command line is analysed against this list
/// In the switch list, switch names can be prefixed with the following:
///  ? - indicates the switch is optional.  This is the default and can be omitted
///  + - indicates the switch is mandatory (an exception is thrown if it is missing)
///  / - indicates the switch is a file or directory  (an exception is thrown if there is no such file or directory)
/// The switch name may be suffixed by = followed by a descriptive string - this string is used in the "usage" message
/// 
/// Optionally, information about the operands (non-switch arguments) may also be passed in to the DefineCmdLine method
///  * a list of operand names - used in the "usage" message
///  * a minimum number of operands - an exception is thrown if there are too few
///  * a maximum number of operands - an exception is thrown if there are too many
/// Operand names may be prefixed by:
///  ? - indicates the operand is optional.  This is the default and can be omitted
///  + - indicates the operand is mandatory.  (an exception is thrown if it is missing)
/// Obviously for positional arguments, mandatory operands must come before optional ones.
/// 
/// On the command line itself, switches are prefixed by - or -- (the latter is preferred)
/// Any command line elemant that does not start with - or -- is considered to be an operand rather thana switch
/// Switches may optionally be suffixed by = and then a value (no spaces are allowed).  
/// Switch values are obtained with the GetSwitch method (if the switch is repeated, the last value is supplied)
/// Conversely the SwitchSupplied method merely returns true if the switch existed on the command line, false otherwise
/// and GetSwitchesSupplied returns a list of the switches which were found on the command line
/// 
/// If the Command line includes a -? or --? switch, a usage message is written to the console.
/// 
/// Note:
/// It is not necessary to explicitly Initialse this object 
/// (i.e. compare the command line against the definitions)
/// This will be done when the first method is invoked.
/// </summary>
public class CmdLineImpl : ICmdLine
{
    private bool _IsInitialised { get; set; } = false;
    private int _MinPositional { get; set; }
    private int _MaxPositional { get; set; }
    private readonly char[] _SwitchSplitter = ['='];
    private readonly List<string> _AllSwitches = [];
    private readonly List<string> _MandatorySwitches = [];
    private readonly List<string> _PathSwitches = [];
    private readonly Dictionary<string, string> _Switches = [];
    private readonly List<string> _Operands = [];

    private string _Usage { get; set; } = "";

    /// <summary>Defines the expected format of the command line
    /// Switches are arguments prefixed by one or two minus signs and may occur at any point and in any order
    /// Operands are defined by their position number on the command line, excluding switches
    /// </summary>
    /// <param name="switches">A list of the expected mandatory and optional switches.  The names may be prefixed by various non-alphabetic characters intended to indicate things like optionality</param>
    /// <param name="positionalNames">Optional. A list of names for operands which can be used in help texts etc.</param>
    /// <param name="minPositional">Optional. The minimum number of operands. Default=0</param>
    /// <param name="maxPositional">Optional. The maximum number of operands. Default=999</param>
    public void DefineCmdLine(List<string> switches, List<string>? positionalNames = null, int minPositional = 0, int maxPositional = 999)
    {
        StringBuilder builder = new();
        for (int ix = 0; ix < switches.Count; ++ix)
        {
            string[] elements = switches[ix].Split(_SwitchSplitter);
            var temp = elements[0];
            bool isMandatory = false;
            bool isPath = false;
            while (temp.StartsWith('?') || temp.StartsWith('+') || temp.StartsWith('/'))
            {
                if (temp.StartsWith('+'))   // mandatory switch
                {
                    isMandatory = true;
                }
                if (temp.StartsWith('/'))
                {
                    isPath = true;
                }
                temp = temp[1..];           // remove the meaingful prefix.  Note: ? is the default anyway so nothing to do
            }
            _AllSwitches.Add(temp);
            if (isMandatory) { _MandatorySwitches.Add(temp); }
            if (isPath) { _PathSwitches.Add(temp); }
            var arg = elements.Length < 2 ? "" : $"=<{elements[1]}>";
            _ = isMandatory ? builder.Append($" -{temp}{arg}") : builder.Append($" [-{temp}{arg}]");
        }
        if (positionalNames != null)
        {
            _MaxPositional = positionalNames.Count;
            for (int ix = 0; ix < _MaxPositional; ++ix)
            {
                var temp = positionalNames[ix];
                if (temp.StartsWith('+')) { temp = temp[1..]; } // remove any + prefix which is the default anyway
                if (temp.StartsWith('?'))                               // everything from here is optional
                {
                    _MinPositional = ix;
                    _ = builder.Append($" [{temp}]");
                }
                else
                {
                    _ = builder.Append($" <{temp}>");
                }
            }
        }
        else
        {
            _MinPositional = minPositional;
            _MaxPositional = maxPositional;
        }
        _Usage = builder.ToString();
    }

    /// <summary>The method which compares the actual command line to the expected command line (as defined in the DefineCmdLine method)
    /// </summary>
    public void Initialise()
    {
        string[] args = Environment.GetCommandLineArgs();
        for (int ix = 1; ix < args.Length; ++ix)
        {
            var arg = args[ix];
            if (arg.StartsWith("--")) { arg = arg[1..]; }
            if (arg.StartsWith('-'))
            {
                string[] elements = arg[1..].Split(_SwitchSplitter);
                _Switches.Add(elements[0], elements.Length > 1 ? elements[1] : "");
            }
            else
            {
                _Operands.Add(arg);
            }
        }
        if (_Switches.ContainsKey("?"))
        {
            Console.WriteLine($"{Context.App} {_Usage}");
            Environment.Exit(0);
        }
        if (_AllSwitches != null) { CheckArgs(); }
        _IsInitialised = true;
    }

    /// <summary>Reports whether a particular switch was actually supplied on the command line</summary>
    /// <param name="switchName">The name of the particular switch to check</param>
    /// <returns><c>true</c> if the switch was supplied; <c>false</c> otherwise</returns>
    public bool SwitchSupplied(string switchName)
    {
        if (!_IsInitialised) { Initialise(); }
        return _Switches.ContainsKey(switchName);
    }

    /// <summary>Returns the value of the command line switch if it was supplied or null otherwise.</summary>
    /// <param name="switchName">The switch to search for</param>
    /// <returns>The value of the command line switch if one was supplied; or null otherwise</returns>
    public string? GetSwitch(string switchName)
    {
        if (!_IsInitialised) { Initialise(); }
        return _Switches.TryGetValue(switchName, out string? val) ? val : null;
    }

    /// <summary>Returns the value of the command line switch if it was supplied or null otherwise.</summary>
    /// <param name="switchName">The switch to search for</param>
    /// <returns>The value of the command line switch if one was supplied; or null otherwise</returns>
    public bool TryGetSwitch(string switchName, out string switchValue)
    {
        if (!_IsInitialised) { Initialise(); }
        bool answer = _Switches.TryGetValue(switchName, out string? val);
        switchValue = val ?? "";
        return answer;
    }

    /// <summary>Returns a list containing the names of the switches which were actually supplied on the command line</summary>
    /// <returns>A list containing the names of the switches which were actually supplied on the command line</returns>
    public List<string> GetSwitchesSupplied() => [.. _Switches.Keys];

    /// <summary>Reports the number of operands supplied on the actual command line (excludes any switches)</summary>
    /// <returns>The number of operands supplied on the actual command line (excludes any switches)</returns>
    public int OperandCount()
    {
        if (!_IsInitialised) { Initialise(); }
        return _Operands.Count;
    }

    /// <summary>Returns the value of a particular operand supplied on the actual command line</summary>
    /// <param name="position">The zero-based index of the operand position (i.e. first operand implies position 0)</param>
    /// <returns>The value of a particular operand supplied on the actual command line</returns>        
    public string GetOperand(int position)
    {
        if (!_IsInitialised) { Initialise(); }
        return _Operands[position];
    }

    /// <summary>Returns the full command line that was supplied when the application was initiated</summary>
    /// <returns>The full command line</returns>
    public string GetCmdLine() => Environment.CommandLine; //temporary

    /// <summary>Returns the value of a named switch if it exists, or throws an exception if the switch was not supplied</summary>
    /// <param name="switchName">The name of the mandatory switch to be searched for</param>
    /// <returns>The value of the mandatory switch that was supplied on the command line</returns>
    /// <exception cref="Exception"> thrown when the named switch was not supplied on the command line</exception>
    public string GetMandatorySwitch(string switchName)
    {
        var answer = GetSwitch(switchName);
        if (answer.IsWhite())
        {
            var msg = $"Mandatory switch {switchName} was not supplied";
            Log.Fatal(msg);
            Log.Fatal(_Usage);
            throw new Exception(msg);
        }
        return answer;
    }

    private void CheckArgs()
    {
        var operandCount = _Operands.Count;
        if (operandCount < _MinPositional || operandCount > _MaxPositional)
        {
            throw new Exception($"Bad number of positional arguments ({operandCount}), expecting between {_MinPositional} and {_MaxPositional}");
        }
        foreach (var mandatory in _MandatorySwitches)
        {
            if (!_Switches.ContainsKey(mandatory))
            {
                var msg = $"Missing mandatory switch '{mandatory}'";
                Log.Fatal(msg);
                Log.Fatal(_Usage);
                Console.WriteLine(msg, _Usage);
                throw new Exception(msg);
            }
        }

        foreach (var switchName in _Switches.Keys)
        {
            if (!_AllSwitches.Contains(switchName))
            {
                throw new Exception($"Switch '{switchName}' is not recognised as valid switch");
            }
            if (_PathSwitches.Contains(switchName))
            {
                _Switches[switchName] = ToSafePath(_Switches[switchName]);
            }
        }
    }

    /// <summary>Converts nulls to empty strings and windows directory separators to unix-style
    /// This saves "\" being interpreted as an escape character 
    /// and avoids null values
    /// It is not foolproof but is usually sufficient
    /// </summary>
    /// <param name="str"></param>
    /// <returns>A string that is not null and that has any '\' replaced by '/'</returns>
    private static string ToSafePath(string? str) => str == null ? "" : str.Replace(@"\", "/");
}
