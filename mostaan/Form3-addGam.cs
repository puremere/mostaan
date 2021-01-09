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
using Telerik.WinControls;

namespace mostaan
{
    public partial class Form3_addGam : Form
    {
        functions fns = new functions();
        Model.Context dbcontext = new Model.Context();
      
        public Form3_addGam()
        {
            
            InitializeComponent();
           
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
            radPanel5.PanelElement.PanelFill.BackColor = Color.White;

            radPanel6.PanelElement.Shape = new RoundRectShape();
            radPanel6.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel6.PanelElement.PanelFill.BackColor = Color.White;

            radPanel7.PanelElement.Shape = new RoundRectShape();
            radPanel7.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel7.PanelElement.PanelFill.BackColor = Color.Violet;

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            


        }

        private void label7_Click(object sender, EventArgs e)
        {
            string gam = gamasli.Text;
            string onv = onvan.Text;
            string shr = sharh.Text;
            string mod = modat.Text;
            string dar = darsad.Text;
            string das = dastavard.Text;

            shenasnameGam model = new shenasnameGam()
            {
                achivement = dastavard.Text,
                darsadeVazni = Int32.Parse(darsad.Text),
                description = sharh.Text,
                duration = modat.Text,
                title = onvan.Text,
                shenasnameID = GlobalVariable.shenasnameID,
                gamAsli = gamasli.Text,
            };
            dbcontext.shenasnameGams.Add(model);
            dbcontext.SaveChanges();

            int index = 0;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "Form2_shenasnameAdd")
                {
                    break;
                }

                index += 1;
            }
            
            this.Hide();

            Application.OpenForms[index].Close();
            Form2_shenasnameAdd form2 = new Form2_shenasnameAdd();
            form2.Show();
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
        private void IsDigitsOnly(object sender, CancelEventArgs e)
        {

        }
    }
}
