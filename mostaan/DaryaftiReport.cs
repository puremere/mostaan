using mostaan.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using mostaan.Classes;

namespace mostaan
{
    public partial class DaryaftiReport : Form
    {
        Model.Context dbcontext = new Model.Context();
        FontClass fontclass = new FontClass();
        //databaseManager manager = new databaseManager();
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
           IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        public void initFont()
        {

            byte[] fontData = Properties.Resources.IRANSans_FaNum_;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.IRANSans_FaNum_.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.IRANSans_FaNum_.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            GlobalVariable.headerlistFONT = new Font(fonts.Families[0], 24.0F, System.Drawing.FontStyle.Regular);

            GlobalVariable.headerlistFONTsmall = new Font(fonts.Families[0], 12.0F, System.Drawing.FontStyle.Regular);
            //GlobalVariable.headerlistFONTBold = new Font(fonts.Families[0], 11.0F, System.Drawing.FontStyle.Bold);
            //GlobalVariable.HlistFONT = new Font(fonts.Families[0], 18.0F, System.Drawing.FontStyle.Regular);
            // label1.Font = GlobalVariable.headerlistFONT;
        }
        public DaryaftiReport(DataTable dt1)
        {
         

            InitializeComponent();
            initFont();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            this.MaximizeBox = false;

            filterPanel.PanelElement.Shape = new RoundRectShape();
            filterPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            filterPanel.PanelElement.PanelFill.BackColor = Color.Gray;


            newRecordPanel.PanelElement.Shape = new RoundRectShape();
            newRecordPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            newRecordPanel.PanelElement.PanelFill.BackColor = Color.Gray;

            if (dt1.Columns.Count != 0)
            {
                dataGridView1.DataSource = dt1;
            }
            else
            {
                List<Model.archive> lst = (from p in dbcontext.Archives
                                           select p).ToList();
                dataGridView1.DataSource = lst;
            }

            
            dataGridView1.Columns[0].HeaderText = "شماره";
            dataGridView1.Columns[1].HeaderText = "موضوع";
            dataGridView1.Columns[2].HeaderText = "نوع محصول";
            dataGridView1.Columns[3].HeaderText = "رده محصول";
            dataGridView1.Columns[4].HeaderText = "مرکز";
            dataGridView1.Columns[5].HeaderText = "پروژه";
            dataGridView1.Columns[6].HeaderText = "نوع سند";
            dataGridView1.Columns[7].HeaderText = "کارفرما";
            dataGridView1.Columns[8].HeaderText = "تاریخ سند";
            dataGridView1.Columns[9].HeaderText = "شماره سند";
            dataGridView1.Columns[10].HeaderText = "واریز";
            dataGridView1.Columns[11].HeaderText = "مبلغ";
            dataGridView1.Columns[12].HeaderText = "حساب";
            this.CenterToScreen();
        }

        private void newRecord_Click(object sender, EventArgs e)
        {
            newRecord newrecord = new newRecord("1");
            newrecord.Show();
        }

        private void newRecord_Click_1(object sender, EventArgs e)
        {
            newRecord newrecord = new newRecord("1");
            newrecord.Show();
            this.Hide();
        }

        private void filterPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void filter_Click(object sender, EventArgs e)
        {
            filterPage filp = new filterPage("1");
            filp.Show();
            this.Hide();
        }
       
        
    }
}
