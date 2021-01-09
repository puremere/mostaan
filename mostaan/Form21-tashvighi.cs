﻿using mostaan.Classes;
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
    public partial class Form21_tashvighi : Form
    {
        public Form21_tashvighi()
        {
            int shenasnameID = GlobalVariable.shenasnameID;
          
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
            radPanel4.PanelElement.PanelFill.BackColor = Color.White;

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
            radPanel10.PanelElement.PanelFill.BackColor = Color.Violet;

            radPanel1.PanelElement.Shape = new RoundRectShape();
            radPanel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel1.PanelElement.PanelFill.BackColor = Color.White;




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


            using (var dbcontext = new Model.Context())
            {
                List<Model.tashvighi> lst = (from p in dbcontext.tashvighis where p.shenasnameID == shenasnameID select p).ToList();
                dataGridView1.DataSource = lst;
                foreach (var item in lst)
                {
                    item.ID = lst.IndexOf(item) + 1;
                }
            }





            dataGridView1.Width = 1200;

            dataGridView1.Columns["ID"].HeaderText = "ردیف";
            dataGridView1.Columns["ID"].Width = 120;
            dataGridView1.Columns["ID"].DisplayIndex = 1;
            dataGridView1.Columns["title"].HeaderText = "گام تشویقی";
            dataGridView1.Columns["title"].Width = 216;
            dataGridView1.Columns["title"].DisplayIndex = 2;
            dataGridView1.Columns["title"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            dataGridView1.Columns["title"].HeaderText = "تشریح تحویلی";
            dataGridView1.Columns["title"].Width = 216;
            dataGridView1.Columns["title"].DisplayIndex = 3;
            dataGridView1.Columns["title"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;


            dataGridView1.Columns["kollPR"].HeaderText = "مبلغ هزینه ریالی";
            dataGridView1.Columns["kollPR"].Width = 216;
            dataGridView1.Columns["kollPR"].DisplayIndex = 4;
           
            dataGridView1.Columns["kollPD"].HeaderText = "مبلغ هزینه دلاری";
            dataGridView1.Columns["kollPD"].Width = 216;
            dataGridView1.Columns["kollPD"].DisplayIndex = 5;
           
            dataGridView1.Columns["shenasnameID"].Visible = false;

            // dataGridView1.Columns["ID"].Visible = false;







            dataGridView1.Columns[0].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[1].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[2].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[3].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[4].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[5].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            
           

            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var dbcontext = new Model.Context())
            {
                int iSelectedGridIndex = dataGridView1.CurrentCell.ColumnIndex;
                if (iSelectedGridIndex != 0)
                    return;
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                string rowID = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();

                Model.tashvighi model = dbcontext.tashvighis.SingleOrDefault(x => x.title == rowID);
                dbcontext.Entry(model).State = EntityState.Deleted;
                dbcontext.SaveChanges();
                int index = 0;
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "Form21_tashvighi")
                    {
                        break;
                    }

                    index += 1;
                }
                this.Hide();

                Application.OpenForms[index].Close();
                Form21_tashvighi form13 = new Form21_tashvighi();
                form13.Show();
            }
        }



        private void label17_Click(object sender, EventArgs e)
        {
            Form19_saryer form = new Form19_saryer();
            form.Show();
            this.Hide();
        }


        private void label18_Click(object sender, EventArgs e)
        {
            //Form21_tashvighi form = new Form21_tashvighi();
            //form.Show();
            //this.Hide();
            int shenasnameID = GlobalVariable.shenasnameID;
            using (var dbcontext = new Model.Context())
            {
                shenasname shen = dbcontext.shenasnames.SingleOrDefault(x => x.ID == shenasnameID);
                shen.isDone = true;
                dbcontext.SaveChanges();
            }
                
            this.Hide();
            Form5_shenasnameList form5 = new Form5_shenasnameList();
            form5.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form22_addTashvighi form = new Form22_addTashvighi();
            form.Show();

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
    }
}