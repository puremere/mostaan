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
    public partial class Form1_chooseList : Form
    {
        Model.Context dbcontext = new Model.Context();
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public Form1_chooseList()
        {
            InitializeComponent();
            FontClass fontclass = new FontClass();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            this.MaximizeBox = false;
            panle1.PanelElement.Shape = new RoundRectShape();
            panle1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panle1.PanelElement.PanelFill.BackColor = Color.Gray;
            panle2.PanelElement.Shape = new RoundRectShape();
            panle2.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panle2.PanelElement.PanelFill.BackColor = Color.Gray;
            this.CenterToScreen();
        }
      
        private void shenasnameAdd_Click(object sender, EventArgs e)
        {


            string id = RandomString(10);
            shenasname model = new shenasname();
            DateTime nowdatetime = DateTime.Now;
            model.token = "123456789";
            model.master = "1";
            model.ID = id;
            model.parent = id;
            model.date = nowdatetime;
            model.dateFrom = DateTime.Now;
            model.dateTo = DateTime.Now;
            model.time = nowdatetime.TimeOfDay;
            dbcontext.shenasnames.Add(model);
            dbcontext.SaveChanges();
            GlobalVariable.shenasnameID = id;
            Form2_shenasnameAdd form = new Form2_shenasnameAdd();

            form.Show();
           
            
            this.Hide();
        }


          
        

        private void shenasnameList_Click(object sender, EventArgs e)
        {
            Form5_shenasnameList form = new Form5_shenasnameList();
            form.Show();
            this.Hide();
        }

        private void Form1_chooseList_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            zero form = new zero();
            form.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            zero form = new zero();
            form.Show();
            this.Hide();
        }
    }
}
