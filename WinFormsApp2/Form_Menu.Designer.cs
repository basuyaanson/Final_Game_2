namespace WinFormsApp2
{
    partial class Form_Menu
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
            L_Title = new Label();
            B_Start = new Button();
            P_Game = new Panel();
            B_About = new Button();
            B_Quit = new Button();
            P_Main = new Panel();
            P_About = new Panel();
            Lb_About = new ListBox();
            panel2 = new Panel();
            P_Score = new Panel();
            L_score_hero = new Label();
            PB_hero = new PictureBox();
            Lb_Score = new ListBox();
            label2 = new Label();
            B_Score = new Button();
            P_Main.SuspendLayout();
            P_About.SuspendLayout();
            P_Score.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PB_hero).BeginInit();
            SuspendLayout();
            // 
            // L_Title
            // 
            L_Title.AutoSize = true;
            L_Title.BackColor = Color.Transparent;
            L_Title.Font = new Font("Yet R", 50.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            L_Title.Location = new Point(60, 123);
            L_Title.Name = "L_Title";
            L_Title.Size = new Size(298, 71);
            L_Title.TabIndex = 0;
            L_Title.Text = "火星生存";
            // 
            // B_Start
            // 
            B_Start.BackColor = Color.Transparent;
            B_Start.Font = new Font("Impact", 30F);
            B_Start.Location = new Point(43, 302);
            B_Start.Name = "B_Start";
            B_Start.Size = new Size(378, 109);
            B_Start.TabIndex = 1;
            B_Start.TabStop = false;
            B_Start.Text = "Start";
            B_Start.UseVisualStyleBackColor = false;
            B_Start.Click += B_Start_Click;
            // 
            // P_Game
            // 
            P_Game.Location = new Point(244, 23);
            P_Game.Name = "P_Game";
            P_Game.Size = new Size(158, 65);
            P_Game.TabIndex = 2;
            P_Game.Visible = false;
            // 
            // B_About
            // 
            B_About.BackColor = Color.Transparent;
            B_About.Font = new Font("Impact", 30F);
            B_About.Location = new Point(43, 555);
            B_About.Name = "B_About";
            B_About.Size = new Size(378, 109);
            B_About.TabIndex = 3;
            B_About.Text = "About";
            B_About.UseVisualStyleBackColor = false;
            B_About.Click += B_About_Click;
            // 
            // B_Quit
            // 
            B_Quit.BackColor = Color.Transparent;
            B_Quit.Font = new Font("Impact", 30F);
            B_Quit.Location = new Point(43, 679);
            B_Quit.Name = "B_Quit";
            B_Quit.Size = new Size(378, 109);
            B_Quit.TabIndex = 4;
            B_Quit.Text = "Quit";
            B_Quit.UseVisualStyleBackColor = false;
            B_Quit.Click += B_Quit_Click;
            // 
            // P_Main
            // 
            P_Main.Controls.Add(P_About);
            P_Main.Controls.Add(panel2);
            P_Main.Controls.Add(P_Score);
            P_Main.Location = new Point(427, 58);
            P_Main.Name = "P_Main";
            P_Main.Size = new Size(1098, 730);
            P_Main.TabIndex = 0;
            P_Main.Visible = false;
            // 
            // P_About
            // 
            P_About.BackColor = Color.Transparent;
            P_About.Controls.Add(Lb_About);
            P_About.Location = new Point(236, 3);
            P_About.Name = "P_About";
            P_About.Size = new Size(329, 214);
            P_About.TabIndex = 4;
            P_About.Visible = false;
            // 
            // Lb_About
            // 
            Lb_About.BackColor = Color.Gray;
            Lb_About.Font = new Font("Microsoft JhengHei UI", 15F);
            Lb_About.ForeColor = SystemColors.ButtonHighlight;
            Lb_About.FormattingEnabled = true;
            Lb_About.ItemHeight = 25;
            Lb_About.Location = new Point(60, 32);
            Lb_About.Name = "Lb_About";
            Lb_About.Size = new Size(663, 204);
            Lb_About.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BackColor = Color.Transparent;
            panel2.Location = new Point(26, 131);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 500);
            panel2.TabIndex = 5;
            // 
            // P_Score
            // 
            P_Score.AutoScroll = true;
            P_Score.BackColor = Color.Transparent;
            P_Score.Controls.Add(L_score_hero);
            P_Score.Controls.Add(PB_hero);
            P_Score.Controls.Add(Lb_Score);
            P_Score.Location = new Point(344, 80);
            P_Score.Name = "P_Score";
            P_Score.Size = new Size(737, 600);
            P_Score.TabIndex = 3;
            P_Score.Visible = false;
            // 
            // L_score_hero
            // 
            L_score_hero.AutoSize = true;
            L_score_hero.Font = new Font("Microsoft JhengHei UI", 15F);
            L_score_hero.Location = new Point(114, 375);
            L_score_hero.Name = "L_score_hero";
            L_score_hero.Size = new Size(107, 25);
            L_score_hero.TabIndex = 7;
            L_score_hero.Text = "使用機甲 : ";
            // 
            // PB_hero
            // 
            PB_hero.Location = new Point(261, 342);
            PB_hero.Name = "PB_hero";
            PB_hero.Size = new Size(250, 255);
            PB_hero.SizeMode = PictureBoxSizeMode.StretchImage;
            PB_hero.TabIndex = 6;
            PB_hero.TabStop = false;
            // 
            // Lb_Score
            // 
            Lb_Score.BackColor = Color.Gray;
            Lb_Score.Font = new Font("Microsoft JhengHei UI", 30F);
            Lb_Score.ForeColor = SystemColors.ControlLightLight;
            Lb_Score.FormattingEnabled = true;
            Lb_Score.ItemHeight = 50;
            Lb_Score.Location = new Point(60, 32);
            Lb_Score.Name = "Lb_Score";
            Lb_Score.Size = new Size(663, 304);
            Lb_Score.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 89);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 0;
            label2.Text = "這是計分板";
            // 
            // B_Score
            // 
            B_Score.BackColor = Color.Transparent;
            B_Score.Font = new Font("Impact", 30F);
            B_Score.Location = new Point(43, 429);
            B_Score.Name = "B_Score";
            B_Score.Size = new Size(378, 109);
            B_Score.TabIndex = 5;
            B_Score.TabStop = false;
            B_Score.Text = "Score";
            B_Score.UseVisualStyleBackColor = false;
            B_Score.Click += B_Score_Click;
            // 
            // Form_Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1584, 861);
            Controls.Add(B_Score);
            Controls.Add(P_Main);
            Controls.Add(B_Quit);
            Controls.Add(B_About);
            Controls.Add(P_Game);
            Controls.Add(L_Title);
            Controls.Add(B_Start);
            MaximumSize = new Size(1600, 900);
            MinimumSize = new Size(1600, 900);
            Name = "Form_Menu";
            Text = "Form_Menu1";
            Load += Form_Menu_Load;
            Paint += Form_Menu_Paint;
            P_Main.ResumeLayout(false);
            P_About.ResumeLayout(false);
            P_Score.ResumeLayout(false);
            P_Score.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PB_hero).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label L_Title;
        private Button B_Start;
        public Panel P_Game;
        private Button B_About;
        private Button B_Quit;
        private Panel P_Main;
        private Button B_Score;
        private Panel P_Score;
       
        private Label label2;
        private Panel P_About;
        private Panel panel2;
        private PictureBox PB_hero;
        private ListBox Lb_Score;
        private ListBox Lb_About;
        private Label L_score_hero;
    }
}