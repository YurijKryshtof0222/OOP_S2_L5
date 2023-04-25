using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_S2_L5.myClasses
{
    public class ColoredLine : Line
    {
        public Color Color { get; set; }

        public ColoredLine(Point firstPoint, Point secondPoint, Color color) 
        {
            this.FirstPoint = new ColoredPoint(firstPoint, color);
            this.SecondPoint = new ColoredPoint(secondPoint, color);
            this.Angle = 180;
        }

        public ColoredLine(Point firstPoint, Point secondPoint, Color color, int angle)
        {
            this.FirstPoint = new ColoredPoint(firstPoint, color);
            this.SecondPoint = new ColoredPoint(secondPoint, color);
            this.Angle = angle;
        }

        public ColoredLine(Line line, Color color) 
        {
            this.FirstPoint = new ColoredPoint(line.FirstPoint, color);
            this.SecondPoint = new ColoredPoint(line.SecondPoint, color);
            this.Angle = line.Angle;
        }

    }

}
