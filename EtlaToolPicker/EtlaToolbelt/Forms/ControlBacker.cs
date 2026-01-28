using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EtlaToolPicker.EtlaToolbelt.Forms;

public abstract class AbstractControlBacker
{ 
    public abstract bool TryLoad(IBackingData backingData, out string msg);
    public abstract bool TrySave(IBackingData backingData, out string msg);
}

public class ControlBacker<T> : AbstractControlBacker
{
    protected Control Ctrl { get; set; } = null!;
    protected string CtrlPropertyName { get; set; } = null!;
    protected string BackingPropertyName { get; set; } = null!;

    public ControlBacker(Control ctrl, String ctrlPropertyName, String backingPropertyName)
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

        ok = Ctrl.TrySetPropertyValue(CtrlPropertyName, val, out msg);
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
        bool ok = Ctrl.TryGetPropertyValue(CtrlPropertyName, out T? val, out msg);
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

/// <summary>Backing for a DataGridView
/// This version populates a BindingSource with a clone of the original data (TryLoad)
/// The DataGridView manipulates the data in the BindingSource
/// If the form changes are cancelled (backed out in a wizard) the original data is unchanged
/// If the form changes are to be applies,
/// Then the BindingSource is copied back into the original List
/// Any deleted rows are removed from the list and any new rows are added as list items
/// 
/// The data must be a List of T 
/// where T is an IGridRowBackingData such that 
/// * it has a Clone function (used by TryLoad) and
/// * it has a TryCopyTo function (used by TrySave to copy back the changed values) and
/// * it has a HasSameKeyAs function (used by TrySave to work out which original item matches a bound item)
/// </summary>
/// <typeparam name="T"></typeparam>
public class GridBacker<T> : ControlBacker<T>
    where T : IGridRowBackingData
{
    private BindingSource _BindingSource { get; set; } =  [];

    public GridBacker(DataGridView grid, string dataPropertyName) : base(grid, nameof(grid.DataSource), dataPropertyName)
    { 
    }

    /// <summary> A DataGridView has the ability to use a BindingSource as backing data for its operations
    /// The BindingSource tracks all the changes that the user makes.
    /// By populating the BindingSource with clones of the original data, we can keep both initial data and altered data
    /// See <see cref="TrySave"> for how to put the data back into the original
    /// </summary>
    /// <param name="data">The Form's backing data</param>
    /// <param name="msg">If there was an error, then an error message, otherwise ""</param>
    /// <returns><c>true</c> if the load succedded, false otherwise</returns>
    public override bool TryLoad(IBackingData data, out string msg)
    {
        var failure = $"Internal error: failed to load data into grid {Ctrl.Name}";

        if (Ctrl is not DataGridView grid) { msg = $"{failure} as it is not a DataGridView"; return false; }

        bool ok = data.TryGetPropertyValue(BackingPropertyName, out List<T>? list, out msg);
        if (!ok) { msg = $"{failure} {msg}"; return false; }
        if (list == null) { msg = $"{failure} Original list is null"; return false; }

        // Populate the DataGridView's backing with clones of the data to be loaded
        _BindingSource.Clear();
        foreach (var item in list)
        {
            IGridRowBackingData clone = (IGridRowBackingData)item.Clone();
            _BindingSource.Add(clone);
        }

        grid.DataSource = _BindingSource;

        msg = "";
        return true;
    }

    public override Boolean TrySave(IBackingData data, out string msg)
    {
        var failure = $"Internal error: failed to save data from grid {Ctrl.Name}.";

        bool ok = data.TryGetPropertyValue(BackingPropertyName, out List<T> ? originalList, out msg);
        if (!ok) { msg = $"{failure} {msg}"; return ok;}
        if (originalList == null) { msg = $"{failure} Original list is null"; return false;  }

        List<T> alteredList = [.. _BindingSource.List.Cast<T>()];

        // Remove any of the original items that do not appear in the BindingSource after user changes
        for (int ix = originalList.Count-1; ix >= 0; --ix)
        {
            var originalItem = originalList[ix];
            if (!alteredList.Exists(item => originalItem.HasSameKeyAs(item)))
            {
                originalList.RemoveAt(ix);
            }
        }

        // Copy over altered items and/or add new items
        for (int ix = 0; ix < alteredList.Count; ++ix)
        {
            T alteredItem = alteredList[ix];
            if (originalList.Exists(item => alteredItem.HasSameKeyAs(item)))
            {
                var originalItem = originalList.Find(item => alteredItem.HasSameKeyAs(item));
                if (originalItem == null) { continue; }
                if (!alteredItem.TryCopyTo(originalItem, out msg)) { msg = $"{failure} {msg}"; }
            }
            else
            {
                originalList.Add(alteredItem);
            }
        }

        //List<T> answer = [];

        //for (int ix = 0; ix < _BindingSource.Count; ++ix)
        //{
        //    var boundItem = _BindingSource[ix];
        //    if (boundItem != null)
        //    {
        //        T item = (T)boundItem;
        //        if (originalList.Exists(item => item.HasSameKeyAs(item)))
        //        {
        //            T? originalItem = originalList.Find(item => item.HasSameKeyAs(item));
        //            if (originalItem == null)
        //            {
        //                msg = $"{failure} Original item Exists but Find failed to return it";
        //                return false;
        //            }
        //            if (!item.TryCopyTo(originalItem, out msg))
        //            {
        //                msg = $"{failure} {msg}";
        //                return false;
        //            }
        //            answer.Add(originalItem);
        //        }
        //        else
        //        {
        //            answer.Add(item);
        //        }
        //    }
        //}
        //ok = data.TrySetPropertyValue(BackingPropertyName, answer, out msg);
        //return ok;

        msg = "";
        return true;
    }
}
