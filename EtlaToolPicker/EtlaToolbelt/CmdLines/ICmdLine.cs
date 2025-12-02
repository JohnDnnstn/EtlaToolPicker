namespace EtlaToolPicker.EtlaToolbelt.CmdLines;

/// <summary>This defines the properties and methods that relate to understanding the command line used to initiate the application
/// Note to implementors:
///  Only the GetMandatorySwitch should throw an exception (if the mandatory switch was not supplied)
///  All other methods defined here must never throw an exception 
/// </summary>
public interface ICmdLine
{
    /// <summary>Defines the expected format of the command line
    /// Switches are arguments prefixed by one or two minus signs and may occur at any point and in any order
    /// Operands are defined by their position number on the command line, excluding switches
    /// </summary>
    /// <param name="switches">A list of the expected mandatory and optional switches.  The names may be prefixed by various non-alphabetic characters intended to indicate things like optionality</param>
    /// <param name="operandNames">Optional. A list of names for operands which can be used in help texts etc.</param>
    /// <param name="minOperand">Optional. The minimum number of operands. Default=0</param>
    /// <param name="maxOperand">Optional. The maximum number of operands. Default=999</param>
    void DefineCmdLine(List<string> switches, List<string>? operandNames = null, int minOperand = 0, int maxOperand = 999);

    /// <summary>The method which compares the actual command line to the expected command line (as defined in the DefineCmdLine method)
    /// </summary>
    void Initialise();

    /// <summary>Returns a list containing the names of the switches which were actually supplied on the command line</summary>
    /// <returns>A list containing the names of the switches which were actually supplied on the command line</returns>
    List<string> GetSwitchesSupplied();

    /// <summary>Reports whether a particular switch was actually supplied on the command line</summary>
    /// <param name="switchName">The name of the particular switch to check</param>
    /// <returns><c>true</c> if the switch was supplied; <c>false</c> otherwise</returns>
    bool SwitchSupplied(string switchName);

    /// <summary>Returns the value of the command line switch if it was supplied or null otherwise.</summary>
    /// <param name="switchName">The switch to search for</param>
    /// <returns>The value of the command line switch if one was supplied; or null otherwise</returns>
    string? GetSwitch(string switchName);

    /// <summary>Attempts to get a supplied switch value.</summary>
    /// <param name="switchName">The name of the switch being queried</param>
    /// <param name="switchValue">The value of the switch, if supplied, or "" otherwise</param>
    /// <returns><c>true</c> if the named switch was supplied, <c>false</c> otherwise</returns>
    bool TryGetSwitch(string switchName, out string switchValue);

    /// <summary>Reports the number of operands supplied on the actual command line (excludes any switches)</summary>
    /// <returns>The number of operands supplied on the actual command line (excludes any switches)</returns>
    int OperandCount();

    /// <summary>Returns the value of a particular operand supplied on the actual command line</summary>
    /// <param name="position">The zero-based index of the operand position (i.e. first operand implies position 0)</param>
    /// <returns>The value of a particular operand supplied on the actual command line</returns>
    string GetOperand(int position);

    /// <summary>Returns the full command line that was supplied when the application was initiated</summary>
    /// <returns>The full command line</returns>
    string GetCmdLine();

    /// <summary>Returns the value of a named switch if it exists, or throws an exception if the switch was not supplied</summary>
    /// <param name="switchName">The name of the mandatory switch to be searched for</param>
    /// <returns>The value of the mandatory switch that was supplied on the command line</returns>
    /// <exception cref="Exception"> thrown when the named switch was not supplied on the command line</exception>
    string GetMandatorySwitch(string switchName);
}
