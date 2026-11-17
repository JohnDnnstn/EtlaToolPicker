using EtlaToolPicker.EtlaToolbelt.Forms;
using System.Diagnostics;

//------------------------------------------------------------------------------------------
// This file was generated from the EtlaTool.Wizards vsn:1.0 template
// Created 29/08/2023 17:44:59
// Copyright: Etla Services Ltd 2019-2023
//------------------------------------------------------------------------------------------


namespace EtlaToolPicker.EtlaToolbelt.Wizards;

/// <summary>A repeating wizard allows the user to go through a number of identical forms, adding or removing some of them as required
/// A use case is when defining foreign keys for a table - there may be any number of these but he form definig them will be identical
/// </summary>
public abstract class RepeatingWizard<TF, TD> : BaseWizard
    where TF : RepeatingWizardForm
    where TD : IBackingData, IRepeatingWizardData<TD,string>
{
    /// <summary>Holds the user's chosen data, one item per form</summary>
    public List<TD>? Data { get; set; }

    //protected RepeatingWizard() : this([]) { }

    /// <summary>Constructor.  Inititialises the list of forms from the data passed in as an argument (or from a new data item if none passed)
    /// </summary>
    /// <param name="data">Any existing user-chosen data</param>
    public RepeatingWizard(List<TD> data) : base()
    {
        Data = data;
        Forms = [];
        foreach (TD item in Data)
        {
            TF form = CreateForm(item);
            Forms.Add(form);
        }
        if (Forms.Count < 1)
        {
            TD item = TD.Factory("");
            Data.Add(item);
            TF form = CreateForm(item);
            Forms.Add(form);
        }
    }

    public override FormResult Show(Form? caller)
    {
        if (Forms == null || Forms.Count < 1) { throw new Exception("Internal error: The wizard must have at least one form defined"); }
        if (Data == null || Data.Count < 1) { throw new Exception("Internal error: The wizard must have at least one data item defined"); }

        if (caller != null) { caller.Visible = false; }

        int ix = 0;
        BaseWizardForm? currentForm = Forms[ix];
        Form? previouslyShownForm = caller;


        try
        {
            while (true)
            {
                try
                {
                    if (currentForm != null)
                    {
                        currentForm.Controls["TxtPgNumber"]!.Text = (ix + 1).ToString();
                        currentForm.Controls["TxtPgOf"]!.Text = Forms.Count.ToString();
                    }
                }
                catch { }

                FormResult result = currentForm?.ShowDialog(previouslyShownForm, ix, MaxFormsIx) ?? FormResult.NEXT;
                previouslyShownForm = currentForm;
                switch (result)
                {
                    case FormResult.EXIT:
                        Application.Exit();
                        return result;
                    case FormResult.NEXT:
                        if (ix == MaxFormsIx) { FinishComplete(caller, previouslyShownForm); return result; }
                        currentForm = Forms[++ix];
                        break;
                    case FormResult.BACK:
                        if (ix == 0) { FinishIncomplete(caller, previouslyShownForm); return result; }
                        currentForm = Forms[--ix];
                        break;
                    case FormResult.ADD:
                        TD item = TD.Factory("");
                        currentForm = CreateForm(item);
                        Forms.Insert(++ix, currentForm);
                        Data.Insert(ix, item);
                        break;
                    case FormResult.REMOVE:
                        Data.RemoveAt(ix);
                        Forms.RemoveAt(ix--);
                        if (ix < 0) { ix = 0; }
                        if (Forms.Count < 1) { FinishIncomplete(caller, previouslyShownForm); return result; }
                        currentForm = Forms[ix];
                        break;
                    default:
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex.ToString());
            throw;
        }
    }

    public abstract TF CreateForm(TD item);
}
