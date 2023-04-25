using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_S2_L5.myClasses
{
    public class Line
    {
        private int angle;

        public Point FirstPoint { get; set; }
        public Point SecondPoint { get; set; }

        public int Angle
        {
            get
            {
                return angle;
            }
            set
            {
                angle = value % 360;
                if (angle < 0) // якщо кут від'ємний, переводимо його в додатній еквівалент
                {
                    angle += 360;
                }
            }
        }

        protected Line() {}

        public Line(Point firstPoint, Point secondPoint)
        {
            this.FirstPoint = firstPoint;
            this.SecondPoint = secondPoint;
            this.Angle = 180;
        }

        public Line(Point firstPoint, Point secondPoint, int angle)
        {
            this.FirstPoint = firstPoint;
            this.SecondPoint = secondPoint;
            this.Angle = angle;
        }

        public Line(Line line) : this(line.FirstPoint, line.SecondPoint, line.Angle)
        {}

    }

}