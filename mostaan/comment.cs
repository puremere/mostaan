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
using Telerik.WinControls;
using mostaan.Model;

namespace mostaan
{
    public partial class comment : Form
    {
       
        string shenasnameID = GlobalVariable.shenasnameID;
        public comment()
        {
            InitializeComponent();
            FontClass fontclass = new FontClass();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            header.Font = mostaan.GlobalVariable.headerlistFONT;
            this.MaximizeBox = false;
            this.CenterToScreen();

            //panel1.PanelElement.Shape = new RoundRectShape();
            //panel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //panel1.PanelElement.PanelFill.BackColor = Color.White;

            panel2.PanelElement.Shape = new RoundRectShape();
            panel2.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panel2.PanelElement.PanelFill.BackColor = Color.White;

            panel3.PanelElement.Shape = new RoundRectShape();
            panel3.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panel3.PanelElement.PanelFill.BackColor = Color.White;


            radPanel1.PanelElement.Shape = new RoundRectShape();
            radPanel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel1.PanelElement.PanelFill.BackColor = Color.Violet;

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
            radPanel5.PanelElement.PanelFill.BackColor = Color.White;

            radPanel6.PanelElement.Shape = new RoundRectShape();
            radPanel6.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel6.PanelElement.PanelFill.BackColor = Color.White;

            radPanel7.PanelElement.Shape = new RoundRectShape();
            radPanel7.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel7.PanelElement.PanelFill.BackColor = Color.White;

            radPanel8.PanelElement.Shape = new RoundRectShape();
            radPanel8.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel8.PanelElement.PanelFill.BackColor = Color.White;

            radPanel9.PanelElement.Shape = new RoundRectShape();
            radPanel9.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel9.PanelElement.PanelFill.BackColor = Color.White;

            radPanel10.PanelElement.Shape = new RoundRectShape();
            radPanel10.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel10.PanelElement.PanelFill.BackColor = Color.White;

            radPanel1.PanelElement.Shape = new RoundRectShape();
            radPanel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel1.PanelElement.PanelFill.BackColor = Color.Violet;




            radPanel13.PanelElement.Shape = new RoundRectShape();
            radPanel13.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel13.PanelElement.PanelFill.BackColor = Color.Blue;
            radPanel14.PanelElement.Shape = new RoundRectShape();
            radPanel14.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel14.PanelElement.PanelFill.BackColor = Color.Gray;


            label1.Font = GlobalVariable.headerlistFONTsupecSmall;
            label4.Font = GlobalVariable.headerlistFONTsupecSmall;
            label5.Font = GlobalVariable.headerlistFONTsupecSmall;
            label6.Font = GlobalVariable.headerlistFONTsupecSmall;
            label7.Font = GlobalVariable.headerlistFONTsupecSmall;
            label8.Font = GlobalVariable.headerlistFONTsupecSmall;
            label9.Font = GlobalVariable.headerlistFONTsupecSmall;
            label10.Font = GlobalVariable.headerlistFONTsupecSmall;
            label11.Font = GlobalVariable.headerlistFONTsupecSmall;
            string shenasnameID = GlobalVariable.shenasnameID; 
            if (shenasnameID != "")
            {
                using (Context dbcontext = new Context())
                {
                    Model.shenasname item = dbcontext.shenasnames.Where(x => x.ID == GlobalVariable.shenasnameID).FirstOrDefault();
                    commentSection.Text = item.comment;
                }

            }





        }

        private void label18_Click(object sender, EventArgs e)
        {
           



            string shenasnameID = GlobalVariable.shenasnameID;
            using (var dbcontext = new Model.Context())
            {

                shenasname shen = dbcontext.shenasnames.SingleOrDefault(x => x.ID == shenasnameID);

                if (shen.final != 1)
                {
                    shen.comment = commentSection.Text;
                    //string parentID = shen.parent;

                    //List<shenasname> shenList = dbcontext.shenasnames.Where(x => x.parent == parentID).ToList();
                    //foreach (shenasname item in shenList)
                    //{
                    //    item.master = "0";
                    //};
                    //shen.isDone = true;
                    //shen.master = "1";
                    //shen.final = 1;
                    dbcontext.SaveChanges();
                }
                //GlobalVariable.shenasnameID = shen.parent;
            }
            this.Hide();
            projectFiles pf = new projectFiles();
            pf.Show();

            
        }


        private void label17_Click(object sender, EventArgs e)
        {
           Form21_tashvighi form = new Form21_tashvighi();
            form.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form6_PMainMoney form = new Form6_PMainMoney();
            form.Show();
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form8_Money_Personal form = new Form8_Money_Personal();
            form.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form9_money_sarmaye form = new Form9_money_sarmaye();
            form.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form11_addMasrafi form = new Form11_addMasrafi();
            form.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form13_Hazine_edari form = new Form13_Hazine_edari();
            form.Show();
            this.Hide();

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form15_addOmrani form = new Form15_addOmrani();
            form.Show();
            this.Hide();
        }



        private void label9_Click(object sender, EventArgs e)
        {
            Form17_gharadad form = new Form17_gharadad();
            form.Show();
            this.Hide();

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form19_saryer form = new Form19_saryer();
            form.Show();
            this.Hide();

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Form21_tashvighi form = new Form21_tashvighi();
            form.Show();
            this.Hide();
        }

        private void radpanel0_Click(object sender, EventArgs e)
        {
            Form6_PMainMoney form = new Form6_PMainMoney();
            form.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            comment form = new comment();
            form.Show();
            this.Hide();
        }

        
    }
}
