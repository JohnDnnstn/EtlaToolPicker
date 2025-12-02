using EtlaToolbeltPicker.EtlaToolbelt.CmdLines;
using EtlaToolbeltPicker.EtlaToolbelt.Infrastructure;

namespace EtlaToolbeltPicker.EtlaToolbelt
{
    /// <summary>An API for the implementation of code to analyse the command line which initiated this application
    /// Usage:
    /// 1) Define a list of strings (e.g. _Switches) to specify the command line switches that are understood/implemented
    /// 2) In the main function or similar, call:
    ///     CmdLine.DefineCmdLine(_Switches);
    /// It is then possible to call the other methods in the API, namely
    ///     CmdLine.GetSwitchesSupplied() - returns a list of the switches that were supplied
    ///     CmdLine.SwitchSupplied(name) - returns true if the switch was supplied on the command line
    ///     CmdLine.GetSwitch(name) - returns the value associated with the switch
    ///     CmdLine.OperandCount() - returns the number of non-switch cmmand line arguments
    ///     CmdLine.GetOperand(position) - returns the value of the 1-based non-switch argument
    /// The precise algorithm depends upon the underlying implementation of this API
    /// See <see cref="CmdLineImpl"/> for the default implementation
    /// </summary>
    public abstract class CmdLine : Fascia<ICmdLine, CmdLineImpl>
    {
        /// <summary>Defines the expected format of the command line
        /// Switches are arguments prefixed by one or two minus signs and may occur at any point and in any order
        /// Operands are defined by their position number on the command line, excluding switches
        /// </summary>
        /// <param name="switches">A list of the expected mandatory and optional switches.  The names may be prefixed by various non-alphabetic characters intended to indicate things like optionality</param>
        /// <param name="operandNames">Optional. A list of names for operands which can be used in help texts etc.</param>
        /// <param name="minOperand">Optional. The minimum number of operands. Default=0</param>
        /// <param name="maxOperand">Optional. The maximum number of operands. Default=999</param>
        public static void DefineCmdLine(List<string> switches, List<string>? operandNames = null, int minOperand = 0, int maxOperand = 999)
        {
            Implementation.DefineCmdLine(switches, operandNames, minOperand, maxOperand);
        }

        /// <summary>The method which compares the actual command line to the expected command line (as defined in the DefineCmdLine method)
        /// </summary>
        public static void Initialise() => Implementation.Initialise();

        /// <summary>Returns a list containing the names of the switches which were actually supplied on the command line</summary>
        /// <returns>A list containing the names of the switches which were actually supplied on the command line</returns>
        public static List<string> GetSwitchesSupplied() => Implementation.GetSwitchesSupplied();

        /// <summary>Reports whether a particular switch was actually supplied on the command line</summary>
        /// <param name="switchName">The name of the particular switch to check</param>
        /// <returns><c>true</c> if the switch was supplied; <c>false</c> otherwise</returns>
        public static bool SwitchSupplied(string switchName) => Implementation.SwitchSupplied(switchName);

        /// <summary>Returns the value of the command line switch if it was supplied or null otherwise.</summary>
        /// <param name="switchName">The switch to search for</param>
        /// <returns>The value of the command line switch if one was supplied; or null otherwise</returns>
        public static string? GetSwitch(string switchName) => Implementation.GetSwitch(switchName);

        /// <summary>Attempts to get a supplied switch value.</summary>
        /// <param name="switchName">The name of the switch being queried</param>
        /// <param name="switchValue">The value of the switch, if supplied, or "" otherwise</param>
        /// <returns><c>true</c> if the named switch was supplied, <c>false</c> otherwise</returns>
        public static bool TryGetSwitch(string switchName, out string switchValue) => Implementation.TryGetSwitch(switchName, out switchValue);

        /// <summary>Reports the number of operands supplied on the actual command line (excludes any switches)</summary>
        /// <returns>The number of operands supplied on the actual command line (excludes any switches)</returns>
        public static int OperandCount() => Implementation.OperandCount();

        /// <summary>Returns the value of a particular operand supplied on the actual command line</summary>
        /// <param name="position">The zero-based index of the operand position (i.e. first operand implies position 0)</param>
        /// <returns>The value of a particular operand supplied on the actual command line</returns>
        public static string GetOperand(int position) => Implementation.GetOperand(position);

        /// <summary>Returns the full command line that was supplied when the application was initiated</summary>
        /// <returns>The full command line</returns>
        public static string GetCmdLine() => Implementation.GetCmdLine();

        /// <summary>Returns the value of a named switch if it exists, or throws an exception if the switch was not supplied</summary>
        /// <param name="switchName">The name of the mandatory switch to be searched for</param>
        /// <returns>The value of the mandatory switch that was supplied on the command line</returns>
        /// <exception cref="Exception"> thrown when the named switch was not supplied on the command line</exception>
        public static string GetMandatorySwitch(string switchName) => Implementation.GetMandatorySwitch(switchName);

    }
}
