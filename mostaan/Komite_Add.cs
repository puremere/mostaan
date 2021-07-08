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
    public partial class Komite_Add : Form
    {
       
        public Komite_Add()
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

            string komiteID = GlobalVariable.comiteID;
            List<Model.shenasname> lst = new List<Model.shenasname>();
            List<user> userlist = dbcontext.users.ToList();
            List<user> userlist2 = dbcontext.users.ToList();





            List<user> list = dbcontext.users.ToList();


            masool.DataSource = userlist;
            masool.DisplayMember = "name";
            masool.ValueMember = "ID";

            janeshin.DataSource = userlist2;
            janeshin.DisplayMember = "name";
            janeshin.ValueMember = "ID";


            List<markaz> markazlist = dbcontext.markazs.Where(x => x.master == "1").ToList();
            bakhsh.DataSource = markazlist;
            bakhsh.DisplayMember = "title";
            bakhsh.ValueMember = "parent";


            if (komiteID != "" && komiteID != null)
            {
                komite selectedbakhsh = dbcontext.komites.SingleOrDefault(x => x.ID == komiteID);

                lst = (from p in dbcontext.shenasnames where p.markaz == selectedbakhsh.parent && p.master == "1" select p).ToList();
                //dataGridView1.DataSource = lst;


              

                title.Text = selectedbakhsh.title;
                masool.SelectedIndex = masool.FindStringExact(selectedbakhsh.masoul);
                janeshin.SelectedIndex = janeshin.FindStringExact(selectedbakhsh.janeshin);
                if (selectedbakhsh.markazID != null)
                {
                    bakhsh.SelectedValue = selectedbakhsh.markazID;
                }
                


            }
            else
            {
                //dataGridView1.DataSource = lst;
            }

        }

        private void filter_Click(object sender, EventArgs e)
        {
            string komiteID = GlobalVariable.comiteID;
            using (var dbcontext = new Model.Context())
            {

                komite marz = dbcontext.komites.SingleOrDefault(x => x.ID == komiteID);

                if (marz.final != 1)
                {
                    string parentID = marz.parent;
                    marz.title = title.Text;
                    marz.masoul = masool.Text;
                    marz.janeshin = janeshin.Text;
                    marz.markazID = bakhsh.SelectedValue.ToString();


                    List<komite> lst = dbcontext.komites.Where(x => x.parent == parentID).ToList();
                    foreach (komite item in lst)
                    {
                        item.master = "0";
                    };
                    marz.isDone = true;
                    marz.master = "1";
                    marz.final = 1;
                    dbcontext.SaveChanges();
                }
                GlobalVariable.comiteID = marz.parent;
            }

            this.Hide();
            Komite_List form5 = new Komite_List();
            form5.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            zero form = new zero();
            form.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Komite_Menu form = new Komite_Menu();
            form.Show();
            this.Hide();
        }
    }
}
