using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace IHIS.SCHS.Reports
{
    public partial class XtraReportBooking : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportBooking()
        {
            InitializeComponent();
        }

        public XtraReportBooking(string barcode)
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
