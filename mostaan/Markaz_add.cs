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
    public partial class Markaz_add : Form
    {
      

        public Markaz_add()
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

            string markazID = GlobalVariable.markazID;
            List<Model.komite> lst = new List<Model.komite>();
            List<user> userlist = dbcontext.users.ToList();
            List<user> userlist2 = dbcontext.users.ToList();





            List<user> list = dbcontext.users.ToList();


            masool.DataSource = userlist;
            masool.DisplayMember = "name";
            masool.ValueMember = "ID";

            janeshin.DataSource = userlist2;
            janeshin.DisplayMember = "name";
            janeshin.ValueMember = "ID";


            List<bakhsh> bakhshlist = dbcontext.bakhshes.Where(x=>x.master == "1").ToList();
            bakhsh.DataSource = bakhshlist;
            bakhsh.DisplayMember = "title";
            bakhsh.ValueMember = "parent";
            

            if (markazID != "" && markazID != null)
            {
                markaz selectedbakhsh = dbcontext.markazs.SingleOrDefault(x => x.ID == markazID);

                lst = (from p in dbcontext.komites where p.markazID == selectedbakhsh.parent && p.master == "1" select p).ToList();
                dataGridView1.DataSource = lst;


                Model.markaz item = dbcontext.markazs.Where(x => x.ID == markazID).FirstOrDefault();

                title.Text = selectedbakhsh.title;
                masool.SelectedIndex = masool.FindStringExact(selectedbakhsh.masoul) ;
                janeshin.SelectedIndex = janeshin.FindStringExact(selectedbakhsh.janeshin);

                if (selectedbakhsh.BakhshID != null)
                {
                    bakhsh.SelectedValue = selectedbakhsh.BakhshID;
                }

                


            }
            else
            {
                dataGridView1.DataSource = lst;
            }



            dataGridView1.Columns["ID"].HeaderText = "ردیف";
            dataGridView1.Columns["ID"].Width = 120;
            dataGridView1.Columns["ID"].DisplayIndex = 1;
            dataGridView1.Columns["title"].HeaderText = "عنوان کمیته";
            dataGridView1.Columns["title"].Width = 216;
            dataGridView1.Columns["title"].DisplayIndex = 2;
            dataGridView1.Columns["title"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            dataGridView1.Columns["masoul"].HeaderText = "مسئول کمیته";
            dataGridView1.Columns["masoul"].Width = 216;
            dataGridView1.Columns["masoul"].DisplayIndex = 3;
            dataGridView1.Columns["masoul"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            dataGridView1.Columns["janeshin"].HeaderText = "جانشین کمیته";
            dataGridView1.Columns["janeshin"].Width = 216;
            dataGridView1.Columns["janeshin"].DisplayIndex = 4;
            dataGridView1.Columns["janeshin"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;



            dataGridView1.Columns["parent"].Visible = false;
            dataGridView1.Columns["final"].Visible = false;
            dataGridView1.Columns["isDone"].Visible = false;
            dataGridView1.Columns["master"].Visible = false;
            dataGridView1.Columns["markazID"].Visible = false;
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
            string markazID = GlobalVariable.markazID;
            using (var dbcontext = new Model.Context())
            {

                markaz marz = dbcontext.markazs.SingleOrDefault(x => x.ID == markazID);

                if (marz.final != 1)
                {
                    string parentID = marz.parent;
                    marz.title = title.Text;
                    marz.masoul = masool.Text;
                    marz.janeshin = janeshin.Text;
                    marz.BakhshID = "0";// bakhsh.SelectedValue.ToString();


                    List<markaz> lst = dbcontext.markazs.Where(x => x.parent == parentID).ToList();
                    foreach (markaz item in lst)
                    {
                        item.master = "0";
                    };
                    marz.isDone = true;
                    marz.master = "1";
                    marz.final = 1;
                    dbcontext.SaveChanges();
                }
                GlobalVariable.markazID = marz.parent;
            }

            this.Hide();
            Markaz_List form5 = new Markaz_List();
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

                    GlobalVariable.comiteID = rowID;
                    Komite_Add form2 = new Komite_Add();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            zero form = new zero();
            form.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Markaz_Menu form = new Markaz_Menu();

            form.Show();
            this.Hide();
        }
    }
}
