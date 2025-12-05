namespace EtlaToolPicker.BackingData;

public class TopLevelData
{
    public string TargetDirectory { get; set; } = "";
    public string TargetNamespace { get; set; } = "";

    public bool HasBlackAndWhite { get; set; } = true;
    public bool HasScripts { get; set; } = false;
    public bool HasForms { get; set; } = false;
    public bool HasWizards { get; set; } = false;
    public bool HasFascias { get; set; } = false;
    public bool HasCmdLines { get; set; } = false;
    public bool HasContexts { get; set; } = false;
    public bool HasLogs { get; set; } = false;

}
