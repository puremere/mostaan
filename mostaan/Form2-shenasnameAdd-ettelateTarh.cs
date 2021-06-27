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
        public Form2_shenasnameAdd()
        {

            string shenasnameID = GlobalVariable.shenasnameID;
            Model.Context dbcontext = new Model.Context();
            InitializeComponent();
            FontClass fontclass = new FontClass();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            header.Font = mostaan.GlobalVariable.headerlistFONTBold;
            //dateFrom.Font = GlobalVariable.headerlistFONTsupecSmall;
            //dateTo.Font = GlobalVariable.headerlistFONTsupecSmall;
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

           

            radPanel1.PanelElement.Shape = new RoundRectShape();
            radPanel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            radPanel1.PanelElement.PanelFill.BackColor = Color.Gray;


            List<Model.markaz> bakhshlist = dbcontext.markazs.Where(x => x.master == "1").ToList();
            List<Model.markaz> bakhshlist2 = dbcontext.markazs.Where(x => x.master == "1").ToList();
            markazcombo.DataSource = bakhshlist;
            markazcombo.DisplayMember = "title";
            markazcombo.ValueMember = "parent";

            dastgah.DataSource = bakhshlist2;
            dastgah.DisplayMember = "title";
            dastgah.ValueMember = "parent";

            List<Model.user> userlist = dbcontext.users.ToList();
            tarah.DataSource = userlist;
            tarah.DisplayMember = "name";
            tarah.ValueMember = "ID";

            List<Model.shenasnameGam> lst = new List<Model.shenasnameGam>();
            List<Model.shenasnameFounder> lstFounder = new List<Model.shenasnameFounder>();
            if (shenasnameID != "")
            {
                Model.shenasname item = dbcontext.shenasnames.Where(x => x.ID == GlobalVariable.shenasnameID).FirstOrDefault();
                List<string> taminIDKist = dbcontext.Archives.Where(x => x.hesab == "0").Select(x => x.shomareTamin).ToList();
                List<Model.archive> arch = (from a in dbcontext.Archives
                                           where a.project == shenasnameID && a.hesab == "1"
                                            select a).ToList();
                if (arch.Count() > 0)
                {
                    startDate.Text = arch.First().tarikh.ToPersianDateString();
                    int pishbini = fns.IsDigitsOnly(item.datePishbini) == true ? Int32.Parse(item.datePishbini) : 0;
                    endDate.Text = arch.First().tarikh.AddMonths(pishbini).ToPersianDateString();
                }


                List<Model.ejraeiat> PejraRially = dbcontext.ejraeiats.Where(x => x.shenasnameID == shenasnameID &&  x.riallyP != 0).ToList();
                List<Model.ejraeiat> pejraDollary = dbcontext.ejraeiats.Where(x => x.shenasnameID == shenasnameID && x.dollaryP != 0).ToList();
               
                prejraeeyat.Text = PejraRially.Count() > 0 ? string.Format("{0:n0}", PejraRially.Sum(x => x.riallyP)): "0";
                pdejraiat.Text = pejraDollary.Count() > 0 ? string.Format("{0:n0}", pejraDollary.Sum(x => x.dollaryP)): "0";

               

                List<Model.tamin> ejraRquery = dbcontext.tamins.Where(x => x.subject == "اجراییات" && x.type == "ریال" && x.hesab == "0" && x.project == shenasnameID &&  taminIDKist.Contains(x.shomareSanad)).ToList();
                long ejraRially = ejraRquery != null ?  ejraRquery.ToList().Sum(x => x.mablagh): 0;
                List<Model.tamin> ejraDquery = dbcontext.tamins.Where(x => x.subject == "اجراییات" && x.type == "دلار" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                long ejrDorllay = ejraDquery != null ? ejraDquery.ToList().Sum(x => x.mablagh) : 0;

                hrejrayiat.Text = string.Format("{0:n0}", ejraRially.ToString()) ;
                hdejraeiat.Text = string.Format("{0:n0}", ejrDorllay.ToString());


                List<Model.sarmaye> PsarRially = dbcontext.sarmayes.Where(x => x.shenasnameID == shenasnameID && x.kollPR != 0).ToList();
                List<Model.sarmaye> PsarDollary = dbcontext.sarmayes.Where(x => x.shenasnameID == shenasnameID && x.kollPD != 0).ToList();

                prsarmaye.Text = PsarRially.Count() > 0 ? string.Format("{0:n0}", PsarRially.Sum(x => x.kollPR)) : "0";
                pdsarmaye.Text = PsarDollary.Count() > 0 ? string.Format("{0:n0}", PsarDollary.Sum(x => x.kollPD)) : "0";

                List<Model.tamin> sarmaRquery = dbcontext.tamins.Where(x => x.subject == "سرمایه" && x.type == "ریال" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                List<Model.tamin> sarmaDquery = dbcontext.tamins.Where(x => x.subject == "سرمایه" && x.type == "دلار" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                long sarmRially = sarmaRquery!= null ? sarmaRquery.ToList().Sum(x => x.mablagh): 0;
                long sarmDorllay = sarmaDquery != null ? sarmaDquery.ToList().Sum(x => x.mablagh) : 0;

                hrsarmaye.Text = string.Format("{0:n0}", sarmRially.ToString());
                hdsarmaye.Text = string.Format("{0:n0}", sarmDorllay.ToString());


                List<Model.masrafi> PmasRially = dbcontext.masrafis.Where(x => x.shenasnameID == shenasnameID && x.kollPR != 0).ToList();
                List<Model.masrafi> PmasDollary = dbcontext.masrafis.Where(x => x.shenasnameID == shenasnameID && x.kollPD != 0).ToList();

                prmasrafi.Text = PmasRially.Count() > 0 ? string.Format("{0:n0}", PmasRially.Sum(x => x.kollPR)) : "0";
                pdmasrafi.Text = PmasDollary.Count() > 0 ? string.Format("{0:n0}", PmasDollary.Sum(x => x.kollPD)) : "0";

                List<Model.tamin> masrafiRquery = dbcontext.tamins.Where(x => x.subject == "مصرفی" && x.type == "ریال" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                List<Model.tamin> masrafiDquery = dbcontext.tamins.Where(x => x.subject == "مصرفی" && x.type == "دلار" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                long masrafRially = masrafiRquery!= null ? masrafiRquery.ToList().Sum(x => x.mablagh) : 0;
                long masrafDorllay = masrafiDquery != null ? masrafiDquery.ToList().Sum(x => x.mablagh): 0;

                hrmasrafi.Text = string.Format("{0:n0}", masrafRially.ToString());
                hdmasrafi.Text = string.Format("{0:n0}", masrafDorllay.ToString()); 

                List<Model.edari> PedaRially = dbcontext.edaris.Where(x => x.shenasnameID == shenasnameID && x.kollPR != 0).ToList();
                List<Model.edari> PedaDollary = dbcontext.edaris.Where(x => x.shenasnameID == shenasnameID && x.kollPD != 0).ToList();

                predari.Text = PedaRially.Count() > 0 ? string.Format("{0:n0}", PedaRially.Sum(x => x.kollPR)) : "0";
                pdedari.Text = PedaDollary.Count() > 0 ? string.Format("{0:n0}", PedaDollary.Sum(x => x.kollPD)) : "0";

                List<Model.tamin> edariRquery = dbcontext.tamins.Where(x => x.subject == "اداری" && x.type == "ریال" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                List<Model.tamin> edariDquery = dbcontext.tamins.Where(x => x.subject == "اداری" && x.type == "دلار" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                
                long edariRially = edariRquery != null ? edariRquery.Sum(x => x.mablagh) : 0;
                long edariDorllay = edariDquery!= null ? edariDquery.Sum(x => x.mablagh) : 0;

                hredari.Text = string.Format("{0:n0}", edariRially.ToString()); 
                hdedari.Text = string.Format("{0:n0}", edariDorllay.ToString());  




                List<Model.omrani> PomrRially = dbcontext.omranis.Where(x => x.shenasnameID == shenasnameID && x.kollPR != 0).ToList();
                List<Model.omrani> PomrDollary = dbcontext.omranis.Where(x => x.shenasnameID == shenasnameID && x.kollPD != 0).ToList();

                promrani.Text = PomrRially.Count() > 0 ? string.Format("{0:n0}", PomrRially.Sum(x => x.kollPR)) : "0";
                pdomrani.Text = PomrDollary.Count() > 0 ? string.Format("{0:n0}", PomrDollary.Sum(x => x.kollPD)) : "0";


                List<Model.tamin> omraniRquery = dbcontext.tamins.Where(x => x.subject == "عمرانی" && x.type == "ریال" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                List<Model.tamin> omraniDquery = dbcontext.tamins.Where(x => x.subject == "عمرانی" && x.type == "دلار" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                long omraniRially = omraniRquery != null ?  omraniRquery.Sum(x => x.mablagh) : 0;
                long omraniDorllay = omraniDquery != null ?  omraniDquery.Sum(x => x.mablagh) : 0;

                hromrani.Text = string.Format("{0:n0}", omraniRially.ToString()); 
                hdomrani.Text = string.Format("{0:n0}", omraniDorllay.ToString()); 


                List<Model.gharardad> PgharRially = dbcontext.gharardads.Where(x => x.shenasnameID == shenasnameID && x.kollPR != 0).ToList();
                List<Model.gharardad> PgharDollary = dbcontext.gharardads.Where(x => x.shenasnameID == shenasnameID && x.kollPD != 0).ToList();

                prgharardad.Text = PgharRially.Count() > 0 ? string.Format("{0:n0}", PgharRially.Sum(x => x.kollPR)) : "0";
                pdgharardad.Text = PgharDollary.Count() > 0 ? string.Format("{0:n0}", PgharDollary.Sum(x => x.kollPD)) : "0";


                List<Model.tamin> ghararRquery = dbcontext.tamins.Where(x => x.subject == "قرارداد" && x.type == "ریال" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                List<Model.tamin> ghararDquery = dbcontext.tamins.Where(x => x.subject == "قرارداد" && x.type == "دلار" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                long ghararRially = ghararRquery != null ? ghararRquery.Sum(x => x.mablagh) : 0;
                long ghararDorllay = ghararDquery!= null ? ghararDquery.Sum(x => x.mablagh) : 0;

                hrgharardad.Text = string.Format("{0:n0}", ghararRially.ToString()); 
                hdgharardad.Text = string.Format("{0:n0}", ghararDorllay.ToString());


                List<Model.sayer> PsayerRially = dbcontext.sayers.Where(x => x.shenasnameID == shenasnameID && x.kollPR != 0).ToList();
                List<Model.sayer> PsayerDollary = dbcontext.sayers.Where(x => x.shenasnameID == shenasnameID && x.kollPD != 0).ToList();

                pravalie.Text = PsayerRially.Count() > 0 ? string.Format("{0:n0}", PsayerRially.Sum(x => x.kollPR)) : "0";
                pdavalie.Text = PsayerDollary.Count() > 0 ? string.Format("{0:n0}", PsayerDollary.Sum(x => x.kollPD)) : "0";


                List<Model.tamin> avalieRquery = dbcontext.tamins.Where(x => x.subject == "مواد" && x.type == "ریال" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                List<Model.tamin> avalieDquery = dbcontext.tamins.Where(x => x.subject == "مواد" && x.type == "دلار" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                long avalieRially = avalieRquery != null ? avalieRquery.Sum(x => x.mablagh) : 0;
                long avalieDorllay = avalieDquery != null? avalieDquery.Sum(x => x.mablagh) : 0;

                hravalie.Text = string.Format("{0:n0}", avalieRially.ToString());
                hdavalie.Text = string.Format("{0:n0}", avalieDorllay.ToString()); 

                List<Model.tashvighi> PtashRially = dbcontext.tashvighis.Where(x => x.shenasnameID == shenasnameID && x.kollPR != 0).ToList();
                List<Model.tashvighi> PtashDollary = dbcontext.tashvighis.Where(x => x.shenasnameID == shenasnameID && x.kollPD != 0).ToList();

                prtashvighi.Text = PtashRially.Count() > 0 ? string.Format("{0:n0}", PtashRially.Sum(x => x.kollPR)) : "0";
                pdtashvighi.Text = PtashDollary.Count() > 0 ? string.Format("{0:n0}", PtashDollary.Sum(x => x.kollPD)) : "0";


                List<Model.tamin> tashvighiRquery = dbcontext.tamins.Where(x => x.subject == "تشویقی" && x.type == "ریال" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                List<Model.tamin> tashvighiDquery = dbcontext.tamins.Where(x => x.subject == "تشویقی" && x.type == "دلار" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                long tashvighiRially = tashvighiRquery!= null ? tashvighiRquery.Sum(x => x.mablagh) : 0;
                long tashvighiDorllay = tashvighiDquery!= null ? tashvighiDquery.Sum(x => x.mablagh): 0;

                hrtashvighi.Text = string.Format("{0:n0}", tashvighiRially.ToString()); 
                hdtashvighi.Text = string.Format("{0:n0}", tashvighiDorllay.ToString());



                List<Model.tamin> sayerhazineRquery = dbcontext.tamins.Where(x => x.subject == "سایر هزینه ها" && x.type == "ریال" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                List<Model.tamin> sayerhazineDquery = dbcontext.tamins.Where(x => x.subject == "سایر هزینه ها" && x.type == "دلار" && x.hesab == "0" && x.project == shenasnameID && taminIDKist.Contains(x.shomareSanad)).ToList();
                long sayerhazineRially = sayerhazineRquery != null ? sayerhazineRquery.Sum(x => x.mablagh) : 0;
                long sayerhazineDorllay = sayerhazineDquery != null ? sayerhazineDquery.Sum(x => x.mablagh) : 0;

                hrsayerhazine.Text = string.Format("{0:n0}", sayerhazineRially.ToString()); 
                hdsayerhazine.Text = string.Format("{0:n0}", sayerhazineDorllay.ToString()); 

                hrkoll.Text = string.Format("{0:n0}", (avalieRially + edariRially + ejraRially + ghararRially + masrafRially + omraniRially + sarmRially + sayerhazineRially + tashvighiRially).ToString()); ;
                hdkoll.Text = string.Format("{0:n0}", (avalieDorllay + edariDorllay + ejrDorllay + ghararDorllay + masrafDorllay + omraniDorllay + sarmDorllay + sayerhazineDorllay + tashvighiDorllay).ToString());
                prkoll.Text = string.Format("{0:n0}", (decimal.Parse(prejraeeyat.Text) + decimal.Parse(prsarmaye.Text) + decimal.Parse(predari.Text) + decimal.Parse(prmasrafi.Text) + decimal.Parse(promrani.Text) + decimal.Parse(pravalie.Text) + decimal.Parse(prtashvighi.Text)).ToString()); 
                pdkoll.Text = string.Format("{0:n0}", (decimal.Parse(pdejraiat.Text) + decimal.Parse(pdsarmaye.Text) + decimal.Parse(pdedari.Text) + decimal.Parse(pdmasrafi.Text) + decimal.Parse(pdomrani.Text) + decimal.Parse(pdavalie.Text) + decimal.Parse(pdtashvighi.Text)).ToString());


                lst = (from p in dbcontext.shenasnameGams where p.shenasnameID == shenasnameID select p).ToList();
                dataGridView1.DataSource = lst;

                lstFounder = (from p in dbcontext.shenasnameFounders where p.shenasnameID == shenasnameID select p).ToList();
                //dataGridView2.DataSource = lstFounder;

                
                hadaf.Text = item.hadaf ;
                title.Text = item.title ;
                
                datePishbini.Text = item.datePishbini;
                //dateFrom.Text = item.dateFrom.ToShortDateString();
                //dateTo.Text = item.dateTo.ToShortDateString();
                if (item.markaz != null)
                {
                    markazcombo.SelectedValue = item.markaz;
                    dastgah.SelectedValue = item.markaz;
                }
                if (item.tarah != null)
                {
                    tarah.SelectedValue = item.tarah;
                }
                
            }
            else
            {
                dataGridView1.DataSource = lst;
                //dataGridView2.DataSource = lstFounder;
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


            


           


            //Phazine.Text = String.Format("{0:n0}", pr) + " ریال و " + string.Format("{0:n0}", pd) + " دلار ";
            //Nhazine.Text = string.Format("{0:n0}", nr) + " ریال و " + string.Format("{0:n0}", nd) + " دلار ";


        }


       
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainTable_Paint(object sender, PaintEventArgs e)
        {

        }

      


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Model.shenasname item = dbcontext.shenasnames.Where(x => x.ID == GlobalVariable.shenasnameID).FirstOrDefault();
            if (item.final != 1)
            {
                Form3_addGam form = new Form3_addGam();
                form.Show();
            }
                
        }

        private void label16_Click(object sender, EventArgs e) // تایید
        {
            Model.shenasname item = dbcontext.shenasnames.Where(x => x.ID == GlobalVariable.shenasnameID).FirstOrDefault();
            if (item.final != 1)
            {
                try
                {
                    item.hadaf = hadaf.Text;
                    item.title = title.Text;
                   
                    item.date = DateTime.Now;
                    item.datePishbini = datePishbini.Text;
                    //item.dateFrom = "";//dateFrom.GetSelectedDateInPersianDateTime().ToShortDateString().ToGeorgianDateTime();
                    //item.dateTo = ""; //dateTo.GetSelectedDateInPersianDateTime().ToShortDateString().ToGeorgianDateTime();
                    item.markaz = markazcombo.SelectedValue.ToString();
                    item.dastgah = dastgah.SelectedValue.ToString();
                    dbcontext.SaveChanges();
                  
                }
                catch (Exception error)
                {
                    //throw;
                }
            }
            Form6_PMainMoney form6 = new Form6_PMainMoney();
            form6.Show();
            this.Hide();


            // this.Hide();
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

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainTable_Paint_1(object sender, PaintEventArgs e)
        {

        }

       
    }
}
