namespace WinFormsApp2
{
    partial class Form_Login
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
            textBoxName = new TextBox();
            button1 = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            loginToolStripMenuItem = new ToolStripMenuItem();
            grToolStripMenuItem = new ToolStripMenuItem();
            grapToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBox1 = new ToolStripTextBox();
            toolStripComboBox1 = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItem1 = new ToolStripMenuItem();
            panel1 = new Panel();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Microsoft JhengHei UI", 10F);
            textBoxName.Location = new Point(92, 25);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 24);
            textBoxName.TabIndex = 0;
          
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft JhengHei UI", 9F);
            button1.Location = new Point(263, 349);
            button1.Name = "button1";
            button1.Size = new Size(75, 30);
            button1.TabIndex = 1;
            button1.Text = "Play";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 10F);
            label1.Location = new Point(15, 28);
            label1.Name = "label1";
            label1.Size = new Size(71, 18);
            label1.TabIndex = 2;
            label1.Text = "用戶名稱 :";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Asset.icon;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(420, 166);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // loginToolStripMenuItem
            // 
            loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            loginToolStripMenuItem.Size = new Size(32, 19);
            // 
            // grToolStripMenuItem
            // 
            grToolStripMenuItem.Name = "grToolStripMenuItem";
            grToolStripMenuItem.Size = new Size(32, 19);
            // 
            // grapToolStripMenuItem
            // 
            grapToolStripMenuItem.Name = "grapToolStripMenuItem";
            grapToolStripMenuItem.Size = new Size(32, 19);
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 23);
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 23);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 6);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(32, 19);
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(textBoxName);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 247);
            panel1.Name = "panel1";
            panel1.Size = new Size(420, 96);
            panel1.TabIndex = 6;
            // 
            // button2
            // 
            button2.Location = new Point(344, 349);
            button2.Name = "button2";
            button2.Size = new Size(75, 30);
            button2.TabIndex = 7;
            button2.Text = "Quit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form_Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 391);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Name = "Form_Login";
            Text = "LoginGame";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxName;
        private Button button1;
        private Label label1;
        private PictureBox pictureBox1;
        private ToolStripMenuItem loginToolStripMenuItem;
        private ToolStripMenuItem grToolStripMenuItem;
        private ToolStripMenuItem grapToolStripMenuItem;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem1;
        private Panel panel1;
        private Button button2;
    }
}