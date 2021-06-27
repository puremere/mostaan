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
    public partial class Form23_showCopies : Form
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public Form23_showCopies()
        {

            InitializeComponent();

            FontClass fontclass = new FontClass();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            this.MaximizeBox = false;
            this.CenterToScreen();


            string shenasnameID = GlobalVariable.shenasnameID;

            using (var dbcontext = new Model.Context())
            {
                List<Model.shenasname> lstdd = dbcontext.shenasnames.ToList();
                List<shenasname> lst = (from p in lstdd where (p.ID == shenasnameID || p.parent == shenasnameID) && (p.final == 1) select p).OrderByDescending(x => x.date).ThenByDescending(x=>x.time).ToList();
               
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
                    shenasname selecteditem = dbcontext.shenasnames.SingleOrDefault(x => x.ID == rowID);
                    if (selecteditem.master != "1")
                    {
                        return;
                    }

                    string sID = RandomString(10);
                    List<shenasnameGam> gamList = dbcontext.shenasnameGams.Where(x => x.shenasnameID == rowID).ToList();
                    if (gamList != null)
                    {

                        foreach (shenasnameGam item in gamList)
                        {
                            shenasnameGam newItem = item;
                            newItem.shenasnameID = sID;
                            dbcontext.shenasnameGams.Add(newItem);
                        }
                    }

                    List<shenasnameFounder> founderList = dbcontext.shenasnameFounders.Where(x => x.shenasnameID == rowID).ToList();
                    if (founderList != null)
                    {

                        foreach (shenasnameFounder item in founderList)
                        {
                            shenasnameFounder newItem = item;
                            newItem.shenasnameID = sID;
                            dbcontext.shenasnameFounders.Add(newItem);
                        }
                    }

                    List<ejraeiat> ejraeatList = dbcontext.ejraeiats.Where(x => x.shenasnameID == rowID).ToList();
                    if (ejraeatList != null)
                    {
                        
                        foreach (ejraeiat item in ejraeatList)
                        {
                            ejraeiat newItem = item;
                            newItem.shenasnameID = sID;
                            dbcontext.ejraeiats.Add(newItem);
                        }
                    }
                    List<sarmaye> sarmayeslist = dbcontext.sarmayes.Where(x => x.shenasnameID == rowID).ToList();
                    if (sarmayeslist != null)
                    {
                        foreach (sarmaye item in sarmayeslist)
                        {
                            sarmaye newItem = item;
                            newItem.shenasnameID = sID;
                            dbcontext.sarmayes.Add(newItem);
                        }
                    }
                    List<masrafi> masrafislist = dbcontext.masrafis.Where(x => x.shenasnameID == rowID).ToList();
                    if (masrafislist != null)
                    {
                        foreach (masrafi item in masrafislist)
                        {
                            masrafi newItem = item;
                            newItem.shenasnameID = sID;
                            dbcontext.masrafis.Add(newItem);
                        }
                    }
                    List<edari> edarislist = dbcontext.edaris.Where(x => x.shenasnameID == rowID).ToList();
                    if (masrafislist != null)
                    {
                        foreach (edari item in edarislist)
                        {
                            edari newItem = item;
                            newItem.shenasnameID = sID;
                            dbcontext.edaris.Add(newItem);
                        }
                    }
                    List<omrani> omranilist = dbcontext.omranis.Where(x => x.shenasnameID == rowID).ToList();
                    if (masrafislist != null)
                    {
                        foreach (omrani item in omranilist)
                        {
                            omrani newItem = item;
                            newItem.shenasnameID = sID;
                            dbcontext.omranis.Add(newItem);
                        }
                    }
                    List<gharardad> gharardadslist = dbcontext.gharardads.Where(x => x.shenasnameID == rowID).ToList();
                    if (masrafislist != null)
                    {
                        foreach (gharardad item in gharardadslist)
                        {
                            gharardad newItem = item;
                            newItem.shenasnameID = sID;
                            dbcontext.gharardads.Add(newItem);
                        }
                    }
                    List<sayer> sayerslist = dbcontext.sayers.Where(x => x.shenasnameID == rowID).ToList();
                    if (masrafislist != null)
                    {
                        foreach (sayer item in sayerslist)
                        {
                            sayer newItem = item;
                            newItem.shenasnameID = sID;
                            dbcontext.sayers.Add(newItem);
                        }
                    }
                    List<tashvighi> tashvighislist = dbcontext.tashvighis.Where(x => x.shenasnameID == rowID).ToList();
                    if (masrafislist != null)
                    {
                        foreach (tashvighi item in tashvighislist)
                        {
                            tashvighi newItem = item;
                            newItem.shenasnameID = sID;
                            dbcontext.tashvighis.Add(newItem);
                        }
                    }

                    shenasname model = new shenasname()
                    {
                        comment = selecteditem.comment,
                        date = DateTime.Now,
                        time = DateTime.Now.TimeOfDay,
                        changer = selecteditem.changer,
                        dastgah = selecteditem.dastgah,
                        dateFrom = DateTime.Now,
                        title = selecteditem.title,
                        token = selecteditem.token,
                        parent = selecteditem.parent,
                        ID = sID,
                        noshke = selecteditem.noshke,
                        dateTo = DateTime.Now,
                        master = selecteditem.master,
                        LvazifeT = selecteditem.LvazifeT,
                        markaz = selecteditem.markaz,
                        LvazifeHPR = selecteditem.LvazifeHPR,
                        LvazifeHPD = selecteditem.LvazifeHPD,
                        LrasmiT = selecteditem.LrasmiT,
                        LrasmiHPR = selecteditem.LrasmiHPR,
                        LrasmiHPD = selecteditem.LrasmiHPD,
                        LgharartamamT = selecteditem.LgharartamamT,
                        LgharartamamHPR = selecteditem.LgharartamamHPR,
                        DghararsaatHPD = selecteditem.DghararsaatHPD,
                        DghararsaatHPR = selecteditem.DghararsaatHPR,
                        DghararsaatT = selecteditem.DghararsaatT,
                        DgharartamamHPD = selecteditem.DgharartamamHPD,
                        DgharartamamHPR = selecteditem.DgharartamamHPR,
                        DgharartamamT = selecteditem.DgharartamamT,
                        DighararsaatHPD = selecteditem.DighararsaatHPD,
                        DighararsaatHPR = selecteditem.DighararsaatHPR,
                        DighararsaatT = selecteditem.DighararsaatT,
                        DigharartamamHPD = selecteditem.DigharartamamHPD,
                        DigharartamamHPR = selecteditem.DigharartamamHPR,
                        DigharartamamT = selecteditem.DigharartamamT,
                        DirasmiHPD = selecteditem.DirasmiHPD,
                        DirasmiHPR = selecteditem.DirasmiHPR,
                        DirasmiT = selecteditem.DirasmiT,
                        DivazifeHPD = selecteditem.DivazifeHPD,
                        DivazifeHPR = selecteditem.DivazifeHPR,
                        DivazifeT = selecteditem.DivazifeT,
                        DrasmiHPD = selecteditem.DrasmiHPD,
                        DrasmiHPR = selecteditem.DrasmiHPR,
                        DrasmiT = selecteditem.DrasmiT,
                        DvazifeHPD = selecteditem.DvazifeHPD,
                        DvazifeHPR = selecteditem.DvazifeHPR,
                        DvazifeT = selecteditem.DvazifeT,
                        FDghararsaatHPD = selecteditem.FDghararsaatHPD,
                        FDghararsaatHPR = selecteditem.FDghararsaatHPR,
                        FDghararsaatT = selecteditem.FDghararsaatT,
                        FDgharartamamHPD = selecteditem.FDgharartamamHPD,
                        FDgharartamamHPR = selecteditem.FDgharartamamHPR,
                        FDgharartamamT = selecteditem.FDgharartamamT,
                        FDrasmiHPD = selecteditem.FDrasmiHPD,
                        FDrasmiHPR = selecteditem.FDrasmiHPR,
                        FDrasmiT = selecteditem.FDrasmiT,
                        FDvazifeHPD = selecteditem.FDvazifeHPD,
                        FDvazifeHPR = selecteditem.FDvazifeHPR,
                        FDvazifeT = selecteditem.FDvazifeT,
                        final = 0,
                        FLghararsaatHPD = selecteditem.FLghararsaatHPD,
                        FLgharartamamT = selecteditem.FLgharartamamT,
                        FLghararsaatHPR = selecteditem.FLghararsaatHPR,
                        FLghararsaatT = selecteditem.FLghararsaatT,
                        FLgharartamamHPD = selecteditem.FLgharartamamHPD,
                        FLgharartamamHPR = selecteditem.FLgharartamamHPR,
                        FLrasmiHPD = selecteditem.FLrasmiHPD,
                        FLrasmiHPR = selecteditem.FLrasmiHPR,
                        FLrasmiT = selecteditem.FLrasmiT,
                        FLvazifeHPD = selecteditem.FLvazifeHPD,
                        FLvazifeHPR = selecteditem.FLvazifeHPR,
                        FLvazifeT = selecteditem.FLvazifeT,
                        hadaf = selecteditem.hadaf,
                        isDone = false,
                        LghararsaatHPD = selecteditem.LghararsaatHPD,
                        LghararsaatHPR = selecteditem.LghararsaatHPR,
                        LghararsaatT = selecteditem.LghararsaatT,
                        LgharartamamHPD = selecteditem.LgharartamamHPD,
                        ZDighararsaatHPD = selecteditem.ZDighararsaatHPD,
                        ZDighararsaatHPR = selecteditem.ZDighararsaatHPR,
                        ZDighararsaatT = selecteditem.ZDighararsaatT,
                        ZDigharartamamHPD = selecteditem.ZDigharartamamHPD,
                        ZDigharartamamHPR = selecteditem.ZDigharartamamHPR,
                        ZDigharartamamT = selecteditem.ZDigharartamamT,
                        ZDirasmiHPD = selecteditem.ZDirasmiHPD,
                        ZDirasmiHPR = selecteditem.ZDirasmiHPR,
                        ZDirasmiT = selecteditem.ZDirasmiT,
                        ZDivazifeHPD = selecteditem.ZDivazifeHPD,
                        ZDivazifeHPR = selecteditem.ZDivazifeHPR,
                        ZDivazifeT = selecteditem.ZDivazifeT,
                        
                        
                        


                    };

                    dbcontext.shenasnames.Add(model);
                    dbcontext.SaveChanges();
                    GlobalVariable.shenasnameID = sID;
                    Form2_shenasnameAdd form2 = new Form2_shenasnameAdd();
                    form2.Show();
                }




            }
            else if (iSelectedGridIndex == 0)
            {
                GlobalVariable.shenasnameID = rowID;
                Form2_shenasnameAdd form2 = new Form2_shenasnameAdd();
                form2.Show();
            }
            else
            {
                return;
            }




        }
    }
}
