namespace EtlaToolbeltPicker.EtlaToolbelt.Forms;

public class ControlBacker
{
    protected Control Ctrl {  get; set; }
    protected string CtrlPropertyName { get; set; }

    protected string BackingPropertyName { get; set; }

    public ControlBacker(Control chkBox, string ctrlPropertyName, string backingPropertyName)
    {
        Ctrl = chkBox;
        CtrlPropertyName = ctrlPropertyName;
        BackingPropertyName = backingPropertyName;
    }

    /// <summary>Sets the Control's property with the value currently in the backing data object's property
    /// <see cref="ObjectPropertyExternsions"/> for the mechanism for getting and setting properties of objects by name
    /// </summary>
    /// <param name="data">The backing data object</param>
    public virtual void Load(IBackingData data)
    {
        var val = data.GetPropertyValue(BackingPropertyName);
        Ctrl.SetPropertyValue(CtrlPropertyName, val);
    }

    /// <summary>Sets the BackingData's property with the value currently in the Control's object's property
    /// <see cref="ObjectPropertyExternsions"/> for the mechanism for getting and setting properties of objects by name
    /// </summary>
    /// <param name="data">The backing data object</param>
    public virtual void Save(IBackingData data)
    {
        var val = Ctrl.GetPropertyValue(CtrlPropertyName);
        data.SetPropertyValue(BackingPropertyName, val);
    }
}


public class RadioButtonBacker<T> : ControlBacker where T : Enum
{
    protected T Val {  get; set; }

    public RadioButtonBacker(RadioButton rdoButton, string backingPropertyName, T val) : base(rdoButton, "Checked", backingPropertyName)
    {
        Val = val;
    }

    public override void Load(IBackingData data)
    {
        var val = data.GetPropertyValue(BackingPropertyName);
        ((RadioButton)Ctrl).Checked = val is T t && t.Equals(Val);
    }

    public override void Save(IBackingData data)
    {
        if (((RadioButton)Ctrl).Checked) { data.SetPropertyValue(BackingPropertyName, Val); }
    }
}
