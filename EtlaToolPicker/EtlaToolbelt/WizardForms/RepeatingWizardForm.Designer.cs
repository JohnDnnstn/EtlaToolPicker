// This class is generated from the EtlaTool.Wizards template

namespace EtlaToolPicker.EtlaToolbelt.Forms
{
    partial class RepeatingWizardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnRemove = new Button();
            BtnNew = new Button();
            TxtPgNumber = new TextBox();
            label1 = new Label();
            TxtPgOf = new TextBox();
            SuspendLayout();
            // 
            // BtnNext
            // 
            BtnNext.FlatAppearance.MouseDownBackColor = SystemColors.ControlLight;
            // 
            // BtnRemove
            // 
            BtnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnRemove.DialogResult = DialogResult.Abort;
            BtnRemove.Location = new Point(93, 491);
            BtnRemove.Name = "BtnRemove";
            BtnRemove.Size = new Size(75, 23);
            BtnRemove.TabIndex = 100;
            BtnRemove.Text = "Remove";
            BtnRemove.UseVisualStyleBackColor = true;
            // 
            // BtnNew
            // 
            BtnNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnNew.DialogResult = DialogResult.OK;
            BtnNew.Location = new Point(765, 491);
            BtnNew.Name = "BtnNew";
            BtnNew.Size = new Size(75, 23);
            BtnNew.TabIndex = 101;
            BtnNew.Text = "New";
            BtnNew.UseVisualStyleBackColor = true;
            // 
            // TxtPgNumber
            // 
            TxtPgNumber.Anchor = AnchorStyles.Bottom;
            TxtPgNumber.Location = new Point(420, 492);
            TxtPgNumber.Name = "TxtPgNumber";
            TxtPgNumber.ReadOnly = true;
            TxtPgNumber.Size = new Size(34, 23);
            TxtPgNumber.TabIndex = 102;
            TxtPgNumber.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Location = new Point(460, 495);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 103;
            label1.Text = "/";
            // 
            // TxtPgOf
            // 
            TxtPgOf.Anchor = AnchorStyles.Bottom;
            TxtPgOf.Location = new Point(478, 492);
            TxtPgOf.Name = "TxtPgOf";
            TxtPgOf.ReadOnly = true;
            TxtPgOf.Size = new Size(34, 23);
            TxtPgOf.TabIndex = 104;
            // 
            // RepeatingWizardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(TxtPgOf);
            Controls.Add(label1);
            Controls.Add(TxtPgNumber);
            Controls.Add(BtnNew);
            Controls.Add(BtnRemove);
            Name = "RepeatingWizardForm";
            Text = "RepeatingWizardForm";
            Controls.SetChildIndex(TxtRubric, 0);
            Controls.SetChildIndex(BtnBack, 0);
            Controls.SetChildIndex(BtnNext, 0);
            Controls.SetChildIndex(BtnRemove, 0);
            Controls.SetChildIndex(BtnNew, 0);
            Controls.SetChildIndex(TxtPgNumber, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(TxtPgOf, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Button BtnRemove;
        protected Button BtnNew;
        private TextBox TxtPgNumber;
        private Label label1;
        private TextBox TxtPgOf;
    }
}