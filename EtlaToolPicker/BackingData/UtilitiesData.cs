using EtlaToolPicker.EtlaToolbelt.Forms;

namespace EtlaToolPicker.BackingData;

public class UtilitiesData : IBackingData
{
    public bool PostgresNames { get; set; } = false;
    public bool Plurals { get; set; } = false;
}
