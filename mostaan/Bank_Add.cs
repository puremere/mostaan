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

namespace mostaan
{
    public partial class Bank_Add : Form
    {
        public Bank_Add()
        {
            InitializeComponent();
            FontClass fontclass = new FontClass();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            this.MaximizeBox = false;
            this.CenterToScreen();
        }

        private void filter_Click(object sender, EventArgs e)
        {
            using (Model.Context dbcontext = new Model.Context())
            {
                bank newBank = new bank()
                {
                    number = shomareHesab.Text,
                    title = name.Text,
                    type = bankType.SelectedItem.ToString(),
                   
                };
                dbcontext.banks.Add(newBank);
                dbcontext.SaveChanges();

                DataTable dt = new DataTable();
                Bank_List userList = new Bank_List(dt);
                userList.Show();
                this.Hide();
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
            DataTable dt = new DataTable();
            Bank_List form = new Bank_List(dt);
            form.Show();
            this.Hide();
        }
    }
}
