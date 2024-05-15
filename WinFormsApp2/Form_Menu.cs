using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.PropertyGridInternal;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;


namespace WinFormsApp2
{
    public partial class Form_Menu : Form

    {  
        public bool IsUse;
        public List<Button> ListButton = new List<Button>();


        public Form_Menu()
        {
            SingleObject.GetSingle().AddGameObject(new MenuBackground(0, 0));
            InitializeComponent();
         

            P_Main.BackColor = Color.FromArgb(100, 100, 100, 100);
            P_Main.Size = new(1098, 730);
            P_Main.Location = new(446, 67);

            P_Game.Size = new(1600, 900);
            P_Game.Location = new(0, 0);

            P_About.Size = new(1098, 730);
            P_About.Location = new(344, 80);

            // SetScoer();
        }

        //獲得背景
        public void getbg()
        {
            B_Start.Enabled = true;
            SingleObject.GetSingle().AddGameObject(new MenuBackground(0, 0));
        }

        //載入form
        public void loadform(object Form)
        {
            /*  if (this.P_Main.Controls.Count > 0)
                  this.P_Main.Controls.RemoveAt(0);*/
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.P_Game.Controls.Add(f);
            this.P_Game.Tag = f;
            P_Game.Show();
            f.Show();

        }

        //使用p
        public void P_MainUse()
        {
            if (IsUse == false)
            {
                P_Main.Show();
                IsUse = true;
            }
            else
            {
                P_Main.Hide();
                IsUse = false;
            }
        }

      

        //---------------按鈕----------
        //開始遊戲
        private void B_Start_Click(object sender, EventArgs e)
        {
            SoundObject.S_Click.Play();
            P_Game.Show();
            P_Game.BringToFront();
            Form_Game Game = new Form_Game();
            loadform(Game);
            B_Start.Enabled = false;
            Game.GetForm(this);
        }

        //成績表
        private void B_Score_Click(object sender, EventArgs e)
        {
            SoundObject.S_Click.Play();
            Console.WriteLine(SoundObject.S_Click.ToString());
            P_MainUse();
            if (IsUse == false)
            {
                P_Score.Hide();
                B_About.Enabled = true;
                AddControl(panel2, true, 1);
            }
            else
            {
                P_Score.Show();
                B_About.Enabled = false;
                AddControl(panel2, false, 0);
            }

        }

        //關於
        private void B_About_Click(object sender, EventArgs e)
        {

            SoundObject.S_Click.Play();
            Console.WriteLine(SoundObject.S_Click.ToString());
            P_MainUse();
            if (IsUse == false)
            {
                P_About.Hide();
                B_Score.Enabled = true;
                AddControl(panel2, true, 1);
            }
            else
            {
                P_About.Show();
                B_Score.Enabled = false;
                AddControl(panel2, false, 1);
            }

        }

        //離開
        private void B_Quit_Click(object sender, EventArgs e)
        {
            SoundObject.S_Click.Play();
            this.Close();
        }

        //-------------------------


        //生成按鈕列表
        public void AddControl(Control c, bool remove, int num)
        {
            if (remove == true)
            {
                while (c.Controls.Count > 0)
                {
                    c.Controls.RemoveAt(c.Controls.Count - 1);
                }
            }
            else
            {
                switch (num)
                {
                    case 0:
                        //獲得文件
                        string Json_Score = System.IO.File.ReadAllText(@".\\Score.json");//
                        //獲得文件列表
                        List<J_Score> Sjson = JsonConvert.DeserializeObject<List<J_Score>>(Json_Score);

                        //依照成績排序
                        List<J_Score> sortedScores = Sjson.OrderByDescending(s => s.Score).ToList();

                        //新增按鈕，並以時間命名
                        for (int i = 0; i < Sjson.Count; i++)
                        {
                            Button btn = new Button();
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.BackColor = Color.FromArgb(100, 240, 250, 250);
                            btn.Font = new Font("Microsoft Tai Le", 15F, FontStyle.Regular, GraphicsUnit.Point);
                            btn.Text = sortedScores[i].Name + "\n成績 : " + sortedScores[i].Score + "\n存檔時間 :" + sortedScores[i].Time;
                            btn.Name = sortedScores[i].Time;

                            btn.Size = new Size(250, 100);
                            btn.Location = new Point(10, i * 120);

                            c.Controls.Add(btn);
                            ListButton.Add(btn);
                            btn.Click += button_Click_GetScore;
                        }
                        for (int i = 0; i < Sjson.Count; i++)
                        {
                            Button btn = new Button();
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.BackColor = Color.FromArgb(100, 240, 250, 250);
                            btn.Font = new Font("Microsoft Tai Le", 9F, FontStyle.Regular, GraphicsUnit.Point);
                            btn.Text = "刪除檔案";
                            btn.Name = sortedScores[i].Time;

                            btn.Size = new Size(20, 100);
                            btn.Location = new Point(260, i * 120);

                            c.Controls.Add(btn);
                            ListButton.Add(btn);
                            btn.Click += button1_Click;
                        }
                        break;

                    case 1:
                        //獲得文件
                        string Json_About = System.IO.File.ReadAllText(@".\\About.json");

                        //獲得文件列表
                        List<J_About> Gjson = JsonConvert.DeserializeObject<List<J_About>>(Json_About);

                        for (int i = 0; i < Gjson.Count; i++)
                        {
                            Button btn = new Button();
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.BackColor = Color.FromArgb(100, 240, 250, 250);
                            btn.Font = new Font("Microsoft Tai Le", 15F, FontStyle.Regular, GraphicsUnit.Point);
                            btn.Text = Gjson[i].Title;
                            btn.Name = Gjson[i].Title;

                            btn.Size = new Size(270, 100);
                            btn.Location = new Point(10, i * 120);

                            c.Controls.Add(btn);
                            ListButton.Add(btn);
                            btn.Click += button_Click_GetAbout;
                        }

                        break;

                }
            }
        }

