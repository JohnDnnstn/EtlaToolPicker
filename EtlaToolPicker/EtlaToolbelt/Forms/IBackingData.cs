namespace EtlaToolPicker.EtlaToolbelt.Forms;

/// <summary>This interface specifies that an object is backing data for a Form
/// On the form being loaded, the form's controls are initialised to the contents of backing properties
/// On the form being closed, the backing data properties are changed to match the equivalent control values
/// </summary>
public interface IBackingData { }

public interface IGridRowBackingData : ICloneable 
{
    bool TryCopyTo(IGridRowBackingData target, out string msg);
    bool HasSameKeyAs(IGridRowBackingData item);
}

public interface IGridListBackingData<T> : 
    IList<T> 
    where T : IGridRowBackingData
{ 
}