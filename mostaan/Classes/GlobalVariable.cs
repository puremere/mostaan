﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mostaan.Classes;
using System.Windows.Forms;
namespace mostaan
{

    class GlobalVariable
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private System.Drawing.Text.PrivateFontCollection fonts = new System.Drawing.Text.PrivateFontCollection();

       
        public static Font headerlistFONTsupecSmall { get; set; }
        public static Font headerlistFONT { get; set; }
        public static Font headerlistFONTBold { get; set; }
        public static Font headerlistFONTsmall { get; set; }
        public static string  shenasnameID { get; set; }
        public static string bakhshID { get; set; }
        public static string markazID { get; set; }
        public static string comiteID { get; set; }
        
        //public static Font shoonzdah { get; set; }

        //public static string role = "user";


        //public static string serrialNumber { get; set; }
        //public static string newCatsAndAreas { get; set; }
        //public static string searchTabghe { get; set; }
        //public static string result { get; set; }

        //public static ListOfAdds.File selectedOwnObject = null;

        //public static string mantagheIDes = "";
        ////جهت انتخاب چک باکس لیست
        //public static string temporaryOwnList = "";
        //public static string notSeenInbox = null;

    }

}
