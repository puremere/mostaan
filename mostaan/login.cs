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

        

        FontClass fontclass = new FontClass();
        //databaseManager manager = new databaseManager();
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
           IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();
        private static string choosenType = "";
        private static string choosenSubject = "";
        public void initFont()
        {

            byte[] fontData = Properties.Resources.IRANSans_FaNum_;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.IRANSans_FaNum_.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.IRANSans_FaNum_.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            GlobalVariable.headerlistFONT = new Font(fonts.Families[0], 24.0F, System.Drawing.FontStyle.Regular);

            GlobalVariable.headerlistFONTsmall = new Font(fonts.Families[0], 12.0F, System.Drawing.FontStyle.Regular);
            GlobalVariable.headerlistFONTBold = new Font(fonts.Families[0], 12.0F, System.Drawing.FontStyle.Bold);
            //GlobalVariable.HlistFONT = new Font(fonts.Families[0], 18.0F, System.Drawing.FontStyle.Regular);
            // label1.Font = GlobalVariable.headerlistFONT;
           

        }

        public login()
        {
            
            InitializeComponent();
            FontClass fontclass = new FontClass();
            initFont();
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
