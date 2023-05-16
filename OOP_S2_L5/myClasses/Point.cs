using OOP_S2_L5.myClasses;
using System;

namespace OOP_S2_L5
{
    public class Point : 
        IMoveable, ICloneable, IComparable, IVectorComparable
    {
        public double Xcoord { get; set; }
        public double Ycoord { get; set; }

        public Point() : this(0, 0) { }

        public Point(double x, double y)
        {
            this.Xcoord = x;
            this.Ycoord = y;
        }

        public Point(Point point)
        {
            this.Xcoord = point.Xcoord;
            this.Ycoord = point.Ycoord;
        }

        public void move(double x, double y)
        {
            this.Xcoord += x;
            this.Ycoord += y;
        }

        public object Clone()
        {
            return new Point(this);
        }

        public int CompareTo(object obj)
        {
            if (this == obj) return 0;
            if (this == null) throw new NullReferenceException();
            
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
            return Xcoord;
        }

        public double YKey()
        {
            return Ycoord;
        }

        public override string ToString()
        {
            return $"point:{{ coordinations[{Xcoord} {Ycoord}] }}";
        }

    }

}