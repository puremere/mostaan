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


           
            shenasname model = new shenasname();
            model.token = "123456789";
            model.final = 0;
            model.date = DateTime.Now;
            model.dateFrom = DateTime.Now;
            model.dateTo = DateTime.Now;
            dbcontext.shenasnames.Add(model);
            dbcontext.SaveChanges();
            
            //model.isFinal = 0;
            //dbcontext.shenasnames.Add(model);
            //dbcontext.SaveChanges();
            int id = dbcontext.shenasnames.ToList().Last().ID;

             GlobalVariable.shenasnameID = id;
             Form2_shenasnameAdd form = new Form2_shenasnameAdd();

            form.Show();
           // this.Hide();
        }


          
        

        private void shenasnameList_Click(object sender, EventArgs e)
        {
            Form5_shenasnameList form = new Form5_shenasnameList();
            form.Show();
           // this.Hide();
        }
    }
}
