using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace simple_3d_graphics_test
{
    class Polygon
    {
        public List<Edge> Edges { get; set; }

        public Polygon(List<Edge> edges)
        {
            Edges = edges;
        }

        public Polygon()
        {
            
        }
    }
}
