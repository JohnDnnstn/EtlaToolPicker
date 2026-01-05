using EtlaToolPicker.BackingData;
using EtlaToolPicker.EtlaToolbelt.Forms;
using static EtlaToolPicker.Program;

namespace EtlaToolPicker
{
    public partial class TopLevelForm : BackedForm
    {
        protected TopLevelData Data { get; set; }

        public TopLevelForm(TopLevelData data) : base(data)
        {
            InitializeComponent();
            Data = data;

            BackingMap.Add(TxtTargetDir, nameof(Data.TargetDirectory));
            BackingMap.Add(TxtNamespace, nameof(Data.TargetNamespace));
            BackingMap.Add(ChkBlackAndWhite, nameof(Data.HasBlackAndWhite));
            BackingMap.Add(ChkScript, nameof(Data.HasScripts));
            BackingMap.Add(ChkForm, nameof(Data.HasForms));
            BackingMap.Add(ChkWizard, nameof(Data.HasWizards));
            BackingMap.Add(ChkFascias, nameof(Data.HasFascias));
            BackingMap.Add(ChkCmdLine, nameof(Data.CmdLines));
            BackingMap.Add(ChkLog, nameof(Data.Logs));
            //Backing.Add(ChkConfig, nameof(Data.HasConfig));
            BackingMap.Add(ChkContext, nameof(Data.Contexts));
            BackingMap.Add(ChkAssemblyInfo, nameof(Data.HasAssemblyInfo));
            BackingMap.Add(TxtApplication, nameof(Data.ApplicationName));
            BackingMap.Add(TxtCompany, nameof(Data.CompanyName));

            BackingMap.Add(RdoZero, nameof(Data.ZeroToThree), ZeroToThree.ZERO);
            BackingMap.Add(RdoOne, nameof(Data.ZeroToThree), ZeroToThree.ONE);
            BackingMap.Add(RdoTwo, nameof(Data.ZeroToThree), ZeroToThree.TWO);
            BackingMap.Add(RdoThree, nameof(Data.ZeroToThree), ZeroToThree.THREE);

            BackingMap.Add(CmbSomeString, nameof(Data.SomeString), TopLevelData.SomeStrings);

            BackingMap.Add(CmbZero, nameof(Data.Next), TopLevelData.AllTopLevelData);

            _ = new VisibiltyCascade(ChkFascias, GrpFascias);
            _ = new VisibiltyCascade(ChkAssemblyInfo, GrpAssemblyInfo);
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var browser = new FolderBrowserDialog())
            {
                if (browser.ShowDialog() == DialogResult.OK)
                {
                    TxtTargetDir.Text = browser.SelectedPath;
                }
            }
        }

        private void BtnAddTools_Click(object sender, EventArgs e)
        {
            TrySave();
            bool ok = GenerateToolbelt.Generate(Data);
            Console.WriteLine("OK = {ok}");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool ok = TrySave();
            Console.WriteLine("OK = {ok}");
        }
    }
}
