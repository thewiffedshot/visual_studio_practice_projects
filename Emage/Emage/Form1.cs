using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            image = new Bitmap(path);

            image = CropImage(image, new Rectangle(new Point(0, 0), new Size(image.Width - (image.Width % interval), image.Height - (image.Height % interval))));
            convertedImage = new Bitmap(path);

            pictureBox.Image = image;
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
            saveDialog.InitialDirectory = Application.StartupPath;
            saveDialog.ShowDialog();
            savePath = saveDialog.FileName;

            smallOption.Enabled = true;
        }

        private void BConvert_Click(object sender, EventArgs e)
        {
            
        }
    }
}
