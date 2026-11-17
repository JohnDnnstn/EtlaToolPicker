using EtlaToolPicker.EtlaToolbelt.CmdLines;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EtlaToolPicker.EtlaToolbelt.CmdLines2;

/// <summary>Implements a command line processor
/// The class is initialised with a set of definitions and then these are checked against the actual command line
/// 
/// All switches on the command line start with a "--" or "-" follwed by their name.  The name is CASE SENSITIVE.  Pascal case is the default
/// Switches that are not "existential" must then be followed by "=" and then their value
/// 
/// The definitions must be supplied as a List of strings, with each string being in the following format:
/// Optional initial prefix:
///     ! The switch is mandatory.  An exception is thrown if the switch is not present
///     ? The switch has a value "True" if present and "False" if absent.
///     | Specifies that what follows indicates something mandatory that can take different forms (see below) e.g. either a file path or a directory and a file name) but one form is mandatory
/// The switch name
/// Zero or more alternate switch names in the format:
///     |altenate_name
/// An optional default specifier in the format
///     =default
/// An optional help string in the format
///     ?help_string
///     
/// e.g.
///     ?MyExistentialSwitch
/// describes a switch which is either present on the Command line (value="True") or absent (value="False")
///     MyOptionalSwitch=MyDefault
/// describes a switch which is not mandatory.  If absent on the Command Line it takes a default value
/// 
/// Switch definitions that start with a | are intended to provide alternatives ways of describing a value that can be derived in different ways
/// For example a file might be described either as a filepath or as a directory and a filename, but one or other descripion is mandatory
/// The switches involved must have already been defined.
/// To fill out the example above, the definitions might look like the following
///     FeedFilePath
///     FeedDirectory=.
///     FeedFile
///     |(FeedFilePath)|(FeedDirectory&FeedFile)]
/// That would specify that either 
///     * either the FeedFilePath switch must be present 
///     * or the FeedFile switch must be present and the FeedFileDirectory is present or defaults to the current directory
///     
/// </summary>
public class CmdLine2Impl
{
    private int _MinPositional { get; set; }
    private int _MaxPositional { get; set; }

    public ICmdLineExtraChecks ExtraChecks { get; set; } = new CmdLineNoExtraChecks();


    private readonly char[] _SwitchSplitter = ['='];
    private readonly List<string> _AllSwitches = [];
    private readonly List<string> _MandatorySwitches = [];
    private readonly List<string> _PathSwitches = [];
    private readonly Dictionary<string, string> _Switches = [];
    private readonly List<string> _Operands = [];

    /// <summary>Contains the supplied values of supplied switches
    /// For existential switches, contains "True" if the switch was supplied and "False" otherwise
    /// For switches with alternative names, each alterantive is present with the same value
    /// </summary>
    private readonly Dictionary<string, string> _SwitchValues = [];

    public void Init(List<string> switches, List<string>? operandNames = null, int minOperand = 0, int maxOperand = 999) 
    {
        _MinPositional = minOperand;
        _MaxPositional = maxOperand;
        DefineCmdLine(switches, operandNames, minOperand, maxOperand);
        ProcessCmdLine();
    }

    /// <summary>Checks whether a switch has been supplied
    /// Note: Existential switches are always assumed to be supplied (value "True" if they were on the command line, "False" otherwise)
    /// </summary>
    /// <param name="switchName"></param>
    /// <returns><c>true</c> if the switch was supplied, <c>false</c> otherwise</returns>
    public bool Exists(string switchName) => _SwitchValues.ContainsKey(switchName);

    /// <summary>Returns the value of a switch
    /// Note: 
    ///     If the switch is an existential switch, then if the switch was present then the string "True" is returned otherwise the string "False" is returned
    ///     If the switch was supplied, then the value of the switch is returned
    ///     If the switch is mandatory and was not supplied then, the initialisation should throw an exception so this is not dealt with
    ///     If a default for a missing optional switch has been supplied then the default is supplied
    ///     Otherwise returns a null
    /// </summary>
    /// <param name="switchName">The name of the switcjh whoose value should be returned</param>
    /// <returns>Returns the value of the switch</returns>
    public string? this[string switchName] => !_SwitchValues.TryGetValue(switchName, out var val) ? null : val;

    public string? Get(string switchName) => this[switchName];

    public T Get<T>(string switchName, IFormatProvider? format = null) where T : IParsable<T>
    {
        if (TryGet(switchName, out T? answer, out string? msg, format)) { return answer; }
        Log.Warn(msg);
        throw new Exception(msg);
    }

    public bool TryGet<T>(string switchName, out T? answer, IFormatProvider? format = null) where T : IParsable<T> => TryGet(switchName, out answer, out _, format);

    public bool TryGet<T>(string switchName, [NotNullWhen(true)] out T? answer, [NotNullWhen(false)] out string? msg, IFormatProvider? format = null) 
        where T : IParsable<T>
    {
        msg = null;
        answer = default;
        string? val = this[switchName];
        if (val == null) { msg = $"No switch '{switchName}' was supplied"; return false; }
        if (!T.TryParse(val, format, out answer)) { msg = $"Failed to parse switch '{switchName}', value='{val}' as '{typeof(T)}'"; return false; }
        return true;
    }

    /// <summary>Defines the expected format of the command line
    /// Switches are arguments prefixed by one or two minus signs and may occur at any point and in any order
    /// Operands are defined by their position number on the command line, excluding switches
    /// </summary>
    /// <param name="switches">A list of the expected mandatory and optional switches.  The names may be prefixed by various non-alphabetic characters intended to indicate things like optionality</param>
    /// <param name="positionalNames">Optional. A list of names for operands which can be used in help texts etc.</param>
    /// <param name="minPositional">Optional. The minimum number of operands. Default=0</param>
    /// <param name="maxPositional">Optional. The maximum number of operands. Default=999</param>
    private void DefineCmdLine(List<string> switches, List<string>? operandNames = null, int minOperand = 0, int maxOperand = 999)
    {
        for (int ix = 0; ix < switches.Count; ++ix)
        {
            char[] sw = switches[ix].ToArray<char>();
            while (sw[ix] == '!')
                DefineSwitch(switches[ix]);
        }
    }

    private void DefineSwitch(string str)
    { 

    }

    private void ProcessCmdLine()
    { 
    }
}
