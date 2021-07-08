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
    public partial class checkList : Form
    {
        public checkList(DataTable dt1)
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
                   var lst = (from p in dbcontext.checks
                                             join b in dbcontext.banks on p.bankID equals b.ID
                                             orderby p.ID descending
                                             select new {ID = b.ID, checkNumber = p.checkNumber, banktitle = b.title, isused = p.isUsed, banknumber = b.number }
                                             ).ToList();
                    dataGridView1.DataSource = lst;
                }
            }


            dataGridView1.Columns["ID"].HeaderText = "ردیف";
            dataGridView1.Columns["ID"].Width = 120;
            dataGridView1.Columns["ID"].DisplayIndex = 1;

            dataGridView1.Columns["banktitle"].HeaderText = "نام بانک";
            dataGridView1.Columns["banktitle"].Width = 200;
            dataGridView1.Columns["banktitle"].DisplayIndex = 2;
            dataGridView1.Columns["banktitle"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            dataGridView1.Columns["banknumber"].HeaderText = "شماره حساب";
            dataGridView1.Columns["banknumber"].Width = 200;
            dataGridView1.Columns["banknumber"].DisplayIndex = 2;
            dataGridView1.Columns["banknumber"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;



            dataGridView1.Columns["checkNumber"].HeaderText = "شماره چک";
            dataGridView1.Columns["checkNumber"].Width = 200;
            dataGridView1.Columns["checkNumber"].DisplayIndex = 3;
            dataGridView1.Columns["checkNumber"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            dataGridView1.Columns["isUsed"].HeaderText = "استفاده شده";
            dataGridView1.Columns["checkNumber"].Width = 200;
            dataGridView1.Columns["checkNumber"].DisplayIndex = 3;
            dataGridView1.Columns["checkNumber"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;



            dataGridView1.Columns[0].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[1].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[2].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[3].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[4].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;


        }

        private void newRecord_Click(object sender, EventArgs e)
        {
            checkAdd form = new checkAdd();
            form.Show();
            this.Hide();
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
