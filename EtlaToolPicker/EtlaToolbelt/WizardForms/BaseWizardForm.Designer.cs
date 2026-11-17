
// This class is generated from the EtlaTool.Wizards template

namespace EtlaToolPicker.EtlaToolbelt.Forms
{
    partial class BaseWizardForm
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
            TxtRubric = new TextBox();
            BtnBack = new Button();
            BtnNext = new Button();
            SuspendLayout();
            // 
            // TxtRubric
            // 
            TxtRubric.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtRubric.Location = new Point(12, 2);
            TxtRubric.Multiline = true;
            TxtRubric.Name = "TxtRubric";
            TxtRubric.ReadOnly = true;
            TxtRubric.Size = new Size(822, 54);
            TxtRubric.TabIndex = 99;
            // 
            // BtnBack
            // 
            BtnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnBack.BackColor = SystemColors.ButtonFace;
            BtnBack.DialogResult = DialogResult.No;
            BtnBack.FlatStyle = FlatStyle.System;
            BtnBack.Location = new Point(12, 420);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(75, 23);
            BtnBack.TabIndex = 91;
            BtnBack.Text = "Back";
            BtnBack.UseVisualStyleBackColor = false;
            // 
            // BtnNext
            // 
            BtnNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnNext.BackColor = SystemColors.ButtonFace;
            BtnNext.DialogResult = DialogResult.Yes;
            BtnNext.FlatAppearance.MouseDownBackColor = SystemColors.ControlLight;
            BtnNext.FlatStyle = FlatStyle.System;
            BtnNext.Location = new Point(713, 420);
            BtnNext.Name = "BtnNext";
            BtnNext.Size = new Size(75, 23);
            BtnNext.TabIndex = 90;
            BtnNext.Text = "Next";
            BtnNext.UseVisualStyleBackColor = false;
            // 
            // BaseWizardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnNext);
            Controls.Add(BtnBack);
            Controls.Add(TxtRubric);
            Name = "BaseWizardForm";
            Text = "Base Wizard Form";
            FormClosing += BaseWizardForm_FormClosing;
            Load += BaseWizardForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        protected Button BtnBack;
        protected Button BtnNext;
        protected TextBox TxtRubric;
    }
}