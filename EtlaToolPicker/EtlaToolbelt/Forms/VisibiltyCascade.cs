namespace EtlaToolPicker.EtlaToolbelt.Forms;

/// <summary>The visibility of a control can depend on whether a checkbox is ticked or a radio button is chosen
/// Generally we also want to change the Enabled status of the control at the same time.
/// The VisibilityCascade sets up a such a relationship
/// To set up this relationship, add the following line to the the Windows form
///     _ = new VisibiltyCascade(&lt; check_box &gt;, &lt; target_control &gt;);
/// When the check_box is checked, the target_control becomes visible and eneable and vice versa
/// </summary>
public class VisibilityCascade
{
    protected Control Target { get; set; }
    private readonly bool _First = true;

    public VisibilityCascade(CheckBox sourceCheckBox, Control target)
    {
        sourceCheckBox.CheckedChanged += SourceCheckBox_CheckedChanged;
        sourceCheckBox.VisibleChanged += SourceCheckBox_CheckedChanged;
        Target = target;
        SourceCheckBox_CheckedChanged(sourceCheckBox, EventArgs.Empty);
        _First = false;
    }

    public VisibilityCascade(RadioButton sourceRadioButton, Control target)
    {
        sourceRadioButton.CheckedChanged += SourceRadioButton_CheckedChanged;
        sourceRadioButton.VisibleChanged += SourceRadioButton_CheckedChanged;
        Target = target;
        SourceRadioButton_CheckedChanged(sourceRadioButton, EventArgs.Empty);
        _First = false;
    }

    private void SourceCheckBox_CheckedChanged(object? sender, EventArgs e)
    {
        if (sender is CheckBox checkBox) { Target.Visible = Target.Enabled = checkBox.Checked && (checkBox.Visible || _First); }
    }

    private void SourceRadioButton_CheckedChanged(object? sender, EventArgs e)
    {
        if (sender is RadioButton radioButton) { Target.Visible = Target.Enabled = radioButton.Checked && (radioButton.Visible|| _First); }
    }
}

/// <summary>The visibility of a Control can depend on the state of more than one other Control
/// This sets a target Control to visible and enabled if both of two other Controls are both Checked and Visible
/// To set up this relationship, add the following line to the the Windows form
///     _ = new VisibiltyCascade(&lt; source_control1 &gt;, &lt; source_control2 &gt;, &lt; target_control &gt;);
/// The source controls are limited to check boxes and radio buttons only
/// </summary>
public class VisibilityCascade2
{ 
    protected RadioButton? Radio1 { get; set; }
    protected CheckBox? Chk1 { get; set; }
    protected RadioButton? Radio2 { get; set; }
    protected CheckBox? Chk2 { get; set; }
    protected Control Targ { get; set; }
    private readonly bool _First = true;

    public VisibilityCascade2(Control src1, Control src2, Control targ)
    {
        if (src1 is RadioButton rb1 ) { Radio1 = rb1; Radio1.CheckedChanged += Source_CheckedChanged; Radio1.VisibleChanged += Source_CheckedChanged; }
        if (src1 is CheckBox chk1) { Chk1 = chk1; Chk1.CheckedChanged += Source_CheckedChanged; Chk1.VisibleChanged += Source_CheckedChanged; }
        if (src2 is RadioButton rb2) { Radio2 = rb2; Radio2.CheckedChanged += Source_CheckedChanged; Radio2.VisibleChanged += Source_CheckedChanged; }
        if (src2 is CheckBox chk2) { Chk2 = chk2; Chk2.CheckedChanged += Source_CheckedChanged; Chk2.VisibleChanged += Source_CheckedChanged; }
        Targ = targ;
        Source_CheckedChanged(null, EventArgs.Empty);
        _First = false;
    }

    private void Source_CheckedChanged(object? sender, EventArgs e)
    {
        Targ.Visible = Targ.Enabled =
            (
                (Radio1 == null || (Radio1.Checked &&(Radio1.Visible || _First) ))
                && (Chk1 == null || (Chk1.Checked && (Chk1.Visible || _First) ))
                && (Radio2 == null || (Radio2.Checked && (Radio2.Visible || _First) ))
                && (Chk2 == null || (Chk2.Checked && (Chk2.Visible || _First) ))
            );
    }
}

/// <summary>The visibility/enabledness of a control can sometimes depend on whether another's Text property is blank
/// This sets a target Control to visible and enabled if a source Control's text is black
/// To set up this relationship, add the following line to the the Windows form
///     _ = new TextVisibiltyCascade(&lt; source_control &gt;, &lt; target_control &gt;);
/// Note: all Controls have a Text property
/// </summary>
public class TextVisibilityCascade
{
    protected Control Target { get; set; }
    private readonly bool _First = true;

    public TextVisibilityCascade(Control source, Control target)
    {
        source.TextChanged += Source_TextChanged;
        source.VisibleChanged += Source_TextChanged;
        Target = target;
        Source_TextChanged(source, EventArgs.Empty);
        _First = false;
    }

    private void Source_TextChanged(object? sender, EventArgs e)
    {
        if (sender is Control ctrl) { Target.Visible = Target.Enabled = !string.IsNullOrWhiteSpace(ctrl.Text) && (ctrl.Visible || _First); }
    }
}

public class TextVisibilityCascade2
{
    protected Control Src1 { get; set; } 
    protected RadioButton? Radio2 { get; set; }
    protected CheckBox? Chk2 { get; set; }
    protected Control Targ { get; set; }
    private readonly bool _First = true;

    public TextVisibilityCascade2(Control src1, Control src2, Control targ)
    {
        Src1 = src1;
        src1.TextChanged += Source_Changed;
        Src1.VisibleChanged += Source_Changed;

        if (src2 is RadioButton rb2) { Radio2 = rb2; Radio2.CheckedChanged += Source_Changed; Radio2.VisibleChanged += Source_Changed; }
        if (src2 is CheckBox chk2) { Chk2 = chk2; Chk2.CheckedChanged += Source_Changed; Chk2.VisibleChanged += Source_Changed; }
        Targ = targ;
        Source_Changed(null, EventArgs.Empty);
        _First = false;
    }


    private void Source_Changed(object? sender, EventArgs e)
    {
        Targ.Visible = Targ.Enabled =
            (
                (!string.IsNullOrWhiteSpace(Src1.Text) && (Src1.Visible || _First) )
                && (Radio2 == null || (Radio2.Checked && (Radio2.Visible || _First)))
                && (Chk2 == null || (Chk2.Checked && (Chk2.Visible || _First)))
            );
    }
}
