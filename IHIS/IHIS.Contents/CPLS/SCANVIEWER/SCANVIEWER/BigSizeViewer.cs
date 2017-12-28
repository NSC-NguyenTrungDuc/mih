using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.CPLS
{
    public partial class BigSizeViewer : XForm
    {
        public BigSizeViewer()
        {
            this.Location = new Point(10,20);
            InitializeComponent();
        }

        Image mImage = null;

        public Image BigImage
        {
            set
            {
                mImage = value;
            }
        }

        public void ShowImage()
        {
            this.pbxImage.Image = this.mImage;
            this.pbxImage.Refresh();
        }
    }
}