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

namespace mostaan
{
    public partial class Form16_omraniAddForm : Form
    {
        functions fns = new functions();
        Model.Context dbcontext = new Model.Context();
        public Form16_omraniAddForm()
        {
            InitializeComponent();
            FontClass fontclass = new FontClass();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            this.MaximizeBox = false;
            this.CenterToScreen();

            radPanel1.PanelElement.Shape = new RoundRectShape();
            radPanel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel1.PanelElement.PanelFill.BackColor = Color.White;


            radPanel2.PanelElement.Shape = new RoundRectShape();
            radPanel2.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel2.PanelElement.PanelFill.BackColor = Color.White;


            radPanel3.PanelElement.Shape = new RoundRectShape();
            radPanel3.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel3.PanelElement.PanelFill.BackColor = Color.White;


            radPanel7.PanelElement.Shape = new RoundRectShape();
            radPanel7.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel7.PanelElement.PanelFill.BackColor = Color.Violet;

        }
        private void label7_Click(object sender, EventArgs e)
        {
            Model.omrani model = new Model.omrani()
            {
                kollPD = Int32.Parse(dollari.Text),
                kollPR = Int32.Parse(rially.Text),
                title = title.Text,
                 zirbana = Int32.Parse(zirbana.Text),
                shenasnameID = GlobalVariable.shenasnameID,


            };
            dbcontext.omranis.Add(model);
            dbcontext.SaveChanges();
            int index = 0;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "Form15_addOmrani")
                {
                    break;
                }

                index += 1;
            }
            this.Hide();

            Application.OpenForms[index].Close();
            Form15_addOmrani form15 = new Form15_addOmrani();
            form15.Show();
        }
        private void notEmpty(object sender, CancelEventArgs e)
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

        private void isDigit(object sender, CancelEventArgs e)
        {
            var cnt = sender as TextBox;
            var boolianvar = fns.IsDigitsOnly(cnt.Text);
            if (cnt.Text.Count() < 1 || !boolianvar)
            {
                e.Cancel = true;
                messageLable.Text = "فیلد مورد باید شامل عدد باشد";


            }
            else
            {
                messageLable.Text = "";
            }
        }

    }
}