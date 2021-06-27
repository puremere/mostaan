using mostaan.Classes;
using mostaan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mostaan
{
    public partial class daryaftiNew : Form
    {
        public daryaftiNew()
        {
            InitializeComponent();
            try
            {
                FontClass fontclass = new FontClass();
                List<Control> allControls = fontclass.GetAllControls(this);
                allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
                this.MaximizeBox = true;
                this.CenterToScreen();
                


                using (Context dbcontext = new Context())
                {
                    List<shenasname> list = dbcontext.shenasnames.Where(x => x.master == "1" && x.final == 1).ToList();
                    project.DataSource = list;
                    project.DisplayMember = "title";
                    project.ValueMember = "ID";

                    List<Model.bank> bnks = dbcontext.banks.ToList();
                    bank.DataSource = bnks;
                    bank.DisplayMember = "FullName";
                    bank.ValueMember = "ID";
                }


            }
            catch (Exception)
            {


            }



        }

        private void filter_Click(object sender, EventArgs e)
        {
            string sourcAddress = sourceLable.Text;
          
            int index = 0;
            int indeximage = 0;
            bool factorimage = false;
            int indexpdf = 0;
            bool factorpdf = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "factorPdf")
                {
                    factorpdf = true;
                    indexpdf = index;
                    break;
                }
                if (form.Name == "factorImage")
                {
                    factorimage = true;
                    indeximage = index;
                    break;
                }
                index += 1;
            }
            if (factorimage == true)
            {
                Application.OpenForms[indeximage].Close();
            }
            if (factorpdf == true)
            {
                Application.OpenForms[indexpdf].Close();
            }

            Context dbcontext = new Context();
            string sanad = shomareSanad1.Text;

            string prj = project.SelectedValue.ToString();
            var shenasname = dbcontext.shenasnames.SingleOrDefault(x => x.ID == prj);
            string shenasnameID = shenasname.ID;
            string shenasnameTitle = shenasname.title;

            var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);


            string mrk = "";
            var mrkobject = (from sh in dbcontext.shenasnames
                             join ma in dbcontext.markazs on sh.markaz equals ma.parent
                             where sh.title == shenasnameTitle
                             select ma);
            if (mrkobject != null)
            {
                mrk = mrkobject.First().title;
            }




            string root = Path.Combine(directory, "FIM");
            System.IO.Directory.CreateDirectory(root);
            string markazPath = Path.Combine(root, mrk);
            System.IO.Directory.CreateDirectory(markazPath);
            string shenasnamePath = Path.Combine(markazPath, shenasnameTitle);
            System.IO.Directory.CreateDirectory(shenasnamePath);
            string pardPath = Path.Combine(shenasnamePath, "فاکتور های دریافتی");
            System.IO.Directory.CreateDirectory(pardPath);


            string trkh = date.GetSelectedDateInPersianDateTime().ToShortDateString().Replace("/", "");
            string finalPrice = "";
            if (shomareSanad1.Text == "")
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
            if (bank.Text == "")
            {
                finalname = "تامینی" + "_" + shomareSanad1.Text + Path.GetExtension(sourcAddress);
            }
            else
            {
                finalname = trkh + "_" + finalPrice + "_" + bank.Text + Path.GetExtension(sourcAddress);

            }

            imageName.Text = Path.Combine(pardPath, finalname).Replace(directory, "");
            string finalPath = pardPath + "\\" + finalname;

            webBrowser1.Navigate("http://localhost/.");
           







            archive pastmodel = dbcontext.Archives.SingleOrDefault(x => x.hesab == "1" && x.shomareSanad == sanad && x.shnesnameTitle == shenasnameTitle && referbish.Text == "0" && x.type == moneytype.Text);

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

            DateTime trk = date.GetSelectedDateInPersianDateTime().ToShortDateString().ToGeorgianDateTime();
            string typ = moneytype.SelectedItem.ToString();


            bool isreferbish = referbish.Text == "0" ? false : true;
            long mbl = (long)intprice;
            archive newITem = new archive()
            {


                mablagh = mbl,
                markaz = "",
                project = shenasnameID,
                shnesnameTitle = shenasnameTitle,
                shomareSanad = sanad,
                tarikh = trk,
                type = typ,
                hesab = "1",
                imageName = imageName.Text,
                bankName = bank.Text,
                checkNumber = sanadType.Text,
                referbish = isreferbish,
                subject = subject.Text


            };
            dbcontext.Archives.Add(newITem);
            dbcontext.SaveChanges();
            


            DataTable dt = new DataTable();
            daryaftiReport daryaftirp = new daryaftiReport(dt);
            daryaftirp.Show();
            this.Close();

            System.IO.File.Move(sourcAddress, finalPath);
            
        }

        private void uploadImage_Click(object sender, EventArgs e)
        {

            var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string root = Path.Combine(directory, "FIM");
            System.IO.Directory.CreateDirectory(root);
            string trashPath = Path.Combine(root, "trash");
            System.IO.Directory.CreateDirectory(trashPath);
            OpenFileDialog f = new OpenFileDialog();
            // f.Filter = "Image files (*.jpg, *.png *.pdf) | *.jpg; *.png *.pdf";

            if (f.ShowDialog() == DialogResult.OK)
            {
                string source = Path.GetFullPath(f.FileName);
                string finalname = "";
                Random _random = new Random();
                string random = _random.Next(10000, 99999).ToString();
                string sourcAddress = source;
                finalname = random + Path.GetExtension(sourcAddress);
                string finalPath = trashPath + "\\" + finalname;

                File.Copy(f.FileName, finalPath);
                sourceLable.Text = source;

                webBrowser1.Navigate(finalPath);

            }
        }

        private void tableLayoutPanel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void shomareSanad1_Enter(object sender, EventArgs e)
        {
            header.Text = "فاکتور پرداختی";
            header.ForeColor = Color.Black;

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
    }
}
