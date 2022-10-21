using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace argazim_invaders
{
    [Serializable()]
    public class Player : Entity, ISerializable
    {
        public static string tank_path = ".\\PICS\\tank.png";
        public static string sniper_path = ".\\PICS\\sniper.png";
        public static string machine_gun_path = ".\\PICS\\machine_gun.png";
        public static List<string> skins = new List<string>
        {
            ".\\PICS\\tank.png",".\\PICS\\sniper.png",".\\PICS\\machine_gun.png"
        };
        private enum _type { Tank = 1, Sniper = 2, Machine_gun = 3 };
        private int _selected_type;
        //private Buffs _boost;
        private int _xp;//how much xp we have
        private int _damage;
        private int _attack_speed;
        
        //private string Save_path = "";//?
        //private bool isUp, isDown, isLeft, isRight;



        public Player(int type, string path,int dmg, int hp, double max_speed,int attack_spd, Point loc) : base(path, true, hp, max_speed, loc)
        {
            this._attack_speed = attack_spd;
            this._selected_type = type;
            this._xp = 0;
            this._damage =(int)(dmg * Get_damage_by_type(type));
            this._HP = hp; //get_hp_by_type(type);
            this._current_hp = hp;
            this._Max_velocity = get_max_speed_by_type(type);
            this._attack_speed = get_fire_rate_by_type(type);
        }                

        public int getSelected_type()
        {
            return this._selected_type;
        }
        public void setVelocity(double x)
        {
            this._Max_velocity = x;
        }
        public double getVelocity()
        {
            return this._Max_velocity;
        }
        public int getXp()
        {
            return this._xp;
        }
        public void setXp(int x)
        {
            this._xp = x;
        }
        public void setDamage(int x)
        {
            this._damage = x;
        }
        public int getDamge()
        {
            return this._damage;
        }
       
        public void setHP(int x)
        {
            this._HP = x;
        }

        public int get_fire_rate()
        {
            return this._attack_speed;
        }

        public void setx(int x)
        {
            this._location.setX(x);
        }
        public void sety(int y)
        {
            this._location.setY(y);
        }

        public void set_attack_speed(int speed)
        {
            this._attack_speed = speed;
        }

        public double get_attack_speed()
        {
            return this._attack_speed;
        }
        public string setSelectedType(int x)
        {
            if (x == (int)_type.Tank)
            {               
                return tank_path;
            }
            if (x == (int)_type.Machine_gun)
            {              
                return machine_gun_path;
            }
            if (x == (int)_type.Sniper)
            {                
                return sniper_path;
            }
            else 
                return "";
        }

        private double Get_damage_by_type(int t)
        {
            if (t == (int)_type.Tank)
                return 1.6;
            if (t == (int)_type.Sniper)
                return 1.2;
            if (t == (int)_type.Machine_gun)
                return 1;

                return 0;
        }

        private int get_hp_by_type(int t)
        {
            if (t == (int)_type.Tank)
                return 12;
            if (t == (int)_type.Sniper)
                return 8;
            if (t == (int)_type.Machine_gun)
                return 5;

            return 0;
        }

        public static double get_max_speed_by_type(int t)
        {
            if (t == 1)
                return 0.2;
            if (t == 2)
                return 0.5;
            if (t == 3)
                return 1;

            return 1;
        }

        public int get_fire_rate_by_type(int x)
        {
            if (x == 1)
                return (int)(1.2 * this._attack_speed);
            if (x == 2)
                return (int)(2 * this._attack_speed);
            if (x == 3)
                return (int)(4 * this._attack_speed);


            return 0;
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("is_visible", this.is_visible); //visible
            info.AddValue("path", this.pic_path);

            info.AddValue("hp", this._HP); // entity
            info.AddValue("speed", this._Max_velocity);
            info.AddValue("xp", this._Exp);
            info.AddValue("locationx", this._location.getX()); // cant save location as is
            info.AddValue("locationy", this._location.getY());

            // private int _xp;_damage;_attack_speed;
            info.AddValue("_xp", this._xp);
            info.AddValue("_damage", this._damage);
            info.AddValue("_attack_speed", this._attack_speed);
        }

        public Player(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this._xp = info.GetInt32("_xp");
            this._damage = info.GetInt32("_damage");
            this._attack_speed = info.GetInt32("_attack_speed");
        }

    }
}

