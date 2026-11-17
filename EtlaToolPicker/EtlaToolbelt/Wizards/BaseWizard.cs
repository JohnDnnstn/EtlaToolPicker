using EtlaToolPicker.EtlaToolbelt.Forms;
using System.Diagnostics;

//------------------------------------------------------------------------------------------
// This file was generated from the EtlaTool.Wizards vsn:1.0 template
// Created 29/08/2023 17:44:59
// Copyright: Etla Services Ltd 2019-2023
//------------------------------------------------------------------------------------------


namespace EtlaToolPicker.EtlaToolbelt.Wizards;

/// <summary>A wizard consists of a sequence of forms where the user can make choices.
/// This class arranges for the sequence to be shown and also allows the user to go backwards through the seqence as well as forwards
/// Usually, the sequence of forms is known beforehand.  The base wizard handles that case.
/// Sometimes the user has to define an one or more sets of choices where the form is identical - this is a repeating wizard, derived from the base wizard
/// Note: A wizard form may initiate "side-wizards" to allow for optional or more detailed choices
/// </summary>
public class BaseWizard
{
    ///// <summary>Translates DialogResult codes into meaningful names in the wizard context
    ///// Buttons on forms can be associated with DialogResults and it makes sense to use that facility.
    ///// In the wizard context, the available set doesn't map nicely to what the we want the buttons to signify
    ///// This mapping makes the wizard code more readable
    ///// </summary>
    //public enum FormResult { 
    //    EXIT = DialogResult.Cancel, 
    //    BACK = DialogResult.No, 
    //    NEXT = DialogResult.Yes, 
    //    REMOVE = DialogResult.Abort, 
    //    ADD = DialogResult.OK 
    //}

    /// <summary>This lists the sequence of forms for this wizard
    /// Note: nulls in this list are ignored
    /// </summary>
    protected List<BaseWizardForm> Forms = [];

    protected int MaxFormsIx => Forms.Count - 1;

    /// <summary>Utility to combine the making and and showing of a one-form wizard easy
    /// It could be argued that there is no need for a wizard if all you are doing is showing one form
    /// but making things work consistently works for me.
    /// </summary>
    /// <param name="form">The form to show</param>
    /// <param name="caller">The form that initiated this wizard if there was one (null if called directly from code)</param>
    public static FormResult ShowSingleton(BaseWizardForm form, Form? caller = null)
    {
        BaseWizard wizard = new();
        List<BaseWizardForm> forms = [form];
        wizard.Forms = forms;
        caller?.Hide();
        FormResult result = wizard.Show(caller);
        return result;
    }

    /// <summary>Walks through the showing of a sequence of forms, allowing the user to go backwards as well as forwards</summary>
    /// <param name="caller">The form which invoked this wizard or null if it was invoked directly from code.  Used for form dimensions</param>
    /// <exception cref="Exception"></exception>
    public virtual FormResult Show(Form? caller)
    {
        if (Forms == null || Forms.Count < 1) { throw new Exception("Internal error: The wizard must have at least one form defined"); }

        if (caller != null) { caller.Visible = false; }

        int ix = 0;
        BaseWizardForm? currentForm = Forms[ix];
        Form? previouslyShownForm = caller;

        try
        {
            while (true)
            {
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
                    case FormResult.REMOVE:
                    case FormResult.ADD:
                    default:
                        throw new Exception($"Unexpected FormResult {result}");

                }
            }
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex.ToString());
            throw;
        }
    }

    /// <summary>Placeholder for code to call if the user has walked through the entire sequence of forms</summary>
    protected virtual void FinishComplete(Form? caller, Form? previouslyShownForm)
    {
        ResizeCaller(caller, previouslyShownForm);
    }

    /// <summary>Placeholder for code to call if the user has walked backwards past the first form</summary>
    protected virtual void FinishIncomplete(Form? caller, Form? previouslyShownForm)
    {
        ResizeCaller(caller, previouslyShownForm);
    }

    protected virtual void ResizeCaller(Form? caller, Form? previouslyShownForm)
    {
        if (caller != null)
        {
            if (previouslyShownForm != null)
            {
                caller.Size = previouslyShownForm.Size;
                caller.Location = previouslyShownForm.Location;
            }
            caller.Visible = true;
        }
    }
}
