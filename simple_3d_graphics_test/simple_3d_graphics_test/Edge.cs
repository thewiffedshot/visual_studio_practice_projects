using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Drawing;
using System.Threading.Tasks;

namespace simple_3d_graphics_test
{
    class Edge
    {
        public Vector2[] Points { get; set; }
        public bool Drawn { get; set; }

        public Edge(Vector2[] points)
        {
            Points = points;
            Drawn = false;
        }

        public void Draw(Bitmap image)
        {
            if (!Drawn)
            {
                Vector2 direction = new Vector2(Points[1].X - Points[0].X, Points[1].Y - Points[0].Y);
                float free = direction.Y * Points[0].X - direction.X * Points[0].Y;

                int maxY = 0, minY = 0, maxX = 0, minX = 0;

                if (Points[0].Y >= Points[1].Y)
                {
                    maxY = (int)Math.Round(Points[0].Y, 0);
                    minY = (int)Math.Round(Points[1].Y, 0);
                }
                else if (Points[0].Y <= Points[1].Y)
                {
                    maxY = (int)Math.Round(Points[1].Y, 0);
                    minY = (int)Math.Round(Points[0].Y, 0);
                }

                if (Points[0].X >= Points[1].X)
                {
                    maxX = (int)Math.Round(Points[0].X, 0);
                    minX = (int)Math.Round(Points[1].X, 0);
                }
                else if (Points[0].X <= Points[1].X)
                {
                    maxX = (int)Math.Round(Points[1].X, 0);
                    minX = (int)Math.Round(Points[0].X, 0);
                }

                for (int i = minY; i <= maxY; i++)
                    for (int j = minX; j <= maxX; j++)
                        if (direction.X * i - direction.Y * j + free < 50 && direction.X* i -direction.Y * j + free > -50 && j > 0 && j < image.Width && i > 0 && i < image.Height) image.SetPixel(j, i, Color.Black);

                Drawn = true;
            }
        }
    }
}
