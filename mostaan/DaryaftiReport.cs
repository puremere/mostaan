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
using mostaan.Model;
using System.IO;

namespace mostaan
{
    public partial class daryaftiReport : Form
    {

        public daryaftiReport(DataTable dt1)
        {
            
            
            InitializeComponent();
            FontClass fontclass = new FontClass();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            this.MaximizeBox = false;
            this.CenterToScreen();


            if (dt1.Columns.Count != 0)
            {
                dataGridView1.DataSource = dt1;
            }
            else
            {
                using (Context dbcontext = new Context())
                {
                    List<Model.archive> lst = (from p in dbcontext.Archives where p.hesab == "1" select p).OrderBy(x=>x.ID).ToList();
                    dataGridView1.DataSource = lst;
                }
            }


            dataGridView1.Width = 1020;
            dataGridView1.Columns["ID"].HeaderText = "ردیف";
            dataGridView1.Columns["ID"].Width = 120;
            dataGridView1.Columns["ID"].DisplayIndex = 3;

            dataGridView1.Columns["referbish"].HeaderText = "اصلاحیه";
            dataGridView1.Columns["referbish"].Width = 200;
            dataGridView1.Columns["referbish"].DisplayIndex = 9;
            dataGridView1.Columns["referbish"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            dataGridView1.Columns["shomareSanad"].HeaderText = "شماره سند";
            dataGridView1.Columns["shomareSanad"].Width = 200;
            dataGridView1.Columns["shomareSanad"].DisplayIndex = 4;
            dataGridView1.Columns["shomareSanad"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;


            dataGridView1.Columns["shnesnameTitle"].HeaderText = "عنوان شناسنامه";
            dataGridView1.Columns["shnesnameTitle"].Width = 300;
            dataGridView1.Columns["shnesnameTitle"].DisplayIndex = 5;
            dataGridView1.Columns["shnesnameTitle"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            dataGridView1.Columns["subject"].HeaderText = "عنوان";
            dataGridView1.Columns["subject"].Width = 300;
            dataGridView1.Columns["subject"].DisplayIndex = 6;
            dataGridView1.Columns["subject"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;





            dataGridView1.Columns["type"].HeaderText = "واحد پولی";
            dataGridView1.Columns["type"].Width = 200;
            dataGridView1.Columns["type"].DisplayIndex = 7;
            dataGridView1.Columns["type"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;



            dataGridView1.Columns["mablagh"].HeaderText = "مبلغ ";
            dataGridView1.Columns["mablagh"].Width = 200;
            dataGridView1.Columns["mablagh"].DisplayIndex = 8;
            dataGridView1.Columns["mablagh"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            dataGridView1.Columns["checkNumber"].HeaderText = "شماره چک ";
            dataGridView1.Columns["checkNumber"].Width = 200;
            dataGridView1.Columns["checkNumber"].DisplayIndex = 9;
            dataGridView1.Columns["checkNumber"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            dataGridView1.Columns["bankName"].HeaderText = "بانک عامل ";
            dataGridView1.Columns["bankName"].Width = 200;
            dataGridView1.Columns["bankName"].DisplayIndex = 10;
            dataGridView1.Columns["bankName"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;


            dataGridView1.Columns["imageName"].Visible = false;
            dataGridView1.Columns["rank"].Visible = false;
            dataGridView1.Columns["markaz"].Visible = false;
            dataGridView1.Columns["tarikh"].Visible = false;
            dataGridView1.Columns["variz"].Visible = false;
            dataGridView1.Columns["hesab"].Visible = false;
            dataGridView1.Columns["radif"].Visible = false;
         
            dataGridView1.Columns["radifTitle"].Visible = false;
            dataGridView1.Columns["project"].Visible = false;


        }
        private void newRecord_Click(object sender, EventArgs e)
        {
            daryaftiNew form = new daryaftiNew();
            form.Show();
            this.Hide();

        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var dbcontext = new Model.Context())
            {
                int iSelectedGridIndex = dataGridView1.CurrentCell.ColumnIndex;
                if (iSelectedGridIndex != 0)
                    return;
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                int rowID = Int32.Parse(dataGridView1.Rows[rowindex].Cells[2].Value.ToString());

                Model.archive model = dbcontext.Archives.SingleOrDefault(x => x.ID == rowID);
               
                dbcontext.Entry(model).State = EntityState.Deleted;
                dbcontext.SaveChanges();
              


                List<Model.archive> lst = (from p in dbcontext.Archives
                                           where p.hesab == "1"
                                           select p).ToList();
                dataGridView1.DataSource = lst;
                string imageName = model.imageName;
                var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);


                System.IO.File.Delete(directory + imageName);

            }
        }

        private void filter_Click(object sender, EventArgs e)
        {
            daryaftiFilter form = new daryaftiFilter("1");
            form.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var dbcontext = new Model.Context())
            {
                int iSelectedGridIndex = dataGridView1.CurrentCell.ColumnIndex;
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                int rowID = Int32.Parse(dataGridView1.Rows[rowindex].Cells[1].Value.ToString());
                Model.archive model = dbcontext.Archives.SingleOrDefault(x => x.ID == rowID);
                string imageName = "";
                imageName = model.imageName;

                if (imageName != "")
                {
                    try
                    {
                        var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                        if (Path.GetExtension(imageName) == ".pdf")
                        {
                            try
                            {
                                factorPdf factore = new factorPdf(directory + imageName);
                                factore.Show();
                            }
                            catch (Exception error)
                            {
                                label1.Text = error.InnerException.Message;
                            }
                        }
                        else
                        {
                            factorImage factor = new factorImage(directory + imageName);
                            factor.Show();
                        }


                    }
                    catch (Exception error)
                    {


                    }


                }


            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            zero form = new zero();
            form.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            zero form = new zero();
            form.Show();
            this.Hide();
        }
    }
}
