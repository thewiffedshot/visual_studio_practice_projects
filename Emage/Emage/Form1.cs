using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace Emage
{
    public partial class Form1 : Form
    {
        private string path;
        private string savePath;
        private static Bitmap image;
        private int width = 0, height = 0;
        private Bitmap resultImage;
        private byte[] tempBitmap;
        private int interval = 32;
        private static ColorVector[,] averages;

        private int rowSize = 0;

        private static decimal stopwatch = 0m;

        private Object _locker = new object();

        public Form1()
        {
            InitializeComponent();
        }

        ~Form1()
        {
            try
            {
                File.Delete(Path.GetTempPath() + "tempImage.bmp");
                File.Delete(Path.GetTempPath() + "resultTemp.bmp");
            }
            catch (FileNotFoundException)
            {
                // Do nothing...
            }
            catch (Exception)
            {
                // Do nothing...
            }
        }

        private void BLoad_Click(object sender, EventArgs e)
        {
            GC.Collect();

            BConvert.Enabled = false;
            BSave.Enabled = false;

            openDialog.InitialDirectory = Application.StartupPath;
            openDialog.ShowDialog();
            path = openDialog.FileName;

            if (smallOption.Checked) interval = 16;

            try
            {
                image = new Bitmap(path);
                if (!(image.Width % interval == 0 && image.Height % interval == 0)) image = CropImage(image, new Rectangle(new Point(0, 0), new Size(image.Width - (image.Width % interval), image.Height - (image.Height % interval))));

                width = image.Width;
                height = image.Height;
                rowSize = (int)Math.Floor((24m*image.Width + 31m) / 32m) * 4;

                resultImage = new Bitmap(image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                resultImage.Save(Path.GetTempPath() + "resultTemp.bmp");

                Bitmap bmp = new Bitmap(image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                Graphics gfx = Graphics.FromImage(bmp);
                gfx.DrawImage(image, new Point(0, 0));
                gfx.Dispose();

                bmp.Save(Path.GetTempPath() + "tempImage.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                tempBitmap = File.ReadAllBytes(Path.GetTempPath() + "tempImage.bmp");
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

            BConvert.Enabled = false;
            BSave.Enabled = false;

            GC.Collect();
        }

        private async void BConvert_Click(object sender, EventArgs e)
        {
            threadOption.Enabled = false;

            string[] lines = ReadLines("data.txt");
            int emojiCount = 0;

            for (int i = 0; i < lines.Length; i += 4)
                if (i < lines.Length) emojiCount++;

            ColorVector[] colors = new ColorVector[emojiCount];
            averages = new ColorVector[(image.Height / interval), (image.Width / interval)];
            string[,] closestPath = new string[(image.Height / interval), (image.Width / interval)];

            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = GetEmojiColor(lines[4 * i]);
            }

            Task[] tasks = new Task[16];

            if (threadOption.Checked)
            {
                tasks[0] = (new Task(() =>
                {
                    for (int i = 0; i < height / interval / 4; i++)
                    {
                        for (int j = 0; j < width / interval / 4; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                }));

                tasks[1] = (new Task(() =>
                {
                    for (int i = 0; i < height / interval / 4; i++)
                    {
                        for (int j = width / interval / 4; j < width / interval / 2; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                }));

                tasks[2] = (new Task(() =>
                {
                    for (int i = 0; i < height / interval / 4; i++)
                    {
                        for (int j = width / interval / 2; j < (width / interval / 4) * 3; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                }));

                tasks[3] = (new Task(() =>
                {
                    for (int i = 0; i < height / interval / 4; i++)
                    {
                        for (int j = (width / interval / 4) * 3; j < width / interval; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                }));

                tasks[4] = (new Task(() =>
                {
                    for (int i = height / interval / 4; i < height / interval / 2; i++)
                    {
                        for (int j = 0; j < width / interval / 4; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                }));

                tasks[5] = (new Task(() =>
                {
                    for (int i = height / interval / 4; i < height / interval / 2; i++)
                    {
                        for (int j = width / interval / 4; j < width / interval / 2; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                }));

                tasks[6] = (new Task(() =>
                {
                    for (int i = height / interval / 4; i < height / interval / 2; i++)
                    {
                        for (int j = width / interval / 2; j < (width / interval / 4) * 3; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                }));

                tasks[7] = (new Task(() =>
                {
                    for (int i = height / interval / 4; i < height / interval / 2; i++)
                    {
                        for (int j = (width / interval / 4) * 3; j < width / interval; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                }));

                tasks[8] = (new Task(() =>
                {
                    for (int i = height / interval / 2; i < (height / interval / 4) * 3; i++)
                    {
                        for (int j = 0; j < width / interval / 4; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                }));

                tasks[9] = (new Task(() =>
                {
                    for (int i = height / interval / 2; i < (height / interval / 4) * 3; i++)
                    {
                        for (int j = width / interval / 4; j < width / interval / 2; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                }));

                tasks[10] = (new Task(() =>
                {
                    for (int i = height / interval / 2; i < (height / interval / 4) * 3; i++)
                    {
                        for (int j = width / interval / 2; j < (width / interval / 4) * 3; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                }));

                tasks[11] = (new Task(() =>
                {
                    for (int i = height / interval / 2; i < (height / interval / 4) * 3; i++)
                    {
                        for (int j = (width / interval / 4) * 3; j < width / interval; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                }));

                tasks[12] = (new Task(() =>
                {
                    for (int i = (height / interval / 4) * 3; i < height / interval; i++)
                    {
                        for (int j = 0; j < width / interval / 4; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                }));

                tasks[13] = (new Task(() =>
                {
                    for (int i = (height / interval / 4) * 3; i < height / interval; i++)
                    {
                        for (int j = width / interval / 4; j < width / interval / 2; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                }));

                tasks[14] = (new Task(() =>
                {
                    for (int i = (height / interval / 4) * 3; i < height / interval; i++)
                    {
                        for (int j = width / interval / 2; j < (width / interval / 4) * 3; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                }));

                tasks[15] = (new Task(() =>
                {
                    for (int i = (height / interval / 4) * 3; i < height / interval; i++)
                    {
                        for (int j = (width / interval / 4) * 3; j < width / interval; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                }));

                foreach (Task task in tasks)
                    task.Start();

                await Task.WhenAll(tasks);
            }
            else
            {
                for (int i = 0; i < image.Height / interval; i++)
                {
                    for (int j = 0; j < image.Width / interval; j++)
                    {
                        GetAverageColor(i, j, false);
                    }
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

                            if (interval == 32)
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

            if (threadOption.Checked)
            {
                try
                {
                    Bitmap bmp = new Bitmap(width, height);
                    Graphics gfx = Graphics.FromImage(bmp);

                    Task[] tasks1 = new Task[4];

                    tasks1[0] = new Task(() =>
                    {
                        for (int i = 0, y = 0; i < closestPath.GetLength(0) * interval / 2; i += interval, y++)
                        {
                            for (int j = 0, x = 0; j < closestPath.GetLength(1) * interval / 2; j += interval, x++)
                                lock (_locker) { gfx.DrawImage(Image.FromFile(Environment.CurrentDirectory + closestPath[y, x]), new Point(j, i)); }
                        }
                    });

                    tasks1[1] = new Task(() =>
                    {
                        for (int i = 0, y = 0; i < closestPath.GetLength(0) * interval / 2; i += interval, y++)
                        {
                            for (int j = closestPath.GetLength(1) * interval / 2, x = j / interval; j < closestPath.GetLength(1) * interval; j += interval, x++)
                                lock (_locker) { gfx.DrawImage(Image.FromFile(Environment.CurrentDirectory + closestPath[y, x]), new Point(j, i)); }
                        }
                    });

                    tasks1[2] = new Task(() =>
                    {
                        for (int i = (closestPath.GetLength(0) + 1) * interval / 2, y = i / interval; i < closestPath.GetLength(0) * interval; i += interval, y++)
                        {
                            for (int j = 0, x = 0; j < closestPath.GetLength(1) * interval / 2; j += interval, x++)
                                lock (_locker) { gfx.DrawImage(Image.FromFile(Environment.CurrentDirectory + closestPath[y, x]), new Point(j, i)); }
                        }
                    });

                    tasks1[3] = new Task(() =>
                    {
                        for (int i = (closestPath.GetLength(0) + 1) * interval / 2, y = i / interval; i < closestPath.GetLength(0) * interval; i += interval, y++)
                        {
                            for (int j = closestPath.GetLength(1) * interval / 2, x = j / interval; j < closestPath.GetLength(1) * interval; j += interval, x++)
                                lock (_locker) { gfx.DrawImage(Image.FromFile(Environment.CurrentDirectory + closestPath[y, x]), new Point(j, i)); }
                        }
                    });

                    foreach (Task task in tasks1)
                        task.Start();

                    await Task.WhenAll(tasks1);

                    image = bmp;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source);
                    Application.Exit();
                }
            }
            else
            {
                try
                {
                    Bitmap bmp = new Bitmap(image.Width, image.Height);
                    Graphics gfx = Graphics.FromImage(bmp);

                    for (int i = 0, y = 0; i < closestPath.GetLength(0) * interval; i += interval, y++)
                    {
                        for (int j = 0, x = 0; j < closestPath.GetLength(1) * interval; j += interval, x++)
                            gfx.DrawImage(Image.FromFile(Environment.CurrentDirectory + closestPath[y, x]), new Point(j, i));
                    }

                    image = bmp;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source);
                    Application.Exit();
                }
            }

            pictureBox.Image = image;

            try
            {
                File.Delete(Path.GetTempPath() + "tempImage.bmp");
                File.Delete(Path.GetTempPath() + "resultTemp.bmp");
            }
            catch (FileNotFoundException)
            {
                // Do nothing...
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + " Please take note of the exception and try again.", exc.Source);
                Application.Restart();
            }

            BSave.Enabled = true;
            threadOption.Enabled = true;

            averages = null;
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

        private void GetAverageColor(int quadY, int quadX, bool threaded)
        {
            double averageRed = 0x00, averageGreen = 0x00, averageBlue = 0x00;

            if (threaded)
            {
                for (int y = quadY * interval; y < interval * (quadY + 1); y++)
                {
                    for (int x = quadX * interval; x < interval * (quadX + 1); x++)
                    {
                        Color c;

                        c = BitmapReadPixel(x, y);

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

                averages[quadY, quadX] = new ColorVector((byte)averageRed, (byte)averageGreen, (byte)averageBlue);
            }
            else
            {
                for (int y = quadY * interval; y < interval * (quadY + 1); y++)
                {
                    for (int x = quadX * interval; x < interval * (quadX + 1); x++)
                    {
                        Color c;

                        c = image.GetPixel(x, y);

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

                averages[quadY, quadX] = new ColorVector((byte)averageRed, (byte)averageGreen, (byte)averageBlue);
            }
        }

        private Color BitmapReadPixel(int x, int y)
        {
            Color color = Color.Black;
            int offset = 0x0A; // Offset containing value of beginning of pixel data.

            try
            {
                offset = tempBitmap[offset]; // Offset of beggining of pixel data.

                offset += (height - 0x1 - y) * rowSize + x * 0x3;

                color = Color.FromArgb(tempBitmap[offset + 2], tempBitmap[offset + 1], tempBitmap[offset]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Please take note of the exception and try again.", ex.Source);
                Application.Restart();
            }

            return color;
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

        private void timer_Tick(object sender, EventArgs e)
        {
            stopwatch += 0.01m;
        }
    }
}
