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
    public partial class factorPdf : Form
    {
        public factorPdf(string pdfName)
        {
            //var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            InitializeComponent();

            webBrowser1.Navigate(pdfName);
            // axAcroPDF1.src = directory + pdfName;
        }
    }
}
