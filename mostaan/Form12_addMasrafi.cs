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


namespace mostaan
{
    public partial class Form12_addMasrafi : Form
    {
        functions fns = new functions();
        Model.Context dbcontext = new Model.Context();
        public Form12_addMasrafi()
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

            radPanel8.PanelElement.Shape = new RoundRectShape();
            radPanel8.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel8.PanelElement.PanelFill.BackColor = Color.White;


            radPanel7.PanelElement.Shape = new RoundRectShape();
            radPanel7.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel7.PanelElement.PanelFill.BackColor = Color.Violet;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            mostaan.Model.masrafi model = new Model.masrafi()
            {
                count = Int32.Parse(count.Text),
                creatoreCo = Ctitle.Text,
                title = title.Text,
                kollPD = Int32.Parse(koldollary.Text),
                kollPR = Int32.Parse(kolrially.Text),
                vahedPD = Int32.Parse(vaheddollary.Text),
                vahedPR = Int32.Parse(vahedrially.Text),
                shenasnameID = GlobalVariable.shenasnameID,


            };
            Model.masrafi item = dbcontext.masrafis.SingleOrDefault(x => x.title == title.Text && x.shenasnameID == GlobalVariable.shenasnameID );
            if (item == null)
            {
                dbcontext.masrafis.Add(model);
                dbcontext.SaveChanges();
                int index = 0;
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "Form11_addMasrafi")
                    {
                        break;
                    }

                    index += 1;
                }
                this.Hide();

                Application.OpenForms[index].Close();
                Form11_addMasrafi form11 = new Form11_addMasrafi();
                form11.Show();
            }
            else
            {
                message.Text = "عنوان تکراری مجاز نیست";
            }
                
            
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
