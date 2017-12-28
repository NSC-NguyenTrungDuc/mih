using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace IHIS.OCSO
{
    public partial class ReportMedicalRecord : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportMedicalRecord()
        {
            InitializeComponent();
        }

        private void ReportMedicalRecord_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           // xrPictureBox2.ImageUrl = "..\000001189\000001189__20160714165807423835.jpg";
            xrLabel12.Text = "Ngày " + DateTime.Now.ToString("dd") + " Tháng " + DateTime.Now.ToString("MM") + " Năm " + DateTime.Now.ToString("yyyy");
        }

        private void xrLabel30_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel30.Text = xrLabel18.Text;
        }

    }
}
