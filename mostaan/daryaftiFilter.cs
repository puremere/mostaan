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
    public partial class daryaftiFilter : Form
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

        public daryaftiFilter(string type)
        {
            InitializeComponent();
            header.Text = "افزودن اطلاعات پرداختی جدید";
            filterPanel1.PanelElement.Shape = new RoundRectShape();
            filterPanel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            filterPanel1.PanelElement.PanelFill.BackColor = Color.Gray;


            initFont();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            this.MaximizeBox = false;
            this.CenterToScreen();


            List<shenasname> list = context.shenasnames.Where(x => x.master == "1" && x.final==1).ToList();

            project.DataSource = list;
            project.DisplayMember = "title";
            project.ValueMember = "ID";

            project.SelectedItem = null;
            project.SelectedText = "--انتخاب شناسنامه--";

        }

        private void filter_Click(object sender, EventArgs e)
        {
            DateTime trkFrom = dateFrom.GetSelectedDateInPersianDateTime().ToShortDateString().ToGeorgianDateTime();
            DateTime trkTo = dateTo.GetSelectedDateInPersianDateTime().ToShortDateString().ToGeorgianDateTime();
            Int64 prcFrom = Int64.Parse(priceFrom.Text);
            Int64 prcTo = Int64.Parse(priceTo.Text);

            List<Model.archive> lst = new List<archive>();
            var plist = (from p in context.Archives select p);
            string prj = "";
            if (project.SelectedValue != null)
            {
                prj = project.SelectedValue.ToString();
            }
            List<archive> lst2 = plist.ToList();
            if (project.SelectedItem != null)
            {
                plist = plist.Where(x => x.project == prj);
            }

           
            if (markaz.Text != "")
            {
                plist = plist.Where(x => x.markaz == markaz.Text);
            }
            if (shomareSanad.Text != "")
            {
                plist = plist.Where(x => x.shomareSanad == shomareSanad.Text);
            }

            if (moneytype.Text != "")
            {
                plist = plist.Where(x => x.type == moneytype.Text);
            }
            if (true)
            {
                plist = plist.Where(x => x.hesab == "1");
                plist = plist.Where(x => x.tarikh >= trkFrom && x.tarikh <= trkTo);
                plist = plist.Where(x => x.mablagh >= prcFrom && x.mablagh <= prcTo);
            }
            lst = plist.ToList();


            DataTable dt = ToDataTable(lst);
            daryaftiReport daryafti = new daryaftiReport(dt);
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
