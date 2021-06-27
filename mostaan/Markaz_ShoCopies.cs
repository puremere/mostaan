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
    public partial class Markaz_ShoCopies : Form
    {
     
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public Markaz_ShoCopies()
        {

            InitializeComponent();

            FontClass fontclass = new FontClass();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            this.MaximizeBox = false;
            this.CenterToScreen();


            string markazID = GlobalVariable.markazID;

            using (var dbcontext = new Model.Context())
            {

                List<markaz> lst = (from p in dbcontext.markazs where (p.ID == markazID || p.parent == markazID) && (p.final == 1) select p).OrderByDescending(x => x.date).ThenByDescending(x => x.time).ToList();

                List<ViewModel.shenasnameCopiesVM> list = new List<ViewModel.shenasnameCopiesVM>();
                foreach (var item in lst)
                {
                    int index = lst.IndexOf(item);

                    string count = index == 0 ? "نسخه نهایی" : "نسخه " + (lst.Count() - (index)).ToString();
                    ViewModel.shenasnameCopiesVM vmitem = new ViewModel.shenasnameCopiesVM()
                    {
                        ID = item.ID,
                        count = count,
                        date = item.date.ToPersianDateString(),
                        changer = item.changer,




                    };
                    list.Add(vmitem);

                }
                dataGridView1.DataSource = list;

            }




            dataGridView1.Columns["ID"].HeaderText = "ردیف";
            dataGridView1.Columns["ID"].Width = 110;
            dataGridView1.Columns["ID"].DisplayIndex = 0;

            dataGridView1.Columns["count"].HeaderText = "نسخه";
            dataGridView1.Columns["count"].Width = 200;
            dataGridView1.Columns["count"].DisplayIndex = 1;
            dataGridView1.Columns["count"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;


            dataGridView1.Columns["date"].HeaderText = "تاریخ";
            dataGridView1.Columns["date"].Width = 200;
            dataGridView1.Columns["date"].DisplayIndex = 2;
            dataGridView1.Columns["date"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            //dataGridView1.Columns["noskhe"].HeaderText = "تغییرات";
            //dataGridView1.Columns["noskhe"].Width = 416;
            //dataGridView1.Columns["noskhe"].DisplayIndex = 3;
            //dataGridView1.Columns["noskhe"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

            dataGridView1.Columns["changer"].HeaderText = "تغییر دهنده ";
            dataGridView1.Columns["changer"].Width = 200;
            dataGridView1.Columns["changer"].DisplayIndex = 3;
            dataGridView1.Columns["changer"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;




            dataGridView1.Columns[0].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[1].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[2].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[3].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[4].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;




            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;





            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.DefaultCellStyle.Font = GlobalVariable.headerlistFONTsmall;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int iSelectedGridIndex = dataGridView1.CurrentCell.ColumnIndex;
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            string rowID = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            if (iSelectedGridIndex == 1)
            {
                using (Context dbcontext = new Context())
                {
                    markaz selecteditem = dbcontext.markazs.SingleOrDefault(x => x.ID == rowID);
                    if (selecteditem.master != "1")
                    {
                        return;
                    }
                    DateTime date = DateTime.Now;
                    TimeSpan time = DateTime.Now.TimeOfDay;

                    string ID = RandomString(10);
                    markaz model = new markaz()
                    {
                        masoul = selecteditem.masoul,
                        BakhshID = selecteditem.BakhshID,
                        changer = selecteditem.changer,
                        date = date,
                        time = time,
                        ID = ID,
                        parent = selecteditem.parent,
                        final = 0,
                        isDone = false,
                        janeshin = selecteditem.janeshin,
                        master = "0",
                        title = selecteditem.title

                    };

                    dbcontext.markazs.Add(model);
                    dbcontext.SaveChanges();
                    GlobalVariable.markazID = ID;
                    Markaz_add form2 = new Markaz_add();
                    form2.Show();
                }




            }
            else if (iSelectedGridIndex == 0)
            {
                GlobalVariable.markazID = rowID;
                Markaz_add form2 = new Markaz_add();
                form2.Show();
            }
            else
            {
                return;
            }




        }
    }
}
