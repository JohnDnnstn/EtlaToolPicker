using EtlaToolPicker.BackingData;

namespace EtlaToolPicker
{
    public partial class TopLevel : Form
    {
        protected TopLevelData Data { get; set; }

        public TopLevel()
        {
            InitializeComponent();
            Data = new TopLevelData
            {
                TargetDirectory = "C:/Projects/Tests/PickerTest",
                TargetNamespace = "PickerTest",
                HasBlackAndWhite = true
            };
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {

        }

        private void BtnAddTools_Click(object sender, EventArgs e) => GenerateToolbelt.Generate(Data);
    }
}
