using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mostaan
{
    public partial class factorImage : Form
    {
        public factorImage(string imageName)
        {
            //var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(imageName);

            this.WindowState = FormWindowState.Maximized;

        }
    }
}
