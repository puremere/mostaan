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
    public partial class Markaz_Menu : Form
    {
      

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public Markaz_Menu()
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
            panle2.PanelElement.Shape = new RoundRectShape();
            panle2.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panle2.PanelElement.PanelFill.BackColor = Color.Gray;
            this.CenterToScreen();
        }

        private void bakhshList_Click(object sender, EventArgs e)
        {
            Markaz_List form = new Markaz_List();
            form.Show();
        }

        private void bakhshAdd_Click(object sender, EventArgs e)
        {
            using (Context dbcontext = new Context())
            {
                string id = RandomString(10);
                markaz model = new markaz();
                DateTime nowdatetime = DateTime.Now;
                model.master = "1";
                model.ID = id;
                model.parent = id;
                model.date = nowdatetime;
                model.time = nowdatetime.TimeOfDay;
                model.changer = "admin";
                dbcontext.markazs.Add(model);
                dbcontext.SaveChanges();
                GlobalVariable.markazID = id;

                Markaz_add form = new Markaz_add();

                form.Show();
            }


        }
    }
}
