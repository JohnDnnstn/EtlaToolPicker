namespace EtlaToolPicker.Forms;

partial class TestsForm
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
        GrdTest = new DataGridView();
        L2lTest = new EtlaToolPicker.EtlaToolbelt.Forms.List2List();
        CmbSomeString = new ComboBox();
        CmbZero = new ComboBox();
        groupBox1 = new GroupBox();
        RdoThree = new RadioButton();
        RdoTwo = new RadioButton();
        RdoOne = new RadioButton();
        RdoZero = new RadioButton();
        ((System.ComponentModel.ISupportInitialize)GrdTest).BeginInit();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // GrdTest
        // 
        GrdTest.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        GrdTest.Location = new Point(253, 40);
        GrdTest.Name = "GrdTest";
        GrdTest.Size = new Size(523, 124);
        GrdTest.TabIndex = 26;
        // 
        // L2lTest
        // 
        L2lTest.Location = new Point(253, 188);
        L2lTest.Name = "L2lTest";
        L2lTest.Size = new Size(523, 160);
        L2lTest.TabIndex = 27;
        // 
        // CmbSomeString
        // 
        CmbSomeString.FormattingEnabled = true;
        CmbSomeString.Location = new Point(29, 40);
        CmbSomeString.Name = "CmbSomeString";
        CmbSomeString.Size = new Size(111, 23);
        CmbSomeString.TabIndex = 28;
        // 
        // CmbZero
        // 
        CmbZero.FormattingEnabled = true;
        CmbZero.Location = new Point(29, 84);
        CmbZero.Name = "CmbZero";
        CmbZero.Size = new Size(111, 23);
        CmbZero.TabIndex = 29;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(RdoThree);
        groupBox1.Controls.Add(RdoTwo);
        groupBox1.Controls.Add(RdoOne);
        groupBox1.Controls.Add(RdoZero);
        groupBox1.Location = new Point(29, 197);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(200, 125);
        groupBox1.TabIndex = 30;
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
        // TestsForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(groupBox1);
        Controls.Add(CmbZero);
        Controls.Add(CmbSomeString);
        Controls.Add(L2lTest);
        Controls.Add(GrdTest);
        Name = "TestsForm";
        Text = "TestsForm";
        Load += TestsForm_Load;
        ((System.ComponentModel.ISupportInitialize)GrdTest).EndInit();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView GrdTest;
    private EtlaToolbelt.Forms.List2List L2lTest;
    private ComboBox CmbSomeString;
    private ComboBox CmbZero;
    private GroupBox groupBox1;
    private RadioButton RdoThree;
    private RadioButton RdoTwo;
    private RadioButton RdoOne;
    private RadioButton RdoZero;
}