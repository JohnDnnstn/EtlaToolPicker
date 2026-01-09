namespace EtlaToolPicker.EtlaToolbelt.Forms;

public abstract class AbstractControlBacker
{ 
    public abstract bool TryLoad(IBackingData backingData, out string msg);
    public abstract bool TrySave(IBackingData backingData, out string msg);
}

public class ControlBacker<T>() : AbstractControlBacker
{
    protected Control Ctrl { get; set; } = null!;
    protected string CtrlPropertyName { get; set; } = null!;
    protected string BackingPropertyName { get; set; } = null!;

    public ControlBacker(Control ctrl, String ctrlPropertyName, String backingPropertyName) : this()
    {
        Ctrl = ctrl;
        CtrlPropertyName = ctrlPropertyName;
        BackingPropertyName = backingPropertyName;
    }

    /// <summary>Tries to set the Control's property with the value currently in the backing data object's property
    /// <see cref="ObjectPropertyExtensions"/> for the mechanism for getting and setting properties of objects by name
    /// </summary>
    /// <param name="data">The backing data object</param>
    /// <param name="msg">An error message if the method failed</param>
    /// <returns><c>true</c> if the method succeeded; <c>false</c> otherwise</returns>
    public override bool TryLoad(IBackingData data, out string msg)
    {
        bool ok = data.TryGetPropertyValue(BackingPropertyName, out T? val, out msg);
        if (!ok) 
        {
            var thisMsg = $"Failed to get backing data property {BackingPropertyName} when loading {Ctrl.Name}";
            Log.Error(thisMsg);
            msg += "\n" + thisMsg;
            return false; 
        }

        ok = Ctrl.TrySetPropertyValue<T>(CtrlPropertyName, val, out msg);
        if (!ok)
        {
            var thisMsg = $"Failed to load {Ctrl.Name} from backing data";
            Log.Error(thisMsg);
            msg += "\n" + thisMsg;
        }
        return ok;
    }

    /// <summary>Tries to set the BackingData's property with the value currently in the Control object's property
    /// <see cref="ObjectPropertyExtensions"/> for the mechanism for getting and setting properties of objects by name
    /// </summary>
    /// <param name="data">The backing data object</param>
    /// <param name="msg">An error message if the method failed</param>
    /// <returns><c>true</c> if the method succeeded; <c>false</c> otherwise</returns>
    public override bool TrySave(IBackingData data, out string msg)
    {
        bool ok = Ctrl.TryGetPropertyValue<T>(CtrlPropertyName, out T? val, out msg);
        if (!ok)
        {
            var thisMsg = $"Failed to get property {CtrlPropertyName} of control when saving {Ctrl.Name}";
            Log.Error(msg);
            msg += "\n" + thisMsg;
            return false;
        }

        ok = data.TrySetPropertyValue<T>(BackingPropertyName, val, out msg);
        if (!ok)
        {
            var thisMsg = $"Failed to set backing property {BackingPropertyName} when saving {Ctrl.Name}";
            Log.Error(thisMsg);
            msg += "\n" + thisMsg;
        }
        return ok;
    }
}


public class RadioButtonBacker<E>(RadioButton rdoButton, string backingPropertyName, E val) 
    : ControlBacker<E>(rdoButton, nameof(rdoButton.Checked), backingPropertyName) where E : Enum
{
    protected E? Val { get; set; } = val;

    public override Boolean TryLoad(IBackingData data, out String msg)
    {
        bool ok = data.TryGetPropertyValue<E>(BackingPropertyName, out E? val, out msg);
        if (!ok)
        {
            var thisMsg = $"Failed to get backing data property {BackingPropertyName} when loading {Ctrl.Name}";
            Log.Error(thisMsg);
            msg += "\n" + thisMsg;
            return false;
        }

        ((RadioButton)Ctrl).Checked = val is E e && e.Equals(Val);
        return true;
    }

    public override bool TrySave(IBackingData data, out String msg)
    {
        if (((RadioButton)Ctrl).Checked)
        {
            bool ok = data.TrySetPropertyValue(BackingPropertyName, Val, out msg);
            if (!ok) { return false; }
        }
        msg = "";
        return true;
    }
}


public class ComboBoxBacker<T> : ControlBacker<T>
{
    public ComboBoxBacker(ComboBox cmbBox, string backingPropertyName, List<T> items, bool? limitToList) 
        : base(cmbBox, typeof(T)==typeof(string) ? nameof(cmbBox.SelectedText) : nameof(cmbBox.SelectedItem), backingPropertyName)
    {
        cmbBox.Items.Clear();
        if (items != null)
        {
            for (int ix = 0; ix < items.Count; ++ix)
            {
                T item = items[ix];
                if (item != null) { cmbBox.Items.Add(item); }
            }
        }
        if (limitToList != null)
        {
            if (limitToList.Value) { cmbBox.DropDownStyle = ComboBoxStyle.DropDownList; }
            else { cmbBox.DropDownStyle = ComboBoxStyle.DropDown; }
        }
    }

    public ComboBoxBacker(ComboBox cmbBox, string backingPropertyName, List<string> items, bool? limitToList = null)
        : base(cmbBox, nameof(cmbBox.SelectedText), backingPropertyName)
    {
        cmbBox.Items.Clear();
        if (items != null)
        {
            for (int ix = 0; ix < items.Count; ++ix)
            {
                string item = items[ix];
                if (item != null) { cmbBox.Items.Add(item); }
            }
        }
        if (limitToList != null)
        {
            if (limitToList.Value) { cmbBox.DropDownStyle = ComboBoxStyle.DropDownList; }
            else { cmbBox.DropDownStyle = ComboBoxStyle.DropDown; }
        }
    }

    public override Boolean TryLoad(IBackingData data, out String msg)
    {
        bool ok = data.TryGetPropertyValue(BackingPropertyName, out T? val, out msg);
        if (!ok)
        {
            var thisMsg = $"Internal error: Failed to get backing property {BackingPropertyName} when loading {Ctrl.Name}";
            msg += "\n" + thisMsg;
            return false;
        }

        if (val == null)
        {
            ((ComboBox)Ctrl).SelectedIndex = -1;
            return true;
        }

        ok = Ctrl.TrySetPropertyValue(CtrlPropertyName, val, out msg);
        if (!ok)
        {
            var thisMsg = $"Internal error: Failed to set property {CtrlPropertyName} when loading {Ctrl.Name}";
            msg += "\n" + thisMsg;
            return false;
        }

        return true;
    }

    public override bool TrySave(IBackingData data, out String msg) 
    {
        bool ok = Ctrl.TryGetPropertyValue(CtrlPropertyName, out T? val, out msg);
        if (!ok) 
        {
            var thisMsg = $"Internal error: Failed to get backing property {CtrlPropertyName} when saving {Ctrl.Name}";
            msg += "\n" + thisMsg;
            return false; 
        }

        ok = data.TrySetPropertyValue(BackingPropertyName, val, out msg);
        if (!ok)
        {
            var thisMsg = $"Internal error: Failed to set property {BackingPropertyName} when saving {Ctrl.Name}";
            msg += "\n" + thisMsg;
            return false;
        }

        return true;
    }
}
