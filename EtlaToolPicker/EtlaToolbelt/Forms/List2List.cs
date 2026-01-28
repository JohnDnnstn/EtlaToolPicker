using System.Collections;
using System.ComponentModel;

//------------------------------------------------------------------------------------------
// This file was generated from the EtlaTool.Wizards vsn:1.0 template
// Created 29/08/2023 17:44:59
// Copyright: Etla Services Ltd 2019-2023
//------------------------------------------------------------------------------------------


namespace EtlaToolPicker.EtlaToolbelt.Forms;

public partial class List2List : UserControl
{

    #region events
    public event EventHandler<EventArgs>? ListsChanged;
    public event EventHandler<DestinationSelectedArgs>? DestinationSelectedIndexChanged;
    public event Action<string>? SourceListInitWithMissingElement;

    public class DestinationSelectedArgs : EventArgs
    {
        public int SelectedIndex { get; set; }
        public string? SelectedText { get; set; }
    }

    protected virtual void BroadcastListChangedEvent(EventArgs e) => ListsChanged?.Invoke(this, e);

    protected virtual void BroadcastDestinationSelectedIndexChanged(EventArgs e)
    {
        DestinationSelectedArgs args = new()
        {
            SelectedIndex = LstDestination.SelectedIndex,
            SelectedText = LstDestination.SelectedItem?.ToString(),
        };
        DestinationSelectedIndexChanged?.Invoke(this, args);
    }

    protected virtual void BroadcastSourceListInitWithMissingElement(string name) => SourceListInitWithMissingElement?.Invoke(name);

    protected void ListBox_DrawItem(object sender, DrawItemEventArgs e)
    {
        if (sender is not ListBox box || e == null || e.Index < 0 || e.Index > box.Items.Count) { return; }
        string? item = box.Items[e.Index].ToString();
        if (item == null) { return; }

        Font? font = e.Font;
        if (font == null) { return; }
        Color colour = e.ForeColor;
        Color backColour = e.BackColor;

        foreach (var format in _Formats)
        {
            if (format.Items.Contains(item))
            {
                if (format.Foreground != null) { colour = (Color)format.Foreground; }
                if (format.Background != null) { backColour = (Color)format.Background; }
                if (OperatingSystem.IsWindows())
                {
                    if (format.FontStyle != null) { font = new Font(font, (FontStyle)format.FontStyle); }
                }
            }
        }

        e.DrawBackground();
        TextRenderer.DrawText(e.Graphics, item, font, e.Bounds.Location, colour, backColour);
    }

    #endregion

    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //public bool Initialised { get; set; } = false;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsValid { get; set; } = true;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<object> ChosenItems { get => GetDestinationList(); set => InitialiseDestination(value); }

    public List2List()
    {
        InitializeComponent();
    }

    public void Initialise(List<object> source, List<object> destination)
    {
        InitialiseSource(source);
        InitialiseDestination(destination);
    }

    public void InitialiseSource(List<object> source, bool broadcastEvent = true)
    {
        var oldSrc = GetSourceList();
        LstSource.Items.Clear();

        foreach (var srcItem in source)
        {
            if (srcItem != null) { _ = LstSource.Items.Add(srcItem); }
        }

        if (broadcastEvent && !oldSrc.SequenceEqual(GetSourceList()))
        {
            BroadcastListChangedEvent(new EventArgs());
        }
    }

    public void InitialiseDestination(List<object> destination, bool broadcastMissingElement = true)
    {
        IsValid = true;
        var oldDest = GetDestinationList();
        LstDestination.Items.Clear();
        if (destination != null)
        {
            foreach (var destItem in destination)
            {
                if (destItem != null)
                {
                    if (LstSource.Items.Contains(destItem))
                    {
                        LstSource.Items.Remove(destItem);
                        _ = LstDestination.Items.Add(destItem);
                    }
                    else
                    {
                        IsValid = false;
                        if (broadcastMissingElement)
                        {
                            string name = destItem?.ToString() ?? "UNKNOWN";
                            BroadcastSourceListInitWithMissingElement(name);
                        }
                    }
                }
            }
        }
        if (!oldDest.SequenceEqual(GetDestinationList()))
        {
            BroadcastListChangedEvent(new EventArgs());
        }
    }

