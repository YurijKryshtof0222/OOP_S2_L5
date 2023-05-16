using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_S2_L5.myClasses
{
    public class Polyline : 
        IMoveable, ICloneable, IComparable, IVectorComparable, IColoredLine
    {
        private Color color;
        
        public Color Color { 
            set {
                for (int i = 0; i < Points.Count; i++)
                {
                    Points[i].Color = value;
                }
                color = value; 
            }
            get{ return color; }
        }
        public List<ColoredPoint> Points { set; get; }

        public Polyline(Color color, params Point[] points)
        {
            Points = new List<ColoredPoint>();
            for (int i = 0; i < points.Length; i++)
            {
                Points.Add(new ColoredPoint(points[i], color));
            }
            Color = color;
        }

        public Polyline(Polyline polyline) 
        {
            Points = new List<ColoredPoint>();
            for (int i = 0; i < polyline.Points.Count; i++)
            {
                Points.Add(polyline.Points[i]);
            }
            this.Color = polyline.color;
        }

        public void AddPoint(ColoredPoint point)
        {
            Points.Add(new ColoredPoint(point, Color));
        }

        public void RemovePointAt(int index)
        {
            Points.RemoveAt(index);
        }

        private ColoredPoint GetCenter()
        {
            double x = 0, y = 0;
            foreach (var point in Points)
            {
                x += point.Xcoord;
                y += point.Ycoord;
            }
            int count = Points.Count;
            return new ColoredPoint(new Point((int)(x / count), (int)(y / count)), color);
        }

        public void Scale(double factor)
        {
            var center = GetCenter();
            for (int i = 0; i < Points.Count; i++)
            {
                var distanceX = Points[i].Xcoord - center.Xcoord;
                var distanceY = Points[i].Ycoord - center.Ycoord;
                Points[i].Xcoord = center.Xcoord + (int)(distanceX * factor);
                Points[i].Ycoord = center.Ycoord + (int)(distanceY * factor);
            }
        }

        public void move(double x, double y)
        {
            foreach (var point in Points)
            {
                point.move(x, y);
            }
        }

        public object Clone()
        {
            return new Polyline(this);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            IVectorComparable another = obj as IVectorComparable;
            int xCompare = this.XKey().CompareTo(another.XKey());
            if (xCompare != 0)
            {
                return this.YKey().CompareTo(another.YKey());
            }
            return xCompare;
        }

        public double XKey()
        {
            double maxX = Points[0].Xcoord;
            foreach(var point in Points)
            {
                if (maxX > point.Xcoord)
                    maxX = point.Xcoord;
            }
            return maxX;
        }

        public double YKey()
        {
            double maxY = Points[0].Xcoord;
            foreach (var point in Points)
            {
                if (maxY < point.Ycoord)
                    maxY = point.Ycoord;
            }
            return maxY;
        }

        public override string ToString()
        {
            string str = "polyline {";
            for (int i = 0; i < Points.Count; i++)
            {
                str += (i+1) + " " + Points[i].ToString();
            }

            return str +  "}";
        }

    }

}