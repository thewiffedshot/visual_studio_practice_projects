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

        private object _locker = new object();

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

        private void BConvert_Click(object sender, EventArgs e)
        {
            threadOption.Enabled = false;

            timer.Start();

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

            if (threadOption.Checked)
            {
                var t1 = new Task(() =>
                {
                    for (int i = 0; i < height / interval / 4; i++)
                    {
                        for (int j = 0; j < width / interval / 4; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                });

                var t2 = new Task(() =>
                {
                    for (int i = 0; i < height / interval / 4; i++)
                    {
                        for (int j = width / interval / 4; j < width / interval / 2; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                });

                var t3 = new Task(() =>
                {
                    for (int i = 0; i < height / interval / 4; i++)
                    {
                        for (int j = width / interval / 2; j < (width / interval / 4) * 3 ; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                });

                var t4 = new Task(() =>
                {
                    for (int i = 0; i < height / interval / 4; i++)
                    {
                        for (int j = (width / interval / 4) * 3; j < width / interval; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                });

                var t5 = new Task(() =>
                {
                    for (int i = height / interval / 4; i < height / interval / 2; i++)
                    {
                        for (int j = 0; j < width / interval / 4; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                });

                var t6 = new Task(() =>
                {
                    for (int i = height / interval / 4; i < height / interval / 2; i++)
                    {
                        for (int j = width / interval / 4; j < width / interval / 2; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                });

                var t7 = new Task(() =>
                {
                    for (int i = height / interval / 4; i < height / interval / 2; i++)
                    {
                        for (int j = width / interval / 2; j < (width / interval / 4) * 3; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                });

                var t8 = new Task(() =>
                {
                    for (int i = height / interval / 4; i < height / interval / 2; i++)
                    {
                        for (int j = (width / interval / 4) * 3; j < width / interval; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                });

                var t9 = new Task(() =>
                {
                    for (int i = height / interval / 2; i < (height / interval / 4) * 3; i++)
                    {
                        for (int j = 0; j < width / interval / 4; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                });

                var t10 = new Task(() =>
                {
                    for (int i = height / interval / 2; i < (height / interval / 4) * 3; i++)
                    {
                        for (int j = width / interval / 4; j < width / interval / 2; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                });

                var t11 = new Task(() =>
                {
                    for (int i = height / interval / 2; i < (height / interval / 4) * 3; i++)
                    {
                        for (int j = width / interval / 2; j < (width / interval / 4) * 3; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                });

                var t12 = new Task(() =>
                {
                    for (int i = height / interval / 2; i < (height / interval / 4) * 3; i++)
                    {
                        for (int j = (width / interval / 4) * 3; j < width / interval; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                });

                var t13 = new Task(() =>
                {
                    for (int i = (height / interval / 4) * 3; i < height / interval; i++)
                    {
                        for (int j = 0; j < width / interval / 4; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                });

                var t14 = new Task(() =>
                {
                    for (int i = (height / interval / 4) * 3; i < height / interval; i++)
                    {
                        for (int j = width / interval / 4; j < width / interval / 2; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                });

                var t15 = new Task(() =>
                {
                    for (int i = (height / interval / 4) * 3; i < height / interval; i++)
                    {
                        for (int j = width / interval / 2; j < (width / interval / 4) * 3; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                });

                var t16 = new Task(() =>
                {
                    for (int i = (height / interval / 4) * 3; i < height / interval; i++)
                    {
                        for (int j = (width / interval / 4) * 3; j < width / interval; j++)
                        {
                            GetAverageColor(i, j, true);
                        }
                    }
                });

                t1.Start();
                t2.Start();
                t3.Start();
                t4.Start();
                t5.Start();
                t6.Start();
                t7.Start();
                t8.Start();
                t9.Start();
                t10.Start();
                t11.Start();
                t12.Start();
                t13.Start();
                t14.Start();
                t15.Start();
                t16.Start();

                while (t1.Status == TaskStatus.WaitingToRun || t1.Status == TaskStatus.Running
                    || t2.Status == TaskStatus.WaitingToRun || t2.Status == TaskStatus.Running
                    || t3.Status == TaskStatus.WaitingToRun || t3.Status == TaskStatus.Running
                    || t4.Status == TaskStatus.WaitingToRun || t4.Status == TaskStatus.Running
                    || t5.Status == TaskStatus.WaitingToRun || t5.Status == TaskStatus.Running
                    || t6.Status == TaskStatus.WaitingToRun || t6.Status == TaskStatus.Running
                    || t7.Status == TaskStatus.WaitingToRun || t7.Status == TaskStatus.Running
                    || t8.Status == TaskStatus.WaitingToRun || t8.Status == TaskStatus.Running
                    || t9.Status == TaskStatus.WaitingToRun || t9.Status == TaskStatus.Running
                    || t10.Status == TaskStatus.WaitingToRun || t10.Status == TaskStatus.Running
                    || t11.Status == TaskStatus.WaitingToRun || t11.Status == TaskStatus.Running
                    || t12.Status == TaskStatus.WaitingToRun || t12.Status == TaskStatus.Running
                    || t13.Status == TaskStatus.WaitingToRun || t13.Status == TaskStatus.Running
                    || t14.Status == TaskStatus.WaitingToRun || t14.Status == TaskStatus.Running
                    || t15.Status == TaskStatus.WaitingToRun || t15.Status == TaskStatus.Running
                    || t16.Status == TaskStatus.WaitingToRun || t16.Status == TaskStatus.Running)
                {
                    // Do nothing...                 
                }
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

                            if (interval == 16)
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
                try
                {
                    image = DrawImage(closestPath, true, ref resultImage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source);
                    Application.Exit();
                }
            else
                try
                {
                    image = DrawImage(closestPath, false, ref resultImage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source);
                    Application.Exit();
                }

            pictureBox.Image = image;

            timer.Stop();
            MessageBox.Show(stopwatch.ToString() + " seconds.", "Time:");

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
            image.Dispose();
        }

        private Bitmap DrawImage(string[,] path, bool threaded, ref Bitmap result)
        {
            if (threaded)
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

                // TODO...

                /*Bitmap bmp = result;

                for (int i = 0, y = 0; i < path.GetLength(0) * interval; i += interval, y++)
                {
                    for (int j = 0, x = 0; j < path.GetLength(1) * interval; j += interval, x++)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            
                        }
                    }
                }

                return bmp;*/
            }
            else
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

        private void BitmapDrawImage(int x, int y, string path)
        {
            Color color = Color.Black;
            int offset = 0x0A; // Offset containing value of beginning of pixel data.

            byte[] buffer = new byte[3];

            try
            {
                using (var fs = File.Open(Path.GetTempPath() + "resultTemp.bmp", FileMode.Open, FileAccess.Write, FileShare.Write))
                {
                    fs.Read(buffer, offset, buffer.Length);

                    offset = buffer[0]; // Offset of beginning of pixel data.

                    offset += (image.Height - 0x01 - y) * rowSize + (x * 0x03);

                    fs.Write(buffer, offset, buffer.Length);

                    color = Color.FromArgb(buffer[2], buffer[1], buffer[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Please take note of the exception and try again.", ex.Source);
                Application.Restart();
            }
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