    /// <summary>Used when the user has already chosen but the underlying set of options has changed as it keeps the choices where possible</summary>
    /// <param name="throwIfNotInSource"></param>
    public void ReinitialiseDestination(bool broadcastMissingElement = false)
    {
        List<object> newDest = GetDestinationList();
        InitialiseDestination(newDest, broadcastMissingElement);
    }

    #region Formatting
    private List<FormatInfo> _Formats { get; init; } = [];


    protected class FormatInfo
    {
        public HashSet<string?> Items { get; set; } = [];
        public Color? Foreground { get; set; }
        public Color? Background { get; set; }

        public FontStyle? FontStyle { get; set; }
    }

    public void ClearFormats() => _Formats.Clear();

    public void AddFormats(IEnumerable itemsToFormat, Color? foreground, Color? background, FontStyle? style = null)
    {
        HashSet<string?> items = [];
        foreach (var item in itemsToFormat) { _ = items.Add(item.ToString()); }

        if (!OperatingSystem.IsWindows()) { style = null; }

        var info = new FormatInfo() { Items = items, Foreground = foreground, Background = background, FontStyle = style };
        _Formats.Add(info);
    }
    #endregion

    public List<object> GetDestinationList()
    {
        List<object> answer = [];
        foreach (object item in LstDestination.Items)
        {
            answer.Add(item);
        }
        return answer;
    }

    public List<object> GetSourceList()
    {
        List<object> answer = [];
        foreach (object item in LstSource.Items)
        {
            answer.Add(item);
        }
        return answer;
    }

    public List<object> GetAllItems() => [.. GetDestinationList(), .. GetSourceList()];

    #region Moving items around
    private void BtnAddAll_Click(object sender, EventArgs e)
    {
        LstDestination.Items.AddRange(LstSource.Items);
        LstSource.Items.Clear();
        BroadcastListChangedEvent(e);
    }

    private void BtnAddSelected_Click(object sender, EventArgs e)
    {
        List<object> temp = [.. LstSource.SelectedItems];

        foreach (var item in temp)
        {
            _ = LstDestination.Items.Add(item);
            LstSource.Items.Remove(item);
        }
        BroadcastListChangedEvent(e);
    }

    private void BtnRemoveSelected_Click(object sender, EventArgs e)
    {
        List<object> temp = [.. LstDestination.SelectedItems];

        foreach (var item in temp)
        {
            _ = LstSource.Items.Add(item);
            LstDestination.Items.Remove(item);
        }
        BroadcastListChangedEvent(e);
    }

    private void BtnRemoveAll_Click(object sender, EventArgs e)
    {
        LstSource.Items.AddRange(LstDestination.Items);
        LstDestination.Items.Clear();
        BroadcastListChangedEvent(e);
    }

    /// <summary>Move all the selected items to the top, keeping their relative positions the same
    /// Start from the bottom and work up in order to do this
    /// Note: Documentation does not mention any guarantee that SelectedItems is sorted by index nor that SelectedIndices is sorted
    /// </summary>
    /// <param name="sender">unused</param>
    /// <param name="e">unused</param>
    private void BtnMoveTop_Click(object sender, EventArgs e)
    {
        List<int> indices = [.. LstDestination.SelectedIndices.Cast<int>()];
        indices.Sort();
        indices.Reverse();
        LstDestination.SelectedIndices.Clear();

        List<object> items = [];
        for (int ix = 0; ix < indices.Count; ++ix)
        {
            items.Add(LstDestination.Items[indices[ix]]);
        }
        foreach (var item in items)
        {
            LstDestination.Items.Remove(item);
            LstDestination.Items.Insert(0, item);
            LstDestination.SelectedItems.Add(item);
        }
        BroadcastListChangedEvent(e);
    }

