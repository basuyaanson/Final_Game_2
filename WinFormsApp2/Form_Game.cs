using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form_Game : Form
    {
        List<Button> ListButton = new List<Button>();
        public int HeroNumber
        { get; set; }
        public bool StartGame
        { get; set; }
        public int WaveCount
        { get; set; }
        public bool UseSkill;

        public Form_Game()
        {
            SingleObject.GetSingle().AddGameObject(new Background(0, 0));
            InitializeComponent();
            StartGame = false;
            SelectHero();
            InitialGame();
        }

        //
        public Form_Menu F_Menu;
        public void GetForm(Form_Menu f)
        {
            F_Menu = f;
        }

        public bool Hold
        { get; set; }
        public bool CnaFire { get; set; }
        public int TimeCount
        { get; set; }

        //遊戲初始化
        public void InitialGame()
        {

           // P_Info.BackColor = Color.FromArgb(100, 100, 100, 100);
            //新增鼠標icon
            /*  Bitmap bitmap = (Bitmap)Bitmap.FromFile(@"..\..\..\Asset\aim.ico");
              this.Cursor = new Cursor(bitmap.GetHicon());*/
            P_Meun.Hide();
            //計時器
            TimeCount = 1;
            WaveCount = 1;
            CnaFire = true;
            //準心
            SingleObject.GetSingle().AddGameObject(new Aim(0, 0));

        }

        //-------------操作

        //滑鼠移動
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (StartGame == true)
            {
                SingleObject.GetSingle().Aim.MouseMove(e);
            }
        }

        //按下滑鼠
        private void Form_Game_MouseDown(object sender, MouseEventArgs e)
        {
            if (StartGame == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Hold = true;
                    if (CnaFire == true && Hold == true)
                    {
                        SingleObject.GetSingle().Hero.Fire();
                        CnaFire = false;
                    }
                    Fire_Tick.Start();
                }
                else if (e.Button == MouseButtons.Right)
                {
                }
            }
        }

        //放開滑鼠
        private void Form_Game_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                Hold = false;
            }
            else if (e.Button == MouseButtons.Right)
            {
            }
        }

        //按下鍵盤
        private void Form_Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == PlayerInput.keyup)
            {
                PlayerInput.IsUp = true;
            }
            if (e.KeyCode == PlayerInput.keydown)
            {
                PlayerInput.IsDown = true;
            }
            if (e.KeyCode == PlayerInput.keyright)
            {
                PlayerInput.IsRight = true;
            }
            if (e.KeyCode == PlayerInput.keyleft)
            {
                PlayerInput.IsLeft = true;
            }
            if (e.KeyCode == PlayerInput.keySpace)
            {
                Console.WriteLine("按下");
                if (PlayerInput.IsSpace == true)
                {

                    P_Meun.Show();
                    TimeStop(true);
                    PlayerInput.IsSpace = false;
                    Console.WriteLine("開始");
                }
                else if (PlayerInput.IsSpace == false)
                {
                    P_Meun.Hide();
                    TimeStop(false);
                    PlayerInput.IsSpace = true;
                    Console.WriteLine("暫停");
                }
            }
        }

        //放開鍵盤
        private void Form_Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == PlayerInput.keyup)
                PlayerInput.IsUp = false;
            if (e.KeyCode == PlayerInput.keydown)
                PlayerInput.IsDown = false;
            if (e.KeyCode == PlayerInput.keyright)
                PlayerInput.IsRight = false;
            if (e.KeyCode == PlayerInput.keyleft)
                PlayerInput.IsLeft = false;

        }

        //---------------計時器

        //畫面刷新 玩家移動刷新
        private void Game_Tick_Tick(object sender, EventArgs e)
        {
            if (PlayerInput.IsUp && SingleObject.GetSingle().Hero.y >= 10)
            {
                SingleObject.GetSingle().Hero.y -= (int)SingleObject.GetSingle().Hero.Speed;
            }
            if (PlayerInput.IsDown && SingleObject.GetSingle().Hero.y <= 790)
            {
                SingleObject.GetSingle().Hero.y += (int)SingleObject.GetSingle().Hero.Speed;
            }
            if (PlayerInput.IsLeft && SingleObject.GetSingle().Hero.x >= 10)
            {
                SingleObject.GetSingle().Hero.x -= (int)SingleObject.GetSingle().Hero.Speed;
            }
            if (PlayerInput.IsRight && SingleObject.GetSingle().Hero.x <= 1530)
            {
                SingleObject.GetSingle().Hero.x += (int)SingleObject.GetSingle().Hero.Speed;
            }
            this.Invalidate();

        }

        //時間計時器 與 敵人生成
        private void Time_Tick_Tick(object sender, EventArgs e)
        {
            //生成敵人
            if (TimeCount % 6 == 0)
            {
                
                EnemyWave(0);
            }
            if (TimeCount % 15 == 0 || TimeCount % 25 == 0)
            {
                EnemyWave(1);
            }
            if (TimeCount % 60 == 0)
            {
                WaveCount++;
                EnemyWave(2);
            }
            //遊戲時間計時
            TimeCount++;
            L_timeCount.Text = TimeCount.ToString();
            Cheaklevelup();
            UpdataInfo();

        }

        //自動開火
        private void Fire_Tick_Tick(object sender, EventArgs e)
        {
            CnaFire = true;
            if (CnaFire == true && Hold == true)
            {
                SingleObject.GetSingle().Hero.Fire();
                CnaFire = false;
            }
            if (Hold == false)
            {
                Fire_Tick.Stop();
                CnaFire = true;
            }
        }

        //---------------自訂義事件

        //更新資訊面版
        public void UpdataInfo()
        {
            L_PlayerInfo.Text =
                "移動速度:" + SingleObject.GetSingle().Hero.Speed + " ( " + SingleObject.GetSingle().Hero.HeroSpeed + " + " + SingleObject.GetSingle().Hero.Wp.MoveSpeed + ")" +
                "\n射速:" + SingleObject.GetSingle().Hero.ShotSpeed +
                "\n傷害:" + SingleObject.GetSingle().Hero.Damage + " (" + SingleObject.GetSingle().Hero.Wp.Damage + " + " + SingleObject.GetSingle().Hero.HeroDamage + ")" +
                "\n武器種類:" + SingleObject.GetSingle().Hero.Wp.WPName.ToString();
            ;
            L_HP.Text = "血量 : " + SingleObject.GetSingle().Hero.HP.ToString();
            L_Score.Text = "分數 : " + SingleObject.GetSingle().Hero.Score.ToString();
            L_WaveCount.Text = "波次 : " + WaveCount;
            L_LV.Text = "LV : " + SingleObject.GetSingle().Hero.Level.ToString();
            if (SingleObject.GetSingle().Hero.HP <= 0)
            {
                GameOver();
            }
        }

        //選擇英雄
        public void SelectHero()
        {
            for (int i = 0; i < Enum.GetNames(typeof(Heroinfo.HeroName)).Count(); i++)
            {
                Button btn = new Button();
              
                btn.Size = new Size(200, 500);
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.FromArgb(100,240,250,250);
                btn.Font = new Font("Microsoft Tai Le", 15F, FontStyle.Regular, GraphicsUnit.Point);
                btn.Location = new Point(this.Width / 6 + i * 210, this.Height / 4);
                btn.Name = "btn" + i;
                btn.Text = "選擇英雄 :\n" + Enum.GetName(typeof(Heroinfo.HeroName), i)+
                    "\n"+ Heroinfo.info[i];
                btn.TextAlign = ContentAlignment.BottomLeft;

                btn.Image = Heroinfo.H_Img[i];
               
                btn.ImageAlign = ContentAlignment.TopCenter;

              
                btn.Click += Hero_Selcet_Click;
                this.Controls.Add(btn);
                ListButton.Add(btn);
            }
        }

        //選擇Buff
        public void SelectBuff()
        {
            TimeStop(true);
            for (int i = 0; i < 3; i++)
            {
                string[] buff = SingleObject.GetSingle().Hero.GetBuff();

                Button btn = new Button();
                btn.Font = new Font("Microsoft Tai Le", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
                btn.Location = new Point(this.Width / 4 + i * 200, this.Height / 4);
                btn.Name = buff[0];
                btn.Size = new Size(198, 472);
                btn.Text = "選擇Buff :\n" + buff[1];
                btn.Click += Buff_Selcet_Click;
                this.Controls.Add(btn);
                ListButton.Add(btn);
                Console.WriteLine(buff[0]);
            }

        }

        //暫停遊戲
        public void TimeStop(bool Stop)
        {
            SoundObject.S_Click.Play();
            if (Stop == true)
            {
                L_Stop.Text = "遊戲暫停中";
                L_Tip.Text = "按下空白鍵繼續";
                Game_Tick.Stop();
                Time_Tick.Stop();
                Fire_Tick.Stop();
            }
            else
            {
                L_Stop.Text = "";
                L_Tip.Text = "";
                Game_Tick.Start();
                Time_Tick.Start();
            }

        }

        //遊戲結束
        public void GameOver()
        {
            P_Meun.Show();
            TimeStop(true);
            PlayerInput.IsSpace = false;
            Console.WriteLine("開始");
            DateTime now = DateTime.Now;
            string customFormat = now.ToString("yyyy-MM-dd HH:mm:ss");
            L_Stop.Text = "遊戲結束";
            L_Tip.Text = "玩家名稱 : " + GetLogininfo.UserName +
                "\n成績 : " + SingleObject.GetSingle().Hero.Score +
                "\n達成時間 : " + customFormat +
                "\n波次 : " + this.WaveCount +
                "\n玩家等級" + SingleObject.GetSingle().Hero.Level +
                "\n使用機甲" + Enum.GetName(typeof(Heroinfo.HeroName), SingleObject.GetSingle().Hero.WeaponNumber+1); 
                ;
       
            //將數據賦值，用於新增成績
            GetLogininfo.AddScoer(GetLogininfo.UserName,
                SingleObject.GetSingle().Hero.Score,
                customFormat,
                this.WaveCount,
                SingleObject.GetSingle().Hero.Level,
                SingleObject.GetSingle().Hero.WeaponNumber
                );
            
        }

        //遊戲結束
        public void BackToMenu()
        {
            int k = SingleObject.GetSingle().EnemyList.Count;
            while (k != 0)
            {
                SingleObject.GetSingle().RemoveGameObject(SingleObject.GetSingle().EnemyList[k - 1]);
                k--;
            }
            k = SingleObject.GetSingle().BackG.Count();
            while (k != 0)
            {
                SingleObject.GetSingle().RemoveGameObject(SingleObject.GetSingle().BackG[k - 1]);
                k--;
            }
            F_Menu.getbg();
            F_Menu.P_Game.Hide();

            this.Close();
        }

        //獲得敵人隨機位置
        public int[] GetRandom()
        {
            Random r = new Random();
            int[] XY = { 0, 0 };
            //判斷左右還是上下
            if (r.Next(0, 100) > 50)
            {
                // 判斷左還是右
                if (r.Next(0, 100) > 50)
                {
                    XY[0] = -10;
                }
                else
                {
                    XY[0] = 1610;
                }
                XY[1] = r.Next(0, 910);
            }
            else
            {
                // 判斷上還是下
                if (r.Next(0, 100) > 50)
                {
                    XY[1] = -10;
                }
                else
                {
                    XY[1] = 910;
                }
                XY[0] = r.Next(0, 1610);
            }
            return XY;
        }

        //新增敵人
        public void EnemyWave(int Wavelevel)
        {
            int[] RandomXY = new int[2];
            Random r = new Random();
            //新增敵人
            switch (Wavelevel)
            {
                //普通怪
                case 0:
                    for (int i = 0; i < 4; i++)
                    {
                        RandomXY = GetRandom();
                        SingleObject.GetSingle().AddGameObject(new EnemyNormal(RandomXY[0], RandomXY[1],
                            SingleObject.GetSingle().Hero, r.Next(0, 1), WaveCount));
                    }

                    break;
                //特殊怪
                case 1:
                    for (int i = 0; i < 2; i++)
                    {
                        RandomXY = GetRandom();
                        SingleObject.GetSingle().AddGameObject(new EnemySpecial(RandomXY[0], RandomXY[1],
                            SingleObject.GetSingle().Hero, r.Next(0, 2), WaveCount));
                    }
                    break;
                //首領
                case 2:
                    for (int i = 0; i < 1; i++)
                    {
                        RandomXY = GetRandom();
                        SingleObject.GetSingle().AddGameObject(new EnemyBoss(RandomXY[0], RandomXY[1],
                          SingleObject.GetSingle().Hero, r.Next(0, 1), WaveCount));
                    }
                    break;
            }

        }

        //檢測升級
        public void Cheaklevelup()
        {
            if (SingleObject.GetSingle().Hero.Score > 10 * SingleObject.GetSingle().Hero.Level)
            {
                SelectBuff();
            }
        }

        //---------------綁定

        //確定選擇buff
        private void Buff_Selcet_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            Console.WriteLine(button.Name);
            SingleObject.GetSingle().Hero.SelcetBuff(button.Name);

            SingleObject.GetSingle().Hero.SetWeaponInfo(SingleObject.GetSingle().Hero.WeaponNumber);
            TimeStop(false);

            int k = 3;
            while (k != 0)
            {
                this.Controls.Remove(ListButton[k - 1]);
                ListButton.Remove((ListButton[k - 1]));
                k--;
            }
            UpdataInfo();
        }

        //確定選擇英雄
        private void Hero_Selcet_Click(object sender, EventArgs e)
        {
           
            Button button = sender as Button;
            StartGame = true;//開始遊戲
            //判斷選擇角色
            if (button.Name == "btn0")
            {
                SingleObject.GetSingle().AddGameObject(new HeroNormal(1600 / 2, 900 / 2, 1));//新增玩家
            }
            else if (button.Name == "btn1")
            {
                SingleObject.GetSingle().AddGameObject(new HeroGunSlinger(1600 / 2, 900 / 2, 0));//新增玩家
            }
            else if (button.Name == "btn2")
            {
                SingleObject.GetSingle().AddGameObject(new HeroQuick(1600 / 2, 900 / 2, 0));//新增玩家
            }
            else if (button.Name == "btn3")
            {
                SingleObject.GetSingle().AddGameObject(new HeroTimeStop(1600 / 2, 900 / 2, 2));//新增玩家
            }
            else if (button.Name == "btn4")
            {
                SingleObject.GetSingle().AddGameObject(new HeroSniper(1600 / 2, 900 / 2, 0));//新增玩家
            }
            else if (button.Name == "btn5")
            {
                SingleObject.GetSingle().AddGameObject(new HeroShocked(1600 / 2, 900 / 2, 4));//新增玩家
            }

            Fire_Tick.Interval = (int)SingleObject.GetSingle().Hero.ShotSpeed;//射速
            TimeStop(false);
            //刪除按鈕
            int k = Enum.GetNames(typeof(Heroinfo.HeroName)).Count();
            while (k != 0)
            {
                this.Controls.Remove(ListButton[k - 1]);
                ListButton.Remove((ListButton[k - 1]));
                k--;
            }
            UpdataInfo();
           
        }

        //回到主頁
        private void B_Back_Click(object sender, EventArgs e)
        {
            BackToMenu();
        }

      

        //---------------窗口事件

        //載入畫面時調用
        private void Form_Game_Load(object sender, EventArgs e)
        {
            
            //將圖像繪製到緩存區，解決閃屏的問題
            this.SetStyle
                (ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw,
                true);
        }

        //畫面刷新調用
        private void Form_Game_Paint(object sender, PaintEventArgs e)
        {
            SingleObject.GetSingle().DrawBK(e.Graphics);
            if (StartGame == true)
            {
                 SingleObject.GetSingle().DrawGameObject(e.Graphics);
            }
        }

    }
}
