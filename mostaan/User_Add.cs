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
    public partial class User_Add : Form
    {
        public User_Add()
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
                user newUser = new user()
                {
                    //family_Number = family_Number.Text,
                    //grade = grade.Text,
                    //madrak = madrak.Text,
                    //madrak_Title = madrak.Text,
                    //maskan = maskan.Text,
                    //meli_Code = meli_Code.Text,
                    //mobile = mobile.Text,
                    name = name.Text,
                    pasdari_Code = pasdari_Code.Text,
                    shomareHesab = shomareHesab.Text,
                    //phone = phone.Text,
                    sazman_Enterdate = DateTime.Now, // sazman_Enterdate.GetSelectedDateInPersianDateTime().ToShortDateString().ToGeorgianDateTime(),
                    Sepah_Enterdate = DateTime.Now, //Sepah_Enterdate.GetSelectedDateInPersianDateTime().ToShortDateString().ToGeorgianDateTime(),
                    //tahol = tahol.Text,
                    //univercity = univercity.Text,
                    //univercity_Score = shomareHesab.Text,
                    //jaygah = jaygah.Text
                };
                dbcontext.users.Add(newUser);
                dbcontext.SaveChanges();

                DataTable dt = new DataTable();
                User_List userList = new User_List(dt);
                userList.Show();
                this.Hide();
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            zero form = new zero();
            form.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            User_List list = new User_List(dt);

            list.Show();
            this.Hide();
        }
    }
}
