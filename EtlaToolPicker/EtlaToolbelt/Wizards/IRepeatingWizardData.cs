using EtlaToolPicker.EtlaToolbelt.Forms;

namespace EtlaToolPicker.EtlaToolbelt.Wizards;

public interface IRepeatingWizardData<TBackingData, TArg> : IBackingData
{
    public abstract static TBackingData Factory(TArg arg);
}
