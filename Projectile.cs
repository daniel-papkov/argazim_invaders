using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static argazim_invaders.Point;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace argazim_invaders
{
    [Serializable()]
    public class Projectile:Visble, ISerializable
    {
        protected double _Speed;
        protected Point _Location;
        protected int _Damage;
        protected double _Angle;
        public const string bullet1 = ".\\PICS\\images.png";
        public const string bullet2 = ".\\PICS\\awchy.png";


        public Projectile(string path, bool vis, double speed, Point loc, int dmg, double ang) : base(path, vis)
        {
            this.pic_path = path;
            this._Speed = speed;
            this._Location = loc;
            this._Damage = dmg;
            this._Angle = ang;            
        }


        public bool is_in_bound()
        {
            double x = this._Location.getX();
            double y = this._Location.getY();
            if (x < 0 || x > 100)
                return false;
            if (y < 0 || y > 100)
                return false;

            return true;
        }

        public double get_angle()
        {
            return this._Angle;
        }

        public void set_projectile_damage(int val)
        {
            this._Damage = val;
        }

        public void move()
        {
            double x = _Location.getX();
            double y = _Location.getY();
            
            x += (_Speed * Math.Cos((Math.PI/180) *_Angle));
            y -= (_Speed * Math.Sin((Math.PI / 180)* _Angle));
            this._Location.setX((int)x);
            this._Location.setY((int)y);            
        }

        public Point Get_location()
        {
            return this._Location;
        }

        public int get_projectile_damage()
        {
            return this._Damage;
        }

        public double get_speed()
        {
            return this._Speed;
        }


        public void Set_location(Point p)
        {
            this._Location = p;
        }

        public bool is_hit(Entity e)
        {
            if (Point.distance(_Location, e.Get_location()) < 5)
            {
                return true;
            }
            return false;
        }        

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("speed",this._Speed);
            info.AddValue("locationx",this._Location.getX()); // cant save location as it
            info.AddValue("locationy", this._Location.getY());
            info.AddValue("damage", this._Damage);
            info.AddValue("angle", this._Angle);

            info.AddValue("is_visible", this.is_visible);
            info.AddValue("path", this.pic_path);
        }

        public Projectile(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this._Speed = info.GetDouble("speed");
            int x= info.GetInt32("locationx");
            int y = info.GetInt32("locationy");
            this._Location = new Point(x,y);
            this._Damage = info.GetInt32("damage");
            this._Angle = info.GetDouble("angle");
        }
    }    
}
