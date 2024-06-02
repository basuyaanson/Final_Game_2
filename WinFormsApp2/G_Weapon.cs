using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    enum WeaponType
    {
        手槍, 步槍, 衝鋒槍, 能量槍
    }

    //武器父類
    class WeaponFater : GameObject
    {
        //建構子 子彈座標，發射速度，
        public WeaponFater(int x, int y, Image Img) : base(x, y, Img.Width, Img.Height)
        {
            this.Time = 0;
        }
        public WeaponType WPName;
        //圖片
        private Image Img;
        //射擊目標
        public int TargetX
        {
            get; set;
        }
        public int TargetY
        {
            get;
            set;
        }
        public double unitX
        {
            get;
            set;
        }
        public double unitY
        {
            get;
            set;
        }

        //數值
        public int MoveSpeed
        { get; set; }//持有武器速度
        public int ShotSpeed//射速
        { get; set; }
        public int Time
        {
            get; set;
        }
     
        //子彈移動
        public virtual void Move()
        {
            //計算向量
            if (Time == 0)
            {
                int dx = this.TargetX - this.x;
                int dy = this.TargetY - this.y;
                double length = Math.Sqrt(dx * dx + dy * dy);

                this.unitX = dx / length;
                this.unitY = dy / length;
                this.Time = 1;
            }

            // 更新敌人的位置
            this.x += (int)(this.Speed * this.unitX);
            this.y += (int)(this.Speed * this.unitY);
        }
        //武器數據
        public virtual void GetInfo()
        {

        }
    }

    class WP_Pistol : WeaponFater
    {
        //圖片
        private static Image img = Asset.bullet1;

        //目標座標 發射座標 子彈移動速度
        public WP_Pistol(int TargetX, int TargetY, int x, int y) : base(x, y, img)
        {
            this.TargetX = TargetX;
            this.TargetY = TargetY;
            GetInfo();
        }

        //基礎數值
        public override void GetInfo()
        {
            //名稱
            WPName = WeaponType.手槍;
            //武器數值
            this.Damage = 65;//傷害
            this.ShotSpeed = 500;//射速
            this.Speed = 50;//子彈移動速度
            this.MoveSpeed = 4;//玩家持移速加成
        }

        //------------------------
        public override void Draw(Graphics g)
        {
            Move();
            g.DrawImage(img, this.x, this.y);
        }

      
    }

    class WP_Rifle : WeaponFater
    {
        //圖片
        private static Image img = Asset.bullet1;

        //目標座標 發射座標 子彈移動速度
        public WP_Rifle(int TargetX, int TargetY, int x, int y) : base(x, y, img)
        {
            this.TargetX = TargetX;
            this.TargetY = TargetY;
            GetInfo();
        }

        public override void GetInfo()
        {
            //名稱
            WPName = WeaponType.步槍;
            //武器數值
            this.Damage = 31;//傷害
            this.ShotSpeed = 300;//射速
            this.Speed = 50;//子彈移動速度
            this.MoveSpeed = 3;//玩家持有移速加成
        }


        //------------------------
        public override void Draw(Graphics g)
        {
            Move();
            g.DrawImage(img, this.x, this.y);
        }

    }   

    class WP_SMG : WeaponFater
    {
           
        //圖片
           
        private static Image img = Asset.bullet1;
 
        //目標座標 發射座標 子彈移動速度
        public WP_SMG(int TargetX, int TargetY, int x, int y) : base(x, y, img)  
        {
               this.TargetX = TargetX;
               this.TargetY = TargetY;
               GetInfo();
        }

          
        public override void GetInfo()
        {
               //名稱
               WPName = WeaponType.衝鋒槍;
               //武器數值
               this.Damage = 18;//傷害
               this.ShotSpeed = 150;//射速
               this.Speed = 50;//子彈移動速度
               this.MoveSpeed = 3;//玩家持有移速加成
        }
        //------------------------
        public override void Draw(Graphics g)
        {
            Move();
            g.DrawImage(img, this.x, this.y);
        }
       }

    class WP_Boom : WeaponFater
     {
         //圖片
         private static Image img = Asset.Boom;
         public Thread thread ;
        //目標座標 發射座標 子彈移動速度
        public WP_Boom(int TargetX, int TargetY, int x, int y) : base(x, y, img)
        {
               this.TargetX = TargetX;
               this.TargetY = TargetY;
               GetInfo();
        }

           public override void GetInfo()
           {
               //名稱
               WPName = WeaponType.能量槍;
               //武器數值
               this.Damage = 150;//傷害
               this.ShotSpeed = 1000;//射速
               this.Speed = 20;//子彈移動速度
               this.MoveSpeed = 2;//玩家持有移速加成
           }
            
        public void CountDown()
        {
            Thread.Sleep(2000);
            SingleObject.GetSingle().RemoveGameObject(this);
            thread.Join();
        }


           //------------------------
           public override void Draw(Graphics g)
           {
               Move();
               g.DrawImage(img, this.x, this.y);
           }

           //子彈移動
           public override void Move()
           {
               // 更新敌人的位置
               this.x = this.TargetX;
               this.y = this.TargetY;
                thread = new Thread(CountDown);
                thread.Start();
            }
            
       }

    class WP_grenade : WeaponFater
    {
        //圖片
        private static Image img = Asset.bullet2;

        //目標座標 發射座標 子彈移動速度
        public WP_grenade(int TargetX, int TargetY, int x, int y) : base(x, y, img)
        {
            this.TargetX = TargetX;
            this.TargetY = TargetY;
            GetInfo();
        }

        public override void GetInfo()
        {
            //名稱
            WPName = WeaponType.能量槍;
            //武器數值
            this.Damage = 150;//傷害
            this.ShotSpeed = 1000;//射速
            this.Speed = 20;//子彈移動速度
            this.MoveSpeed = 2;//玩家持有移速加成
        }


        //------------------------
        public override void Draw(Graphics g)
        {
            Move();
            g.DrawImage(img, this.x, this.y);
        }

    }
}
