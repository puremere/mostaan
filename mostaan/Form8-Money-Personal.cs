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
    public partial class Form8_Money_Personal : Form
    {
        functions fns = new functions();
        Model.Context dbcontext = new Model.Context();
        public Form8_Money_Personal()
        {
            InitializeComponent();
            FontClass fontclass = new FontClass();

            List<Control> allControls = fontclass.GetAllControls(this);
            List<Control> alltextBox = fontclass.GetAllTextBox(this);

            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsupecSmall);
            alltextBox.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);

            alltextBox.ForEach(x => x.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox20_KeyDown));

            header.Font = mostaan.GlobalVariable.headerlistFONT;
            this.MaximizeBox = false;
            this.CenterToScreen();

            //panel1.PanelElement.Shape = new RoundRectShape();
            //panel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //panel1.PanelElement.PanelFill.BackColor = Color.White;
            header.Font = GlobalVariable.headerlistFONTBold;
            label2.Font = GlobalVariable.headerlistFONTsmall;
            label77.Font = GlobalVariable.headerlistFONTsmall;
            label3.Font = GlobalVariable.headerlistFONTsmall;
            label18.Font = GlobalVariable.headerlistFONTsmall;
            label17.Font = GlobalVariable.headerlistFONTsmall;
            label12.Font = GlobalVariable.headerlistFONTsmall;



            panel2.PanelElement.Shape = new RoundRectShape();
            panel2.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panel2.PanelElement.PanelFill.BackColor = Color.White;


            panel3.PanelElement.Shape = new RoundRectShape();
            panel3.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panel3.PanelElement.PanelFill.BackColor = Color.Violet;


            radPanel1.PanelElement.Shape = new RoundRectShape();
            radPanel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel1.PanelElement.PanelFill.BackColor = Color.White;

            radPanel2.PanelElement.Shape = new RoundRectShape();
            radPanel2.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel2.PanelElement.PanelFill.BackColor = Color.White;

            radPanel3.PanelElement.Shape = new RoundRectShape();
            radPanel3.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel3.PanelElement.PanelFill.BackColor = Color.Violet;

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
            radPanel1.PanelElement.PanelFill.BackColor = Color.White;




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

            if (GlobalVariable.shenasnameID != 0)
            {
                Model.shenasname item = dbcontext.shenasnames.FirstOrDefault(x => x.ID == GlobalVariable.shenasnameID);


                DrasmiT.Text = item.DrasmiT.ToString();
                DrasmiHPR.Text = item.DrasmiHPR.ToString();
                DrasmiHPD.Text = item.DrasmiHPD.ToString();
                DgharartamamT.Text = item.DgharartamamT.ToString();
                DgharartamamHPR.Text = item.DgharartamamHPR.ToString();
                DgharartamamHPD.Text = item.DgharartamamHPD.ToString();
                DghararsaatT.Text = item.DghararsaatT.ToString();
                DghararsaatHPR.Text = item.DghararsaatHPR.ToString();
                DghararsaatHPD.Text = item.DghararsaatHPD.ToString();
                DvazifeT.Text = item.DvazifeT.ToString();
                DvazifeHPR.Text = item.DvazifeHPR.ToString();
                DvazifeHPD.Text = item.DvazifeHPD.ToString();

                ZDirasmiT.Text = item.ZDirasmiT.ToString();
                ZDirasmiHPR.Text = item.ZDirasmiHPR.ToString();
                ZDirasmiHPD.Text = item.ZDirasmiHPD.ToString();
                ZDigharartamamT.Text = item.ZDigharartamamT.ToString();
                ZDigharartamamHPR.Text = item.ZDigharartamamHPR.ToString();
                ZDigharartamamHPD.Text = item.ZDigharartamamHPD.ToString();
                ZDighararsaatT.Text = item.ZDighararsaatT.ToString();
                ZDighararsaatHPR.Text = item.ZDighararsaatHPR.ToString();
                ZDighararsaatHPD.Text = item.ZDighararsaatHPD.ToString();
                ZDivazifeT.Text = item.ZDivazifeT.ToString();
                ZDivazifeHPR.Text = item.ZDivazifeHPR.ToString();
                ZDivazifeHPD.Text = item.ZDivazifeHPD.ToString();

                LrasmiT.Text = item.LrasmiT.ToString();
                LrasmiHPR.Text = item.LrasmiHPR.ToString();
                LrasmiHPD.Text = item.LrasmiHPD.ToString();
                LgharartamamT.Text = item.LgharartamamT.ToString();
                LgharartamamHPR.Text = item.LgharartamamHPR.ToString();
                LgharartamamHPD.Text = item.LgharartamamHPD.ToString();
                LghararsaatT.Text = item.LghararsaatT.ToString();
                LghararsaatHPR.Text = item.LghararsaatHPR.ToString();
                LghararsaatHPD.Text = item.LghararsaatHPD.ToString();
                LvazifeT.Text = item.LvazifeT.ToString();
                LvazifeHPR.Text = item.LvazifeHPR.ToString();
                LvazifeHPD.Text = item.LvazifeHPD.ToString();

                DirasmiT.Text = item.DirasmiT.ToString();
                DirasmiHPR.Text = item.DirasmiHPR.ToString();
                DirasmiHPD.Text = item.DirasmiHPD.ToString();
                DigharartamamT.Text = item.DigharartamamT.ToString();
                DigharartamamHPR.Text = item.DigharartamamHPR.ToString();
                DigharartamamHPD.Text = item.DigharartamamHPD.ToString();
                DighararsaatT.Text = item.DighararsaatT.ToString();
                DighararsaatHPR.Text = item.DighararsaatHPR.ToString();
                DighararsaatHPD.Text = item.DighararsaatHPD.ToString();
                DivazifeT.Text = item.DivazifeT.ToString();
                DivazifeHPR.Text = item.DivazifeHPR.ToString();
                DivazifeHPD.Text = item.DivazifeHPD.ToString();

                FLrasmiT.Text = item.FLrasmiT.ToString();
                FLrasmiHPR.Text = item.FLrasmiHPR.ToString();
                FLrasmiHPD.Text = item.FLrasmiHPD.ToString();
                FLgharartamamT.Text = item.FLgharartamamT.ToString();
                FLgharartamamHPR.Text = item.FLgharartamamHPR.ToString();
                FLgharartamamHPD.Text = item.FLgharartamamHPD.ToString();
                FLghararsaatT.Text = item.FLghararsaatT.ToString();
                FLghararsaatHPR.Text = item.FLghararsaatHPR.ToString();
                FLghararsaatHPD.Text = item.FLghararsaatHPD.ToString();
                FLvazifeT.Text = item.FLvazifeT.ToString();
                FLvazifeHPR.Text = item.FLvazifeHPR.ToString();
                FLvazifeHPD.Text = item.FLvazifeHPD.ToString();
            }



        }



        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            //TextBox tb = sender as TextBox;
            //if (tb.Text.Length > 3)
            //{
            //    this.Text = String.Format("{0:n0}", tb.Text);
            //}
        }



        private void label18_Click(object sender, EventArgs e)
        {
            int id = GlobalVariable.shenasnameID;
            Model.shenasname item = dbcontext.shenasnames.FirstOrDefault(x => x.ID == id);

            try
            {
                item.DrasmiT = Int32.Parse(DrasmiT.Text);
                item.DrasmiHPR = Int32.Parse(DrasmiHPR.Text);
                item.DrasmiHPD = Int32.Parse(DrasmiHPD.Text);
                item.DgharartamamT = Int32.Parse(DgharartamamT.Text);
                item.DgharartamamHPR = Int32.Parse(DgharartamamHPR.Text);
                item.DgharartamamHPD = Int32.Parse(DgharartamamHPD.Text);
                item.DghararsaatT = Int32.Parse(DghararsaatT.Text);
                item.DghararsaatHPR = Int32.Parse(DghararsaatHPR.Text);
                item.DghararsaatHPD = Int32.Parse(DghararsaatHPD.Text);
                item.DvazifeT = Int32.Parse(DvazifeT.Text);
                item.DvazifeHPR = Int32.Parse(DvazifeHPR.Text);
                item.DvazifeHPD = Int32.Parse(DvazifeHPD.Text);

                item.ZDirasmiT = Int32.Parse(ZDirasmiT.Text);
                item.ZDirasmiHPR = Int32.Parse(ZDirasmiTHPR.Text);
                item.ZDirasmiHPD = Int32.Parse(ZDirasmiHPD.Text);
                item.ZDigharartamamT = Int32.Parse(ZDigharartamamT.Text);
                item.ZDigharartamamHPR = Int32.Parse(ZDigharartamamHPR.Text);
                item.ZDigharartamamHPD = Int32.Parse(ZDigharartamamHPD.Text);
                item.ZDighararsaatT = Int32.Parse(ZDighararsaatT.Text);
                item.ZDighararsaatHPR = Int32.Parse(ZDighararsaatHPR.Text);
                item.ZDighararsaatHPD = Int32.Parse(ZDighararsaatHPD.Text);
                item.ZDivazifeT = Int32.Parse(ZDivazifeT.Text);
                item.ZDivazifeHPR = Int32.Parse(ZDivazifeHPR.Text);
                item.ZDivazifeHPD = Int32.Parse(ZDivazifeHPD.Text);

                item.LrasmiT = Int32.Parse(LrasmiT.Text);
                item.LrasmiHPR = Int32.Parse(LrasmiHPR.Text);
                item.LrasmiHPD = Int32.Parse(LrasmiHPD.Text);
                item.LgharartamamT = Int32.Parse(LgharartamamT.Text);
                item.LgharartamamHPR = Int32.Parse(LgharartamamHPR.Text);
                item.LgharartamamHPD = Int32.Parse(LgharartamamHPD.Text);
                item.LghararsaatT = Int32.Parse(LghararsaatT.Text);
                item.LghararsaatHPR = Int32.Parse(LghararsaatHPR.Text);
                item.LghararsaatHPD = Int32.Parse(LghararsaatHPD.Text);
                item.LvazifeT = Int32.Parse(LvazifeT.Text);
                item.LvazifeHPR = Int32.Parse(LvazifeHPR.Text);
                item.LvazifeHPD = Int32.Parse(LvazifeHPD.Text);

                item.DirasmiT = Int32.Parse(DirasmiT.Text);
                item.DirasmiHPR = Int32.Parse(DirasmiHPR.Text);
                item.DirasmiHPD = Int32.Parse(DirasmiHPD.Text);
                item.DigharartamamT = Int32.Parse(DigharartamamT.Text);
                item.DigharartamamHPR = Int32.Parse(DigharartamamHPR.Text);
                item.DigharartamamHPD = Int32.Parse(DigharartamamHPD.Text);
                item.DighararsaatT = Int32.Parse(DighararsaatT.Text);
                item.DighararsaatHPR = Int32.Parse(DighararsaatHPR.Text);
                item.DighararsaatHPD = Int32.Parse(DighararsaatHPD.Text);
                item.DivazifeT = Int32.Parse(DivazifeT.Text);
                item.DivazifeHPR = Int32.Parse(DivazifeHPR.Text);
                item.DivazifeHPD = Int32.Parse(DivazifeHPD.Text);

                item.FLrasmiT = Int32.Parse(FLrasmiT.Text);
                item.FLrasmiHPR = Int32.Parse(FLrasmiHPR.Text);
                item.FLrasmiHPD = Int32.Parse(FLrasmiHPD.Text);
                item.FLgharartamamT = Int32.Parse(FLgharartamamT.Text);
                item.FLgharartamamHPR = Int32.Parse(FLgharartamamHPR.Text);
                item.FLgharartamamHPD = Int32.Parse(FLgharartamamHPD.Text);
                item.FLghararsaatT = Int32.Parse(FLghararsaatT.Text);
                item.FLghararsaatHPR = Int32.Parse(FLghararsaatHPR.Text);
                item.FLghararsaatHPD = Int32.Parse(FLghararsaatHPD.Text);
                item.FLvazifeT = Int32.Parse(FLvazifeT.Text);
                item.FLvazifeHPR = Int32.Parse(FLvazifeHPR.Text);
                item.FLvazifeHPD = Int32.Parse(FLvazifeHPD.Text);

                dbcontext.SaveChanges();
                this.Hide();
                Form9_money_sarmaye form9 = new Form9_money_sarmaye();
                form9.Show();
                this.Hide();
            }
            catch
            {
                Form9_money_sarmaye form9 = new Form9_money_sarmaye();
                form9.Show();
                this.Hide();
            }



        }

        private void panel161_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
            Form6_PMainMoney form = new Form6_PMainMoney();
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

        private void notEmpty(object sender, CancelEventArgs e)
        {
            var cnt = sender as TextBox;
            if (cnt.Text.Count() < 1)
            {
                e.Cancel = true;
                messageLable.Text = "فیلد مورد نظر نباید خالی باشد";


            }
            else
            {
                messageLable.Text = "";
            }
        }

        private void isDigit(object sender, CancelEventArgs e)
        {
            var cnt = sender as TextBox;
            var boolianvar = fns.IsDigitsOnly(cnt.Text);
            if (cnt.Text.Count() < 1 || !boolianvar)
            {
                e.Cancel = true;
                messageLable.Text = "فیلد مورد باید شامل عدد باشد";


            }
            else
            {
                messageLable.Text = "";
            }
        }
    }
}
