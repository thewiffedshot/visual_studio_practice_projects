using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10
{
    class Disk
    {
        uint position = 0;
        uint size;
        
        public Disk(uint _size)
        {
            size = _size;
        }

        public void Move(uint _position)
        {
            if (_position < 0 || _position > 2) throw new ArgumentOutOfRangeException("Позицията на диска трябва да е между 0 и 2 включително.");
            else if (_position == position) throw new InvalidOperationException("Операцията е безсмислена.");

            Console.WriteLine("{0} --> {1}", (char)('A' + position), (char)('A' + _position));
            position = _position;
        }
    }   
}
