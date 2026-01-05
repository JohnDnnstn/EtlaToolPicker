namespace EtlaToolPicker.EtlaToolbelt.Forms;

/// <summary>This class sets up a relationship between the Controls of a Form and a Backing object
/// On the form being loaded, the form's controls are initialised to the contents of backing properties
/// On the form being closed, the backing data properties are changed to match the equivalent control values
/// </summary>
public class BackingMap(IBackingData data)
{
    #region Properties
    protected IBackingData Data { get; set; } = data;
    protected List<AbstractControlBacker> ControlBackers { get; set; } = [];
    #endregion

    #region Add methods

    /// <summary>Adds a relationship between a control and its backing data</summary>
    /// <param name="ctrl">The control</param>
    /// <param name="ctrlPropertyName">The property of the control set at load and saved at close</param>
    /// <param name="dataPropertyName">The property of the backing data setting the control at load and saved to at close</param>
    protected void Add<T>(Control ctrl, string ctrlPropertyName, string dataPropertyName)
    {
        var ctrlBacker = new ControlBacker<T>(ctrl, ctrlPropertyName, dataPropertyName);
        ControlBackers.Add(ctrlBacker);
    }

    /// <summary>Adds a relationship between a check box and its backing data</summary>
    /// <param name="chkBox">The check box</param>
    /// <param name="dataPropertyName">The property of the backing data setting the control at load and saved to at close</param>
    public void Add(CheckBox chkBox, string dataPropertyName) => Add<bool>(chkBox, nameof(chkBox.Checked), dataPropertyName);

    /// <summary>Adds a relationship between a radio button and its backing data
    /// This variant maps onto a single boolean property as a 1-to-1 relationship
    /// </summary>
    /// <param name="rdoBtn">The radio button</param>
    /// <param name="dataPropertyName">The property of the backing data setting the control at load and saved to at close</param>
    public void Add(RadioButton rdoBtn, string dataPropertyName) => Add<bool>(rdoBtn, nameof(rdoBtn.Checked), dataPropertyName);

    /// <summary>Adds a relationship between a radio button and its backing data
    /// This variant maps each of a group of radio buttons to a single enum property of the backing data
    /// </summary>
    /// <typeparam name="T">The enum type</typeparam>
    /// <param name="rdoBtn">The radio button</param>
    /// <param name="dataPropertyName">The property of the backing data setting the control at load and saved to at close</param>
    /// <param name="checkedValue">The enum value associated with this particular radio button</param>
    public void Add<T>(RadioButton rdoBtn, string dataPropertyName, T checkedValue) where T : Enum
    {
        var ctrlBacker = new RadioButtonBacker<T>(rdoBtn, dataPropertyName, checkedValue);
        ControlBackers.Add(ctrlBacker);
    }

    /// <summary>Adds a relationship between a text box and its backing data
    /// This variant maps onto a single boolean property as a 1-to-1 relationship
    /// </summary>
    /// <param name="txtBox">The text box</param>
    /// <param name="dataPropertyName">The property of the backing data setting the control at load and saved to at close</param>
    public void Add(TextBox txtBox, string dataPropertyName) => Add<string>(txtBox, nameof(txtBox.Text), dataPropertyName);

    /// <summary>Adds a relationship between a combo box and its backing data
    /// This variant assumes the list of possible values of the combo box is defined elsewhere
    /// </summary>
    /// <param name="cmbBox">The combo box</param>
    /// <param name="dataPropertyName">The property of the backing data setting the control at load and saved to at close</param>
    public void Add<T>(ComboBox cmbBox, string dataPropertyName) => Add<T>(cmbBox, nameof(cmbBox.SelectedItem), dataPropertyName);

    /// <summary>Adds a relationship between a combo box and its backing data
    /// This variant assumes the list of possible values of the combo box is defined in the arguments
    /// By default the user is limited to the list of possible values unless T is string
    /// Passing limitToList=true would limit the user even for string values
    /// Passing limitToList=false would not make much sense apart from 
    /// </summary>
    /// <typeparam name="T">The value type</typeparam>
    /// <param name="cmbBox">The combo box</param>
    /// <param name="dataPropertyName">The backing data property that holds the selected item</param>
    /// <param name="items">The list of possible items to choose</param>
    /// <param name="limitToList">Whether the user is limited to the list of possible values</param>
    public void Add<T>(ComboBox cmbBox, string dataPropertyName, List<T> items, bool? limitToList = null)
    {
        if (limitToList == null && typeof(T) != typeof(string)) { limitToList = true; }
        var ctrlBacker = new ComboBoxBacker<T>(cmbBox, dataPropertyName, items, limitToList);
        ControlBackers.Add(ctrlBacker);
    }

    #endregion

    //public void Load()
    //{
    //    foreach(ControlBacker ctrlBacker in ControlBackers)
    //    {
    //        ctrlBacker.Load(Data);
    //    }
    //}

    public void Load()
    {
        foreach (AbstractControlBacker ctrlBacker in ControlBackers)
        {
            bool ok = ctrlBacker.TryLoad(Data, out string msg);
            if (!ok)
            {
                MessageBox.Show(msg, "Error: Failed to load backing data", MessageBoxButtons.OK);
                return;
            }
        }
    }

    //public void Save()
    //{
    //    foreach (ControlBacker ctrlBacker in ControlBackers)
    //    {
    //        ctrlBacker.Save(Data);
    //    }
    //}

    public bool TrySave()
    {
        foreach (AbstractControlBacker ctrlBacker in ControlBackers)
        {
            bool ok = ctrlBacker.TrySave(Data, out string msg);
            if (!ok)
            {
                MessageBox.Show(msg, "Error: Failed to save state to backing data", MessageBoxButtons.OK);
                return false;
            }
        }
        return true;
    }
}
