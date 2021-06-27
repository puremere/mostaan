using mostaan.Classes;
using mostaan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mostaan
{
    public partial class tamin_Report : Form
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
        public tamin_Report(DataTable dt1)
        {
            InitializeComponent();
            initFont();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            this.MaximizeBox = false;

        
        

            if (dt1.Columns.Count != 0)
            {
                dataGridView1.DataSource = dt1;
            }
            else
            {
                List<Model.tamin> lst = (from p in dbcontext.tamins
                                           where p.hesab == "0"
                                           select p).OrderBy(x => x.ID).ToList();
                dataGridView1.DataSource = lst;
            }




            dataGridView1.Columns["ID"].HeaderText = "ردیف";
            dataGridView1.Columns["ID"].Width = 120;
            dataGridView1.Columns["ID"].DisplayIndex = 2;

            dataGridView1.Columns["shomareSanad"].HeaderText = "شماره سند";
            dataGridView1.Columns["shomareSanad"].Width = 200;
            dataGridView1.Columns["shomareSanad"].DisplayIndex = 3;
            dataGridView1.Columns["shomareSanad"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;


            dataGridView1.Columns["shnesnameTitle"].HeaderText = "عنوان شناسنامه";
            dataGridView1.Columns["shnesnameTitle"].Width = 300;
            dataGridView1.Columns["shnesnameTitle"].DisplayIndex = 4;
            dataGridView1.Columns["shnesnameTitle"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;


            dataGridView1.Columns["subject"].HeaderText = "جدول";
            dataGridView1.Columns["subject"].Width = 200;
            dataGridView1.Columns["subject"].DisplayIndex = 5;
            dataGridView1.Columns["subject"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;


            dataGridView1.Columns["radifTitle"].HeaderText = "عنوان ردیف";
            dataGridView1.Columns["radifTitle"].Width = 300;
            dataGridView1.Columns["radifTitle"].DisplayIndex = 6;
            dataGridView1.Columns["radifTitle"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;


            dataGridView1.Columns["type"].HeaderText = "واحد پولی";
            dataGridView1.Columns["type"].Width = 200;
            dataGridView1.Columns["type"].DisplayIndex = 7;
            dataGridView1.Columns["type"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;



            dataGridView1.Columns["mablagh"].HeaderText = "مبلغ ";
            dataGridView1.Columns["mablagh"].Width = 200;
            dataGridView1.Columns["mablagh"].DisplayIndex = 8;
            dataGridView1.Columns["mablagh"].DefaultCellStyle.Font = GlobalVariable.headerlistFONTsupecSmall;

          



            dataGridView1.Columns["imageName"].Visible = false;
            dataGridView1.Columns["rank"].Visible = false;
            dataGridView1.Columns["markaz"].Visible = false;
            dataGridView1.Columns["tarikh"].Visible = false;
            dataGridView1.Columns["variz"].Visible = false;
            dataGridView1.Columns["hesab"].Visible = false;
            dataGridView1.Columns["radif"].Visible = false;
            dataGridView1.Columns["project"].Visible = false;



            dataGridView1.Columns[0].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[1].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[2].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[3].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[4].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[5].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[6].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[7].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[8].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;
            dataGridView1.Columns[9].HeaderCell.Style.Font = GlobalVariable.headerlistFONTsupecSmall;



            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;




            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.DefaultCellStyle.Font = GlobalVariable.headerlistFONTsmall;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.CenterToScreen();

        }

        private void newRecord_Click(object sender, EventArgs e)
        {
            tamin_New form = new tamin_New("0");
            form.Show();
        }
       

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int iSelectedGridIndex = dataGridView1.CurrentCell.ColumnIndex;
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                int rowID = Int32.Parse(dataGridView1.Rows[rowindex].Cells[2].Value.ToString());
                Model.tamin model = dbcontext.tamins.SingleOrDefault(x => x.ID == rowID);
                if (iSelectedGridIndex == 0)
                {
                    label1.Text = "بانک تامین";
                    label1.ForeColor = Color.Black;

                    string imageName = model.imageName;
                    if (imageName != "")
                    {
                        var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                        try
                        {

                            if (Path.GetExtension(imageName) == ".pdf")
                            {
                                try
                                {
                                    //label1.Text = "takes too far";
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

                            label1.Text = "0000-" + error.InnerException.Message;
                        }


                    }

                }
                else if (iSelectedGridIndex == 1)
                {
                    string IDsrt = rowID.ToString();
                    archive rmodel = dbcontext.Archives.SingleOrDefault(x => x.shomareTamin == model.shomareSanad);
                    if(rmodel == null)
                    {
                        dbcontext.tamins.Remove(model);
                        dbcontext.SaveChanges();
                        List<Model.tamin> lst = (from p in dbcontext.tamins
                                                 where p.hesab == "0"
                                                 select p).OrderBy(x => x.ID).ToList();
                        dataGridView1.DataSource = lst;
                    }
                    else
                    {
                        label1.Text = "تامین مورد نظر دارای فاکتور می باشد";
                        label1.ForeColor = Color.Red;
                    }

                

                }
            }
            catch (Exception er)
            {

                label1.Text = "111-" + er.InnerException.Message;
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                List<string> idlist = dbcontext.Archives.Where(x => x.hesab == "0").Select(x => x.shomareTamin).ToList();
                List<Model.tamin> lst = dbcontext.tamins.Where(x => !idlist.Contains(x.shomareSanad)).ToList();
                 dataGridView1.DataSource = lst;

            } // if
            else
            {
                List<Model.tamin> lst = (from p in dbcontext.tamins
                                         where p.hesab == "0"
                                         select p).OrderBy(x => x.ID).ToList();
                dataGridView1.DataSource = lst;
            } // else
        }
    }
}
