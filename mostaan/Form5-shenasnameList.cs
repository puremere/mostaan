using mostaan.Classes;
using mostaan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace mostaan
{
    public partial class Form5_shenasnameList : Form
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        Model.Context dbcontext = new Model.Context();
        public Form5_shenasnameList()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.CenterToScreen();
            FontClass fontclass = new FontClass();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            List<Model.shenasname> lst = new List<shenasname>();
            var q = dbcontext.shenasnames.Where(x => x.ID == x.parent || x.final == 0).OrderByDescending(x=>x.ID);// && x.isDone != true
            if (q != null)
            {
                lst = q.ToList();
                foreach(var item in lst)
                {
                    item.datestring = item.date.ToPersianDateString();
                }
            }
            if (lst.Count == 0)
            {
                return;
            }



            dataGridView1.DataSource = lst;

            dataGridView1.Columns["ID"].HeaderText = "شناسه";
            dataGridView1.Columns["ID"].Width = 250;
            dataGridView1.Columns["ID"].DisplayIndex = 3;

            dataGridView1.Columns["title"].HeaderText = "عنوان";
            dataGridView1.Columns["title"].Width = 250;
            dataGridView1.Columns["title"].DisplayIndex = 4;
            
            dataGridView1.Columns["hadaf"].HeaderText = "هدف پروژه";
            dataGridView1.Columns["hadaf"].Width = 250;
            dataGridView1.Columns["hadaf"].DisplayIndex = 5;

            dataGridView1.Columns["dastgah"].HeaderText = "دستگاه اجرایی پیشنهاد دهنده";
            dataGridView1.Columns["dastgah"].Width = 250;
            dataGridView1.Columns["dastgah"].DisplayIndex = 6;

            dataGridView1.Columns["datestring"].HeaderText = "تاریخ ارائه طرح";
            dataGridView1.Columns["datestring"].Width = 250;
            dataGridView1.Columns["datestring"].DisplayIndex = 7;

            dataGridView1.Columns[6].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[1].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[2].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[3].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[4].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[5].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[6].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[7].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[8].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;

            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.Visible = false;
            }
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns["datestring"].Visible = true;
            dataGridView1.Columns["dastgah"].Visible = true;
            dataGridView1.Columns["hadaf"].Visible = true;
            dataGridView1.Columns["title"].Visible = true;
            dataGridView1.Columns["ID"].Visible = true;
            



            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.DefaultCellStyle.Font = GlobalVariable.headerlistFONTsmall;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            //int zarib = 0;

            //Telerik.WinControls.UI.RadPanel haderPanel = new Telerik.WinControls.UI.RadPanel();
            //haderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            //haderPanel.Padding = new System.Windows.Forms.Padding(5);
            //haderPanel.Height = 50;
            //haderPanel.PanelElement.Shape = new RoundRectShape();
            //haderPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //haderPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            //((Telerik.WinControls.Primitives.BorderPrimitive)(haderPanel.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

            //System.Windows.Forms.Label haderPanelLable = new System.Windows.Forms.Label();
            //haderPanelLable.BackColor = System.Drawing.Color.Transparent;
            //haderPanelLable.Dock = System.Windows.Forms.DockStyle.Fill;
            //haderPanelLable.ForeColor = System.Drawing.Color.White;
            //haderPanelLable.Location = new System.Drawing.Point(5, 5);
            //haderPanelLable.TabIndex = 0;
            //haderPanelLable.Text = "لیست شناسنامه پروژه";
            //haderPanelLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //haderPanelLable.AutoSize = false;
            //haderPanelLable.Font = GlobalVariable.headerlistFONTBold;

            //haderPanel.Controls.Add(haderPanelLable);
            //this.panelHolder.Controls.Add(haderPanel);

            //for (int i = 0; i< lst.Count; i = i+2)
            //{

            //    Telerik.WinControls.UI.RadPanel radPanel = new Telerik.WinControls.UI.RadPanel();
            //    radPanel.Dock = System.Windows.Forms.DockStyle.Bottom; 
            //    radPanel.Padding = new System.Windows.Forms.Padding(15);
            //    radPanel.Width = this.panelHolder.Width;
            //    ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            //    ((Telerik.WinControls.Primitives.FillPrimitive)(radPanel.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Transparent;
            //    ((Telerik.WinControls.Primitives.FillPrimitive)(radPanel.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Transparent;
            //    ((Telerik.WinControls.Primitives.FillPrimitive)(radPanel.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Transparent;
            //    ((Telerik.WinControls.Primitives.FillPrimitive)(radPanel.GetChildAt(0).GetChildAt(0))).GradientStyle = Telerik.WinControls.GradientStyles.Linear;
            //    ((Telerik.WinControls.Primitives.FillPrimitive)(radPanel.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;

            //    System.Windows.Forms.TableLayoutPanel table =  new System.Windows.Forms.TableLayoutPanel();
            //    table.ColumnCount = 2;
            //    table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //    table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //    table.Dock = System.Windows.Forms.DockStyle.Fill;
            //    table.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            //    if (lst.Count() > i)
            //    {
            //        Telerik.WinControls.UI.RadPanel radPanel20 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel20.Dock = System.Windows.Forms.DockStyle.Fill;
            //        radPanel20.Padding = new System.Windows.Forms.Padding(20);
            //        radPanel20.PanelElement.Shape = new RoundRectShape();
            //        radPanel20.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel20.PanelElement.PanelFill.BackColor = Color.Transparent;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel20.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;


            //        Telerik.WinControls.UI.RadPanel radPanel21 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            //        // radPanel21.Padding = new System.Windows.Forms.Padding(15);
            //        radPanel21.PanelElement.Shape = new RoundRectShape();
            //        radPanel21.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel21.PanelElement.PanelFill.BackColor = Color.White;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel21.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            //        //((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel21.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(90)))), ((int)(((byte)(222)))));
            //        zarib = radPanel21.Height;
            //        Telerik.WinControls.UI.RadPanel radPanel22 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel22.Dock = System.Windows.Forms.DockStyle.Top;
            //        radPanel22.Padding = new System.Windows.Forms.Padding(0);
            //        radPanel22.PanelElement.Shape = new RoundRectShape();
            //        radPanel22.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel22.PanelElement.PanelFill.BackColor = Color.Gray;
            //        radPanel22.Height = 50;


            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel22.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

            //        System.Windows.Forms.Label lable22 = new System.Windows.Forms.Label();
            //        lable22.BackColor = System.Drawing.Color.Transparent;
            //        lable22.Dock = System.Windows.Forms.DockStyle.Fill;
            //        lable22.ForeColor = System.Drawing.Color.White;
            //        lable22.Location = new System.Drawing.Point(5, 5);
            //        lable22.TabIndex = 0;
            //        lable22.Text = lst[i].title;
            //        lable22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //        lable22.AutoSize = false;
            //        lable22.Font = GlobalVariable.headerlistFONTsmall;


            //        Telerik.WinControls.UI.RadPanel radPanel23 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel23.Dock = System.Windows.Forms.DockStyle.Top;
            //        radPanel23.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            //        radPanel23.Height = 50;
            //        radPanel23.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel23.PanelElement.PanelFill.BackColor = Color.White;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel23.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            //        radPanel23.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            //        System.Windows.Forms.Label lable23 = new System.Windows.Forms.Label();
            //        lable23.BackColor = System.Drawing.Color.Transparent;
            //        lable23.Dock = System.Windows.Forms.DockStyle.Fill;
            //        lable23.ForeColor = System.Drawing.Color.Black;
            //        lable23.Location = new System.Drawing.Point(5, 5);
            //        lable23.TabIndex = 0;
            //        lable23.Text = "هدف پروژه :";
            //        lable23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //        lable23.AutoSize = false;
            //        lable23.Font = GlobalVariable.headerlistFONTBold;
            //        lable23.RightToLeft = System.Windows.Forms.RightToLeft.Yes;



            //        Telerik.WinControls.UI.RadPanel radPanel24 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel24.Dock = System.Windows.Forms.DockStyle.Top;
            //        radPanel24.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            //        radPanel24.Height = 50;
            //        radPanel24.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel24.PanelElement.PanelFill.BackColor = Color.White;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel24.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;



            //        System.Windows.Forms.Label lable24 = new System.Windows.Forms.Label();
            //        lable24.BackColor = System.Drawing.Color.Transparent;
            //        lable24.Dock = System.Windows.Forms.DockStyle.Fill;
            //        lable24.ForeColor = System.Drawing.Color.Black;
            //        lable24.Location = new System.Drawing.Point(5, 5);
            //        lable24.TabIndex = 0;
            //        lable24.Text = lst[i].hadaf == null ? "" : lst[i].hadaf.ToString();
            //        lable24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //        lable24.AutoSize = false;
            //        lable24.Font = GlobalVariable.headerlistFONTsmall;
            //        lable24.RightToLeft = System.Windows.Forms.RightToLeft.Yes;


            //        Telerik.WinControls.UI.RadPanel radPanel25 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel25.Dock = System.Windows.Forms.DockStyle.Top;
            //        radPanel25.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            //        radPanel25.Height = 50;
            //        radPanel25.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel25.PanelElement.PanelFill.BackColor = Color.White;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel25.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;



            //        System.Windows.Forms.Label lable25 = new System.Windows.Forms.Label();
            //        lable25.BackColor = System.Drawing.Color.Transparent;
            //        lable25.Dock = System.Windows.Forms.DockStyle.Fill;
            //        lable25.ForeColor = System.Drawing.Color.Black;
            //        lable25.Location = new System.Drawing.Point(5, 5);
            //        lable25.TabIndex = 0;
            //        lable25.Text = "دستگاه اجرایی پیشنهاد دهنده :";
            //        lable25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //        lable25.AutoSize = false;
            //        lable25.Font = GlobalVariable.headerlistFONTBold;
            //        lable25.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            //        Telerik.WinControls.UI.RadPanel radPanel26 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel26.Dock = System.Windows.Forms.DockStyle.Top;
            //        radPanel26.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            //        radPanel26.Height = 50;
            //        radPanel26.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel26.PanelElement.PanelFill.BackColor = Color.White;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel26.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;


            //        System.Windows.Forms.Label lable26 = new System.Windows.Forms.Label();
            //        lable26.BackColor = System.Drawing.Color.Transparent;
            //        lable26.Dock = System.Windows.Forms.DockStyle.Fill;
            //        lable26.ForeColor = System.Drawing.Color.Black;
            //        lable26.Location = new System.Drawing.Point(5, 5);
            //        lable26.TabIndex = 0;
            //        lable26.Text = lst[i].dastgah;
            //        lable26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //        lable26.AutoSize = false;
            //        lable26.Font = GlobalVariable.headerlistFONTsmall;

            //        Telerik.WinControls.UI.RadPanel radPanel27 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel27.Dock = System.Windows.Forms.DockStyle.Top;
            //        radPanel27.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            //        radPanel27.Height = 50;
            //        radPanel27.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel27.PanelElement.PanelFill.BackColor = Color.White;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel27.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;


            //        System.Windows.Forms.Label lable27 = new System.Windows.Forms.Label();
            //        lable27.BackColor = System.Drawing.Color.Transparent;
            //        lable27.Dock = System.Windows.Forms.DockStyle.Fill;
            //        lable27.ForeColor = System.Drawing.Color.Black;
            //        lable27.Location = new System.Drawing.Point(5, 5);
            //        lable27.TabIndex = 0;
            //        lable27.Text = "تاریخ ارائه طرح :";
            //        lable27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //        lable27.AutoSize = false;
            //        lable27.Font = GlobalVariable.headerlistFONTBold;
            //        lable27.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            //        Telerik.WinControls.UI.RadPanel radPanel28 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel28.Dock = System.Windows.Forms.DockStyle.Top;
            //        radPanel28.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            //        radPanel28.Height = 50;
            //        radPanel28.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel28.PanelElement.PanelFill.BackColor = Color.White;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel28.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;


            //        System.Windows.Forms.Label lable28 = new System.Windows.Forms.Label();
            //        lable28.BackColor = System.Drawing.Color.Transparent;
            //        lable28.Dock = System.Windows.Forms.DockStyle.Fill;
            //        lable28.ForeColor = System.Drawing.Color.Black;
            //        lable28.Location = new System.Drawing.Point(5, 5);
            //        lable28.TabIndex = 0;
            //        lable28.Text =lst[i].date.ToPersianDateString();
            //        lable28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //        lable28.AutoSize = false;
            //        lable28.Font = GlobalVariable.headerlistFONTsmall;

            //        Telerik.WinControls.UI.RadPanel radPanel29 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel29.Dock = System.Windows.Forms.DockStyle.Top;
            //        radPanel29.Padding = new System.Windows.Forms.Padding(25, 5, 25, 5);
            //        radPanel29.Height = 50;
            //        radPanel29.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel29.PanelElement.PanelFill.BackColor = Color.White;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel29.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;






            //        if (lst[i].isDone == true)
            //        {
            //            Telerik.WinControls.UI.RadPanel radPanel292 = new Telerik.WinControls.UI.RadPanel();
            //            radPanel292.Dock = System.Windows.Forms.DockStyle.Right;
            //            radPanel292.Padding = new System.Windows.Forms.Padding(5);
            //            radPanel292.Height = 50;
            //            radPanel292.Width = radPanel29.Width / 2;
            //            radPanel292.PanelElement.Shape = new RoundRectShape();
            //            radPanel292.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //            radPanel292.PanelElement.PanelFill.BackColor = Color.Purple;
            //            ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel292.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;



            //            System.Windows.Forms.Label lable292 = new System.Windows.Forms.Label();
            //            lable292.BackColor = System.Drawing.Color.Transparent;
            //            lable292.Dock = System.Windows.Forms.DockStyle.Fill;
            //            lable292.ForeColor = System.Drawing.Color.White;
            //            lable292.Location = new System.Drawing.Point(5, 5);
            //            lable292.TabIndex = 0;
            //            lable292.Name ="H"+ lst[i].ID.ToString();
            //            lable292.Text = "مشاهده نسخه ها";
            //            lable292.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //            lable292.AutoSize = false;
            //            lable292.Font = GlobalVariable.headerlistFONTsupecSmall;
            //            lable292.Click += new System.EventHandler(showCopies);






            //            radPanel29.Controls.Add(radPanel292);
            //            radPanel292.Controls.Add(lable292);
            //        }
            //        else
            //        {
            //            Telerik.WinControls.UI.RadPanel radPanel291 = new Telerik.WinControls.UI.RadPanel();
            //            radPanel291.Dock = System.Windows.Forms.DockStyle.Left;
            //            radPanel291.Padding = new System.Windows.Forms.Padding(5);
            //            radPanel291.Height = 50;
            //            radPanel291.Width = radPanel29.Width / 2;
            //            radPanel291.PanelElement.Shape = new RoundRectShape();
            //            radPanel291.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //            radPanel291.PanelElement.PanelFill.BackColor = Color.Red;
            //            ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel291.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

            //            System.Windows.Forms.Label lable291 = new System.Windows.Forms.Label();
            //            lable291.BackColor = System.Drawing.Color.Transparent;
            //            lable291.Dock = System.Windows.Forms.DockStyle.Fill;
            //            lable291.ForeColor = System.Drawing.Color.White;
            //            lable291.Location = new System.Drawing.Point(5, 5);
            //            lable291.TabIndex = 0;
            //            lable291.Text = "حذف";
            //            lable291.Name = "D" + lst[i].ID.ToString();
            //            lable291.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //            lable291.AutoSize = false;
            //            lable291.Font = GlobalVariable.headerlistFONTsupecSmall;
            //            lable291.Click += new System.EventHandler(DeleteItem);


            //            Telerik.WinControls.UI.RadPanel radPanel292 = new Telerik.WinControls.UI.RadPanel();
            //            radPanel292.Dock = System.Windows.Forms.DockStyle.Right;
            //            radPanel292.Padding = new System.Windows.Forms.Padding(5);
            //            radPanel292.Height = 50;
            //            radPanel292.Width = radPanel29.Width / 2;
            //            radPanel292.PanelElement.Shape = new RoundRectShape();
            //            radPanel292.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //            radPanel292.PanelElement.PanelFill.BackColor = Color.Purple;
            //            ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel292.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;



            //            System.Windows.Forms.Label lable292 = new System.Windows.Forms.Label();
            //            lable292.BackColor = System.Drawing.Color.Transparent;
            //            lable292.Dock = System.Windows.Forms.DockStyle.Fill;
            //            lable292.ForeColor = System.Drawing.Color.White;
            //            lable292.Location = new System.Drawing.Point(5, 5);
            //            lable292.TabIndex = 0;
            //            lable292.Name = lst[i].ID.ToString();
            //            lable292.Text = "ویرایش";

            //            lable292.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //            lable292.AutoSize = false;
            //            lable292.Font = GlobalVariable.headerlistFONTsupecSmall;
            //            lable292.Click += new System.EventHandler(viewDetail);

            //            radPanel29.Controls.Add(radPanel291);
            //            radPanel291.Controls.Add(lable291);

            //            radPanel29.Controls.Add(radPanel292);
            //            radPanel292.Controls.Add(lable292);
            //        }








            //        radPanel22.Controls.Add(lable22);
            //        radPanel23.Controls.Add(lable23);
            //        radPanel24.Controls.Add(lable24);
            //        radPanel25.Controls.Add(lable25);
            //        radPanel26.Controls.Add(lable26);
            //        radPanel27.Controls.Add(lable27);
            //        radPanel28.Controls.Add(lable28);





            //        radPanel21.Controls.Add(radPanel29);
            //        radPanel21.Controls.Add(radPanel28);
            //        radPanel21.Controls.Add(radPanel27);
            //        radPanel21.Controls.Add(radPanel26);
            //        radPanel21.Controls.Add(radPanel25);
            //        radPanel21.Controls.Add(radPanel24);
            //        radPanel21.Controls.Add(radPanel23);
            //        radPanel21.Controls.Add(radPanel22);

            //        radPanel20.Controls.Add(radPanel21);

            //        table.Controls.Add(radPanel20);


            //    }

            //    if (lst.Count() > (i +1))
            //    {
            //        i += 1; 
            //        Telerik.WinControls.UI.RadPanel radPanel30 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel30.Dock = System.Windows.Forms.DockStyle.Fill;
            //        radPanel30.Padding = new System.Windows.Forms.Padding(20);
            //        radPanel30.PanelElement.Shape = new RoundRectShape();
            //        radPanel30.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel30.PanelElement.PanelFill.BackColor = Color.Transparent;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel30.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;


            //        Telerik.WinControls.UI.RadPanel radPanel31 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel31.Dock = System.Windows.Forms.DockStyle.Fill;
            //        // radPanel31.Padding = new System.Windows.Forms.Padding(15);
            //        radPanel31.PanelElement.Shape = new RoundRectShape();
            //        radPanel31.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel31.PanelElement.PanelFill.BackColor = Color.White;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel31.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            //        //((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel31.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(90)))), ((int)(((byte)(222)))));

            //        Telerik.WinControls.UI.RadPanel radPanel32 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel32.Dock = System.Windows.Forms.DockStyle.Top;
            //        radPanel32.Padding = new System.Windows.Forms.Padding(0);
            //        radPanel32.PanelElement.Shape = new RoundRectShape();
            //        radPanel32.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel32.PanelElement.PanelFill.BackColor = Color.Gray;
            //        radPanel32.Height = 50;


            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel32.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

            //        System.Windows.Forms.Label lable32 = new System.Windows.Forms.Label();
            //        lable32.BackColor = System.Drawing.Color.Transparent;
            //        lable32.Dock = System.Windows.Forms.DockStyle.Fill;
            //        lable32.ForeColor = System.Drawing.Color.White;
            //        lable32.Location = new System.Drawing.Point(5, 5);
            //        lable32.TabIndex = 0;
            //        lable32.Text = lst[i].title;
            //        lable32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //        lable32.AutoSize = false;
            //        lable32.Font = GlobalVariable.headerlistFONTsmall;


            //        Telerik.WinControls.UI.RadPanel radPanel33 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel33.Dock = System.Windows.Forms.DockStyle.Top;
            //        radPanel33.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            //        radPanel33.Height = 50;
            //        radPanel33.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel33.PanelElement.PanelFill.BackColor = Color.White;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel33.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;


            //        System.Windows.Forms.Label lable33 = new System.Windows.Forms.Label();
            //        lable33.BackColor = System.Drawing.Color.Transparent;
            //        lable33.Dock = System.Windows.Forms.DockStyle.Fill;
            //        lable33.ForeColor = System.Drawing.Color.Black;
            //        lable33.Location = new System.Drawing.Point(5, 5);
            //        lable33.TabIndex = 0;
            //        lable33.Text = "هدف پروژه :";
            //        lable33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //        lable33.AutoSize = false;
            //        lable33.Font = GlobalVariable.headerlistFONTBold;


            //        Telerik.WinControls.UI.RadPanel radPanel34 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel34.Dock = System.Windows.Forms.DockStyle.Top;
            //        radPanel34.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            //        radPanel34.Height = 50;
            //        radPanel34.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel34.PanelElement.PanelFill.BackColor = Color.White;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel34.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;



            //        System.Windows.Forms.Label lable34 = new System.Windows.Forms.Label();
            //        lable34.BackColor = System.Drawing.Color.Transparent;
            //        lable34.Dock = System.Windows.Forms.DockStyle.Fill;
            //        lable34.ForeColor = System.Drawing.Color.Black;
            //        lable34.Location = new System.Drawing.Point(5, 5);
            //        lable34.TabIndex = 0;
            //        lable34.Text = lst[i].hadaf;
            //        lable34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //        lable34.AutoSize = false;
            //        lable34.Font = GlobalVariable.headerlistFONTsmall;


            //        Telerik.WinControls.UI.RadPanel radPanel35 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel35.Dock = System.Windows.Forms.DockStyle.Top;
            //        radPanel35.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            //        radPanel35.Height = 50;
            //        radPanel35.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel35.PanelElement.PanelFill.BackColor = Color.White;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel35.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;



            //        System.Windows.Forms.Label lable35 = new System.Windows.Forms.Label();
            //        lable35.BackColor = System.Drawing.Color.Transparent;
            //        lable35.Dock = System.Windows.Forms.DockStyle.Fill;
            //        lable35.ForeColor = System.Drawing.Color.Black;
            //        lable35.Location = new System.Drawing.Point(5, 5);
            //        lable35.TabIndex = 0;
            //        lable35.Text = "دستگاه اجرایی پیشنهاد دهنده :";
            //        lable35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //        lable35.AutoSize = false;
            //        lable35.Font = GlobalVariable.headerlistFONTBold;


            //        Telerik.WinControls.UI.RadPanel radPanel36 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel36.Dock = System.Windows.Forms.DockStyle.Top;
            //        radPanel36.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            //        radPanel36.Height = 50;
            //        radPanel36.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel36.PanelElement.PanelFill.BackColor = Color.White;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel36.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;


            //        System.Windows.Forms.Label lable36 = new System.Windows.Forms.Label();
            //        lable36.BackColor = System.Drawing.Color.Transparent;
            //        lable36.Dock = System.Windows.Forms.DockStyle.Fill;
            //        lable36.ForeColor = System.Drawing.Color.Black;
            //        lable36.Location = new System.Drawing.Point(5, 5);
            //        lable36.TabIndex = 0;
            //        lable36.Text = lst[i].dastgah;
            //        lable36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //        lable36.AutoSize = false;
            //        lable36.Font = GlobalVariable.headerlistFONTsmall;

            //        Telerik.WinControls.UI.RadPanel radPanel37 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel37.Dock = System.Windows.Forms.DockStyle.Top;
            //        radPanel37.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            //        radPanel37.Height = 50;
            //        radPanel37.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel37.PanelElement.PanelFill.BackColor = Color.White;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel37.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;


            //        System.Windows.Forms.Label lable37 = new System.Windows.Forms.Label();
            //        lable37.BackColor = System.Drawing.Color.Transparent;
            //        lable37.Dock = System.Windows.Forms.DockStyle.Fill;
            //        lable37.ForeColor = System.Drawing.Color.Black;
            //        lable37.Location = new System.Drawing.Point(5, 5);
            //        lable37.TabIndex = 0;
            //        lable37.Text = "تاریخ ارائه طرح :";
            //        lable37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //        lable37.AutoSize = false;
            //        lable37.Font = GlobalVariable.headerlistFONTBold;

            //        Telerik.WinControls.UI.RadPanel radPanel38 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel38.Dock = System.Windows.Forms.DockStyle.Top;
            //        radPanel38.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            //        radPanel38.Height = 50;
            //        radPanel38.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel38.PanelElement.PanelFill.BackColor = Color.White;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel38.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;


            //        System.Windows.Forms.Label lable38 = new System.Windows.Forms.Label();
            //        lable38.BackColor = System.Drawing.Color.Transparent;
            //        lable38.Dock = System.Windows.Forms.DockStyle.Fill;
            //        lable38.ForeColor = System.Drawing.Color.Black;
            //        lable38.Location = new System.Drawing.Point(5, 5);
            //        lable38.TabIndex = 0;
            //        lable38.Text = lst[i].date.ToPersianDateString();
            //        lable38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //        lable38.AutoSize = false;
            //        lable38.Font = GlobalVariable.headerlistFONTsmall;

            //        Telerik.WinControls.UI.RadPanel radPanel39 = new Telerik.WinControls.UI.RadPanel();
            //        radPanel39.Dock = System.Windows.Forms.DockStyle.Top;
            //        radPanel39.Padding = new System.Windows.Forms.Padding(25, 5, 25, 5);
            //        radPanel39.Height = 50;
            //        radPanel39.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //        radPanel39.PanelElement.PanelFill.BackColor = Color.White;
            //        ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel39.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;






            //        if (lst[i].isDone == true)
            //        {
            //            Telerik.WinControls.UI.RadPanel radPanel392 = new Telerik.WinControls.UI.RadPanel();
            //            radPanel392.Dock = System.Windows.Forms.DockStyle.Right;
            //            radPanel392.Padding = new System.Windows.Forms.Padding(5);
            //            radPanel392.Height = 50;
            //            radPanel392.Width = radPanel39.Width / 2;
            //            radPanel392.PanelElement.Shape = new RoundRectShape();
            //            radPanel392.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //            radPanel392.PanelElement.PanelFill.BackColor = Color.Purple;
            //            ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel392.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

            //            System.Windows.Forms.Label lable392 = new System.Windows.Forms.Label();
            //            lable392.BackColor = System.Drawing.Color.Transparent;
            //            lable392.Dock = System.Windows.Forms.DockStyle.Fill;
            //            lable392.ForeColor = System.Drawing.Color.White;
            //            lable392.Location = new System.Drawing.Point(5, 5);
            //            lable392.TabIndex = 0;
            //            lable392.Text = "مشاهده نسخه ها";
            //            lable392.Name = "H" + lst[i].ID.ToString();
            //            lable392.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //            lable392.AutoSize = false;
            //            lable392.Font = GlobalVariable.headerlistFONTsupecSmall;
            //            lable392.Click += new System.EventHandler(showCopies);





            //            radPanel39.Controls.Add(radPanel392);

            //            radPanel392.Controls.Add(lable392);
            //        }
            //        else
            //        {


            //            Telerik.WinControls.UI.RadPanel radPanel391 = new Telerik.WinControls.UI.RadPanel();
            //            radPanel391.Dock = System.Windows.Forms.DockStyle.Left;
            //            radPanel391.Padding = new System.Windows.Forms.Padding(5);
            //            radPanel391.Height = 50;
            //            radPanel391.Width = radPanel39.Width / 2;
            //            radPanel391.PanelElement.Shape = new RoundRectShape();
            //            radPanel391.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //            radPanel391.PanelElement.PanelFill.BackColor = Color.Red;
            //            ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel391.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

            //            System.Windows.Forms.Label lable391 = new System.Windows.Forms.Label();
            //            lable391.BackColor = System.Drawing.Color.Transparent;
            //            lable391.Dock = System.Windows.Forms.DockStyle.Fill;
            //            lable391.ForeColor = System.Drawing.Color.White;
            //            lable391.Location = new System.Drawing.Point(5, 5);
            //            lable391.TabIndex = 0;
            //            lable391.Text = "حذف";
            //            lable391.Name = "D" + lst[i].ID.ToString();
            //            lable391.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //            lable391.AutoSize = false;
            //            lable391.Font = GlobalVariable.headerlistFONTsupecSmall;
            //            lable391.Click += new System.EventHandler(DeleteItem);



            //            Telerik.WinControls.UI.RadPanel radPanel392 = new Telerik.WinControls.UI.RadPanel();
            //            radPanel392.Dock = System.Windows.Forms.DockStyle.Right;
            //            radPanel392.Padding = new System.Windows.Forms.Padding(5);
            //            radPanel392.Height = 50;
            //            radPanel392.Width = radPanel39.Width / 2;
            //            radPanel392.PanelElement.Shape = new RoundRectShape();
            //            radPanel392.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //            radPanel392.PanelElement.PanelFill.BackColor = Color.Purple;
            //            ((Telerik.WinControls.Primitives.BorderPrimitive)(radPanel392.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

            //            System.Windows.Forms.Label lable392 = new System.Windows.Forms.Label();
            //            lable392.BackColor = System.Drawing.Color.Transparent;
            //            lable392.Dock = System.Windows.Forms.DockStyle.Fill;
            //            lable392.ForeColor = System.Drawing.Color.White;
            //            lable392.Location = new System.Drawing.Point(5, 5);
            //            lable392.TabIndex = 0;
            //            lable392.Text = "ویرایش";

            //            lable392.Name = lst[i].ID.ToString();
            //            lable392.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //            lable392.AutoSize = false;
            //            lable392.Font = GlobalVariable.headerlistFONTsupecSmall;
            //            lable392.Click += new System.EventHandler(viewDetail);



            //            radPanel39.Controls.Add(radPanel391);

            //            radPanel391.Controls.Add(lable391);


            //            radPanel39.Controls.Add(radPanel392);
            //            radPanel392.Controls.Add(lable392);

            //        }







            //        radPanel32.Controls.Add(lable32);
            //        radPanel33.Controls.Add(lable33);
            //        radPanel34.Controls.Add(lable34);
            //        radPanel35.Controls.Add(lable35);
            //        radPanel36.Controls.Add(lable36);
            //        radPanel37.Controls.Add(lable37);
            //        radPanel38.Controls.Add(lable38);






            //        radPanel31.Controls.Add(radPanel39);
            //        radPanel31.Controls.Add(radPanel38);
            //        radPanel31.Controls.Add(radPanel37);
            //        radPanel31.Controls.Add(radPanel36);
            //        radPanel31.Controls.Add(radPanel35);
            //        radPanel31.Controls.Add(radPanel34);
            //        radPanel31.Controls.Add(radPanel33);
            //        radPanel31.Controls.Add(radPanel32);


            //        radPanel30.Controls.Add(radPanel31);
            //        table.Controls.Add(radPanel30);


            //        i -= 1;
            //    }



            //    radPanel.Height =500;

            //    radPanel.Controls.Add(table);
            //    this.panelHolder.Controls.Add(radPanel);





            //}

            //int addon = (lst.Count % 2) > 0 ? 1 : 0;
            //this.panelHolder.Height =  ((lst.Count/2) + addon) * 500  + 50;

            //this.radVScrollBar1.Maximum = this.panelHolder.Size.Height - this.radPanel1.Size.Height;




        }
      
       
        private void viewDetail(string elid)
        {
            
            string id = elid;
            GlobalVariable.shenasnameID = id;
            Form2_shenasnameAdd form2 = new Form2_shenasnameAdd();
            form2.Show();

        }
        private void DeleteItem(string elid)
        {

            try
            {

                string id = elid;
                GlobalVariable.shenasnameID = id;



                List<shenasnameGam> gamList = dbcontext.shenasnameGams.Where(x => x.shenasnameID == id).ToList();
                List<shenasnameFounder> founderList = dbcontext.shenasnameFounders.Where(x => x.shenasnameID == id).ToList();
                List<ejraeiat> ejraeatList = dbcontext.ejraeiats.Where(x => x.shenasnameID == id).ToList();
                List<sarmaye> sarmayeslist = dbcontext.sarmayes.Where(x => x.shenasnameID == id).ToList();
                List<masrafi> masrafislist = dbcontext.masrafis.Where(x => x.shenasnameID == id).ToList();
                List<edari> edarislist = dbcontext.edaris.Where(x => x.shenasnameID == id).ToList();
                List<omrani> omranilist = dbcontext.omranis.Where(x => x.shenasnameID == id).ToList();
                List<gharardad> gharardadslist = dbcontext.gharardads.Where(x => x.shenasnameID == id).ToList();
                List<sayer> sayerslist = dbcontext.sayers.Where(x => x.shenasnameID == id).ToList();
                List<tashvighi> tashvighislist = dbcontext.tashvighis.Where(x => x.shenasnameID == id).ToList();

                foreach(var item in gamList)
                {
                    dbcontext.shenasnameGams.Remove(item);
                }
                foreach(var item in founderList)
                {
                    dbcontext.shenasnameFounders.Remove(item);
                }
                foreach (var item in ejraeatList)
                {
                    dbcontext.ejraeiats.Remove(item);
                }
                foreach (var item in sarmayeslist)
                {
                    dbcontext.sarmayes.Remove(item);
                }
                foreach (var item in masrafislist)
                {
                    dbcontext.masrafis.Remove(item);
                }
                foreach (var item in edarislist)
                {
                    dbcontext.edaris.Remove(item);
                }
                foreach (var item in omranilist)
                {
                    dbcontext.omranis.Remove(item);
                }
                foreach (var item in gharardadslist)
                {
                    dbcontext.gharardads.Remove(item);
                }
                foreach (var item in sayerslist)
                {
                    dbcontext.sayers.Remove(item);
                }
                foreach (var item in tashvighislist)
                {
                    dbcontext.tashvighis.Remove(item);
                }
                

               shenasname delitem = dbcontext.shenasnames.SingleOrDefault(x => x.ID == GlobalVariable.shenasnameID);




                dbcontext.Entry(delitem).State = EntityState.Deleted;
                dbcontext.SaveChanges();
                


                Form5_shenasnameList form2 = new Form5_shenasnameList();
                this.Hide();
                form2.Show();
            }
            catch (Exception errror)
            {
               // message.Text = errror.InnerException.Message;
            }
             

        }
        private void showCopies(string elid)
        {
          
            string id = elid;
            GlobalVariable.shenasnameID = id;
            Form23_showCopies form = new Form23_showCopies();
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            int iSelectedGridIndex = dataGridView1.CurrentCell.ColumnIndex;
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            string rowID = dataGridView1.Rows[rowindex].Cells["ID"].Value.ToString();

            Model.shenasname item = dbcontext.shenasnames.Where(x => x.ID == rowID).FirstOrDefault();
            if (iSelectedGridIndex == 0)
            {
                if (item.final == 1)
                {
                    showCopies(rowID);
                }
            }
            else if (iSelectedGridIndex == 1)
            {
                if (item.final != 1)
                {
                    DeleteItem(rowID);
                }
            }
            else if (iSelectedGridIndex == 2)
            {
                if (item.final != 1)
                {
                    viewDetail(rowID);
                }
            }
            else
            {
                    return;
            }



           
           

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            zero form = new zero();
            form.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1_chooseList intro = new Form1_chooseList();

            intro.Show();
            this.Hide();
        }
    }
}
