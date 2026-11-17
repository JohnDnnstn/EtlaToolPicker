// This class is generated from the EtlaTool.Wizards template

namespace EtlaToolPicker.EtlaToolbelt.Forms;

/// <summary>Translates DialogResult codes into meaningful names in the wizard context
/// Buttons on forms can be associated with DialogResults and it makes sense to use that facility.
/// In the wizard context, the available set doesn't map nicely to what the we want the buttons to signify
/// This mapping makes the wizard code more readable
/// </summary>
public enum FormResult
{
    EXIT = DialogResult.Cancel,
    BACK = DialogResult.No,
    NEXT = DialogResult.Yes,
    REMOVE = DialogResult.Abort,
    ADD = DialogResult.OK
}

/// <summary>Defines the common attributes of a form that can be used in an ETLA wizard
/// By default, if Map created and initialised with backing data (implements IWizardData)
/// then controls are loaded from backing data on form_load event
/// and controls are saved to backing data on form_closing on clicking NEXT or ADD iff it is valid 
/// This behaviour can be overridden
/// Adds controls:
///  * Rubric text
///  * A Back button - and sets the DialogResult to be DialogResult.No which equates to WizardResult.BACK
///  * A Next button - and sets the DialogResult to be DialogResult.Yes which equates to WizardResult.NEXT
///  Note: The Close button (i.e. top left X) remains unchange as DialogResult.Cancel which equates to WizardResult.EXIT
/// </summary>
public partial class BaseWizardForm : BackedForm
{
    /// <summary>Used for mapping the controls of a form to their backing data 
    /// General usage:
    ///   * TableLevelMappings are added in the Forms constructor
    ///     e.g.
    ///         Map.Add(TxtFooCtrl,nameof(data.Foo));   // data.Foo being string and mapped to TxtFooCtrl.Text
    ///         Map.Add(ChkBarCtrl,nameof(data.Bar));   // data.Bar being bool and mapped to TxtBarCtrl.Checked
    ///   * LoadFormStateFromBackingData() automatically called on form_Load event
    ///   * SaveFormStateToBackingData() automatically called on form_Closing event when NEXT or ADD clicked and form contents are valid
    /// LoadFormStateFromBackingData() and SaveFormStateToBackingData() can be called manually (e.g. LoadFormStateFromBackingData() may be required for DataGridView initialisation)
    /// </summary>

    protected int Ix { get; set; }
    protected int MaxIx { get; set; }

    public BaseWizardForm() : base() { InitializeComponent(); }

    public BaseWizardForm(IBackingData data) : base(data)
    {
        InitializeComponent();
        StartPosition = FormStartPosition.Manual;
        TxtRubric.Text = "This is a test";
    }

    /// <summary>Displays a form to the user, returning a value indicating which button was used to dismiss the form
    /// </summary>
    /// <param name="previouslyShownForm">Used so that this form takes up the position and size of the previous form</param>
    /// <param name="ix">Indicates the position of this form in the list of forms.  May imply Back and Next button text should be something else</param>
    /// <param name="maxIx">Indicates the index of the last form in the list of forms.  May imply Next button text should be something else</param>
    /// <returns>An indication of which button was used to dismiss the form</returns>
    public virtual FormResult ShowDialog(Form? previouslyShownForm, int ix, int maxIx)
    {
        if (previouslyShownForm != null)
        {
            Location = previouslyShownForm.Location;
            Size = previouslyShownForm.Size;
        }
        Ix = ix;
        MaxIx = maxIx;
        SetButtonText(ix, maxIx);
        DialogResult result = ShowDialog();
        return (FormResult)result;
    }

    /// <summary>Placeholder for code to allow the Back or Next button text to be changed
    /// Examples:
    ///     ix == 0, change the back button text to Revert
    ///     ix == maxIx, change the next button text to Done
    /// </summary>
    /// <param name="ix">Zero-based index of current form in the Forms list</param>
    /// <param name="maxIx">Number of forms in the Forms list</param>
    protected virtual void SetButtonText(int ix, int maxIx) { }

    protected bool ShouldSave(FormClosingEventArgs e)
    {
        return
            !e.Cancel
            && (DialogResult == (DialogResult)FormResult.NEXT || DialogResult == (DialogResult)FormResult.ADD);
    }

    /// <summary>Default event handler called when the form is loaded.  <see cref="LoadFormStateFromBackingData()"/>.</summary>
    /// <param name="sender">Not used</param>
    /// <param name="e">Not used</param>
    protected virtual void BaseWizardForm_Load(object sender, EventArgs e) => LoadFormStateFromBackingData();

    /// <summary>Copies data from backing data to controls if a ControlMapper has been defined/// </summary>
    protected virtual void LoadFormStateFromBackingData() => Map?.Load();

    /// <summary>Default event handler called when the form is closing
    /// Checks whether the form is in a valid state <see cref="IsInvalid(out string?)"/>
    /// Resulting actions depend on how it was closed.  If the current state is invalid...
    ///     This will usually result in an error message (unless the user was closing the application anyway)
    ///     The user is not able to go on to the next form but can, optionally, go back to the previous one
    /// If the current state is valid, the SaveFormStateToBackingData() method is called
    /// This is intended to save the values in the form's controls to a backing object but here is a just a placeholder
    /// </summary>
    /// <param name="sender">Not used</param>
    /// <param name="e">e.Cancel is used to indicate whether the form remains open</param>
    protected void BaseWizardForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = false;
        FormResult result = (FormResult)DialogResult;
        bool isInvalid = IsInvalid(out string? msg);

        switch (result)
        {
            case FormResult.NEXT:
            case FormResult.ADD:
                if (isInvalid)
                {
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                else
                {
                    try
                    {
                        SaveFormStateToBackingData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        e.Cancel = true;
                    }
                }
                break;
            case FormResult.BACK:
                if (isInvalid)
                {
                    if (this is RepeatingWizardForm)
                    {
                        MessageBox.Show($"{msg}\nPlease correct this or remove this instance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                    else
                    {
                        DialogResult button = MessageBox.Show($"{msg}\nDo you want to continue anyway?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (button == DialogResult.No)
                        {
                            e.Cancel = true;
                        }
                    }
                }
                break;
            case FormResult.EXIT:
                break;

        }
    }

    ///// <summary>Placeholder for a validity check
    ///// The default result in the placeholder is to return false (i.e. valid) and a null message.
    ///// </summary>
    ///// <param name="msg">Indication of any problem found or null if no problem found</param>
    ///// <returns>True if the user input is found to be invalid/incomplete/etc.; false otherwise</returns>
    //protected virtual bool IsInvalid(out string? msg)
    //{
    //    msg = null;
    //    return false;
    //}

    /// <summary>Copies data from controls to backing data if a Control Mapper has been defined///</summary>
    protected virtual void SaveFormStateToBackingData() 
    { 
        var savedOk = Map?.TrySave();
        if (savedOk.HasValue && !savedOk.Value) 
        {   
            MessageBox.Show("Failed to save this form's data to backing data.","Error saving data",MessageBoxButtons.OK, MessageBoxIcon.Error); 
        } 
    }
}