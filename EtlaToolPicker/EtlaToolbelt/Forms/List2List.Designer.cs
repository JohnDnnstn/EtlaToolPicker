//------------------------------------------------------------------------------------------
// This file was generated from the EtlaTool.Wizards vsn:1.0 template
// Created 29/08/2023 17:44:59
// Copyright: Etla Services Ltd 2019-2023
//------------------------------------------------------------------------------------------


using System.Windows.Forms;
using System.Xml.Linq;

namespace EtlaToolbeltPicker.EtlaToolbelt.Forms;

partial class List2List
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tableLayoutPanel1 = new TableLayoutPanel();
        LstSource = new ListBox();
        LstDestination = new ListBox();
        tableLayoutPanel2 = new TableLayoutPanel();
        BtnAddAll = new Button();
        BtnAddSelected = new Button();
        BtnRemoveSelected = new Button();
        BtnRemoveAll = new Button();
        tableLayoutPanel4 = new TableLayoutPanel();
        BtnMoveTop = new Button();
        BtnMoveUp = new Button();
        BtnMoveDown = new Button();
        BtnMoveBottom = new Button();
        tableLayoutPanel3 = new TableLayoutPanel();
        tableLayoutPanel1.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        tableLayoutPanel4.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.AutoSize = true;
        tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        tableLayoutPanel1.ColumnCount = 5;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 4F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
        tableLayoutPanel1.Controls.Add(LstSource, 0, 0);
        tableLayoutPanel1.Controls.Add(LstDestination, 3, 0);
        tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
        tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 4, 0);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 1;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.Size = new Size(160, 160);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // LstSource
        // 
        LstSource.Dock = DockStyle.Fill;
        LstSource.FormattingEnabled = true;
        LstSource.ItemHeight = 15;
        LstSource.Location = new Point(3, 3);
        LstSource.Name = "LstSource";
        LstSource.SelectionMode = SelectionMode.MultiExtended;
        LstSource.Size = new Size(32, 154);
        LstSource.TabIndex = 0;
        LstSource.DoubleClick += BtnAddSelected_Click;
        // 
        // LstDestination
        // 
        LstDestination.Dock = DockStyle.Fill;
        LstDestination.FormattingEnabled = true;
        LstDestination.ItemHeight = 15;
        LstDestination.Location = new Point(85, 3);
        LstDestination.Name = "LstDestination";
        LstDestination.SelectionMode = SelectionMode.MultiExtended;
        LstDestination.Size = new Size(32, 154);
        LstDestination.TabIndex = 1;
        LstDestination.SelectedIndexChanged += LstDestination_SelectedIndexChanged;
        LstDestination.DoubleClick += BtnRemoveSelected_Click;
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.ColumnCount = 1;
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel2.Controls.Add(BtnAddAll, 0, 0);
        tableLayoutPanel2.Controls.Add(BtnAddSelected, 0, 1);
        tableLayoutPanel2.Controls.Add(BtnRemoveSelected, 0, 3);
        tableLayoutPanel2.Controls.Add(BtnRemoveAll, 0, 4);
        tableLayoutPanel2.Dock = DockStyle.Fill;
        tableLayoutPanel2.Location = new Point(41, 3);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 5;
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel2.Size = new Size(34, 154);
        tableLayoutPanel2.TabIndex = 2;
        // 
        // BtnAddAll
        // 
        BtnAddAll.Font = new Font("Wingdings 3", 10F, FontStyle.Bold);
        BtnAddAll.Location = new Point(3, 3);
        BtnAddAll.Name = "BtnAddAll";
        BtnAddAll.Size = new Size(28, 23);
        BtnAddAll.TabIndex = 0;
        BtnAddAll.Text = "I";
        BtnAddAll.UseVisualStyleBackColor = true;
        BtnAddAll.Click += BtnAddAll_Click;
        // 
        // BtnAddSelected
        // 
        BtnAddSelected.Font = new Font("Wingdings 3", 10F, FontStyle.Bold);
        BtnAddSelected.Location = new Point(3, 33);
        BtnAddSelected.Name = "BtnAddSelected";
        BtnAddSelected.Size = new Size(28, 23);
        BtnAddSelected.TabIndex = 1;
        BtnAddSelected.Text = "\"";
        BtnAddSelected.UseVisualStyleBackColor = true;
        BtnAddSelected.Click += BtnAddSelected_Click;
        // 
        // BtnRemoveSelected
        // 
        BtnRemoveSelected.Font = new Font("Wingdings 3", 10F, FontStyle.Bold);
        BtnRemoveSelected.Location = new Point(3, 97);
        BtnRemoveSelected.Name = "BtnRemoveSelected";
        BtnRemoveSelected.Size = new Size(28, 23);
        BtnRemoveSelected.TabIndex = 2;
        BtnRemoveSelected.Text = "!";
        BtnRemoveSelected.UseVisualStyleBackColor = true;
        BtnRemoveSelected.Click += BtnRemoveSelected_Click;
        // 
        // BtnRemoveAll
        // 
        BtnRemoveAll.Font = new Font("Wingdings 3", 10F, FontStyle.Bold);
        BtnRemoveAll.Location = new Point(3, 127);
        BtnRemoveAll.Name = "BtnRemoveAll";
        BtnRemoveAll.Size = new Size(28, 23);
        BtnRemoveAll.TabIndex = 3;
        BtnRemoveAll.Text = "H";
        BtnRemoveAll.UseVisualStyleBackColor = true;
        BtnRemoveAll.Click += BtnRemoveAll_Click;
        // 
        // tableLayoutPanel4
        // 
        tableLayoutPanel4.ColumnCount = 1;
        tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
        tableLayoutPanel4.Controls.Add(BtnMoveTop, 0, 0);
        tableLayoutPanel4.Controls.Add(BtnMoveUp, 0, 1);
        tableLayoutPanel4.Controls.Add(BtnMoveDown, 0, 3);
        tableLayoutPanel4.Controls.Add(BtnMoveBottom, 0, 4);
        tableLayoutPanel4.Dock = DockStyle.Fill;
        tableLayoutPanel4.Location = new Point(123, 3);
        tableLayoutPanel4.Name = "tableLayoutPanel4";
        tableLayoutPanel4.RowCount = 5;
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel4.Size = new Size(34, 154);
        tableLayoutPanel4.TabIndex = 3;
        // 
        // BtnMoveTop
        // 
        BtnMoveTop.Font = new Font("Wingdings 3", 10F, FontStyle.Bold);
        BtnMoveTop.Location = new Point(3, 3);
        BtnMoveTop.Name = "BtnMoveTop";
        BtnMoveTop.Size = new Size(28, 23);
        BtnMoveTop.TabIndex = 0;
        BtnMoveTop.Text = "+";
        BtnMoveTop.UseVisualStyleBackColor = true;
        BtnMoveTop.Click += BtnMoveTop_Click;
        // 
        // BtnMoveUp
        // 
        BtnMoveUp.Font = new Font("Wingdings 3", 10F);
        BtnMoveUp.Location = new Point(3, 33);
        BtnMoveUp.Name = "BtnMoveUp";
        BtnMoveUp.Size = new Size(28, 23);
        BtnMoveUp.TabIndex = 1;
        BtnMoveUp.Text = "#";
        BtnMoveUp.UseVisualStyleBackColor = true;
        BtnMoveUp.Click += BtnMoveUp_Click;
        // 
        // BtnMoveDown
        // 
        BtnMoveDown.Font = new Font("Wingdings 3", 10F);
        BtnMoveDown.Location = new Point(3, 97);
        BtnMoveDown.Name = "BtnMoveDown";
        BtnMoveDown.Size = new Size(28, 23);
        BtnMoveDown.TabIndex = 2;
        BtnMoveDown.Text = "$";
        BtnMoveDown.UseVisualStyleBackColor = true;
        BtnMoveDown.Click += BtnMoveDown_Click;
        // 
        // BtnMoveBottom
        // 
        BtnMoveBottom.Font = new Font("Wingdings 3", 10F, FontStyle.Bold);
        BtnMoveBottom.Location = new Point(3, 127);
        BtnMoveBottom.Name = "BtnMoveBottom";
        BtnMoveBottom.Size = new Size(28, 23);
        BtnMoveBottom.TabIndex = 3;
        BtnMoveBottom.Text = ",";
        BtnMoveBottom.UseVisualStyleBackColor = true;
        BtnMoveBottom.Click += BtnMoveBottom_Click;
        // 
        // tableLayoutPanel3
        // 
        tableLayoutPanel3.ColumnCount = 1;
        tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
        tableLayoutPanel3.Dock = DockStyle.Fill;
        tableLayoutPanel3.Location = new Point(0, 0);
        tableLayoutPanel3.Name = "tableLayoutPanel3";
        tableLayoutPanel3.RowCount = 5;
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel3.Size = new Size(200, 100);
        tableLayoutPanel3.TabIndex = 0;
        // 
        // List2List
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(tableLayoutPanel1);
        Name = "List2List";
        Size = new Size(160, 160);
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel2.ResumeLayout(false);
        tableLayoutPanel4.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private ListBox LstSource;
    private ListBox LstDestination;
    private TableLayoutPanel tableLayoutPanel2;
    private Button BtnAddAll;
    private Button BtnAddSelected;
    private Button BtnRemoveSelected;
    private Button BtnRemoveAll;
    private TableLayoutPanel tableLayoutPanel4;
    private TableLayoutPanel tableLayoutPanel3;
    private Button BtnMoveTop;
    private Button BtnMoveUp;
    private Button BtnMoveDown;
    private Button BtnMoveBottom;
}
