namespace EtlaToolPicker.EtlaToolbelt.CmdLines;

public interface ICmdLineExtraChecks
{
    bool DefineCheck(string extraDefinition);
    bool ChecksOk();
}
