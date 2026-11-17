namespace EtlaToolPicker.EtlaToolbelt.Forms;

public static class Cascades
{
    public static void Visibility(Control target, Control source)
    {
        if (source is CheckBox chk) { _ = new VisibilityCascade(chk, target); }
        if (source is RadioButton rdo) { _ = new VisibilityCascade(rdo, target); }
    }


}
