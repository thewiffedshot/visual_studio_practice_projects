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
        public Form1()
        {
            InitializeComponent();
        }

        private void BLoad_Click(object sender, EventArgs e)
        {
            openDialog.InitialDirectory = Application.StartupPath;
            openDialog.ShowDialog();
            string path = openDialog.FileName;
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            saveDialog.InitialDirectory = Application.StartupPath;
            saveDialog.ShowDialog();
            string path = saveDialog.FileName;
        }

        private void BConvert_Click(object sender, EventArgs e)
        {

        }
    }
}
