namespace EtlaToolPicker.EtlaToolbelt.Forms;

/// <summary>The visibility of a control can depend on whether a checkbox is ticked or a radio button is chosen
/// Generally we also want to change the Enabled status of the control at the same time.
/// The VisibilityCascade sets up a such a relationship
/// To set up this relationship, add the following line to the the Windows form
///     _ = new VisibiltyCascade(&lt check_box &gt, &lt target_control &gt);
/// When the check_box is checked, the target_control becomes visible and eneable and vice versa
/// </summary>
public class VisibiltyCascade
{
    protected Control Target { get; set; }

    public VisibiltyCascade(CheckBox sourceCheckBox, Control target)
    {
        sourceCheckBox.CheckedChanged += SourceCheckBox_CheckedChanged;
        Target = target;
        SourceCheckBox_CheckedChanged(sourceCheckBox, EventArgs.Empty);
    }

    public VisibiltyCascade(RadioButton sourceRadioButton, Control target)
    {
        sourceRadioButton.CheckedChanged += SourceRadioButton_CheckedChanged;
        Target = target;
        SourceRadioButton_CheckedChanged(sourceRadioButton, EventArgs.Empty);
    }

    private void SourceCheckBox_CheckedChanged(object? sender, EventArgs e)
    {
        if (sender is CheckBox checkBox) { Target.Visible = Target.Enabled = checkBox.Checked && checkBox.Visible; }
    }

    private void SourceRadioButton_CheckedChanged(object? sender, EventArgs e)
    {
        if (sender is RadioButton radioButton) { Target.Visible = Target.Enabled = radioButton.Checked && radioButton.Visible; }
    }

}
