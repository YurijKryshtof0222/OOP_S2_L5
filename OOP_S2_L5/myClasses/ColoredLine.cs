using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_S2_L5.myClasses
{
    public class ColoredLine : Line, IColoredLine
    {
        public Color Color { get; set; }

        public ColoredLine(Point firstPoint, Point secondPoint, Color color) 
        {
            this.FirstPoint = new ColoredPoint(firstPoint, color);
            this.SecondPoint = new ColoredPoint(secondPoint, color);
            this.Color = color;
            this.Angle = 180;
        }

        public ColoredLine(Point firstPoint, Point secondPoint, Color color, int angle)
        {
            this.FirstPoint = new ColoredPoint(firstPoint, color);
            this.SecondPoint = new ColoredPoint(secondPoint, color);
            this.Color = color;
            this.Angle = angle;
        }

        public ColoredLine(Line line, Color color) 
        {
            this.FirstPoint = new ColoredPoint(line.FirstPoint, color);
            this.SecondPoint = new ColoredPoint(line.SecondPoint, color);
            this.Color = color;
            this.Angle = line.Angle;
        }

        public ColoredLine(ColoredLine coloredLine)
        {
            this.FirstPoint = new ColoredPoint(coloredLine.FirstPoint, coloredLine.Color);
            this.SecondPoint = new ColoredPoint(coloredLine.SecondPoint, coloredLine.Color);
            this.Angle = coloredLine.Angle;
            this.Color = coloredLine.Color;
        }

        public new object Clone()
        {
            return new ColoredLine(this);
        }

        public override string ToString()
        {
            return $"colored line{{ first {FirstPoint}, second {SecondPoint} }}";
        }

    }

}
