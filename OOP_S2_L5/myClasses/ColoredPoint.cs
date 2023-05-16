using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_S2_L5.myClasses
{
    public class ColoredPoint : Point, ICloneable
    {
        public Color Color { get; set; }

        public ColoredPoint() 
        { 
            this.Color = new Color(0, 0, 0);
        }

        public ColoredPoint(double x, double y) : base(x, y)
        {
            this.Color = new Color(0, 0, 0);
        }

        public ColoredPoint(Point point) : base(point)
        {
            this.Color = new Color(0, 0, 0);
        }

        public ColoredPoint(Color color)
        {
            this.Color = new Color(color);
        }

        public ColoredPoint(double x, double y, Color color) : base(x, y)
        {
            this.Color = new Color(color);
        }

        public ColoredPoint(Point point, Color color) : base(point)
        {
            this.Color = new Color(color);
        }
        
    }

}