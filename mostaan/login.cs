using mostaan.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace mostaan
{
    public partial class login : Form
    {
       

      
        public login()
        {
            InitializeComponent();
            FontClass fontclass = new FontClass();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            this.MaximizeBox = false;
            loginFormHeaderPanel.PanelElement.Shape = new RoundRectShape();
            loginFormHeaderPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            loginFormHeaderPanel.PanelElement.PanelFill.BackColor = Color.Gray;

            loginBodyPanle.PanelElement.Shape = new RoundRectShape();
            loginBodyPanle.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            loginBodyPanle.PanelElement.PanelFill.BackColor = Color.White;

            verifPanel.PanelElement.Shape = new RoundRectShape();
            verifPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            verifPanel.PanelElement.PanelFill.BackColor = Color.Gray;

            
            this.CenterToScreen();


        }

        private void vrifyButt_Click(object sender, EventArgs e)
        {
             message.Text = "";
             if ( username.Text == "admin" && password.Text == "admin")
            {
                //ChooseBank choosbank = new ChooseBank();
                //choosbank.Show();
                zero form = new zero();
                form.Show();
                this.Hide();
            }
            else
            {
                message.Text = "نام کاربری یا رمز عبور اشتباه است";
            }
        }
    }
}
