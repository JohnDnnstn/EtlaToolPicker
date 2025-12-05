namespace EtlaToolPicker
{
    partial class TopLevel
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            BtnBrowse = new Button();
            label2 = new Label();
            textBox3 = new TextBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            checkBox7 = new CheckBox();
            checkBox8 = new CheckBox();
            groupBox1 = new GroupBox();
            BtnContextImpl = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            checkBox9 = new CheckBox();
            BtnAddTools = new Button();
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
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(776, 23);
            textBox1.TabIndex = 1;
            textBox1.Text = "This allows you to choose parts of the ETLA toolbox to put into an ETLA toolbelt";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(149, 49);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(558, 23);
            textBox2.TabIndex = 2;
            // 
            // BtnBrowse
            // 
            BtnBrowse.Location = new Point(713, 48);
            BtnBrowse.Name = "BtnBrowse";
            BtnBrowse.Size = new Size(75, 23);
            BtnBrowse.TabIndex = 3;
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
            // textBox3
            // 
            textBox3.Location = new Point(149, 78);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(226, 23);
            textBox3.TabIndex = 5;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(17, 22);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(74, 19);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "CmdLine";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(17, 47);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(46, 19);
            checkBox2.TabIndex = 7;
            checkBox2.Text = "Log";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(12, 122);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(111, 19);
            checkBox3.TabIndex = 8;
            checkBox3.Text = "Black and White";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(17, 72);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(62, 19);
            checkBox4.TabIndex = 9;
            checkBox4.Text = "Config";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(17, 97);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(67, 19);
            checkBox5.TabIndex = 10;
            checkBox5.Text = "Context";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(12, 147);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(61, 19);
            checkBox6.TabIndex = 11;
            checkBox6.Text = "Scripts";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Location = new Point(12, 172);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(59, 19);
            checkBox7.TabIndex = 12;
            checkBox7.Text = "Forms";
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.Location = new Point(12, 197);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(67, 19);
            checkBox8.TabIndex = 13;
            checkBox8.Text = "Wizards";
            checkBox8.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnContextImpl);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(checkBox4);
            groupBox1.Controls.Add(checkBox5);
            groupBox1.Location = new Point(139, 147);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 124);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fascia Tools";
            // 
            // BtnContextImpl
            // 
            BtnContextImpl.Location = new Point(97, 94);
            BtnContextImpl.Name = "BtnContextImpl";
            BtnContextImpl.Size = new Size(75, 23);
            BtnContextImpl.TabIndex = 14;
            BtnContextImpl.Text = "Impl";
            BtnContextImpl.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(97, 69);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 13;
            button4.Text = "Impl";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(97, 44);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 12;
            button3.Text = "Impl";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(97, 19);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 11;
            button2.Text = "Impl";
            button2.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            checkBox9.AutoSize = true;
            checkBox9.Location = new Point(139, 122);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(114, 19);
            checkBox9.TabIndex = 15;
            checkBox9.Text = "Fascia style tools";
            checkBox9.UseVisualStyleBackColor = true;
            // 
            // BtnAddTools
            // 
            BtnAddTools.Location = new Point(713, 415);
            BtnAddTools.Name = "BtnAddTools";
            BtnAddTools.Size = new Size(75, 23);
            BtnAddTools.TabIndex = 16;
            BtnAddTools.Text = "Add Tools";
            BtnAddTools.UseVisualStyleBackColor = true;
            BtnAddTools.Click += BtnAddTools_Click;
            // 
            // TopLevel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnAddTools);
            Controls.Add(checkBox9);
            Controls.Add(groupBox1);
            Controls.Add(checkBox8);
            Controls.Add(checkBox7);
            Controls.Add(checkBox6);
            Controls.Add(checkBox3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(BtnBrowse);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "TopLevel";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button BtnBrowse;
        private Label label2;
        private TextBox textBox3;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private CheckBox checkBox8;
        private GroupBox groupBox1;
        private Button BtnContextImpl;
        private Button button4;
        private Button button3;
        private Button button2;
        private CheckBox checkBox9;
        private Button BtnAddTools;
    }
}
