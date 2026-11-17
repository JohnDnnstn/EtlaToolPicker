using EtlaToolPicker.BackingData;
using EtlaToolPicker.EtlaToolbelt.Forms;
using static EtlaToolPicker.Program;

namespace EtlaToolPicker.Forms;

public partial class TestsForm : BackedForm
{
    protected TopLevelData Data { get; set; } = new TopLevelData();

    //For the designer
    protected TestsForm() { }

    public TestsForm(TopLevelData data) : base(data)
    {
        InitializeComponent();

        Data = data;

        Map.Add(CmbSomeString, nameof(Data.SomeString), TopLevelData.SomeStrings);
        Map.Add(CmbZero, nameof(Data.Next), TopLevelData.AllTopLevelData);

        Map.Add(RdoZero, nameof(Data.ZeroToThree), ZeroToThree.ZERO);
        Map.Add(RdoOne, nameof(Data.ZeroToThree), ZeroToThree.ONE);
        Map.Add(RdoTwo, nameof(Data.ZeroToThree), ZeroToThree.TWO);
        Map.Add(RdoThree, nameof(Data.ZeroToThree), ZeroToThree.THREE);

        Map.Add<BaseCol>(GrdTest, nameof(Data.BaseCols));
        Map.Add(L2lTest, nameof(Data.ChosenTopLevelData), TopLevelData.AllTopLevelData);
    }

    private void InitGrid()
    {
        GrdTest.Columns.Clear();

        GrdTest.AutoGenerateColumns = true;
        GrdTest.AutoSize = true;

        DataGridViewColumn gridCol = new DataGridViewTextBoxColumn();
        gridCol.DataPropertyName = gridCol.Name = nameof(BaseCol.Id);
        gridCol.ReadOnly = true;
        GrdTest.Columns.Add(gridCol);

        gridCol = new DataGridViewTextBoxColumn();
        gridCol.DataPropertyName = gridCol.Name = "ColName";
        GrdTest.Columns.Add(gridCol);

        gridCol = new DataGridViewTextBoxColumn();
        gridCol.DataPropertyName = gridCol.Name = "SomeText";
        GrdTest.Columns.Add(gridCol);

        GrdTest.Visible = GrdTest.Enabled = true;
        GrdTest.Refresh();
    }

    private void TestsForm_Load(object sender, EventArgs e)
    {
        InitGrid();
    }
}
