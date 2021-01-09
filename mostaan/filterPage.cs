using mostaan.Classes;
using mostaan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace mostaan
{
    public partial class filterPage : Form
    {
        Context context = new Context();

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
            GlobalVariable.headerlistFONTBold = new Font(fonts.Families[0], 12.0F, System.Drawing.FontStyle.Bold);
            //GlobalVariable.HlistFONT = new Font(fonts.Families[0], 18.0F, System.Drawing.FontStyle.Regular);
            // label1.Font = GlobalVariable.headerlistFONT;
            header.Font = GlobalVariable.headerlistFONTBold;
        }
        public filterPage(string type)
        {
            InitializeComponent();
            if (type == "1")
            {
                header.Text = "افزودن اطلاعات دریافتی جدید";
            }
            filterPanel1.PanelElement.Shape = new RoundRectShape();
            filterPanel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            filterPanel1.PanelElement.PanelFill.BackColor = Color.Gray;


            initFont();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            this.MaximizeBox = false;
            this.CenterToScreen();
         
        }
       
        private void filter_Click(object sender, EventArgs e)
        {
            List<Model.archive> lst = new List<archive>();
            var plist = (from p in context.Archives select p);
            if (subject.Text != "")
            {
                plist = plist.Where(x => x.subject == subject.Text);
            }
            if(productType.Text != "")
            {
                plist = plist.Where(x => x.productType == productType.Text);
            }
            if (rank.Text != "")
            {
                plist = plist.Where(x => x.rank == rank.Text);
            }
            if (markaz.Text != "")
            {
                plist = plist.Where(x => x.markaz == markaz.Text);
            }
            if (project.Text != "")
            {
                plist = plist.Where(x => x.project == project.Text);
            }
            if (sanadType.Text != "")
            {
                plist = plist.Where(x => x.sanadType == sanadType.Text);
            }
            if (karfarma.Text != "")
            {
                plist = plist.Where(x => x.karfarma == karfarma.Text);
            }
            if (tarikh.Text != "")
            {
                plist = plist.Where(x => x.tarikh == tarikh.Text);
            }
            if (shomareSanad.Text != "")
            {
                plist = plist.Where(x => x.shomareSanad == shomareSanad.Text);
            }
            if (variz.Text != "")
            {
                plist = plist.Where(x => x.variz == variz.Text);
            }
            if (price.Text != "")
            {
                plist = plist.Where(x => x.mablagh == price.Text);
            }
            if (hesab.Text != "")
            {
                plist = plist.Where(x => x.hesab == hesab.Text);
            }
            lst = plist.ToList();


            DataTable dt = ToDataTable(lst);
            DaryaftiReport daryafti = new DaryaftiReport(dt);
            daryafti.Show();



        }
        public DataTable ToDataTable<T>(List<T> items)

        {

            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)

            {

                //Setting column names as Property names

                dataTable.Columns.Add(prop.Name);

            }

            foreach (T item in items)

            {

                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)

                {

                    //inserting property values to datatable rows

                    values[i] = Props[i].GetValue(item, null);

                }

                dataTable.Rows.Add(values);

            }

            //put a breakpoint here and check datatable

            return dataTable;

        }


    }
}
