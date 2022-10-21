using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static argazim_invaders.Visble;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace argazim_invaders
{
    [Serializable()]
    public class Entity:Visble, ISerializable
    {
        public static string obstacle = ".\\PICS\\crate.png";
        protected int _HP;
        protected int _current_hp;
        protected Label _hp_bar;
        protected bool _can_shoot;
        protected double _Max_velocity;
        protected int _Exp;
        protected Point _location; // x,y are % of postion on screen
        protected bool is_Up=false, is_Down=false, is_Left=false, is_Right=false;

       

        public Entity(string path, bool state, int hp, double speed,Point loc) : base(path, state)
        {
            this._HP = hp;
            this._current_hp = hp;
            this._Max_velocity = speed;
            this._Exp = 5;
            this._location = loc;            
        }


        public int get_current_hp()
        {
            return this._current_hp;
        }
        public void set_current_hp(int val)
        {
            this._current_hp=val;
        }

        public Label GetProgressBar()
        {
            return this._hp_bar;
        }
        public void Set_progressbar(Label new_bar)
        {
            this._hp_bar = new_bar;
        }

        public bool is_ent_alive()
        {
            if(_HP > 0)
            {
                return true;
            }
            return false;
        }

        public void set_can_shoot(bool shoot)
        {
            this._can_shoot = shoot;
        }
        public bool get_can_shoot()
        {
            return this._can_shoot;
            //return true;
        }

        public int getHP()
        {
            return this._HP;
        }

        public void setHP(int new_hp)
        { 
            this._HP=new_hp;
        }

        //movement getters and setters

        public bool get_is_up()
        {
            return this.is_Up;
        }
        public bool get_is_down()
        {
            return this.is_Down;
        }
        public bool get_is_left()
        {
            return this.is_Left;
        }
        public bool get_is_right()
        {
            return this.is_Right;
        }

        public int get_Exp()
        {
            return this._Exp;
        }


        public bool is_in_bound()
        {
            double x = this._location.getX();
            double y = this._location.getY();
            if (x < 0 || x > 100)
                return false;
            if (y < 0 || y > 100)
                return false;

            return true;
        }

        public void set_is_up(bool is_up)
        {
            this.is_Up = is_up;
        }
        public void set_is_down(bool is_down)
        {
            this.is_Down = is_down;
        }
        public void set_is_left(bool is_left)
        {
            this.is_Left = is_left;
        }
        public void set_is_right(bool is_right)
        {
            this.is_Right = is_right;
        }

        public void move_ent()
        {
            if (is_moving())
            {
                if (this.is_Left)
                {
                    this._location.setX(this._location.getX() - Math.Ceiling(this._Max_velocity));
                    if (this._location.getX() < 2)
                        this._location.setX(2);
                }
                if (this.is_Right)
                {
                    this._location.setX(this._location.getX() + Math.Ceiling(this._Max_velocity));
                    if (this._location.getX() > 98)
                        this._location.setX(98);
                }
                if (this.is_Up)
                {
                    this._location.setY(this._location.getY() - Math.Ceiling(this._Max_velocity));
                    if (this._location.getY() < 2)
                        this._location.setY(2);
                }
                if (this.is_Down)
                {
                    this._location.setY(this._location.getY() + Math.Ceiling(this._Max_velocity));
                    if (this._location.getY() > 98)
                        this._location.setY(98);
                }
            }
        }

        public bool is_moving()
        {
            return this.is_Up || this.is_Down || this.is_Left || this.is_Right;
        }



        public Point Get_location()
        { 
            return this._location;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        { //string path, bool state, int hp, double speed,Point loc
            info.AddValue("is_visible", this.is_visible); //visible
            info.AddValue("path", this.pic_path);

            info.AddValue("hp", this._HP);
            info.AddValue("speed", this._Max_velocity);
            info.AddValue("xp", this._Exp);
            info.AddValue("locationx", this._location.getX()); // cant save location as is
            info.AddValue("locationy", this._location.getY());
        }
        public Entity(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this._HP = info.GetInt32("hp");
            this._current_hp = this._HP;
            this._Max_velocity = info.GetDouble("speed");
            this._Exp = info.GetInt32("xp");
            double x = info.GetDouble("locationx");
            double y = info.GetDouble("locationy");
            this._location = new Point(x, y);
        }

    }
}
