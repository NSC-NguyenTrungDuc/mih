using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using IHIS.Framework;

namespace Report2005
{
    public partial class ReportBIL2016U02 : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportBIL2016U02()
        {
            InitializeComponent();
        }

        private void ReportBIL2016U02_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (NetInfo.Language == LangMode.Vi)
            {
                lblMoneyToString.Visible = true;
         
            }
            else
            { 
                 lblMoneyToString.Visible = false;
                
            }
        }

    }
}
