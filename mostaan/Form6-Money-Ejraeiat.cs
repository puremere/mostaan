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
    public partial class Form6_PMainMoney : Form
    {
        Model.Context dbcontext = new Model.Context();
        int shenasnameID = GlobalVariable.shenasnameID;
        public Form6_PMainMoney()
        {

            InitializeComponent();
            FontClass fontclass = new FontClass();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            header.Font = mostaan.GlobalVariable.headerlistFONT;
            this.MaximizeBox = false;
            this.CenterToScreen();

            //panel1.PanelElement.Shape = new RoundRectShape();
            //panel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //panel1.PanelElement.PanelFill.BackColor = Color.White;

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
            radPanel3.PanelElement.PanelFill.BackColor = Color.White;

            radPanel4.PanelElement.Shape = new RoundRectShape();
            radPanel4.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel4.PanelElement.PanelFill.BackColor = Color.Violet;

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

            radPanel12.PanelElement.Shape = new RoundRectShape();
            radPanel12.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel12.PanelElement.PanelFill.BackColor = Color.LightGray;

            radPanel11.PanelElement.Shape = new RoundRectShape();
            radPanel11.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel11.PanelElement.PanelFill.BackColor = Color.LightGray;


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

            Phazine.Font = GlobalVariable.headerlistFONTBold;
            Nhazine.Font = GlobalVariable.headerlistFONTBold;

            List<Model.ejraeiat>  lst = (from p in dbcontext.ejraeiats where p.shenasnameID == shenasnameID select p).ToList();
            dataGridView1.DataSource = lst;
            int pd = lst.Sum(x => x.dollaryP);
            int pr = lst.Sum(x => x.riallyP);

            int nd = lst.Sum(x => x.dollaryN);
            int nr = lst.Sum(x => x.riallyN);

            Phazine.Text =  String.Format("{0:n0}", pr) + " ریال و " + string.Format("{0:n0}", pd) + " دلار ";
            Nhazine.Text = string.Format("{0:n0}", nr)  + " ریال و " + string.Format("{0:n0}", nd) + " دلار ";


            foreach (var item in lst)
            {
                item.ID = lst.IndexOf(item) + 1;
            }
            int Pwidth = dataGridView1.Width;

            dataGridView1.Columns["ID"].HeaderText = "ردیف";
            dataGridView1.Columns["ID"].Width = (Pwidth / 14);
            dataGridView1.Columns["ID"].DisplayIndex = 1;
            dataGridView1.Columns["title"].HeaderText = "شرح هزینه";
            dataGridView1.Columns["title"].Width = (Pwidth / 14 )*3;
            dataGridView1.Columns["title"].DisplayIndex = 2;
          
            dataGridView1.Columns["riallyP"].HeaderText = "کل هزینه پیش بینی ریالی";
            dataGridView1.Columns["riallyP"].Width = (Pwidth / 14)*3;
            dataGridView1.Columns["riallyP"].DisplayIndex = 3;
            dataGridView1.Columns["riallyN"].HeaderText = "کل هزینه نهایی ریالی";
            dataGridView1.Columns["riallyN"].Width = (Pwidth / 14) * 3;
            dataGridView1.Columns["riallyN"].DisplayIndex = 4;
            dataGridView1.Columns["riallyN"].DefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.Columns["riallyN"].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns["dollaryP"].HeaderText = "کل هزینه پیش بینی دلاری";
            dataGridView1.Columns["dollaryP"].Width = (Pwidth / 14) * 3;
            dataGridView1.Columns["riallyN"].DisplayIndex = 5;
            dataGridView1.Columns["dollaryN"].HeaderText = "کل هزینه نهایی دلاری";
            dataGridView1.Columns["dollaryN"].Width = (Pwidth / 14) * 3;
            dataGridView1.Columns["riallyN"].DisplayIndex = 6;
            dataGridView1.Columns["dollaryN"].DefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.Columns["dollaryN"].DefaultCellStyle.ForeColor = Color.White;

            dataGridView1.Columns["shenasnameID"].Visible = false;
           // dataGridView1.Columns["ID"].Visible = false;






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



        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            Form7_addEjraeiat form7 = new Form7_addEjraeiat();
            form7.Show();

        }

        private void label18_Click_1(object sender, EventArgs e)
        {
            Form8_Money_Personal form8 = new Form8_Money_Personal();
            form8.Show();
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

        private void label17_Click(object sender, EventArgs e)
        {
            Form5_shenasnameList form = new Form5_shenasnameList();
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

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
