using EtlaToolPicker.EtlaToolbelt.Forms;

namespace EtlaToolPicker;

public class BaseCol : IGridRowBackingData
{
    #region static properties
    private static int LastId = 0;
    #endregion

    public int Id { get; set; }
    public string ColName {get; set; } = "";
    public string SomeText { get; set; } = "";

    public BaseCol() { Id = ++LastId; }

    public BaseCol(string colName) : this() { ColName = colName; }
    public BaseCol(int id) { Id = id; }

    #region IGridRowBackingData
    public bool TryCopyTo(IGridRowBackingData target, out String msg)
    {
        if (target is BaseCol targ)
        {
            targ.ColName = ColName;
            targ.SomeText = SomeText;
            msg = "";
            return true;
        }
        msg = "Internal error: target was not a BaseCol";
        return false;
    }

    public bool HasSameKeyAs(IGridRowBackingData target)
    {
        if (target is BaseCol item) { return item.Id == Id; }
        return false;
    }

    public Object Clone()
    {
        var answer = new BaseCol(Id)
        {
            ColName = ColName,
            SomeText = SomeText
        };
        return answer;
    }
    #endregion
}
