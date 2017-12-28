using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace IHIS.NURO.Reports
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();
        }

        public XtraReport1(string barcode)
        {
            try
            {
                InitializeComponent();
                this.xrBarCode1.Text = barcode;
            }
            catch (Exception ex)
            {
                
            }
        }

    }
}
