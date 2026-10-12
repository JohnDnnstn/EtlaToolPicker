using System.ComponentModel;

namespace EtlaToolPicker.EtlaToolbelt.Forms;

/// <summary>This class is intended to be the base class for forms that use the BackingMap mechanism
/// The BackingMap mechanism is intendend to provide a place to store user input with the following characteriistics:
/// * When user entry is complete, the form data is either saved to the backing data or ignored depending on how the user exited and if a validation check succeeded
/// * When the form is loaded, it is pre-populated by the contents of the backing data
/// * The actual backing data is an ordinary class and should be initialised to whatever 
/// </summary>
public partial class BackedForm : Form
{
    protected BackingMap Map { get; set; }

	// Only required for the Form designer
    public BackedForm()
    {
        InitializeComponent();
        Map = new();
        if (LicenseManager.UsageMode == LicenseUsageMode.Runtime) 
        { 
            MessageBox.Show("Warning: Argumentless constructor being used in RunTime for BackedForm derived Form.  Did you forget ' : base(data)'");
        }
    }

    public BackedForm(IBackingData data)
    {
        InitializeComponent();
        Map = new(data);
    }

    /// <summary>Placeholder for a validity check
    /// The default result in the placeholder is to return false (i.e. valid) and a null message.
    /// </summary>
    /// <param name="msg">Indication of any problem found or null if no problem found</param>
    /// <returns>True if the user input is found to be invalid/incomplete/etc.; false otherwise</returns>
    protected virtual bool IsInvalid(out string msg)
    {
        msg = "";
        return false;
    }

    protected virtual bool TrySave()
    {
        bool isInvalid = IsInvalid(out string msg);

        if (isInvalid)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        bool ok = Map.TrySave();
        return ok;
    }

    protected virtual void BackedForm_Load(object sender, EventArgs e) => Map.Load();

    protected virtual void BackedForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = false;

        var dialogResult = DialogResult;
        if (dialogResult == DialogResult.Yes)
        {
            bool ok = TrySave();
            e.Cancel = !ok;
        }
    }
}
