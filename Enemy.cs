using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace argazim_invaders
{
    [Serializable()]
    public class Enemy:Entity, ISerializable
    {
        public static List<string> EnemyNames = new List<string> { ".\\PICS\\boss.png",".\\PICS\\suicider.png"};
        public enum _type { shooter = 1, suicide = 2 };
        private int _Exp_reward;
        private int _damage;
        private int _selected_type;
        private int _fire_rate;


        public Enemy(string path, bool state, int hp, double speed, Point loc, int exp, int damage, int type) 
            : base(path, state, hp, speed, loc)
        {
            this._Exp_reward = 5;
            this._damage = damage;
            this._selected_type = type;
            this._fire_rate = get_fire_rate_by_type(type);                        
        }
        public void setVelocity(double x)
        {
            this._Max_velocity = x;
        }
        public double getVelocity()
        {
            return this._Max_velocity;
        }
        public int getExpReward()
        {
            return this._Exp_reward;
        }
        public void setExpReward(int x)
        {
            this._Exp_reward = x;
        }
        public void setDamage(int x)
        {
            this._damage = x;
        }
        public int getDamge()
        {
            return this._damage;
        }
        //public int getHP()
        //{
        //    return this._HP;
        //}
        public void setHP(int x)
        {
            this._HP = x;
        }

        public int get_selected_type()
        {
            return this._selected_type;
        }
        public int getXp()
        {
            return this._Exp_reward;
        }
        public void setXp(int x)
        {
            this._Exp = x;
        }

        public void setx(int x)
        {
            this._location.setX(x);
        }

        public void sety(int y)
        {
            this._location.setY(y);
        }

        public void set_fire_rate(int rate)
        {
            this._fire_rate = rate;
        }

        public int get_fire_rate()
        {
            return this._fire_rate;
        }

        public int get_fire_rate_by_type(int x)
        { 
            
            if (x == 1)
                return 3;
            if (x == 2)
                return 1;


            return 1;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //string path, bool state, int hp, double speed, Point loc, int exp, int damage, int type
            info.AddValue("is_visible", this.is_visible);//Visible
            info.AddValue("path", this.getpicpath());


            info.AddValue("hp", this._HP);//entity
            info.AddValue("speed", this._Max_velocity);
            info.AddValue("xp", this._Exp_reward);
            info.AddValue("locationx", this._location.getX()); // cant save location as is
            info.AddValue("locationy", this._location.getY());

            info.AddValue("xp_reward", this.getXp());//this (enemy)
            info.AddValue("damage", this.getDamge());
            info.AddValue("type", this._selected_type);
        }

        public Enemy(SerializationInfo info, StreamingContext context):base(info, context)
        {
            this._Exp_reward = info.GetInt32("xp");
            this._damage = info.GetInt32("damage");
            this._selected_type = info.GetInt32("type");
            this._fire_rate = get_fire_rate_by_type(this._selected_type);
        }
    }
    
}