    /// <summary>Move all the selected items up one
    /// The complicating factor is that the item immediately above it may also be selected
    /// Whole blocks need to appear to be moved together
    /// To do this, move the item above the selected block to just below the selected block
    /// </summary>
    /// <param name="sender">unused</param>
    /// <param name="e">unused</param>
    private void BtnMoveUp_Click(object sender, EventArgs e)
    {
        var indices = LstDestination.SelectedIndices;
        var bottom = -1; // the index of the last item in the block currently being procesed
        bool inSelection = false;
        for (int ix = LstDestination.Items.Count - 1; ix >= 0; ix--)
        {
            if (indices.Contains(ix)) // i.e. this was selected
            {
                inSelection = true;
                if (bottom == -1) { bottom = ix; }
            }
            else
            {
                if (inSelection)
                {
                    var item = LstDestination.Items[ix];
                    LstDestination.Items.RemoveAt(ix);
                    LstDestination.Items.Insert(bottom, item);
                    inSelection = false;
                    bottom = -1;
                }
            }
        }
    }

    /// <summary>Move all the selected items down one
    /// The complicating factor is that the item immediately above it may also be selected
    /// Whole blocks need to appear to be moved together
    /// To do this, move the item below the selected block to just above the selected block
    /// </summary>
    /// <param name="sender">unused</param>
    /// <param name="e">unused</param>
    private void BtnMoveDown_Click(object sender, EventArgs e)
    {
        var indices = LstDestination.SelectedIndices;
        var bottom = -1;
        bool inSelection = false;
        for (int ix = 0; ix < LstDestination.Items.Count; ++ix)
        {
            if (indices.Contains(ix)) // i.e. this was selected
            {
                inSelection = true;
                if (bottom == -1) { bottom = ix; }
            }
            else
            {
                if (inSelection)
                {
                    var item = LstDestination.Items[ix];
                    LstDestination.Items.RemoveAt(ix);
                    LstDestination.Items.Insert(bottom, item);
                    inSelection = false;
                    bottom = -1;
                }
            }
        }
    }

    /// <summary>Move selected items to the bottom of the list, keeping their relative positions the same
    /// Note: Documentation does not mention any guarantee that SelectedItems is sorted by index nor that SelectedIndices is sorted
    /// </summary>
    /// <param name="sender">Unused</param>
    /// <param name="e">Unused</param>
    private void BtnMoveBottom_Click(object sender, EventArgs e)
    {
        List<int> indices = [.. LstDestination.SelectedIndices.Cast<int>()];
        indices.Sort();
        LstDestination.SelectedIndices.Clear();

        List<object> items = [];
        for (int ix = 0; ix < indices.Count; ++ix)
        {
            items.Add(LstDestination.Items[indices[ix]]);
        }
        foreach (var item in items)
        {
            LstDestination.Items.Remove(item);
            _ = LstDestination.Items.Add(item);
            LstDestination.SelectedItems.Add(item);
        }
        BroadcastListChangedEvent(e);
    }
    #endregion

    private void LstDestination_SelectedIndexChanged(object sender, EventArgs e) => BroadcastDestinationSelectedIndexChanged(e);

}

public class List2ListBacker<T> : ControlBacker<T>
{
    public List2ListBacker(List2List list2list, string destinationPropertyName, List<T> sourceItems)
        : base(list2list, nameof(list2list.ChosenItems), destinationPropertyName)
    {
        List<object> sourceObjects = [.. sourceItems.Cast<object>()];
        list2list.InitialiseSource(sourceObjects);
    }

    public override bool TryLoad(IBackingData data, out string msg)
    {
        if (Ctrl is List2List list2list)
        {
            if (data.TryGetPropertyValue(BackingPropertyName, out List<T>? items, out msg))
            {
                if (items != null)
                {
                    list2list.InitialiseDestination([.. items.Cast<object>()]);
                    return true;
                }
            }
        }
        else
        {
            msg = $"Internal Error: Control {Ctrl.Name} is not a List2ListControl";
        }
        return false;
    }

    public override bool TrySave(IBackingData data, out String msg)
    {
        if (Ctrl is List2List list2list)
        {
            List<object> objects = list2list.ChosenItems;
            List<T> items = [.. objects.Cast<T>()];
            return data.TrySetPropertyValue(BackingPropertyName, items, out msg);
        }
        else
        {
            msg = $"Internal Error: Control {Ctrl.Name} is not a List2ListControl";
        }
        return false;
    }
}

public partial class BackingMap
{
    public void Add<T>(List2List ctrl, string dataDestinationPropertyName, List<T> sourceItems)
    {
        var list2listBacker = new List2ListBacker<T>(ctrl, dataDestinationPropertyName, sourceItems);
        ControlBackers.Add(list2listBacker);
    }
}
