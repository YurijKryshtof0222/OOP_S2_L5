using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_S2_L5.myClasses
{
    public class Line : 
        IMoveable, ICloneable, IComparable, IVectorComparable
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

        public void move(double x, double y)
        {
            this.FirstPoint.move(x, y);
            this.SecondPoint.move(x, y);
        }

        public object Clone()
        {
            return new Line(this);
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
            return FirstPoint.Xcoord > SecondPoint.Xcoord 
                ? FirstPoint.Xcoord : SecondPoint.Xcoord;
        }

        public double YKey()
        {
            return FirstPoint.Ycoord > SecondPoint.Ycoord
                ? FirstPoint.Ycoord : SecondPoint.Ycoord;
        }

        public override string ToString()
        {
            return $"line, first {FirstPoint}, second {SecondPoint}]";
        }

    }

}