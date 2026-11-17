using EtlaToolPicker.BackingData;
using EtlaToolPicker.EtlaToolbelt.Forms;

namespace EtlaToolPicker.Forms;

public partial class UtilitiesForm : BaseWizardForm
{
    protected UtilitiesData Data { get; set; } = new();

    protected UtilitiesForm() : base() { }

    public UtilitiesForm(UtilitiesData data) : base(data)
    {
        InitializeComponent();
        Data = data;

        Map.Add(ChkPlurals, nameof(Data.Plurals));
        Map.Add(ChkPostgresNames, nameof(Data.PostgresNames));
    }
}
