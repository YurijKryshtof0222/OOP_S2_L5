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

    }

}