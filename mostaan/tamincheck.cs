using mostaan.Classes;
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
    public partial class tamincheck : Form
    {
        Model.Context context = new Model.Context();
        public tamincheck(string id)
        {
            InitializeComponent();
            FontClass fontclass = new FontClass();
            this.MaximizeBox = false;
            this.CenterToScreen();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = mostaan.GlobalVariable.headerlistFONTsmall);

            Model.tamin model = context.tamins.SingleOrDefault(x => x.shomareSanad == id);
            shenasname.Text = model.shnesnameTitle;
            jadval.Text = model.subject;
            radif.Text = model.radifTitle;
            gheymat.Text = model.mablagh.ToString();
            vahed.Text = model.type;

        }

     
    }
}
