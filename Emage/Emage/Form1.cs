using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Emage
{
    public partial class Form1 : Form
    {
        private string path;
        private string savePath;
        private Bitmap image;
        private Bitmap convertedImage;
        private int interval = 32;

        public Form1()
        {
            InitializeComponent();
        }

        private void BLoad_Click(object sender, EventArgs e)
        {
            openDialog.InitialDirectory = Application.StartupPath;
            openDialog.ShowDialog();
            path = openDialog.FileName;

            if (smallOption.Checked) interval = 16;
            smallOption.Enabled = false;

            try
            {
                image = new Bitmap(path);
                if (!(image.Width % interval == 0 && image.Height % interval == 0)) image = CropImage(image, new Rectangle(new Point(0, 0), new Size(image.Width - (image.Width % interval), image.Height - (image.Height % interval))));
                convertedImage = new Bitmap(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Please take note of the exception and try again.", ex.Source);
                Application.Restart();
            }

            pictureBox.Image = image;

            BConvert.Enabled = true;
        }

        private Bitmap CropImage(Bitmap b, Rectangle r)
        {
            Bitmap nb = new Bitmap(r.Width, r.Height);
            Graphics g = Graphics.FromImage(nb);
            g.DrawImage(b, -r.X, -r.Y);
            return nb;
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            bool saveException = false;

            saveDialog.InitialDirectory = Application.StartupPath;

            do
            {
                try
                {
                    saveDialog.ShowDialog();
                    savePath = saveDialog.FileName;
                    SaveImage(image, savePath);

                    saveException = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Please try again.", ex.Source);
                    saveException = true;
                }

            } while (saveException);

            smallOption.Enabled = true;
            BConvert.Enabled = false;
            BSave.Enabled = false;

            GC.Collect();
        }

        private void BConvert_Click(object sender, EventArgs e)
        {
            string[] lines = ReadLines("data.txt");
            int emojiCount = 0;

            for (int i = 0; i < lines.Length; i += 4)
                if (i < lines.Length) emojiCount++;

            ColorVector[] colors = new ColorVector[emojiCount];
            ColorVector[,] averages = new ColorVector[(image.Height / interval), (image.Width / interval)];
            string[,] closestPath = new string[(image.Height / interval), (image.Width / interval)];

            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = GetEmojiColor(lines[4 * i]);
            }

            for (int i = 0; i < image.Height / interval; i++)
            {
                for (int j = 0; j < image.Width / interval; j++)
                {
                    averages[i, j] = GetAverageColor(i, j);
                }
            }

            for (int i = 0; i < averages.GetLength(0); i++)
            {
                for (int j = 0; j < averages.GetLength(1); j++)
                {
                    double distance = int.MaxValue;
                    int n = 0;

                    foreach (ColorVector c in colors)
                    {
                        if (c.GetDistanceFrom(averages[i, j]) < distance)
                        {
                            distance = c.GetDistanceFrom(averages[i, j]);

                            if (!smallOption.Checked)
                            {
                                closestPath[i, j] = lines[n * 4 + 1];
                            }
                            else
                            {
                                closestPath[i, j] = lines[n * 4 + 2];
                            }
                        }

                        n++;
                    }
                }
            }

            try
            {
                image = DrawImage(closestPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                Application.Exit();
            }

            pictureBox.Image = image;

            BSave.Enabled = true;
        }

        private Bitmap DrawImage(string[,] path)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.Clear(Color.Black);
            
            for (int i = 0, y = 0; i < path.GetLength(0) * interval; i += interval, y++)
            {
                for (int j = 0, x = 0; j < path.GetLength(1) * interval; j += interval, x++)
                    gfx.DrawImage(Image.FromFile(Environment.CurrentDirectory + path[y, x]), new Point(j, i));
            }

            return bmp;
        }

        private void SaveImage(Bitmap image, string path)
        {
            image.Save(path, System.Drawing.Imaging.ImageFormat.Png);
        }

        private string[] ReadLines(string path)
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + " Please supply the missing file and then restart the program.", ex.Source);
                Application.Exit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " Sort out the exception and then restart the program.", e.Source);
                Application.Exit();
            }

            return null;
        }

        private ColorVector GetAverageColor(int quadY, int quadX)
        {
            double averageRed = 0x00, averageGreen = 0x00, averageBlue = 0x00;

            for (int y = quadY * interval; y < interval * (quadY + 1); y++)
            {
                for (int x = quadX * interval; x < interval * (quadX + 1); x++)
                {
                    Color c = image.GetPixel(x, y);
                    averageRed += c.R * c.R;
                    averageGreen += c.G * c.G;
                    averageBlue += c.B * c.B;
                }
            }

            averageRed /= interval * interval;
            averageRed = Math.Sqrt(averageRed);

            averageGreen /= interval * interval;
            averageGreen = Math.Sqrt(averageGreen);

            averageBlue /= interval * interval;
            averageBlue = Math.Sqrt(averageBlue);

            return new ColorVector((byte)averageRed, (byte)averageGreen, (byte)averageBlue);        
        }

        private ColorVector GetEmojiColor(string name)
        {
            string hexRed = "", hexGreen = "", hexBlue = "";
            byte red, green, blue;

            hexRed += name[1];
            hexRed += name[2];

            hexGreen += name[3];
            hexGreen += name[4];

            hexBlue += name[5];
            hexBlue += name[6];

            red = byte.Parse(hexRed, System.Globalization.NumberStyles.HexNumber);
            green = byte.Parse(hexGreen, System.Globalization.NumberStyles.HexNumber);
            blue = byte.Parse(hexBlue, System.Globalization.NumberStyles.HexNumber);

            return new ColorVector(red, green, blue);
        }
    }
}
