﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Windows.Forms;

namespace simple_3d_graphics_test
{
    public partial class Form1 : Form
    {
        static Vertex[] cubeOne = { new Vertex(new Vector4(10, 10, -40, 1)), new Vertex(new Vector4(-10, 10, -40, 1)), new Vertex(new Vector4(-10, -10, -40, 1)), new Vertex(new Vector4(10, -10, -40, 1)), new Vertex(new Vector4(10, 10, 40, 1)), new Vertex(new Vector4(-10, 10, 40, 1)), new Vertex(new Vector4(-10, -10, 40, 1)), new Vertex(new Vector4(10, -10, 40, 1)) };
        static Vertex[] cubeOneCopy = cubeOne;
        static int angle = 0;

        Vector2[] cubeOneTransformed = new Vector2[cubeOne.Length];
        static Vector3 viewPoint = new Vector3(50, 50, 50);
        static float distance = viewPoint.Length();
        float distanceFromViewPlane = 400f;
        float xAng = (float)Math.Asin(viewPoint.Y / Math.Sqrt(viewPoint.X * viewPoint.X + viewPoint.Y * viewPoint.Y));
        float zAng = (float)Math.Asin(Math.Sqrt(viewPoint.X * viewPoint.X + viewPoint.Y * viewPoint.Y) / distance);
        Bitmap image = new Bitmap(600, 600);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelDistance.Text = trackDistance.Value.ToString();
        }

        private void Translate(Vertex[] vertices, Vector3 t)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].position.X += t.X;
                vertices[i].position.Y += t.Y;
                vertices[i].position.Z += t.Z;
            }
        }

        private Vector4 GetCenter(Vertex[] mesh)
        {
            Vector4 average = new Vector4(0, 0, 0, 1);
            int counter = 0;

            foreach (Vertex vertex in mesh)
            {
                average += vertex.position;
                counter++;
            }

            if (counter != 0)
            average /= counter;

            average.W = 1;

            return average;
        }

        private void Rotate()
        {
            Quaternion q = new Quaternion(new Vector3(trackRotX.Value, trackRotY.Value, trackRotZ.Value), trackRotAngle.Value * (float)(Math.PI / 180));

            foreach (Vertex vertex in cubeOne)
            {
                Vector4 c = GetCenter(cubeOne);

                vertex.position -= c;

                vertex.position = new Vector4(q.RotateVector(new Vector3(vertex.position.X, vertex.position.Y, vertex.position.Z)), 1);

                vertex.position += c;

                vertex.position.W = 1;
            }
        }

        private Vector4 viewTransform(Vector4 world)
        {
            float xView = -world.X * (float)Math.Sin(xAng) + world.Y * (float)Math.Cos(xAng);
            float yView = -world.X * (float)Math.Cos(xAng) * (float)Math.Cos(zAng) - world.Y * (float)Math.Sin(xAng) * (float)Math.Cos(zAng) + world.Z * (float)Math.Sin(zAng);
            float zView = -world.X * (float)Math.Cos(xAng) * (float)Math.Sin(zAng) + -world.Y * (float)Math.Sin(xAng) * (float)Math.Sin(zAng) + -world.Z * (float)Math.Cos(zAng) + distance;

            return new Vector4(xView, yView, zView, 1);
        }

        private Vector2 ProjectToViewPlane(Vector4 view)
        {
            return new Vector2((float)Math.Round(view.X / (view.Z / distanceFromViewPlane), 0), (float)Math.Round(view.Y / (view.Z / distanceFromViewPlane), 0));
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

            Translate(cubeOne, new Vector3(trackX.Value, trackY.Value, trackZ.Value)); // -6, 8, -14, 857

            if (trackRotX.Value != 0 || trackRotY.Value != 0 || trackRotZ.Value != 0) Rotate();

            for (int i = 0; i < cubeOne.Length; i++)
            {
                cubeOneTransformed[i] = ProjectToViewPlane(viewTransform(cubeOne[i].position));
            }

            Edge[] edges = new Edge[12];
            edges[0] = new Edge(new Vector2[] { cubeOneTransformed[0], cubeOneTransformed[1] });
            edges[1] = new Edge(new Vector2[] { cubeOneTransformed[1], cubeOneTransformed[2] });
            edges[2] = new Edge(new Vector2[] { cubeOneTransformed[2], cubeOneTransformed[3] });
            edges[3] = new Edge(new Vector2[] { cubeOneTransformed[3], cubeOneTransformed[0] });

            edges[4] = new Edge(new Vector2[] { cubeOneTransformed[4], cubeOneTransformed[5] });
            edges[5] = new Edge(new Vector2[] { cubeOneTransformed[5], cubeOneTransformed[6] });
            edges[6] = new Edge(new Vector2[] { cubeOneTransformed[6], cubeOneTransformed[7] });
            edges[7] = new Edge(new Vector2[] { cubeOneTransformed[7], cubeOneTransformed[4] });

            edges[8] = new Edge(new Vector2[] { cubeOneTransformed[0], cubeOneTransformed[4] });
            edges[9] = new Edge(new Vector2[] { cubeOneTransformed[1], cubeOneTransformed[5] });
            edges[10] = new Edge(new Vector2[] { cubeOneTransformed[2], cubeOneTransformed[6] });
            edges[11] = new Edge(new Vector2[] { cubeOneTransformed[3], cubeOneTransformed[7] });

            for (int i = 0; i < edges.Length; i++)
            {
                edges[i].Draw(image);
            }

            pictureBox1.Image = image;
        }

        private void trackX_Scroll(object sender, EventArgs e)
        {
            labelX.Text = trackX.Value.ToString();
        }

        private void trackY_Scroll(object sender, EventArgs e)
        {
            labelY.Text = trackY.Value.ToString();
        }

        private void trackZ_Scroll(object sender, EventArgs e)
        {
            labelZ.Text = trackZ.Value.ToString();
        }

        private void trackDistance_Scroll(object sender, EventArgs e)
        {
            labelDistance.Text = trackDistance.Value.ToString();
            distanceFromViewPlane = trackDistance.Value;
        }

        private void trackRotX_Scroll(object sender, EventArgs e)
        {
            labelRotX.Text = trackRotX.Value.ToString();
        }

        private void trackRotY_Scroll(object sender, EventArgs e)
        {
            labelRotY.Text = trackRotY.Value.ToString();
        }

        private void trackRotZ_Scroll(object sender, EventArgs e)
        {
            labelRotZ.Text = trackRotZ.Value.ToString();
        }

        private void trackRotAngle_Scroll(object sender, EventArgs e)
        {
            labelRotAngle.Text = trackRotAngle.Value.ToString();
        }
    }
}
