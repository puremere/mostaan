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
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace mostaan
{
    public partial class tamin_New : Form
    {
        Model.Context context = new Model.Context();

        FontClass fontclass = new FontClass();
        //databaseManager manager = new databaseManager();
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
           IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();
        private static string choosenType = "";
        private static string choosenSubject = "";
        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
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
        public tamin_New(string type)
        {

            InitializeComponent();
            referbish.Text = type;
            List<shenasname> list = context.shenasnames.Where(x => x.master == "1" && x.final == 1).ToList();
            project.DataSource = list;
            project.DisplayMember = "title";
            project.ValueMember = "ID";



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

            var number = shomareSanad.Text;
            using (Model.Context dbcontext = new Model.Context())
            {
                tamin model = dbcontext.tamins.FirstOrDefault(x => x.shomareSanad == number);
                if (model != null)
                {
                    header.Text = "این شماره قبلا ثبت شده است";
                    return;
                }
            }



            if (radif.SelectedValue == null && subject.SelectedItem.ToString() != "سایر هزینه ها")
            {
                header.Text = "ردیف انتخاب نشده است";
                header.ForeColor = Color.Red;
                return;
            }

            header.Text = "1";
            string sanad = shomareSanad.Text;
            Int64 mbl = Int64.Parse(price.Text);
            string prj = project.SelectedValue.ToString();
            var shenasname = context.shenasnames.SingleOrDefault(x => x.ID == prj);
            string shenasnameID = shenasname.ID;
            string shenasnameTitle = shenasname.title;
            string rd = subject.SelectedText != "مواد اولیه" ? "" : radif.SelectedValue.ToString();
            header.Text = "2";
            archive pastmodel = context.Archives.SingleOrDefault(x => x.hesab == "0" && x.shomareSanad == sanad && x.mablagh == mbl && x.shnesnameTitle == shenasnameTitle && x.radif == rd);

            if (pastmodel != null)
            {
                header.Text = "برای پارامتر های موجود فاکتور انتخاب شده است";
                header.ForeColor = Color.Red;
                return;
            }




            functions fns = new functions();
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);


            string mrk = "";
            mrk = (from sh in context.shenasnames
                   join ma in context.markazs on sh.markaz equals ma.parent
                   where sh.title == shenasnameTitle
                   select ma).First().title;


            header.Text = "3";
            string root = Path.Combine(directory, "FIM");
            System.IO.Directory.CreateDirectory(root);
            string taminPath = Path.Combine(root, "tamin");
            System.IO.Directory.CreateDirectory(taminPath);

            
            string trkh = date.GetSelectedDateInPersianDateTime().ToShortDateString().Replace("/", "");
            string finalPrice = "";

            if (shomareSanad.Text == "")
            {
                header.Text = "شماره سند را وارد نمایید";
                header.ForeColor = Color.Red;
                return;
            }
            if (price.Text == "")
            {
                header.Text = "مبلغ را وارد نمایید";
                header.ForeColor = Color.Red;
                return;
            }

            float intprice = float.Parse(price.Text);
            if (intprice / 1000000 > 1)
            {
                finalPrice = (intprice / 1000000) + "MT";
            }
            else
            {
                finalPrice = (intprice / 1000) + "HT";
            }
           
            string finalname = "";
            string random = RandomNumber(10000, 99999).ToString();
            string sourcAddress = sourceLable.Text;
           
            finalname = random + Path.GetExtension(sourcAddress);

            imageName.Text = Path.Combine(taminPath, finalname).Replace(directory, "");
            string finalPath = taminPath + "\\" + finalname;
            
           
            //try
            //{
            //    System.IO.File.Delete(sourcAddress);
            //}
            //catch (IOException error)
            //{

            //}

            if (moneytype.SelectedItem == null)
            {
                header.Text = "واحد پولی را انتخاب کنید";
                header.ForeColor = Color.Red;
                return;
            }

            if (pastmodel != null)
            {
                header.Text = "برای پارامتر های موجود فاکتور انتخاب شده است";
                header.ForeColor = Color.Red;
                return;
            }



            //string rd = "";
            string rdTitle = "";
            string choosenSubject = subject.Text;
            if (radif.SelectedValue != null)
            {
                rd = radif.SelectedValue.ToString();
                int intrd = Int32.Parse(rd);

                switch (choosenSubject)
                {

                    case "اجراییات":
                        rdTitle = context.ejraeiats.SingleOrDefault(x => x.ID == intrd).title;
                        break;
                    case "سرمایه":
                        rdTitle = context.sarmayes.SingleOrDefault(x => x.ID == intrd).title;
                        break;
                    case "قرارداد":
                        rdTitle = context.gharardads.SingleOrDefault(x => x.ID == intrd).title;
                        break;
                    case "عمرانی":
                        rdTitle = context.omranis.SingleOrDefault(x => x.ID == intrd).title;
                        break;
                    case "اداری":
                        rdTitle = context.edaris.SingleOrDefault(x => x.ID == intrd).title;
                        break;
                    case "مصرفی":
                        rdTitle = context.masrafis.SingleOrDefault(x => x.ID == intrd).title;
                        break;
                    case "مواد":
                        rdTitle = context.sayers.SingleOrDefault(x => x.ID == intrd).title;
                        break;
                    case "تشویقی":
                        rdTitle = context.tashvighis.SingleOrDefault(x => x.ID == intrd).title;
                        break;
                }
            }




            bool isreferbish = referbish.Text == "0" ? false : true;
            string sbj = choosenSubject;
            DateTime trk = date.GetSelectedDateInPersianDateTime().ToShortDateString().ToGeorgianDateTime();
            string typ = moneytype.SelectedItem.ToString();
            tamin newITem = new tamin()
            {

                radif = rd,
                mablagh = mbl,
                markaz = "",
                project = shenasnameID,
                shnesnameTitle = shenasnameTitle,
                radifTitle = rdTitle,
                shomareSanad = sanad,
                subject = sbj,
                tarikh = trk,
                type = typ,
                hesab = "0",
                imageName = imageName.Text,
                //bankName = bank.Text,
                //checkNumber = checkNumber.Text,
                //referbish = isreferbish

            };
            context.tamins.Add(newITem);
            context.SaveChanges();
            webBrowser1.Navigate("http://localhost/");
           


            DataTable dt = new DataTable();
            tamin_Report taminform = new tamin_Report(dt);
            taminform.Show();
            this.Close();
            File.Move(sourcAddress, finalPath);
            try
            {
                File.Delete(sourcAddress);
            }
            catch (IOException error)
            {

            }




        }

        private void subject_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox combo = sender as ComboBox;
            string value = combo.SelectedItem.ToString();
            string shenasname = project.SelectedValue.ToString();


            switch (value)
            {
                case "اجراییات":

                    List<ejraeiat> ejraeeatlist = context.ejraeiats.Where(x => x.shenasnameID == shenasname).ToList();
                    radif.DataSource = ejraeeatlist;
                    radif.DisplayMember = "title";
                    radif.ValueMember = "ID";


                    break;
                case "سرمایه":
                    List<sarmaye> sarmayelist = context.sarmayes.Where(x => x.shenasnameID == shenasname).ToList();
                    radif.DataSource = sarmayelist;
                    radif.DisplayMember = "title";
                    radif.ValueMember = "ID";
                    break;
                case "قرارداد":
                    List<gharardad> ghararlist = context.gharardads.Where(x => x.shenasnameID == shenasname).ToList();
                    radif.DataSource = ghararlist;
                    radif.DisplayMember = "title";
                    radif.ValueMember = "ID";
                    break;
                case "عمرانی":
                    List<omrani> omranilist = context.omranis.Where(x => x.shenasnameID == shenasname).ToList();
                    radif.DataSource = omranilist;
                    radif.DisplayMember = "title";
                    radif.ValueMember = "ID";
                    break;
                case "اداری":
                    List<edari> edarilist = context.edaris.Where(x => x.shenasnameID == shenasname).ToList();
                    radif.DataSource = edarilist;
                    radif.DisplayMember = "title";
                    radif.ValueMember = "ID";
                    break;
                case "مصرفی":
                    List<masrafi> masrafilist = context.masrafis.Where(x => x.shenasnameID == shenasname).ToList();
                    radif.DataSource = masrafilist;
                    radif.DisplayMember = "title";
                    radif.ValueMember = "ID";
                    break;
                case "مواد اولیه":
                    List<sayer> sayerlist = context.sayers.Where(x => x.shenasnameID == shenasname).ToList();
                    radif.DataSource = sayerlist;
                    radif.DisplayMember = "title";
                    radif.ValueMember = "ID";
                    break;
                case "تشویقی":
                    List<tashvighi> tashvighlist = context.tashvighis.Where(x => x.shenasnameID == shenasname).ToList();
                    radif.DataSource = tashvighlist;
                    radif.DisplayMember = "title";
                    radif.ValueMember = "ID";
                    break;
                case "سایر هزینه ها":
                    radif.Text = "";
                    break;
            }




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
                string finalname = "";
                string random = RandomNumber(10000, 99999).ToString();
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

        private void shomareSanad_Leave(object sender, EventArgs e)
        {
            var number = shomareSanad.Text;
            using (Model.Context dbcontext = new Model.Context())
            {
                tamin model = dbcontext.tamins.FirstOrDefault(x => x.shomareSanad == number);
                if (model != null)
                {
                    header.Text = "این شماره قبلا ثبت شده است";
                    header.ForeColor = Color.Red;
                }
            }
        }

        private void shomareSanad_Enter(object sender, EventArgs e)
        {
            header.Text = "فاکتور پرداختی";
            header.ForeColor = Color.Black;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            zero form = new zero();
            form.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            tamin_Report form = new tamin_Report(dt);
            form.Show();
            this.Hide();
        }
    }
}
