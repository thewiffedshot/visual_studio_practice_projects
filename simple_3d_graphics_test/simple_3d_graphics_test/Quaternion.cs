using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace simple_3d_graphics_test
{
    class Quaternion
    {
        public Vector4 value { get; set; }

        public Quaternion(Vector4 _value)
        {
            value = _value;
        }
    }
}
