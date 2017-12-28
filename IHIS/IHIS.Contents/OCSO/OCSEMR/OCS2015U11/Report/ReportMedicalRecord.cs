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

        private void xrPictureBox2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            if (xrPictureBox2.Image == null) {
                xrPictureBox2.SizeF = new SizeF(1F, 1F);
                Detail1.HeightF = 22F;
                return; 
            }

            //xrPictureBox2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            int pictureBoxWidth = xrPictureBox2.Image.Width;
            int pictureBoxHeight = xrPictureBox2.Image.Height;
            if (pictureBoxWidth > 600) 
            { 
                pictureBoxWidth = 600;
                pictureBoxHeight = pictureBoxWidth * xrPictureBox2.Image.Height / xrPictureBox2.Image.Width;
            }

            xrPictureBox2.SizeF = new SizeF(pictureBoxWidth, pictureBoxHeight);
        }

    }
}
