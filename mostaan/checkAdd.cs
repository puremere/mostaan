using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mostaan.Classes;
using mostaan.Model;
namespace mostaan
{
    public partial class checkAdd : Form
    {
        
        public checkAdd()
        {
            InitializeComponent();
            FontClass fontclass = new FontClass();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            this.MaximizeBox = false;
            this.CenterToScreen();
            using (Context context = new Context())
            {
                List<Model.bank> bnks = context.banks.ToList();
                
                bankCombo.DataSource = bnks;
                bankCombo.DisplayMember = "FullName";
                bankCombo.ValueMember = "ID";
            }
                
        }

        private void filter_Click(object sender, EventArgs e)
        {
            using (Context dbcontext = new Context())
            {
                if (numberFrom.Text != "" && numberTo.Text != "" && bankCombo.SelectedItem != null && pasvand.Text != "")
                {
                    int from = int.Parse(numberFrom.Text);
                    int tedad = int.Parse(numberTo.Text);
                    if (tedad > 0)
                    {
                        string ischeck = "";
                        for (int i = 0; i < tedad; i++)
                        {

                            string checknumber = pasvand.Text + "/" + (from + i).ToString();
                            int selectedBank = int.Parse(bankCombo.SelectedValue.ToString());
                            List<check> isexist = dbcontext.checks.Where(x => x.checkNumber == checknumber && x.bankID == selectedBank).ToList();
                            if (isexist.Count() >0)
                            {
                                ischeck = checknumber;
                            }

                        }
                        if (ischeck == "")
                        {
                            for (int i = 0; i < tedad; i++)
                            {
                                string checknumber = pasvand.Text + "/" + (from + i).ToString();
                                check isexist = dbcontext.checks.SingleOrDefault(x => x.checkNumber == checknumber);
                                if (isexist == null)
                                {
                                    check model = new check()
                                    {
                                        bankID = int.Parse(bankCombo.SelectedValue.ToString()),
                                        isUsed = false,
                                        checkNumber = checknumber,
                                    };
                                    dbcontext.checks.Add(model);

                                }

                            }
                            dbcontext.SaveChanges();
                            DataTable dt = new DataTable();
                            checkList checkList = new checkList(dt);
                            checkList.Show();
                            this.Hide();

                        }
                        else
                        {
                            header.Text = "چک با شماره  " + ischeck + " قبلا ثبت شده است ";
                        }
                        
                    }
                }
            }
        }

     
    }
}
