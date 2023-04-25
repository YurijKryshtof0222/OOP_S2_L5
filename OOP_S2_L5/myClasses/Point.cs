using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_S2_L5
{
    public class Point
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
        
    }

}