namespace EtlaToolPicker.EtlaToolbelt.Forms;

public partial class BackedForm : Form
{
    protected BackingMap BackingMap { get; set; } = null!;

    /// <summary>Only used by the designer</summary>
    protected BackedForm() {}

    public BackedForm(IBackingData data)
    {
        InitializeComponent();
        BackingMap = new(data);
    }

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

        bool ok = BackingMap.TrySave();
        return ok;
    }

    protected virtual void BackedForm_Load(object sender, EventArgs e) => BackingMap.Load();

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
