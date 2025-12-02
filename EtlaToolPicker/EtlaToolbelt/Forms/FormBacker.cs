namespace EtlaToolPicker.EtlaToolbelt.Forms;

/// <summary>This class sets up a relationship between the Controls of a Form and a Backing object
/// On the form being loaded, the form's controls are initialised to the contents of backing properties
/// On the form being closed, the backing data properties are changed to match the equivalent control values
/// </summary>
public class FormBacker
{
    protected IBackingData Data { get; set; }

    protected List<ControlBacker> ControlBackers { get; set; } = [];

    public FormBacker(IBackingData data) { Data = data; }

    public void Add(ControlBacker ctrlBacker) => ControlBackers.Add(ctrlBacker);
}
