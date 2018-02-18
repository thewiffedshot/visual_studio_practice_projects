using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emage
{
    class ColorVector
    {
        byte red = 0x00, green = 0x00, blue = 0x00;

        public ColorVector(byte _red, byte _green, byte _blue)
        {
            red = _red;
            green = _green;
            blue = _blue;
        }
        
        public ColorVector()
        {

        }

        public double GetDistanceFrom(ColorVector a)
        {
            return Math.Abs(Math.Sqrt((a.red - red) * (a.red - red) + (a.green - green) * (a.green - green) + (a.blue - blue) * (a.blue - blue)));
        }
    }
}
