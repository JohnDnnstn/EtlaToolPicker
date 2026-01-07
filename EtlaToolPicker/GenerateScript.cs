using EtlaToolPicker.EtlaToolbelt;

namespace EtlaToolPicker;

public class GenerateScript : Script
{
    public class Col
    {
        internal string Name { get; set; }
        internal string SqlType { get; set; }
        internal Col(string name) 
        { 
            Name = name; 
            SqlType = "text"; 
        }

        public override string ToString() => Name;
    }

    internal string Generate(List<string> letters)
    {
        List<Col> cols = [];
        foreach (var letter in letters)
        {
            cols.Add(new Col(letter));
        }

        Scr("Hello world", false);
        Scr("{", 1);
        Scr("SELECT",1);
        PrettyJoin(letters, ", ", maxLine: 120, itemPrefix: "table678.");
        Scr("FROM Table1;",-1);
        Scr();
        Scr("SELECT",1);
        ItemPerLineJoin(letters);
        Scr("FROM Table2;",-1);
        Scr("}", -1);

        return ReturnAndClear();
    }
}
