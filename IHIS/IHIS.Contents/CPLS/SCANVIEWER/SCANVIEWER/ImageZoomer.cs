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
    public partial class ImageZoomer : XForm
    {
        public ImageZoomer()
        {
            InitializeComponent();
        }

        Image mImage = null;

        public Image ZoomImage
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