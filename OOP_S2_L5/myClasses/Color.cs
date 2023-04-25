using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_S2_L5.myClasses
{
    public struct Color
    {
        public byte Red { get; set; }
        public byte Blue { get; set; }
        public byte Green { get; set; }

        public Color(byte red, byte green, byte blue) 
        { 
            Red = red;
            Green = green;
            Blue = blue;
        }

        public Color(Color color)
        {
            Red = color.Red;
            Green = color.Green;
            Blue = color.Blue;
        }
        
    }

}