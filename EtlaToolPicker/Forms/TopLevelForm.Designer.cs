namespace EtlaToolPicker
{
    partial class TopLevelForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            TxtRubric = new TextBox();
            TxtTargetDir = new TextBox();
            BtnBrowse = new Button();
            label2 = new Label();
            TxtNamespace = new TextBox();
            ChkCmdLine = new CheckBox();
            ChkLog = new CheckBox();
            ChkBlackAndWhite = new CheckBox();
            ChkConfig = new CheckBox();
            ChkContext = new CheckBox();
            ChkScript = new CheckBox();
            ChkForm = new CheckBox();
            ChkWizard = new CheckBox();
            GrpFascias = new GroupBox();
            BtnContext = new Button();
            BtnConfig = new Button();
            BtnLog = new Button();
            BtnCmdLine = new Button();
            ChkFascias = new CheckBox();
            BtnAddTools = new Button();
            ChkAssemblyInfo = new CheckBox();
            GrpAssemblyInfo = new GroupBox();
            TxtCompany = new TextBox();
            TxtApplication = new TextBox();
            label4 = new Label();
            label3 = new Label();
            BtnSave = new Button();
            groupBox1 = new GroupBox();
            RdoThree = new RadioButton();
            RdoTwo = new RadioButton();
            RdoOne = new RadioButton();
            RdoZero = new RadioButton();
            CmbZero = new ComboBox();
            CmbSomeString = new ComboBox();
            GrpFascias.SuspendLayout();
            GrpAssemblyInfo.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 52);
            label1.Name = "label1";
            label1.Size = new Size(134, 15);
            label1.TabIndex = 0;
            label1.Text = "Target Project Directory:";
            // 
            // TxtRubric
            // 
            TxtRubric.Location = new Point(12, 12);
            TxtRubric.Name = "TxtRubric";
            TxtRubric.ReadOnly = true;
            TxtRubric.Size = new Size(776, 23);
            TxtRubric.TabIndex = 1;
            TxtRubric.TabStop = false;
            TxtRubric.Text = "This allows you to choose parts of the ETLA toolbox to put into an ETLA toolbelt";
            // 
            // TxtTargetDir
            // 
            TxtTargetDir.Location = new Point(149, 49);
            TxtTargetDir.Name = "TxtTargetDir";
            TxtTargetDir.Size = new Size(558, 23);
            TxtTargetDir.TabIndex = 2;
            // 
            // BtnBrowse
            // 
            BtnBrowse.Location = new Point(713, 48);
            BtnBrowse.Name = "BtnBrowse";
            BtnBrowse.Size = new Size(75, 23);
            BtnBrowse.TabIndex = 1;
            BtnBrowse.Text = "Browse";
            BtnBrowse.UseVisualStyleBackColor = true;
            BtnBrowse.Click += BtnBrowse_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 81);
            label2.Name = "label2";
            label2.Size = new Size(106, 15);
            label2.TabIndex = 4;
            label2.Text = "Target namespace:";
            // 
            // TxtNamespace
            // 
            TxtNamespace.Location = new Point(149, 78);
            TxtNamespace.Name = "TxtNamespace";
            TxtNamespace.Size = new Size(226, 23);
            TxtNamespace.TabIndex = 2;
            // 
            // ChkCmdLine
            // 
            ChkCmdLine.AutoSize = true;
            ChkCmdLine.Location = new Point(17, 22);
            ChkCmdLine.Name = "ChkCmdLine";
            ChkCmdLine.Size = new Size(74, 19);
            ChkCmdLine.TabIndex = 6;
            ChkCmdLine.Text = "CmdLine";
            ChkCmdLine.UseVisualStyleBackColor = true;
            // 
            // ChkLog
            // 
            ChkLog.AutoSize = true;
            ChkLog.Location = new Point(17, 47);
            ChkLog.Name = "ChkLog";
            ChkLog.Size = new Size(46, 19);
            ChkLog.TabIndex = 7;
            ChkLog.Text = "Log";
            ChkLog.UseVisualStyleBackColor = true;
            // 
            // ChkBlackAndWhite
            // 
            ChkBlackAndWhite.AutoSize = true;
            ChkBlackAndWhite.Location = new Point(12, 122);
            ChkBlackAndWhite.Name = "ChkBlackAndWhite";
            ChkBlackAndWhite.Size = new Size(111, 19);
            ChkBlackAndWhite.TabIndex = 8;
            ChkBlackAndWhite.Text = "Black and White";
            ChkBlackAndWhite.UseVisualStyleBackColor = true;
            // 
            // ChkConfig
            // 
            ChkConfig.AutoSize = true;
            ChkConfig.Enabled = false;
            ChkConfig.Location = new Point(17, 72);
            ChkConfig.Name = "ChkConfig";
            ChkConfig.Size = new Size(62, 19);
            ChkConfig.TabIndex = 9;
            ChkConfig.Text = "Config";
            ChkConfig.UseVisualStyleBackColor = true;
            // 
            // ChkContext
            // 
            ChkContext.AutoSize = true;
            ChkContext.Location = new Point(17, 97);
            ChkContext.Name = "ChkContext";
            ChkContext.Size = new Size(67, 19);
            ChkContext.TabIndex = 10;
            ChkContext.Text = "Context";
            ChkContext.UseVisualStyleBackColor = true;
            // 
            // ChkScript
            // 
            ChkScript.AutoSize = true;
            ChkScript.Location = new Point(12, 147);
            ChkScript.Name = "ChkScript";
            ChkScript.Size = new Size(61, 19);
            ChkScript.TabIndex = 11;
            ChkScript.Text = "Scripts";
            ChkScript.UseVisualStyleBackColor = true;
            // 
            // ChkForm
            // 
            ChkForm.AutoSize = true;
            ChkForm.Location = new Point(12, 172);
            ChkForm.Name = "ChkForm";
            ChkForm.Size = new Size(59, 19);
            ChkForm.TabIndex = 12;
            ChkForm.Text = "Forms";
            ChkForm.UseVisualStyleBackColor = true;
            // 
            // ChkWizard
            // 
            ChkWizard.AutoSize = true;
            ChkWizard.Location = new Point(12, 197);
            ChkWizard.Name = "ChkWizard";
            ChkWizard.Size = new Size(67, 19);
            ChkWizard.TabIndex = 13;
            ChkWizard.Text = "Wizards";
            ChkWizard.UseVisualStyleBackColor = true;
            // 
            // GrpFascias
            // 
            GrpFascias.Controls.Add(BtnContext);
            GrpFascias.Controls.Add(BtnConfig);
            GrpFascias.Controls.Add(BtnLog);
            GrpFascias.Controls.Add(BtnCmdLine);
            GrpFascias.Controls.Add(ChkCmdLine);
            GrpFascias.Controls.Add(ChkLog);
            GrpFascias.Controls.Add(ChkConfig);
            GrpFascias.Controls.Add(ChkContext);
            GrpFascias.Location = new Point(139, 147);
            GrpFascias.Name = "GrpFascias";
            GrpFascias.Size = new Size(200, 124);
            GrpFascias.TabIndex = 14;
            GrpFascias.TabStop = false;
            GrpFascias.Text = "Fascia Tools";
            // 
            // BtnContext
            // 
            BtnContext.Location = new Point(97, 94);
            BtnContext.Name = "BtnContext";
            BtnContext.Size = new Size(75, 23);
            BtnContext.TabIndex = 14;
            BtnContext.Text = "Impl";
            BtnContext.UseVisualStyleBackColor = true;
            // 
            // BtnConfig
            // 
            BtnConfig.Enabled = false;
            BtnConfig.Location = new Point(97, 69);
            BtnConfig.Name = "BtnConfig";
            BtnConfig.Size = new Size(75, 23);
            BtnConfig.TabIndex = 13;
            BtnConfig.Text = "Impl";
            BtnConfig.UseVisualStyleBackColor = true;
            // 
            // BtnLog
            // 
            BtnLog.Location = new Point(97, 44);
            BtnLog.Name = "BtnLog";
            BtnLog.Size = new Size(75, 23);
            BtnLog.TabIndex = 12;
            BtnLog.Text = "Impl";
            BtnLog.UseVisualStyleBackColor = true;
            // 
            // BtnCmdLine
            // 
            BtnCmdLine.Location = new Point(97, 19);
            BtnCmdLine.Name = "BtnCmdLine";
            BtnCmdLine.Size = new Size(75, 23);
            BtnCmdLine.TabIndex = 11;
            BtnCmdLine.Text = "Impl";
            BtnCmdLine.UseVisualStyleBackColor = true;
            // 
            // ChkFascias
            // 
            ChkFascias.AutoSize = true;
            ChkFascias.Location = new Point(139, 122);
            ChkFascias.Name = "ChkFascias";
            ChkFascias.Size = new Size(114, 19);
            ChkFascias.TabIndex = 15;
            ChkFascias.Text = "Fascia style tools";
            ChkFascias.UseVisualStyleBackColor = true;
            // 
            // BtnAddTools
            // 
            BtnAddTools.DialogResult = DialogResult.Yes;
            BtnAddTools.Location = new Point(713, 415);
            BtnAddTools.Name = "BtnAddTools";
            BtnAddTools.Size = new Size(75, 23);
            BtnAddTools.TabIndex = 16;
            BtnAddTools.Text = "Add Tools";
            BtnAddTools.UseVisualStyleBackColor = true;
            BtnAddTools.Click += BtnAddTools_Click;
            // 
            // ChkAssemblyInfo
            // 
            ChkAssemblyInfo.AutoSize = true;
            ChkAssemblyInfo.Location = new Point(359, 122);
            ChkAssemblyInfo.Name = "ChkAssemblyInfo";
            ChkAssemblyInfo.Size = new Size(268, 19);
            ChkAssemblyInfo.TabIndex = 17;
            ChkAssemblyInfo.Text = "AssmblyInfo Generation From Version Control";
            ChkAssemblyInfo.UseVisualStyleBackColor = true;
            // 
            // GrpAssemblyInfo
            // 
            GrpAssemblyInfo.Controls.Add(TxtCompany);
            GrpAssemblyInfo.Controls.Add(TxtApplication);
            GrpAssemblyInfo.Controls.Add(label4);
            GrpAssemblyInfo.Controls.Add(label3);
            GrpAssemblyInfo.Location = new Point(359, 147);
            GrpAssemblyInfo.Name = "GrpAssemblyInfo";
            GrpAssemblyInfo.Size = new Size(429, 124);
            GrpAssemblyInfo.TabIndex = 18;
            GrpAssemblyInfo.TabStop = false;
            GrpAssemblyInfo.Text = "AssemblyInfo";
            // 
            // TxtCompany
            // 
            TxtCompany.Location = new Point(83, 48);
            TxtCompany.Name = "TxtCompany";
            TxtCompany.Size = new Size(340, 23);
            TxtCompany.TabIndex = 3;
            // 
            // TxtApplication
            // 
            TxtApplication.Location = new Point(83, 23);
            TxtApplication.Name = "TxtApplication";
            TxtApplication.Size = new Size(340, 23);
            TxtApplication.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 48);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 1;
            label4.Text = "Company:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 23);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 0;
            label3.Text = "Application:";
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(359, 415);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(75, 23);
            BtnSave.TabIndex = 19;
            BtnSave.Text = "Save";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RdoThree);
            groupBox1.Controls.Add(RdoTwo);
            groupBox1.Controls.Add(RdoOne);
            groupBox1.Controls.Add(RdoZero);
            groupBox1.Location = new Point(139, 296);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 125);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // RdoThree
            // 
            RdoThree.AutoSize = true;
            RdoThree.Location = new Point(10, 97);
            RdoThree.Name = "RdoThree";
            RdoThree.Size = new Size(55, 19);
            RdoThree.TabIndex = 21;
            RdoThree.TabStop = true;
            RdoThree.Text = "Three";
            RdoThree.UseVisualStyleBackColor = true;
            // 
            // RdoTwo
            // 
            RdoTwo.AutoSize = true;
            RdoTwo.Location = new Point(10, 72);
            RdoTwo.Name = "RdoTwo";
            RdoTwo.Size = new Size(47, 19);
            RdoTwo.TabIndex = 21;
            RdoTwo.TabStop = true;
            RdoTwo.Text = "Two";
            RdoTwo.UseVisualStyleBackColor = true;
            // 
            // RdoOne
            // 
            RdoOne.AutoSize = true;
            RdoOne.Location = new Point(10, 47);
            RdoOne.Name = "RdoOne";
            RdoOne.Size = new Size(47, 19);
            RdoOne.TabIndex = 21;
            RdoOne.TabStop = true;
            RdoOne.Text = "One";
            RdoOne.UseVisualStyleBackColor = true;
            // 
            // RdoZero
            // 
            RdoZero.AutoSize = true;
            RdoZero.Location = new Point(10, 22);
            RdoZero.Name = "RdoZero";
            RdoZero.Size = new Size(49, 19);
            RdoZero.TabIndex = 0;
            RdoZero.TabStop = true;
            RdoZero.Text = "Zero";
            RdoZero.UseVisualStyleBackColor = true;
            // 
            // CmbZero
            // 
            CmbZero.FormattingEnabled = true;
            CmbZero.Location = new Point(442, 314);
            CmbZero.Name = "CmbZero";
            CmbZero.Size = new Size(340, 23);
            CmbZero.TabIndex = 21;
            // 
            // CmbSomeString
            // 
            CmbSomeString.FormattingEnabled = true;
            CmbSomeString.Location = new Point(12, 314);
            CmbSomeString.Name = "CmbSomeString";
            CmbSomeString.Size = new Size(111, 23);
            CmbSomeString.TabIndex = 22;
            // 
            // TopLevelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CmbSomeString);
            Controls.Add(CmbZero);
            Controls.Add(groupBox1);
            Controls.Add(BtnSave);
            Controls.Add(GrpAssemblyInfo);
            Controls.Add(ChkAssemblyInfo);
            Controls.Add(BtnAddTools);
            Controls.Add(ChkFascias);
            Controls.Add(GrpFascias);
            Controls.Add(ChkWizard);
            Controls.Add(ChkForm);
            Controls.Add(ChkScript);
            Controls.Add(ChkBlackAndWhite);
            Controls.Add(TxtNamespace);
            Controls.Add(label2);
            Controls.Add(BtnBrowse);
            Controls.Add(TxtTargetDir);
            Controls.Add(TxtRubric);
            Controls.Add(label1);
            Name = "TopLevelForm";
            Text = "Top level Form";
            GrpFascias.ResumeLayout(false);
            GrpFascias.PerformLayout();
            GrpAssemblyInfo.ResumeLayout(false);
            GrpAssemblyInfo.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TxtRubric;
        private TextBox TxtTargetDir;
        private Button BtnBrowse;
        private Label label2;
        private TextBox TxtNamespace;
        private CheckBox ChkCmdLine;
        private CheckBox ChkLog;
        private CheckBox ChkBlackAndWhite;
        private CheckBox ChkConfig;
        private CheckBox ChkContext;
        private CheckBox ChkScript;
        private CheckBox ChkForm;
        private CheckBox ChkWizard;
        private GroupBox GrpFascias;
        private Button BtnContext;
        private Button BtnConfig;
        private Button BtnLog;
        private Button BtnCmdLine;
        private CheckBox ChkFascias;
        private Button BtnAddTools;
        private CheckBox ChkAssemblyInfo;
        private GroupBox GrpAssemblyInfo;
        private Label label3;
        private Label label4;
        private TextBox TxtApplication;
        private TextBox TxtCompany;
        private Button BtnSave;
        private GroupBox groupBox1;
        private RadioButton RdoThree;
        private RadioButton RdoTwo;
        private RadioButton RdoOne;
        private RadioButton RdoZero;
        private ComboBox CmbZero;
        private ComboBox CmbSomeString;
    }
}
