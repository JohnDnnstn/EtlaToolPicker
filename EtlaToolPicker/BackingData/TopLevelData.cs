using EtlaToolPicker.EtlaToolbelt.Forms;
using static EtlaToolPicker.Program;

namespace EtlaToolPicker.BackingData;

public class TopLevelData : IBackingData
{
    public string TargetDirectory { get; set; } = "";
    public string TargetNamespace { get; set; } = "";

    public bool HasBlackAndWhite { get; set; } = true;
    public bool HasScripts { get; set; } = false;
    public bool HasForms { get; set; } = false;
    public bool HasWizards { get; set; } = false;

    public bool HasFascias { get; set; } = true;
    internal bool HasCmdLines => HasFascias && CmdLines;
    internal bool HasConfigs => HasFascias && Configs;
    internal bool HasContexts => HasFascias && Contexts;
    internal bool HasLogs => HasFascias && Logs;
    public bool CmdLines { get; set; } = false;
    public bool Configs { get; set; } = false;
    public bool Contexts { get; set; } = false;
    public bool Logs { get; set; } = false;

    public bool HasAssemblyInfo { get; set; } = true;
    public string ApplicationName { get; set; } = "MyApp";
    public string CompanyName { get; set; } = "MyCo";

    public ZeroToThree ZeroToThree { get; set; } = ZeroToThree.TWO;


    public static List<TopLevelData> AllTopLevelData { get; set; } = [
        new TopLevelData() { ZeroToThree = ZeroToThree.TWO },
        new TopLevelData() { ZeroToThree = ZeroToThree.ONE },
        new TopLevelData() { ZeroToThree = ZeroToThree.THREE },
        new TopLevelData() { ZeroToThree = ZeroToThree.ZERO },
    ];
    public TopLevelData? Next { get; set; } = null;

    public static List<string> SomeStrings { get; set; } = ["x", "y", "z"];

    public string SomeString { get; set; } = "";

    public override string ToString() => ZeroToThree.ToString();
}
