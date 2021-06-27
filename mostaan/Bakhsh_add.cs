using mostaan.Classes;
using mostaan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace mostaan
{
    public partial class Bakhsh_add : Form
    {
        public Bakhsh_add()
        {
            InitializeComponent();
            Model.Context dbcontext = new Model.Context();
           
            FontClass fontclass = new FontClass();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
           
            this.MaximizeBox = false;
            this.CenterToScreen();



            radPanel1.PanelElement.Shape = new RoundRectShape();
            radPanel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel1.PanelElement.PanelFill.BackColor = Color.White;


            radPanel2.PanelElement.Shape = new RoundRectShape();
            radPanel2.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel2.PanelElement.PanelFill.BackColor = Color.White;

            radPanel3.PanelElement.Shape = new RoundRectShape();
            radPanel3.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel3.PanelElement.PanelFill.BackColor = Color.White;

            radPanel4.PanelElement.Shape = new RoundRectShape();
            radPanel4.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel4.PanelElement.PanelFill.BackColor = Color.White;

            radPanel5.PanelElement.Shape = new RoundRectShape();
            radPanel5.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel5.PanelElement.PanelFill.BackColor = Color.Gray;

            string bakhshID = GlobalVariable.bakhshID;
            List<Model.markaz> lst = new List<Model.markaz>();
            List<user> userlist = dbcontext.users.ToList();
            List<user> userlist2 = dbcontext.users.ToList();





            List<user> list = dbcontext.users.ToList();
       

            masool.DataSource = userlist;
            masool.DisplayMember = "name";
            masool.ValueMember = "ID";

            janeshin.DataSource = userlist2;
            janeshin.DisplayMember = "name";
            janeshin.ValueMember = "ID";

            
            if (bakhshID != "" )
            {
                bakhsh selectedbakhsh = dbcontext.bakhshes.SingleOrDefault(x => x.ID == bakhshID);

                lst = (from p in dbcontext.markazs where p.BakhshID == selectedbakhsh.parent && p.master == "1" select p).ToList();
                dataGridView1.DataSource = lst;


                Model.bakhsh item = dbcontext.bakhshes.Where(x => x.ID == bakhshID).FirstOrDefault();

                title.Text = item.title;
                masool.SelectedIndex = masool.FindStringExact(selectedbakhsh.masoul);
                janeshin.SelectedIndex = janeshin.FindStringExact(selectedbakhsh.janeshin);
                


            }
            else
            {
                dataGridView1.DataSource = lst;
            }


           
            dataGridView1.Columns["ID"].HeaderText = "ردیف";
            dataGridView1.Columns["ID"].Width = 120;
            dataGridView1.Columns["ID"].DisplayIndex = 1;
            dataGridView1.Columns["title"].HeaderText = "عنوان مرکز";
            dataGridView1.Columns["title"].Width = 216;
            dataGridView1.Columns["title"].DisplayIndex = 2;
            dataGridView1.Columns["title"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            dataGridView1.Columns["masoul"].HeaderText = "مسئول مرکز";
            dataGridView1.Columns["masoul"].Width = 216;
            dataGridView1.Columns["masoul"].DisplayIndex = 3;
            dataGridView1.Columns["masoul"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            dataGridView1.Columns["janeshin"].HeaderText = "جانشین مرکز";
            dataGridView1.Columns["janeshin"].Width = 216;
            dataGridView1.Columns["janeshin"].DisplayIndex = 4;
            dataGridView1.Columns["janeshin"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;



            dataGridView1.Columns["parent"].Visible = false;
            dataGridView1.Columns["final"].Visible = false;
            dataGridView1.Columns["isDone"].Visible = false;
            dataGridView1.Columns["master"].Visible = false;
            dataGridView1.Columns["BakhshID"].Visible = false;
            dataGridView1.Columns["changer"].Visible = false;
            dataGridView1.Columns["date"].Visible = false;
            dataGridView1.Columns["time"].Visible = false;
         

            // dataGridView1.Columns["ID"].Visible = false;







            dataGridView1.Columns[0].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[1].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[2].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[3].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[4].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
           



            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
          

        }

        private void filter_Click(object sender, EventArgs e)
        {
            string bakhshID = GlobalVariable.bakhshID;
            using (var dbcontext = new Model.Context())
            {

                bakhsh bakh = dbcontext.bakhshes.SingleOrDefault(x => x.ID == bakhshID);

                if (bakh.final != 1)
                {
                    string parentID = bakh.parent;
                    bakh.title = title.Text;
                    bakh.masoul = masool.Text;
                    bakh.janeshin =janeshin.Text;
                 

                    List<bakhsh> lst = dbcontext.bakhshes.Where(x => x.parent == parentID).ToList();
                    foreach (bakhsh item in lst)
                    {
                        item.master = "0";
                    };
                    bakh.isDone = true;
                    bakh.master = "1";
                    bakh.final = 1;
                    dbcontext.SaveChanges();
                }
                GlobalVariable.bakhshID = bakh.parent;
            }

            this.Hide();
            Bakhsh_List form5 = new Bakhsh_List();
            form5.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int iSelectedGridIndex = dataGridView1.CurrentCell.ColumnIndex;
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            string rowID = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            if (iSelectedGridIndex == 0)
            {
                using (Context dbcontext = new Context())
                {
                   
                    GlobalVariable.markazID = rowID;
                    Markaz_add form2 = new Markaz_add();
                    form2.Show();
                }




            }
            else if (iSelectedGridIndex == 0)
            {
                GlobalVariable.bakhshID = rowID;
                Bakhsh_add form2 = new Bakhsh_add();
                form2.Show();
            }
            else
            {
                return;
            }
        }
    }
}
