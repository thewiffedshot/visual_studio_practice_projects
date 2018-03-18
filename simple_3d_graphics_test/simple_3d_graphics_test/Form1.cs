using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simple_3d_graphics_test
{
    public partial class Form1 : Form
    {
        static Vector4[] cubeOne = { new Vector4(0, 0, 0, 1), new Vector4(0, 20, 0, 1), new Vector4(20, 20, 0, 1), new Vector4(20, 0, 0, 1), new Vector4(0, 0, 20, 1), new Vector4(0, 20, 20, 1), new Vector4(20, 20, 20, 1), new Vector4(20, 0, 20, 1) };
        Vector4[] cubeOneTransformed = new Vector4[cubeOne.Length];
        static Vector3 viewPoint = new Vector3(50, 50, 50);
        static float distance = viewPoint.Length();
        float distanceFromViewPlane = 50f;
        float xAng = (float)Math.Asin(viewPoint.Y / Math.Sqrt(viewPoint.X * viewPoint.X + viewPoint.Y * viewPoint.Y));
        float zAng = (float)Math.Asin(Math.Sqrt(viewPoint.X * viewPoint.X + viewPoint.Y * viewPoint.Y) / distance);
        Bitmap image = new Bitmap(800, 800);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Translate(Vector4[] vertecies, Vector3 t)
        {
            for (int i = 0; i < vertecies.Length; i++)
            {
                vertecies[i].X += t.X;
                vertecies[i].Y += t.Y;
                vertecies[i].Z += t.Z;
            }
        }

        private Vector4 viewTransform(Vector4 world)
        {
            float xView = -world.X * (float)Math.Sin(xAng) + world.Y * (float)Math.Cos(xAng);
            float yView = -world.X * (float)Math.Cos(xAng) * (float)Math.Cos(zAng) + -world.Y * (float)Math.Sin(xAng) * (float)Math.Cos(zAng) + world.Z * (float)Math.Sin(zAng);
            float zView = -world.X * (float)Math.Cos(xAng) * (float)Math.Sin(zAng) + -world.Y * (float)Math.Sin(xAng) * (float)Math.Sin(zAng) + -world.Z * (float)Math.Cos(zAng) + distance;

            return new Vector4(xView, yView, zView, 1);
        }

        private Vector2 ProjectToViewPlane(Vector4 view)
        {
            return new Vector2((float)Math.Round(view.X, 0), (float)Math.Round(view.Y, 0));
        }

        private void DrawImage(int x, int y)
        {
            for (int i = x - 2; i <= x + 2; i++)
                for (int j = y - 2; j <= y + 2; j++)
                    if (i > 0 && j > 0 && i < image.Height && j < image.Height)
                        image.SetPixel(i, j, Color.Black);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                    image.SetPixel(i, j, Color.White);

            //Translate(cubeOne, new Vector3(20, 20, 20));

            for (int i = 0; i < cubeOne.Length; i++)
            {
                cubeOneTransformed[i] = viewTransform(cubeOne[i]);
            }

            for (int i = 0; i < cubeOne.Length; i++)
            {
                Vector2 p = ProjectToViewPlane(cubeOneTransformed[i]);
                DrawImage((int)p.X, (int)p.Y);
            }

            pictureBox1.Image = image;
        }
    }
}
