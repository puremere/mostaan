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
    public partial class projectFiles : Form
    {
        public projectFiles()
        {
            InitializeComponent();
            FontClass fontclass = new FontClass();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            this.MaximizeBox = false;
            this.CenterToScreen();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            string itemname = itemList.SelectedItem.ToString();
            if (itemname == "")
            {
                return;
            }
            string shenasnameID = GlobalVariable.shenasnameID;

            using (var dbcontext = new Model.Context())
            {
                shenasname shen = dbcontext.shenasnames.SingleOrDefault(x => x.ID == shenasnameID);


                if (shen.final != 1)
                {
                    var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    string root = Path.Combine(directory, "FIM");
                    System.IO.Directory.CreateDirectory(root);
                    string trashPath = Path.Combine(root, "asset");
                    System.IO.Directory.CreateDirectory(trashPath);

                    OpenFileDialog f = new OpenFileDialog();
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
                        webBrowser1.Navigate(finalPath);



                        switch (itemname)
                        {
                            case "بایگانی موارد":
                                shen.bayganiFile = finalname;
                                break;
                            case "قرارداد":
                                shen.gharardadFile = finalname;
                                break;
                            case "متمم":
                                shen.motamamFile = finalname;
                                break;
                            case "پیوست متنی":
                                shen.peyvastFile = finalname;
                                break;
                            case "لیست مواد":
                                shen.listmavadFile = finalname;
                                break;
                            case "گانت چارت":
                                shen.gantFile = finalname;
                                break;
                            case "مجوز ستاد کل":
                                shen.mojavezFile = finalname;
                                break;
                            case "گزارش پیشرفت":
                                shen.pishraftFile = finalname;
                                break;
                        }
                        dbcontext.SaveChanges();

                        //factorPdf factor = new factorPdf(source);
                        //factor.Show();


                    }
                }


                
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

            string itemname = itemList.SelectedItem.ToString();
            if (itemname == "")
            {
                return;
            }
            using (Context dbcontext = new Context())
            {
                string shenasnameID = GlobalVariable.shenasnameID;
                shenasname model = dbcontext.shenasnames.SingleOrDefault(x => x.ID == shenasnameID);
                string finalname = "";
                switch (itemname)
                {
                    case "بایگانی موارد":
                        finalname = model.bayganiFile;
                        break;
                    case "قرارداد":
                        finalname = model.gharardadFile;
                        break;
                    case "متمم":
                        finalname = model.motamamFile;
                        break;
                    case "پیوست متنی":
                        finalname = model.peyvastFile;
                        break;
                    case "لیست مواد":
                        finalname = model.listmavadFile;
                        break;
                    case "گانت چارت":
                        finalname = model.gantFile;
                        break;
                    case "مجوز ستاد کل":
                        finalname = model.mojavezFile;
                        break;
                    case "گزارش پیشرفت":
                        finalname = model.pishraftFile;
                        break;
                }
                string imageName = finalname;
                if (imageName != null)
                {
                    var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    string root = Path.Combine(directory, "FIM");
                    System.IO.Directory.CreateDirectory(root);
                    string trashPath = Path.Combine(root, "asset");
                    System.IO.Directory.CreateDirectory(trashPath);

                    string finalPath = trashPath + "\\" + finalname;
                    try
                    {

                        webBrowser1.Navigate(finalPath);


                    }
                    catch (Exception error)
                    {

                        label1.Text = "0000-" + error.InnerException.Message;
                    }


                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            string shenasnameID = GlobalVariable.shenasnameID;
            using (var dbcontext = new Model.Context())
            {

                shenasname shen = dbcontext.shenasnames.SingleOrDefault(x => x.ID == shenasnameID);

                if (shen.final != 1)
                {
                    string parentID = shen.parent;

                    List<shenasname> shenList = dbcontext.shenasnames.Where(x => x.parent == parentID).ToList();
                    foreach (shenasname item in shenList)
                    {
                        item.master = "0";
                    };
                    shen.isDone = true;
                    shen.master = "1";
                    shen.final = 1;

                    dbcontext.SaveChanges();
                }

                this.Hide();
                Form5_shenasnameList form5 = new Form5_shenasnameList();
                form5.Show();
            }
        }
    }
}
