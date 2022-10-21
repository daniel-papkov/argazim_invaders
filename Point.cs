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
    public class Point: ISerializable
    {
        protected double _X, _Y;

        public Point(double x, double y)
        {
            _X = x;
            _Y = y;
        }

        public double getX()
        {
            return (int)_X;
        }
        public double getY()
        {
            return (int)_Y;
        }
        public void setX(double x)
        {
            this._X = x;
        }
        public void setY(double y)
        {
            this._Y = y;
        }
        public void setX_Y(double x, double y)
        {
            this._X = x;
            this._Y = y;
        }
        public static double distance(Point p1, Point p2)
        {
            double x1 =p1.getX(),x2=p2.getX(),y1=p1.getY(),y2=p2.getY();
            return Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)));            
        }


        public static double get_angle_to_point(Point A, Point B)
        {
            double y = Math.Abs((double)(A.getY() - B.getY()));
            double x = Math.Abs((double)(A.getX() - B.getX()));
            double m = (y/x);
            double angle = Math.Atan(m);
            angle *= 180 / Math.PI;
            if (A.getY() < B.getY())
                angle = 360-angle;

            return angle;            
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return "x: " + this._X + " y: " + this._Y;
        }
    }
}
