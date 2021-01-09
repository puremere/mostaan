using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mostaan.Classes
{
    public class FontClass
    {
        // control is TextBox
        
        public List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {
                
                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
                else
                    list.Add(c);
            }

            return list;
        }
        public List<Control> GetAllTextBox(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {

                if (c.Controls.Count > 0)
                    list = GetAllTextBox(c, list);
                else
                    if (c is TextBox)
                       list.Add(c);

            }
            return list;
        }
        public List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }
        public List<Control> GetAllTextBox(Control container)
        {
            return GetAllTextBox(container, new List<Control>());
        }

    }
}
