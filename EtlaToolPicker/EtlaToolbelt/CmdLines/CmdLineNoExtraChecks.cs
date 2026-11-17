namespace EtlaToolPicker.EtlaToolbelt.CmdLines;

public class CmdLineNoExtraChecks : ICmdLineExtraChecks
{
    public bool DefineCheck(string extraDefinition) {  return false; }
    public bool ChecksOk() { return true; }
}
