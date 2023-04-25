using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_S2_L5.myClasses
{
    public class Polyline
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

        public void AddPoint(ColoredPoint point)
        {
            Points.Add(point);
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
                var distanceX = Points[i].X - center.X;
                var distanceY = Points[i].Y - center.Y;
                Points[i].X = center.X + (int)(distanceX * factor);
                Points[i].Y = center.Y + (int)(distanceY * factor);
            }
        }


    }

}