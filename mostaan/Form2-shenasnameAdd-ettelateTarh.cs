using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mostaan.Classes;
using Telerik.WinControls;

namespace mostaan
{
    public partial class Form2_shenasnameAdd : Form
    {

        functions fns = new functions();
        Model.Context dbcontext = new Model.Context();

        public Form2_shenasnameAdd()
        {

            int shenasnameID = GlobalVariable.shenasnameID;
            Model.Context dbcontext = new Model.Context();
            InitializeComponent();
            FontClass fontclass = new FontClass();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            header.Font = mostaan.GlobalVariable.headerlistFONT;
            dateFrom.Font = GlobalVariable.headerlistFONTsupecSmall;
            dateTo.Font = GlobalVariable.headerlistFONTsupecSmall;
            this.MaximizeBox = false;
            this.CenterToScreen();

            panel1.PanelElement.Shape = new RoundRectShape();
            panel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panel1.PanelElement.PanelFill.BackColor = Color.White;

            panel2.PanelElement.Shape = new RoundRectShape();
            panel2.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panel2.PanelElement.PanelFill.BackColor = Color.White;

            panel3.PanelElement.Shape = new RoundRectShape();
            panel3.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panel3.PanelElement.PanelFill.BackColor = Color.Violet;
            

            radPanel10.PanelElement.Shape = new RoundRectShape();
            radPanel10.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel10.PanelElement.PanelFill.BackColor = Color.White;

            radPanel11.PanelElement.Shape = new RoundRectShape();
            radPanel11.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel11.PanelElement.PanelFill.BackColor = Color.White;

            //radPanel12.PanelElement.Shape = new RoundRectShape();
            //radPanel12.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //radPanel12.PanelElement.PanelFill.BackColor = Color.White;

            radPanel13.PanelElement.Shape = new RoundRectShape();
            radPanel13.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel13.PanelElement.PanelFill.BackColor = Color.White;

            radPanel14.PanelElement.Shape = new RoundRectShape();
            radPanel14.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel14.PanelElement.PanelFill.BackColor = Color.White;


            radPanel16.PanelElement.Shape = new RoundRectShape();
            radPanel16.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel16.PanelElement.PanelFill.BackColor = Color.Gray;

            radPanel19.PanelElement.Shape = new RoundRectShape();
            radPanel19.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel19.PanelElement.PanelFill.BackColor = Color.Gray;
        
            radPanel18.PanelElement.Shape = new RoundRectShape();
            radPanel18.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel18.PanelElement.PanelFill.BackColor = Color.Gray;

            radPanel1.PanelElement.Shape = new RoundRectShape();
            radPanel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel1.PanelElement.PanelFill.BackColor = Color.Gray;

            this.radVScrollBar1.Maximum = this.panelNum2.Size.Height - this.panelNum1.Size.Height;
            List<Model.shenasnameGam> lst = new List<Model.shenasnameGam>();
            List<Model.shenasnameFounder> lstFounder = new List<Model.shenasnameFounder>();
            if (shenasnameID != 0)
            {

                lst = (from p in dbcontext.shenasnameGams where p.shenasnameID == shenasnameID select p).ToList();
                dataGridView1.DataSource = lst;

                lstFounder = (from p in dbcontext.shenasnameFounders where p.shenasnameID == shenasnameID select p).ToList();
                dataGridView2.DataSource = lstFounder;

                Model.shenasname item = dbcontext.shenasnames.Where(x => x.ID == GlobalVariable.shenasnameID).FirstOrDefault();

                hadaf.Text = item.hadaf ;
                title.Text = item.title ;
                dastgah.Text = item.dastgah ;
                date.Text = item.date.ToShortDateString();
                dateFrom.Text = item.dateFrom.ToShortDateString();
                dateTo.Text = item.dateTo.ToShortDateString();
               
            }
            else
            {
                dataGridView1.DataSource = lst;
                dataGridView2.DataSource = lstFounder;
            }
            dataGridView1.Width = 1300;
            dataGridView1.Columns[1].HeaderText = "گام های اصلی";
            dataGridView1.Columns[1].Width =200;
            dataGridView1.Columns[2].HeaderText = "عنوان اصلی فعالیت";
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].HeaderText = "شرح فعالیت اصلی در این گام";
            dataGridView1.Columns[3].Width =300;
            dataGridView1.Columns[4].HeaderText = "مدت زمان تقریبی (ماه)";
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].HeaderText = "درصد وزنی فعالیت";
            dataGridView1.Columns[5].Width =150;
            dataGridView1.Columns[6].HeaderText = "دستاورد";
            dataGridView1.Columns[6].Width = 300;
            dataGridView1.Columns["shenasnameID"].Visible = false;
            dataGridView1.Columns["ID"].Visible = false;


           



            dataGridView1.Columns[6].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[1].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[2].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[3].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[4].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[5].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;

            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.DefaultCellStyle.Font = GlobalVariable.headerlistFONTsmall;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            dataGridView2.Columns[1].HeaderText = "نام و نام خانوادگی";
            dataGridView2.Columns[1].Width = dataGridView2.Width / 2;
            dataGridView2.Columns[2].HeaderText = "سمت";
            dataGridView2.Columns[2].Width = dataGridView2.Width / 2;
            dataGridView2.Columns["shenasnameID"].Visible = false;
            dataGridView2.Columns["ID"].Visible = false;

            dataGridView2.Columns[1].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsmall;
            dataGridView2.Columns[2].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsmall;

            dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView2.EnableHeadersVisualStyles = false;

            dataGridView2.DefaultCellStyle.Font = GlobalVariable.headerlistFONTsmall;
            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            radPanel18.PanelElement.Shape = new RoundRectShape();
            radPanel18.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
         

        }
       

        private void Form2_shenasnameAdd_Load(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radVScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.panelNum2.Top = -this.radVScrollBar1.Value;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form4_addFounder form = new Form4_addFounder();
            form.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Form3_addGam form = new Form3_addGam();
            form.Show();
        }

        private void label16_Click(object sender, EventArgs e) // تایید
        {
            Model.shenasname item = dbcontext.shenasnames.Where(x => x.ID == GlobalVariable.shenasnameID).FirstOrDefault();
            try
            {
                item.hadaf = hadaf.Text;
                item.title = title.Text;
                item.dastgah = dastgah.Text;
                item.date = date.GetSelectedDateInPersianDateTime().ToShortDateString().ToGeorgianDateTime();
                item.dateFrom = dateFrom.GetSelectedDateInPersianDateTime().ToShortDateString().ToGeorgianDateTime();
                item.dateTo = dateTo.GetSelectedDateInPersianDateTime().ToShortDateString().ToGeorgianDateTime();
                dbcontext.SaveChanges();
                Form6_PMainMoney form6 = new Form6_PMainMoney();
                form6.Show();
                this.Hide();
            }
            catch (Exception error)
            {

                //throw;
            }
           
           // this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void notEmpty (object sender, EventArgs e)
        {
            
        }
        private void notEmptyAndNum(object sender, EventArgs e)
        {
            var cnt = sender as TextBox;
        }

        private void hadaf_Validating(object sender, CancelEventArgs e)
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

      

        private void header_Click(object sender, EventArgs e)
        {

        }
    }
}
