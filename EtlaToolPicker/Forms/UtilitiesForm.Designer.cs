namespace EtlaToolPicker.Forms;

partial class UtilitiesForm
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
        groupBox1 = new GroupBox();
        ChkPostgresNames = new CheckBox();
        ChkPlurals = new CheckBox();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // BtnNext
        // 
        BtnNext.FlatAppearance.MouseDownBackColor = SystemColors.ControlLight;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(ChkPostgresNames);
        groupBox1.Controls.Add(ChkPlurals);
        groupBox1.Location = new Point(19, 75);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(180, 312);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "String Utilities";
        // 
        // ChkPostgresNames
        // 
        ChkPostgresNames.AutoSize = true;
        ChkPostgresNames.Location = new Point(15, 51);
        ChkPostgresNames.Name = "ChkPostgresNames";
        ChkPostgresNames.Size = new Size(143, 19);
        ChkPostgresNames.TabIndex = 1;
        ChkPostgresNames.Text = "Make Postgres Names";
        ChkPostgresNames.UseVisualStyleBackColor = true;
        // 
        // ChkPlurals
        // 
        ChkPlurals.AutoSize = true;
        ChkPlurals.Location = new Point(15, 26);
        ChkPlurals.Name = "ChkPlurals";
        ChkPlurals.Size = new Size(61, 19);
        ChkPlurals.TabIndex = 0;
        ChkPlurals.Text = "Plurals";
        ChkPlurals.UseVisualStyleBackColor = true;
        // 
        // UtilitiesForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(groupBox1);
        Name = "UtilitiesForm";
        Text = "UtilitiesForm";
        Controls.SetChildIndex(groupBox1, 0);
        Controls.SetChildIndex(TxtRubric, 0);
        Controls.SetChildIndex(BtnBack, 0);
        Controls.SetChildIndex(BtnNext, 0);
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox groupBox1;
    private CheckBox ChkPlurals;
    private CheckBox ChkPostgresNames;
}