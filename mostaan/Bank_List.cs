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
    public partial class Bank_List : Form
    {
        public Bank_List(DataTable dt1)
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
                    List<Model.bank> lst = (from p in dbcontext.banks select p).ToList();
                    dataGridView1.DataSource = lst;
                }
            }


            dataGridView1.Width = 550;
            dataGridView1.Columns["ID"].HeaderText = "ردیف";
            dataGridView1.Columns["ID"].Width = 120;
            dataGridView1.Columns["ID"].DisplayIndex = 1;

            dataGridView1.Columns["title"].HeaderText = "نام بانک";
            dataGridView1.Columns["title"].Width = 200;
            dataGridView1.Columns["title"].DisplayIndex = 2;
            dataGridView1.Columns["title"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;



            dataGridView1.Columns["number"].HeaderText = "شماره حساب";
            dataGridView1.Columns["number"].Width = 200;
            dataGridView1.Columns["number"].DisplayIndex = 3;
            dataGridView1.Columns["number"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            dataGridView1.Columns["type"].HeaderText = "نوع حساب";
            dataGridView1.Columns["type"].Width = 200;
            dataGridView1.Columns["type"].DisplayIndex = 3;
            dataGridView1.Columns["type"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;


            dataGridView1.Columns["fullname"].Visible = false;

            dataGridView1.Columns[0].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[1].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[2].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[3].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            
        }

        private void newRecord_Click(object sender, EventArgs e)
        {
            Bank_Add form = new Bank_Add();
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
                using (Context dbcontext = new Context())
                {

                    bank bank = dbcontext.banks.SingleOrDefault(x => x.ID == rowID);
                    dbcontext.banks.Remove(bank);
                    dbcontext.SaveChanges();

                    List<Model.bank> lst = (from p in dbcontext.banks select p).ToList();
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
