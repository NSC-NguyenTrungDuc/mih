using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace IHIS.NURO.Report
{
    public partial class ReportPatientIntroduceLetter : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportPatientIntroduceLetter()
        {
            InitializeComponent();
        }

        private Bitmap GetBitmap(string filename)
        {
            using (FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open))
            {
                Bitmap bmp = new Bitmap(fs);
                return (Bitmap) bmp.Clone();
            }
        }

        public ReportPatientIntroduceLetter(string fileName1, string fileName2, string fileName3, string fileName4, string fileName5)
        {
            //try
            //{
            //    InitializeComponent();
            //    if (fileName1 == "")
            //    {
            //        this.xrPictureBox1.Visible = false;
            //    }
            //    else
            //    {
            //            this.xrPictureBox1.Image = GetBitmap(fileName1);
            //            xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            //    }
            //    if (fileName2 == "")
            //    {
            //        this.xrPictureBox2.Visible = false;
            //    }
            //    else
            //    {
            //        this.xrPictureBox2.Image = GetBitmap(fileName2);
            //        xrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            //    }
            //    if (fileName3 == "")
            //    {
            //        this.xrPictureBox3.Visible = false;
            //    }
            //    else
            //    {
            //        this.xrPictureBox3.Image = GetBitmap(fileName3);
            //        xrPictureBox3.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            //    }
            //    if (fileName4 == "")
            //    {
            //        this.xrPictureBox4.Visible = false;
            //    }
            //    else
            //    {
            //        this.xrPictureBox4.Image = GetBitmap(fileName4);
            //        xrPictureBox4.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            //    }
            //    if (fileName5 == "")
            //    {
            //        this.xrPictureBox5.Visible = false;
            //    }
            //    else
            //    {
            //        this.xrPictureBox5.Image = GetBitmap(fileName5);
            //        xrPictureBox5.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }


    }
}
