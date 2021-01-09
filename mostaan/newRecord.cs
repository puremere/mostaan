using mostaan.Classes;
using mostaan.Model;
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

namespace mostaan
{
    

    public partial class newRecord : Form
    {
        Context context = new Context();

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
            GlobalVariable.headerlistFONTBold = new Font(fonts.Families[0], 12.0F, System.Drawing.FontStyle.Bold);
            //GlobalVariable.HlistFONT = new Font(fonts.Families[0], 18.0F, System.Drawing.FontStyle.Regular);
            // label1.Font = GlobalVariable.headerlistFONT;
            header.Font = GlobalVariable.headerlistFONTBold;
        }
        public newRecord(string type)
        {

            InitializeComponent();

            if (type == "1")
            {
                header.Text = "افزودن اطلاعات دریافتی جدید";
            }
            filterPanel1.PanelElement.Shape = new RoundRectShape();
            filterPanel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            filterPanel1.PanelElement.PanelFill.BackColor = Color.Gray;
            

            initFont();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);
            this.MaximizeBox = false;
            this.CenterToScreen();
        }

        private void filter_Click(object sender, EventArgs e)
        {
            archive newITem = new archive() {
                hesab = hesab.Text,
                 karfarma = karfarma.Text,
                  mablagh = price.Text,
                   markaz = markaz.Text,
                    productType = productType.Text,
                     project = project.Text,
                      rank = rank.Text,
                       sanadType = sanadType.Text,
                        shomareSanad = shomareSanad.Text,
                         subject = subject.Text,
                          tarikh = tarikh.Text,
                           variz = variz.Text

                 
            };
            context.Archives.Add(newITem);
            context.SaveChanges();


            DataTable dt = new DataTable();
            DaryaftiReport daryaftirp = new DaryaftiReport(dt);
            daryaftirp.Show();
            this.Hide();
            


        }
    }
}
