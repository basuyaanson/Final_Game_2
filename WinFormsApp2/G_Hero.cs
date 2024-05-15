using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
   

    class Heroinfo
    {
        public void scal()
        {
         //   H_Img[0].Width * 3;
        }
          
        public static Image[] H_Img =
        {
         Asset.S_H_Normal,Asset.S_H_Gunslinger,Asset.S_H_Quick,Asset.S_H_TimeStop,Asset.S_H_Sniper,Asset.S_H_Shocked
        };
        public enum HeroName
        {
            普通型, 槍俠, 快槍俠, 時停, 狙擊手, 震撼
        }
        public static string[] info =
        {
            "初始裝備步槍，各項數值正常，特技是投擲手榴彈，適用於新手",
            "初始裝備手槍，各項數值正常，但具備射擊天賦，特技是輪舞，可360度射擊",
            "初始裝備手槍，速度快，但血量低，特技是快槍手，增加射擊速度",
            "初始裝備衝鋒槍，血量低，特技是時停，讓敵人停止移動10秒",
            "初始裝備手槍，速度慢，血量低，特技是狙殺，讓敵人一擊斃命，適用於新手",
            "初始裝備步槍，速度慢，血量高，特技是震撼，將敵人鎮走並停止移動2秒",

        };

    }



     //玩家類
     class HeroFather : GameObject
    {
        public int HeroSpeed;
        public double HeroDamage;//傷害加成係數
       
       
        //建構子 傳入座標 武器編號
        public HeroFather(int x, int y, int weaponNumber,Image img) : base(x, y, img.Width, img.Height)
        {
            this.WeaponNumber = weaponNumber;
        }

        //獲得武器類型
        public WeaponFater Wp
        {
            get; set;
        }
        
        //
        public int WeaponNumber
        { get; set; }

        //--------------事件
     

        //獲得玩家基礎數值
        public virtual void SetWeaponInfo(int wea)
        {
            switch (wea)
            {
                case 0:
                    Wp = new WP_Pistol(0, 0, 0, 0);
                    break;

                case 1:
                    Wp = new WP_Rifle(0, 0, 0, 0);
                    break;
                case 2:
                    Wp = new WP_SMG(0, 0, 0, 0);
                    break;
                case 3:
                    Wp = new WP_grenade(0, 0, 0, 0);
                    break;
                case 4:
                    Wp = new WP_Boom(0, 0, 0, 0);
                    break;
            }
            //加成後的數值
            this.Speed = Wp.MoveSpeed + HeroSpeed;//速度等於 武器提供速度 + 玩家移動速度
            this.Damage = Wp.Damage + HeroDamage; //傷害等於 武器提供傷害 + 玩家自身倍率
            this.ShotSpeed = Wp.ShotSpeed;        //射速等於 武器提供射速
            Console.WriteLine("武器加成成功");
        }

        public virtual void UseSkill()
        {
        }

        enum HeroTypeInfo
        {
            普通型各項數值正常特技是投擲手榴彈適合初學者,
            槍俠傷害高但裝甲低特技是輪舞能夠360度射擊,
            快槍俠,
            時停,
            狙擊手,
            震撼
        }

        //-----------BUFF-----------
        //隨機獲得buff
        public virtual string[] GetBuff()
        {
            string[] buff = new string[3];
            Random r = new Random();
            //移動速度 生命值 射速加乘 傷害加成 武器類型
            int rr = r.Next(0,4);
           
            switch (r.Next(0, 4))
            {
                case 0:
                    buff[0] = "0";
                    buff[1] = "移動速度增加 1";
                    return buff;
                case 1:
                    buff[0] = "1";
                    buff[1] = "生命值增加 50";
                    return buff;
                case 2:
                    buff[0] = "2";
                    buff[1] = "變更武器 手槍";
                    return buff;
                case 3:
                    buff[0] = "3";
                    buff[1] = "傷害增加20%";
                    return buff;

                default:
                    return buff;
            }

        }

        //確定選擇buff並賦值
        public virtual void SelcetBuff(string selcet)
        {
            switch (selcet)
            {
                case "0":
                    HeroSpeed += 1;
                    Console.WriteLine("選擇0");
                    break;
                case "1":
                    this.HP += 5;
                    Console.WriteLine("選擇1");
                    break;
                case "2":
                    WeaponNumber = 0;
                    Console.WriteLine("選擇2");
                    break;
                case "3":
                    HeroDamage += Wp.Damage *0.2 ;
                    Console.WriteLine("選擇3");
                    break;
            }
            Console.WriteLine("升級");
            this.Level += 1;
        }

        //玩家死亡
        public virtual bool GameOver()
        {
            if (this.HP <= 0)

            {
               
                return true;
            
            }
            else
            {
                return false;
            }
                
        }

        //-----------------------
        //開火
        public virtual void Fire()
        {
            switch (WeaponNumber)
            {
                case 0:
                    SingleObject.GetSingle().AddGameObject(new WP_Pistol
                            (SingleObject.GetSingle().Aim.x, SingleObject.GetSingle().Aim.y, this.x + this.Width / 2, this.y + this.Height / 2));
                    break;
               case 1:
                    SingleObject.GetSingle().AddGameObject(new WP_Rifle
                            (SingleObject.GetSingle().Aim.x, SingleObject.GetSingle().Aim.y, this.x + this.Width / 2, this.y + this.Height / 2));
                    break;
               case 2:
                    SingleObject.GetSingle().AddGameObject(new WP_SMG
                              (SingleObject.GetSingle().Aim.x, SingleObject.GetSingle().Aim.y, this.x + this.Width / 2, this.y + this.Height / 2));
                    break;
                case 3:
                    SingleObject.GetSingle().AddGameObject(new WP_grenade
                            (SingleObject.GetSingle().Aim.x, SingleObject.GetSingle().Aim.y, this.x + this.Width / 2, this.y + this.Height / 2));
                    break;
                case 4:
                    SingleObject.GetSingle().AddGameObject(new WP_Boom
                            (SingleObject.GetSingle().Aim.x- 100
                            , SingleObject.GetSingle().Aim.y- 100,
                            0,0));

                    break;
                //360度發射
                case 5:
                   
                    for (int angle = 0; angle <= 360; angle += 15)
                    {
                        double radians = angle * Math.PI / 180;
                        int x = (int)(Math.Cos(radians) * 80);
                        int y = (int)(Math.Sin(radians) * 80);

                        SingleObject.GetSingle().AddGameObject(new WP_SMG(
                         (int)(this.x + this.Width / 2 * x),
                          (int)(this.y + this.Height / 2 * y),
                           this.x + this.Width / 2, this.y + this.Height / 2));
                    }
                    break;


            }
            
          
            System.Media.SoundPlayer S_Fire01 = new System.Media.SoundPlayer(Asset.Gun02);
            S_Fire01.Play();
          
        }

    }

    //普通
    class HeroNormal : HeroFather
    {
   
        //建構子 傳入座標 武器編號 設定基礎數值
        public HeroNormal(int x, int y, int weaponNumber) : base(x, y, weaponNumber, img)
        {
            //玩家基礎數值
            this.Level = 1;//等級
            this.HP = 100;//生命值

            this.HeroSpeed = 3;//移動速度
            this.HeroDamage = 1;//傷害倍率
           
            SetWeaponInfo(weaponNumber);
        }

        //圖片
        private static Image img = Asset.H_Normal;
      
        //--------------事件

        public void UseSkill()
        {

        }

        //------------------複寫
        //繪製
       public override void Draw(Graphics g)
        {
            g.DrawImage(img, this.x, this.y);
        }


    }

    //槍俠
    class HeroGunSlinger : HeroFather
    {

        //建構子 傳入座標 武器編號
        public HeroGunSlinger(int x, int y, int weaponNumber) : base(x, y, weaponNumber, img)
        {
            //玩家基礎數值
            this.Level = 1;//等級
            this.HP = 80;//生命值

            this.HeroSpeed = 2;
            this.HeroDamage = 1.5;
           
            SetWeaponInfo(weaponNumber);
        }

        //圖片
        private static Image img = Asset.H_Gunslinger;

        //--------------事件

        public override void UseSkill()
        {


        }

        //------------------複寫
        //繪製
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, this.x, this.y);
        }
      
    }

    //快槍俠
    class HeroQuick : HeroFather
    {

        //建構子 傳入座標 武器編號
        public HeroQuick(int x, int y, int weaponNumber) : base(x, y, weaponNumber, img)
        {
            //玩家基礎數值
            this.Level = 1;//等級
            this.HP = 80;//生命值

            this.HeroSpeed = 3;
            this.HeroDamage = 1.5;
          
            SetWeaponInfo(weaponNumber);
        }

        //圖片
        private static Image img = Asset.H_Quick;

        //--------------事件

        public override void UseSkill()
        {


        }

        //------------------複寫
        //繪製
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, this.x, this.y);
        }

    }

    //時停
    class HeroTimeStop : HeroFather
    {

        //建構子 傳入座標 武器編號
        public HeroTimeStop(int x, int y, int weaponNumber) : base(x, y, weaponNumber, img)
        {
            //玩家基礎數值
            this.Level = 1;//等級
            this.HP = 80;//生命值

            this.HeroSpeed = 2;
            this.HeroDamage = 1.5;
           
            SetWeaponInfo(weaponNumber);
        }

        //圖片
        private static Image img = Asset.H_TimeStop;

        //--------------事件

        public override void UseSkill()
        {


        }

        //------------------複寫
        //繪製
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, this.x, this.y);
        }

    }

    //狙擊手
    class HeroSniper : HeroFather
    {

        //建構子 傳入座標 武器編號
        public HeroSniper(int x, int y, int weaponNumber) : base(x, y, weaponNumber, img)
        {
            //玩家基礎數值
            this.Level = 1;//等級
            this.HP = 80;//生命值

            this.HeroSpeed = 2;
            this.HeroDamage = 1.5;
           
            SetWeaponInfo(weaponNumber);
        }

        //圖片
        private static Image img = Asset.H_Sniper;

        //--------------事件

        public override void UseSkill()
        {


        }

        //------------------複寫
        //繪製
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, this.x, this.y);
        }

    }

    //震撼
    class HeroShocked : HeroFather
    {

        //建構子 傳入座標 武器編號
        public HeroShocked(int x, int y, int weaponNumber) : base(x, y, weaponNumber, img)
        {
            //玩家基礎數值
            this.Level = 1;//等級
            this.HP = 150;//生命值

            this.HeroSpeed = 1;
            this.HeroDamage = 1;
           
            SetWeaponInfo(weaponNumber);
        }

        //圖片
        private static Image img = Asset.H_Shocked;

        //--------------事件

        public override void UseSkill()
        {


        }

        //------------------複寫
        //繪製
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, this.x, this.y);
        }

    }



    //準心
    class Aim : GameObject
    {
        //座標
        public Aim(int x, int y) : base(x, y)
        {
        }
        //移動滑鼠
        public void MouseMove(MouseEventArgs e)
        {

            this.x = e.X;//座標等於鼠標
            this.y = e.Y;
        }
    }

    //按鍵輸入
    class PlayerInput
    {
        public readonly static Keys keyup = Keys.W;
        public readonly static Keys keydown = Keys.S;
        public readonly static Keys keyleft = Keys.A;
        public readonly static Keys keyright = Keys.D;
        public readonly static Keys keySpace = Keys.Space;

        public static bool IsUp = false;
        public static bool IsDown = false;
        public static bool IsLeft = false;
        public static bool IsRight = false;
        public static bool IsSpace = true;
    }

}


