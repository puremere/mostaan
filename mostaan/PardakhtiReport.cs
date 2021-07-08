using mostaan.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using mostaan.Classes;
using System.IO;

namespace mostaan
{
    public partial class PardakhtiReport : Form
    {
        Model.Context dbcontext = new Model.Context();
        FontClass fontclass = new FontClass();
        //databaseManager manager = new databaseManager();
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
           IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        public void initFont()
        {

            byte[] fontData = Properties.Resources.IRANSans_FaNum_;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.IRANSans_FaNum_.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.IRANSans_FaNum_.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            GlobalVariable.headerlistFONT = new Font(fonts.Families[0], 24.0F, System.Drawing.FontStyle.Regular);

            GlobalVariable.headerlistFONTsmall = new Font(fonts.Families[0], 12.0F, System.Drawing.FontStyle.Regular);
            //GlobalVariable.headerlistFONTBold = new Font(fonts.Families[0], 11.0F, System.Drawing.FontStyle.Bold);
            //GlobalVariable.HlistFONT = new Font(fonts.Families[0], 18.0F, System.Drawing.FontStyle.Regular);
            // label1.Font = GlobalVariable.headerlistFONT;
        }
        public PardakhtiReport(DataTable dt1)
        {


            InitializeComponent();
            initFont();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            this.MaximizeBox = false;

            filterPanel.PanelElement.Shape = new RoundRectShape();
            filterPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            filterPanel.PanelElement.PanelFill.BackColor = Color.Gray;


            newRecordPanel.PanelElement.Shape = new RoundRectShape();
            newRecordPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            newRecordPanel.PanelElement.PanelFill.BackColor = Color.Gray;



            if (dt1.Columns.Count != 0)
            {
                dataGridView1.DataSource = dt1;
            }
            else
            {


                var lst = (from p in dbcontext.Archives
                           join t in dbcontext.tamins on p.shomareTamin equals t.shomareSanad
                           where p.hesab == "0"
                           orderby p.ID
                           select new { shomareTamin = t.shomareSanad, shnesnameTitle = t.shnesnameTitle, radifTitle = t.radifTitle, ID = p.ID, tarikh = p.tarikh, hesab = p.hesab, bankName = p.bankName, checkNumber = p.checkNumber, mablagh = t.mablagh, radif = t.radif, subject = t.subject, project = t.project, markaz = t.markaz, shomareSanad = p.shomareSanad, type = t.type }).ToList();
                //dataGridView1.DataSource = lst;
                List<Model.archive> finallist = new List<Model.archive>();

                foreach (var item in lst)
                {
                    finallist.Add(new Model.archive
                    {
                        bankName = item.bankName,
                        checkNumber = item.checkNumber,
                        hesab = item.hesab,
                        ID = item.ID,
                        imageName = "",
                        mablagh = item.mablagh,
                        markaz = item.markaz,
                        project = item.project,
                        radif = item.radif,
                        radifTitle = item.radifTitle,
                        shnesnameTitle = item.shnesnameTitle,
                        shomareSanad = item.shomareSanad,
                        shomareTamin = item.shomareTamin,
                        subject = item.subject,
                        tarikh = item.tarikh,
                        type = item.type
                    });
                }
                dataGridView1.DataSource = finallist;
            }



            if (dataGridView1.Columns["ID"] != null)
            {
                dataGridView1.Columns["ID"].HeaderText = "ردیف";
                dataGridView1.Columns["ID"].Width = 120;
                dataGridView1.Columns["ID"].DisplayIndex = 2;

                dataGridView1.Columns["shomareSanad"].HeaderText = "شماره سند";
                dataGridView1.Columns["shomareSanad"].Width = 200;
                dataGridView1.Columns["shomareSanad"].DisplayIndex = 3;
                dataGridView1.Columns["shomareSanad"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;


                dataGridView1.Columns["shomareTamin"].HeaderText = "شماره تامین";
                dataGridView1.Columns["shomareTamin"].Width = 300;
                dataGridView1.Columns["shomareTamin"].DisplayIndex = 4;
                dataGridView1.Columns["shomareTamin"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;


                dataGridView1.Columns["checkNumber"].HeaderText = "شماره چک ";
                dataGridView1.Columns["checkNumber"].Width = 200;
                dataGridView1.Columns["checkNumber"].DisplayIndex = 8;
                dataGridView1.Columns["checkNumber"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

                dataGridView1.Columns["bankName"].HeaderText = "بانک عامل ";
                dataGridView1.Columns["bankName"].Width = 200;
                dataGridView1.Columns["bankName"].DisplayIndex = 8;
                dataGridView1.Columns["bankName"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

                dataGridView1.Columns["shnesnameTitle"].HeaderText = "عنوان شناسنامه ";
                dataGridView1.Columns["shnesnameTitle"].Width = 200;
                dataGridView1.Columns["shnesnameTitle"].DisplayIndex = 8;
                dataGridView1.Columns["shnesnameTitle"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

                dataGridView1.Columns["subject"].HeaderText = "جدول ";
                dataGridView1.Columns["subject"].Width = 200;
                dataGridView1.Columns["subject"].DisplayIndex = 8;
                dataGridView1.Columns["subject"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

                dataGridView1.Columns["radifTitle"].HeaderText = "عنوان ردیف ";
                dataGridView1.Columns["radifTitle"].Width = 200;
                dataGridView1.Columns["radifTitle"].DisplayIndex = 8;
                dataGridView1.Columns["radifTitle"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

                dataGridView1.Columns["mablagh"].HeaderText = "قیمت ";
                dataGridView1.Columns["mablagh"].Width = 200;
                dataGridView1.Columns["mablagh"].DisplayIndex = 8;
                dataGridView1.Columns["mablagh"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

                dataGridView1.Columns["type"].HeaderText = "واحد ";
                dataGridView1.Columns["type"].Width = 200;
                dataGridView1.Columns["type"].DisplayIndex = 8;
                dataGridView1.Columns["type"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

                dataGridView1.Columns["tarikh"].HeaderText = "تاریخ ";
                dataGridView1.Columns["tarikh"].Width = 200;
                dataGridView1.Columns["tarikh"].DisplayIndex = 8;
                dataGridView1.Columns["tarikh"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;



                // dataGridView1.Columns["imageName"].Visible = false;
                dataGridView1.Columns["rank"].Visible = false;
                dataGridView1.Columns["markaz"].Visible = false;
                dataGridView1.Columns["tarikh"].Visible = false;
                dataGridView1.Columns["variz"].Visible = false;
                dataGridView1.Columns["hesab"].Visible = false;
                dataGridView1.Columns["radif"].Visible = false;
                dataGridView1.Columns["project"].Visible = false;
                dataGridView1.Columns["referbish"].Visible = false;
            }
            


            this.CenterToScreen();
        }

        private void newRecord_Click(object sender, EventArgs e)
        {
            pardakhtiNew newrecord = new pardakhtiNew("0");
            newrecord.Show();
        }

        private void newRecord_Click_1(object sender, EventArgs e)
        {
            pardakhtiNew newrecord = new pardakhtiNew("0");
            newrecord.Show();
            this.Hide();
        }

        private void filterPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void filter_Click(object sender, EventArgs e)
        {
            PardakhtiFilter filp = new PardakhtiFilter("1");
            filp.Show();
            this.Hide();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var dbcontext = new Model.Context())
            {
                int iSelectedGridIndex = dataGridView1.CurrentCell.ColumnIndex;
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                int rowID = Int32.Parse(dataGridView1.Rows[rowindex].Cells[2].Value.ToString());
                Model.archive model = dbcontext.Archives.SingleOrDefault(x => x.ID == rowID);
                string imageName = "";
                if (iSelectedGridIndex == 1)
                {
                    imageName = model.imageName;
                }
                else if (iSelectedGridIndex == 0)
                {
                    Model.tamin tmodel = dbcontext.tamins.SingleOrDefault(x => x.shomareSanad == model.shomareTamin);
                    imageName = tmodel.imageName;
                }

                if (imageName != "")
                {
                    try
                    {
                        var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                        if (Path.GetExtension(imageName) == ".pdf")
                        {
                            try
                            {
                                factorPdf factore = new factorPdf(directory+imageName);
                                factore.Show();
                            }
                            catch (Exception error)
                            {
                                label1.Text = error.InnerException.Message;
                            }
                        }
                        else
                        {
                            factorImage factor = new factorImage(directory+imageName);
                            factor.Show();
                        }


                    }
                    catch (Exception error)
                    {


                    }


                }


            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ChooseBank form = new ChooseBank();
            form.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            zero form = new zero();
            form.Show();
            this.Hide();
        }
    }
}
