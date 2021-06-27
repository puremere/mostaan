using mostaan.Classes;
using mostaan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace mostaan
{
    

    public partial class pardakhtiNew : Form
    {
        Context context = new Context();

        FontClass fontclass = new FontClass();
        //databaseManager manager = new databaseManager();
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
           IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();
        private static string choosenType = "";
        private static string choosenSubject = "";
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

            List<Model.bank> bnks = context.banks.ToList() ;
            bank.DataSource = bnks;
            bank.DisplayMember = "FullName";
            bank.ValueMember = "ID";

        }
        public pardakhtiNew(string type)
        {
          
            InitializeComponent();
            referbish.Text = type;
           
           


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
            
            
            var tamintxt = tamin.Text;
            if (tamintxt == "")
            {
                header.Text = "تامین  انتخاب نشده است";
                header.ForeColor = Color.Red;
                return;
            }

            tamin model = context.tamins.SingleOrDefault(x => x.shomareSanad == tamintxt);
            if (model == null)
            {
                header.Text = "شماره تامین وجود ندارد";
                header.ForeColor = Color.Red;
                return;
            }

            Context dbcontext = new Context();
            string sanad = shomareSanad1.Text;
            Int64 mbl = model.mablagh;

            string shenasnameTitle = model.shnesnameTitle;
            archive pastmodel = dbcontext.Archives.SingleOrDefault(x => x.shomareTamin == tamintxt);

            if (pastmodel == null)
            {
                header.Text = "برای پارامتر های موجود فاکتور انتخاب شده است";
                header.ForeColor = Color.Red;
                return;
            }




            functions fns = new functions();
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);


            string mrk = "";
            mrk = (from sh in dbcontext.shenasnames
                   join ma in dbcontext.markazs on sh.markaz equals ma.parent
                   where sh.title == shenasnameTitle
                   select ma).First().title;


            string root = Path.Combine(directory, "FIM");
            System.IO.Directory.CreateDirectory(root);
            string markazPath = Path.Combine(root, mrk);
            System.IO.Directory.CreateDirectory(markazPath);
            string shenasnamePath = Path.Combine(markazPath, shenasnameTitle);
            System.IO.Directory.CreateDirectory(shenasnamePath);
            string pardPath = Path.Combine(shenasnamePath, "فاکتور های پرداختی");
            System.IO.Directory.CreateDirectory(pardPath);


            
            string sourcAddress = sourceLable.Text;
            string trkh = date.GetSelectedDateInPersianDateTime().ToShortDateString().Replace("/", "");
            string finalPrice = "";



            float intprice = model.mablagh;
            if (intprice / 1000000 > 1)
            {
                finalPrice = (intprice / 1000000) + "MT";
            }
            else
            {
                finalPrice = (intprice / 1000) + "HT";
            }
            string finalname = "";
            if (bank.Text == "")
            {
                finalname = "تامینی" + "_" + shomareSanad1.Text + Path.GetExtension(sourcAddress);
            }
            else
            {
                string sv = checkNumber.SelectedValue.ToString();
                finalname = "check" + "_" + bank.Text + "_" + sv + Path.GetExtension(sourcAddress);

            }

            imageName.Text = Path.Combine(pardPath, finalname).Replace(directory, "");
            string finalPath = pardPath + "\\" + finalname;

            


            if (pastmodel == null)
            {
                header.Text = "برای پارامتر های موجود فاکتور انتخاب شده است";
                header.ForeColor = Color.Red;
                return;
            }
          
           

           

            
            bool isreferbish = referbish.Text == "0" ? false : true;
           
            DateTime trk = date.GetSelectedDateInPersianDateTime().ToShortDateString().ToGeorgianDateTime();
           
            archive newITem = new archive() {

                radif ="",
                mablagh =0,
                markaz = "",
                project = "",
                shnesnameTitle = "",
                radifTitle = "",
                shomareSanad = sanad,
                shomareTamin = tamintxt,
                subject = "",
                tarikh = trk,
                type = "",
                hesab = "0",
                imageName = imageName.Text,
                bankName = bank.Text,
                checkNumber = checkNumber.Text,
                referbish = isreferbish

            };

            check checkitem = context.checks.SingleOrDefault(x => x.checkNumber == checkNumber.Text);
            checkitem.isUsed = true;

            context.Archives.Add(newITem);
            context.SaveChanges();

            System.IO.File.Move(sourcAddress, finalPath);
            DataTable dt = new DataTable();
            PardakhtiReport daryaftirp = new PardakhtiReport(dt);
            daryaftirp.Show();
            this.Hide();
            



        }

        private void uploadImage_Click(object sender, EventArgs e)
        {
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string root = Path.Combine(directory, "FIM");
            System.IO.Directory.CreateDirectory(root);
            string trashPath = Path.Combine(root, "trash");
            System.IO.Directory.CreateDirectory(trashPath);

            OpenFileDialog f = new OpenFileDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                string source = Path.GetFullPath(f.FileName);
                sourceLable.Text = source;


                string finalname = "";
                Random _random = new Random();
                string random = _random.Next(10000, 99999).ToString();
                string sourcAddress = source;
                finalname = random + Path.GetExtension(sourcAddress);
                string finalPath = trashPath + "\\" + finalname;

                File.Copy(f.FileName, finalPath);
                sourceLable.Text = source;
                webBrowser1.Navigate(finalPath);
                //factorPdf factor = new factorPdf(source);
                //factor.Show();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var id = tamin.Text;
            try
            {
                Model.tamin tmodel = context.tamins.SingleOrDefault(x => x.shomareSanad == id);
                if (tmodel != null) { gheymat.Text = tmodel.mablagh.ToString(); }
                tamincheck model = new tamincheck(id);
                model.Show();
            }
            catch (Exception)
            {
                header.Text = "شماره سند مورد نظر یافت نشد";
                header.ForeColor = Color.Red;
            }
           

        }

       

        private void bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int item = int.Parse(bank.SelectedValue.ToString());
                List<check> list0 = context.checks.ToList();
                List<check> list = context.checks.Where(x => x.bankID == item && x.isUsed == false).ToList();
                checkNumber.DataSource = list;
                checkNumber.DisplayMember = "checkNumber";
                checkNumber.ValueMember = "ID";

            }
            catch (Exception)
            {


            }
        }

        private void shomareSanad1_Leave(object sender, EventArgs e)
        {
            var number = shomareSanad1.Text;
            using (Context dbcontext = new Context())
            {
                archive model = dbcontext.Archives.FirstOrDefault(x => x.shomareSanad == number);
                if (model != null)
                {
                    header.Text = "این شماره قبلا ثبت شده است";
                    header.ForeColor = Color.Red;
                }
            }
        }

        private void shomareSanad1_Enter(object sender, EventArgs e)
        {
            header.Text = "فاکتور پرداختی";
            header.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Context dbcontext = new Context())
            {
                List<Model.tamin> lst = dbcontext.tamins.Where(c => !dbcontext.Archives.Select(b => b.shomareTamin).Contains(c.shomareSanad)).ToList();
                tamin_Report tr = new tamin_Report(ToDataTable(lst));
                tr.Show();
            }

           
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
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

        private void bankType_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Context dbcontext = new Context())
            {
                string bankValue = bankType.SelectedItem.ToString();
                if (bankValue == "منابع غیر تولید")
                {
                    List<bank> lst = dbcontext.banks.Where(x => x.type == "منابع غیر تولید").ToList();
                    bank.DataSource = lst;

                }
                else
                {
                    List<bank> lst = dbcontext.banks.Where(x => x.type != "منابع غیر تولید").ToList();
                    bank.DataSource = lst;
                }


               
            }
               
        }
    }
}
