﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    //敵人父類
    class EnemyFather : GameObject
    {
        // public static Image Img;
        public Image Img;
        public int wave {  get; set; }
        //建構子 座標,攻擊目標，等級，圖片
        public EnemyFather(int x, int y, GameObject Target,Image img,int Wave) : base(x, y, img.Width, img.Height)
        {
            this.Img = img;
            this.Target = Target;
            this.wave = Wave;
        }

        //攻擊目標
        public GameObject Target
        {
            get; set;
        }
      
        //獲取敵人編號
        public virtual void GetEnemyNumber(int Number)
        {
          
        }

        //死亡
        public virtual void IsDead()
        {
            if (this.HP <= 0)
            {
                //刪除自身
                SingleObject.GetSingle().EnemyList.Remove(this);//
                SingleObject.GetSingle().Hero.Score += this.Score;//
            }
        }

        //敵人向目標移動
        public virtual void MoveEnemy(double speed)
        {
            //計算向量
            double Dx = Target.x - x;
            double Dy = Target.y - y;

            /*// 計算帶有方向的向量*/
            double length = Math.Sqrt(Dx * Dx + Dy * Dy);
            double UnitX = Dx / length;
            double UnitY = Dy / length;

            //靠近後就停止移動
            if (length > 10)
            {
                // 更新敌人的位置
                this.x += (int)(speed * UnitX);
                this.y += (int)(speed * UnitY);
            }
        }
    }

    //普通敵人
    class EnemyNormal : EnemyFather
    {
        //建構子 座標,攻擊目標，等級，攻擊目標，敵人編號
        public EnemyNormal(int x, int y, GameObject Target,int Number,int wave) : base(x, y, Target, GetImageNumber(Number),wave)
        {
            this.Number = Number;
            this.Target = Target;
            GetEnemyNumber(Number);
        }
        
        //獲得敵人編號對應數據
        public override void GetEnemyNumber(int Number)
        {
            switch (Number)
            {
                //普通敵人
                case 0:
                    this.HP = 80 * wave;
                    this.Speed = 3;
                    this.Damage = 10;
                    this.Score = 1;
                    break;
            
            }
        }

        //獲得對應圖片
        public static Image GetImageNumber(int ImgNumber)
        {
            switch (ImgNumber)
            {
                case 0:
                    return Asset.E_N_Zako;
            }
            return null;
        }

        //-----------------複寫
        //繪製事件
        public override void Draw(Graphics g)
        {
            MoveEnemy(this.Speed);
            g.DrawImage(Img, this.x, this.y);
        }
    }

    //特殊敵人
    class EnemySpecial : EnemyFather
    {

        //建構子 座標,攻擊目標，等級，攻擊目標，敵人編號
        public EnemySpecial (int x, int y, GameObject Target, int Number, int wave) : base(x, y, Target, GetImageNumber(Number), wave)
        {
            this.Number = Number;
            this.Target = Target;
            GetEnemyNumber(Number);
        }

        //獲得敵人編號對應數據
        public override void GetEnemyNumber(int Number)
        {
            switch (Number)
            {
                //跑者
                case 0:
                    this.HP = 80 * wave;
                    this.Speed = 5;
                    this.Damage = 30;
                    this.Score = 3;
                    break;
                //坦克
                case 1:
                    this.HP = 150 * wave;
                    this.Speed = 1.5;
                    this.Damage = 30;
                    this.Score = 3;
                    break;
            }
        }

        //獲得對應圖片
        public static Image GetImageNumber(int ImgNumber)
        {
            switch (ImgNumber)
            {
                case 0:
                    return Asset.E_S_Runner;
                case 1:
                    return Asset.E_S_Tank;
            }
            return null;
        }

        //-----------------複寫
        //繪製事件
        public override void Draw(Graphics g)
        {
            MoveEnemy(this.Speed);
            g.DrawImage(Img, this.x, this.y);
        }

    }

    //首領敵人
    class EnemyBoss : EnemyFather
    {

        //建構子 座標,攻擊目標，等級，攻擊目標，敵人編號
        public EnemyBoss(int x, int y, GameObject Target, int Number, int wave) : base(x, y, Target, GetImageNumber(Number), wave)
        {
            this.Number = Number;
            this.Target = Target;
            GetEnemyNumber(Number);
        }

        //獲得敵人編號對應數據
        public override void GetEnemyNumber(int Number)
        {
            switch (Number)
            {
                
                case 0:
                    this.HP = 500 * wave;
                    this.Speed = 1.5;
                    this.Damage = 80;
                    this.Score = 10;
                    break;
            }
        }


        //獲得對應圖片
        public static Image GetImageNumber(int ImgNumber)
        {
            switch (ImgNumber)
            {
                case 0:
                    return Asset.E_B_Tank;
            }
            return null;
        }

    
        //-----------------複寫
        //繪製事件
        public override void Draw(Graphics g)
        {
            MoveEnemy(this.Speed);
            g.DrawImage(Img, this.x, this.y);
        }

     
    }
}
