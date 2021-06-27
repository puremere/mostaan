using mostaan.Classes;
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
    public partial class DaReport : Form
    {
        public DaReport()
        {
            InitializeComponent();
          
        }

        private void newRecord_Click(object sender, EventArgs e)
        {
            DaReport form = new DaReport();
            form.Show();
        }
    }
}
