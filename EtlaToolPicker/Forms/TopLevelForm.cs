using EtlaToolPicker.BackingData;
using EtlaToolPicker.EtlaToolbelt.Forms;
using EtlaToolPicker.EtlaToolbelt.Wizards;
using EtlaToolPicker.Forms;

namespace EtlaToolPicker
{
    public partial class TopLevelForm : BackedForm
    {
        protected TopLevelData Data { get; set; } = new TopLevelData();

        protected TopLevelForm() { }
        public TopLevelForm(TopLevelData data) : base(data)
        {
            InitializeComponent();
            Data = data;

            Map.Add(TxtTargetDir, nameof(Data.TargetDirectory));
            Map.Add(TxtNamespace, nameof(Data.TargetNamespace));

            Map.Add(ChkBlackAndWhite, nameof(Data.HasBlackAndWhite));
            Map.Add(ChkScript, nameof(Data.HasScripts));
            Map.Add(ChkForm, nameof(Data.HasForms));
            Map.Add(ChkWizard, nameof(Data.HasWizards));

            Map.Add(ChkFascias, nameof(Data.HasFascias));
            Map.Add(ChkCmdLine, nameof(Data.CmdLines));
            Map.Add(ChkLog, nameof(Data.Logs));
            //Backing.Add(ChkConfig, nameof(Data.HasConfig));
            Map.Add(ChkContext, nameof(Data.Contexts));

            Map.Add(ChkPostgres, nameof(Data.HasPostgres));

            Map.Add(ChkAssemblyInfo, nameof(Data.HasAssemblyInfo));
            Map.Add(TxtApplication, nameof(Data.ApplicationName));
            Map.Add(TxtCompany, nameof(Data.CompanyName));

            Cascades.Visibility(GrpFascias, ChkFascias);
            Cascades.Visibility(GrpAssemblyInfo, ChkAssemblyInfo);
        }


        private void TopLevelForm_Load(object sender, EventArgs e)
        {
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var browser = new FolderBrowserDialog())
            {
                if (browser.ShowDialog() == DialogResult.OK)
                {
                    TxtTargetDir.Text = browser.SelectedPath;
                    TxtNamespace.Text = Path.GetFileName(browser.SelectedPath);
                    TxtApplication.Text = TxtNamespace.Text;
                }
            }
        }

        private void BtnAddTools_Click(object sender, EventArgs e)
        {
            TrySave();
            bool ok = GenerateToolbelt.Generate(Data);
            Console.WriteLine($"OK = {ok}");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool ok = TrySave();
            Console.WriteLine($"OK = {ok}");
        }

        private void BtnScript_Click(object sender, EventArgs e)
        {
            List<string?> list = ["1234567891123456789212345678931234567894a", "1234567891123456789212345678931234567894b", null, "1234567891123456789212345678931234567894c"];
            var gen = new GenerateScript();
            var temp = gen.Generate(list);
            Console.WriteLine(temp);

        }

        private void BtnUtilities_Click(object sender, EventArgs e)
        {
            using (var form = new UtilitiesForm(Data.UtilitiesData))
            {
                var result = BaseWizard.ShowSingleton(form, this);
                if (result == FormResult.EXIT) { DialogResult = (DialogResult)result; }
            }

        }
    }
}