        //獲得關於
        public void button_Click_GetAbout(object sender, EventArgs e)
        {
            string Json_About = System.IO.File.ReadAllText(@".\\About.json");
            List<J_About> Gjson = JsonConvert.DeserializeObject<List<J_About>>(Json_About);
            Button b = sender as Button;
            Lb_About.Items.Clear();
            for (int i = 0; i < Gjson.Count; i++)
            {
                if (b.Name == Gjson[i].Title)
                {
                    Lb_About.Items.Add(Gjson[i].Title);

                    for (int j = 0; j < Gjson[i].Content.Count; j++)
                    {
                        Lb_About.Items.Add(Gjson[i].Content[j]);

                    }

                    break;
                }
            }
        }

        //獲得成績
        public void button_Click_GetScore(object sender, EventArgs e)
        {
            Button b = sender as Button;
            //獲得文件
            string Json_Score = System.IO.File.ReadAllText(@".\\Score.json");
            //獲得文件清單
            List<J_Score> Gjson = JsonConvert.DeserializeObject<List<J_Score>>(Json_Score);
            Lb_Score.Items.Clear();//清理盒子

            //賦值
            for (int i = 0; i < Gjson.Count; i++)
            {
                //找到時間相同的資料並顯示
                if (b.Name == Gjson[i].Time)
                {
                    Lb_Score.Items.Add("玩家名稱 : " + Gjson[i].Name);
                    Lb_Score.Items.Add("成績 : " + Gjson[i].Score);
                    Lb_Score.Items.Add("達成時間 : " + Gjson[i].Time);
                    Lb_Score.Items.Add("存活波數 : " + Gjson[i].Wave);
                    Lb_Score.Items.Add("玩家等級 : " + Gjson[i].Level);
                    PB_hero.Image = Heroinfo.H_Img[Gjson[i].Hero+1];
                    L_score_hero.Text = "使用機甲 :\n" + Enum.GetName(typeof(Heroinfo.HeroName), Gjson[i].Hero + 1);
                    break;
                }
            }
        }

        //刪除存檔
        private void button1_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            //獲得文件
            string Json_Score = System.IO.File.ReadAllText(@".\\Score.json");

            List<J_Score> records = JsonConvert.DeserializeObject<List<J_Score>>(Json_Score);
  
            if (File.Exists(@".\\Score.json"))
            {
                string existingJson = File.ReadAllText(@".\\Score.json");
                records = JsonConvert.DeserializeObject<List<J_Score>>(existingJson);
            }

            //彈出刪除提示
            DialogResult dialogResult = MessageBox.Show("是否刪除成績", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                records.RemoveAll(r => r.Time == b.Name);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            

            string updatedJson = JsonConvert.SerializeObject(records, Formatting.Indented);
            File.WriteAllText("Score.json", updatedJson);
            B_Score_Click(sender, e);
            B_Score_Click(sender, e);
        }

        //---------------窗口----------
        private void Form_Menu_Load(object sender, EventArgs e)
        {

            //將圖像繪製到緩存區，解決閃屏的問題
            this.SetStyle
                (ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw,
                true);
        }

        private void Form_Menu_Paint(object sender, PaintEventArgs e)
        {
            SingleObject.GetSingle().DrawBK(e.Graphics);
        }

      
    }


}
