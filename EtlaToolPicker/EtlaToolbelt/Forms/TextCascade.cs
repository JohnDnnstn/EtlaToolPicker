namespace EtlaToolbeltPicker.EtlaToolbelt.Forms;

/// <summary>This class deals with the situation where a text box may depend on the values of one other text box
/// When the source box changes, this change should normally cascade to the target text box 
/// (the precise cascade target value depending on the processing function)
/// BUT if the target has been manually changed to be something else then the cascade is broken 
/// unless or until the user manually changes the target to match the calculated cascade value
/// To create the relationship add the following to the Form's constructor
///     _ = new TextCascade( &lt source_box &gt, &lt target_box &gt, &lt processor_function &gt);
/// e.g.
///     _ = new TextCascade(TxtTableName, TxtIdName, MakeId);
/// </summary>
public class TextCascade
{
    #region Properties
    protected TextBox Source { get; set; }
    protected TextBox Target { get; set; }
    protected Func<string, string> Processor { get; set; }
    protected string OldSourceValue { get; set; }

    /// <summary>Used to stop infinite regression</summary>
    protected bool InitialCall { get; set; } = true;
    #endregion

    public TextCascade(TextBox source, TextBox target, Func<string, string> processor)
    {
        Source = source;
        Target = target;
        Processor = processor;
        OldSourceValue = Source.Text;
        Source.TextChanged += Source_TextChanged;
    }

    private void Source_TextChanged(object? sender, EventArgs e)
    {
        if (InitialCall)
        {
            InitialCall = false;
            if (Target.Text.IsWhite() || Target.Text == Processor(OldSourceValue)) { Target.Text = Processor(Source.Text); }
            OldSourceValue = Source.Text;
            InitialCall = true;
        }
    }
}

/// <summary>Similar to the <see cref="TextCascade"/> class, but allows two source text boxes to determine the cascade value
/// e.g.
///     _ = DoubleTextCascade(TxtSchemaName, TxtBaseFeedName, TxtFullFeedName, JoinWithDot);
/// </summary>
public class DoubleTextCascade
{
    protected TextBox Source1 { get; set; }
    protected string OldSource1Value { get; set; }
    protected TextBox Source2 { get; set; }
    protected string OldSource2Value { get; set; }
    protected TextBox Target { get; set; }
    protected Func<string, string, string> Processor { get; set; }
    protected bool InitialCall { get; set; } = true;

    public DoubleTextCascade(TextBox source1, TextBox source2, TextBox target, Func<string, string, string> processor)
    {
        Source1 = source1;
        OldSource1Value = Source1.Text;
        Source2 = source2;
        OldSource2Value = Source2.Text;
        Target = target;
        Processor = processor;
        Source1.TextChanged += Source_TextChanged;
        Source2.TextChanged += Source_TextChanged;
    }

    private void Source_TextChanged(object? sender, EventArgs e)
    {
        if (InitialCall)
        {
            InitialCall = false;
            if (Target.Text.IsWhite() || Target.Text == Processor(OldSource1Value, OldSource2Value))
            {
                Target.Text = Processor(Source1.Text, Source2.Text);
            }
            OldSource1Value = Source1.Text;
            OldSource2Value = Source2.Text;
            InitialCall = true;
        }
    }
}


