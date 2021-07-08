using mostaan.Classes;
using mostaan.Model;
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
    public partial class User_List : Form
    {
        public User_List(DataTable dt1)
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
                    List<Model.user> lst = (from p in dbcontext.users  select p).ToList();
                    dataGridView1.DataSource = lst;
                }
            }


            dataGridView1.Width = 1020;
            dataGridView1.Columns["ID"].HeaderText = "ردیف";
            dataGridView1.Columns["ID"].Width = 120;
            dataGridView1.Columns["ID"].DisplayIndex = 1;

            dataGridView1.Columns["name"].HeaderText = "نام نام خانوادگی";
            dataGridView1.Columns["name"].Width = 200;
            dataGridView1.Columns["name"].DisplayIndex = 2;
            dataGridView1.Columns["name"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;


            dataGridView1.Columns["pasdari_Code"].HeaderText = "کد پاسداری";
            dataGridView1.Columns["pasdari_Code"].Width = 300;
            dataGridView1.Columns["pasdari_Code"].DisplayIndex = 3;
            dataGridView1.Columns["pasdari_Code"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;



            
            dataGridView1.Columns["shomareHesab"].HeaderText = "شماره حساب";
            dataGridView1.Columns["shomareHesab"].Width = 200;
            dataGridView1.Columns["shomareHesab"].DisplayIndex = 4;
            dataGridView1.Columns["shomareHesab"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;



            




            dataGridView1.Columns[0].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[1].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[2].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[3].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[4].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;



            dataGridView1.Columns["meli_Code"].Visible = false;
            dataGridView1.Columns["phone"].Visible = false;
            dataGridView1.Columns["mobile"].Visible = false;
            dataGridView1.Columns["jaygah"].Visible = false;
            dataGridView1.Columns["grade"].Visible = false;
            dataGridView1.Columns["madrak"].Visible = false;
            dataGridView1.Columns["madrak_Title"].Visible = false;
            dataGridView1.Columns["univercity"].Visible = false;
            dataGridView1.Columns["univercity_Score"].Visible = false;
            dataGridView1.Columns["Sepah_Enterdate"].Visible = false;
            dataGridView1.Columns["sazman_Enterdate"].Visible = false;
            dataGridView1.Columns["tahol"].Visible = false;
            dataGridView1.Columns["family_Number"].Visible = false;
            dataGridView1.Columns["maskan"].Visible = false;
            // dataGridView1.Columns["ID"].Visible = false;
            //dataGridView1.Columns["meli_Code"].HeaderText = "شماره ملی";
            //dataGridView1.Columns["meli_Code"].Width = 200;
            //dataGridView1.Columns["meli_Code"].DisplayIndex = 4;
            //dataGridView1.Columns["meli_Code"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;



            //dataGridView1.Columns["phone"].HeaderText = "شماره تلفن داخلی ";
            //dataGridView1.Columns["phone"].Width = 200;
            //dataGridView1.Columns["phone"].DisplayIndex = 5;
            //dataGridView1.Columns["phone"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            //dataGridView1.Columns["mobile"].HeaderText = " شماره همراه";
            //dataGridView1.Columns["mobile"].Width = 200;
            //dataGridView1.Columns["mobile"].DisplayIndex = 6;
            //dataGridView1.Columns["mobile"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            //dataGridView1.Columns["jaygah"].HeaderText = "جایگاه";
            //dataGridView1.Columns["jaygah"].Width = 200;
            //dataGridView1.Columns["jaygah"].DisplayIndex = 7;
            //dataGridView1.Columns["jaygah"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            //dataGridView1.Columns["grade"].HeaderText = "درجه";
            //dataGridView1.Columns["grade"].Width = 200;
            //dataGridView1.Columns["grade"].DisplayIndex = 8;
            //dataGridView1.Columns["grade"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            //dataGridView1.Columns["madrak"].HeaderText = " مدرک تحصیلی ";
            //dataGridView1.Columns["madrak"].Width = 200;
            //dataGridView1.Columns["madrak"].DisplayIndex = 9;
            //dataGridView1.Columns["madrak"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            //dataGridView1.Columns["madrak_Title"].HeaderText = " عنوان مدرک تحصیلی ";
            //dataGridView1.Columns["madrak_Title"].Width = 200;
            //dataGridView1.Columns["madrak_Title"].DisplayIndex = 10;
            //dataGridView1.Columns["madrak_Title"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;



            //dataGridView1.Columns["univercity"].HeaderText = "دانشگاه ";
            //dataGridView1.Columns["univercity"].Width = 200;
            //dataGridView1.Columns["univercity"].DisplayIndex = 11;
            //dataGridView1.Columns["univercity"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            //dataGridView1.Columns["univercity_Score"].HeaderText = "معدل ";
            //dataGridView1.Columns["univercity_Score"].Width = 200;
            //dataGridView1.Columns["univercity_Score"].DisplayIndex = 12;
            //dataGridView1.Columns["univercity_Score"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            //dataGridView1.Columns["Sepah_Enterdate"].HeaderText = "تاریخ ورود به سپاه ";
            //dataGridView1.Columns["Sepah_Enterdate"].Width = 200;
            //dataGridView1.Columns["Sepah_Enterdate"].DisplayIndex = 13;
            //dataGridView1.Columns["Sepah_Enterdate"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            //dataGridView1.Columns["sazman_Enterdate"].HeaderText = "تاریخ ورود به سازمان ";
            //dataGridView1.Columns["sazman_Enterdate"].Width = 200;
            //dataGridView1.Columns["sazman_Enterdate"].DisplayIndex = 14;
            //dataGridView1.Columns["sazman_Enterdate"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            //dataGridView1.Columns["tahol"].HeaderText = "وضعیت تاهل ";
            //dataGridView1.Columns["tahol"].Width = 200;
            //dataGridView1.Columns["tahol"].DisplayIndex = 15;
            //dataGridView1.Columns["tahol"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            //dataGridView1.Columns["family_Number"].HeaderText = "تحت تکلف ";
            //dataGridView1.Columns["family_Number"].Width = 200;
            //dataGridView1.Columns["family_Number"].DisplayIndex = 16;
            //dataGridView1.Columns["family_Number"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            //dataGridView1.Columns["maskan"].HeaderText = "مسکن ";
            //dataGridView1.Columns["maskan"].Width = 200;
            //dataGridView1.Columns["maskan"].DisplayIndex = 17;
            //dataGridView1.Columns["maskan"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;


        }

        private void newRecord_Click(object sender, EventArgs e)
        {
            User_Add form = new User_Add();
            form.Show();
            this.Hide();

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iSelectedGridIndex = dataGridView1.CurrentCell.ColumnIndex;
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int rowID = Int32.Parse(dataGridView1.Rows[rowindex].Cells[1].Value.ToString());
            if (iSelectedGridIndex == 0)
            {
                using  (Context dbcontext = new Context())
                {

                    user user = dbcontext.users.SingleOrDefault(x => x.ID == rowID);
                    dbcontext.users.Remove(user);
                    dbcontext.SaveChanges();

                    List<Model.user> lst = (from p in dbcontext.users select p).ToList();
                    dataGridView1.DataSource = lst;
                    
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
