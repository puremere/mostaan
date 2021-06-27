using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mostaan.Classes;
using Telerik.WinControls;

namespace mostaan
{
    public partial class zero : Form
    {
        public zero()
        {
            InitializeComponent();
            FontClass fontclass = new FontClass();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
          
            this.MaximizeBox = false;
            this.CenterToScreen();
            panle1.PanelElement.Shape = new RoundRectShape();
            panle1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panle1.PanelElement.PanelFill.BackColor = Color.Gray;

            radPanel1.PanelElement.Shape = new RoundRectShape();
            radPanel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel1.PanelElement.PanelFill.BackColor = Color.Gray;

            radPanel2.PanelElement.Shape = new RoundRectShape();
            radPanel2.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel2.PanelElement.PanelFill.BackColor = Color.Gray;

            radPanel3.PanelElement.Shape = new RoundRectShape();
            radPanel3.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel3.PanelElement.PanelFill.BackColor = Color.Gray;

            radPanel4.PanelElement.Shape = new RoundRectShape();
            radPanel4.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel4.PanelElement.PanelFill.BackColor = Color.Gray;

            radPanel5.PanelElement.Shape = new RoundRectShape();
            radPanel5.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel5.PanelElement.PanelFill.BackColor = Color.Gray;

            radPanel6.PanelElement.Shape = new RoundRectShape();
            radPanel6.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel6.PanelElement.PanelFill.BackColor = Color.Gray;

            radPanel7.PanelElement.Shape = new RoundRectShape();
            radPanel7.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel7.PanelElement.PanelFill.BackColor = Color.Gray;

            var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string root = Path.Combine(directory, "FIM");
            string trashPath = Path.Combine(root, "trash");
            if (Directory.Exists(trashPath))
            {
                var dir = new DirectoryInfo(trashPath);
                dir.Delete(true);
                
            }

            this.CenterToScreen();
        }

        private void shenasname_Click(object sender, EventArgs e)
        {
            Form1_chooseList intro = new Form1_chooseList();
            intro.Show();
        }

        private void faktor_Click(object sender, EventArgs e)
        {
            ChooseBank bank = new ChooseBank();
            bank.Show();
        }

        private void sazman_Click(object sender, EventArgs e)
        {
            Bakhsh_Menu intro = new Bakhsh_Menu();
            intro.Show();
        }

        private void user_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            User_List  list = new User_List(dt);
            list.Show();
        }

        private void bakhsh_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            daryaftiReport form = new daryaftiReport(dt);
            form.Show();
        }

        private void markaz_Click(object sender, EventArgs e)
        {
            Markaz_Menu form = new Markaz_Menu();
            form.Show();
        }

        private void komite_Click(object sender, EventArgs e)
        {
            Komite_Menu form = new Komite_Menu();
            form.Show();
        }

        private void bank_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Bank_List form = new Bank_List(dt);
            form.Show();
        }

        private void check_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            checkList form = new checkList(dt);
            form.Show();
        }
    }
}
