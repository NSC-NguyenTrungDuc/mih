using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.PHYS.Properties;

namespace IHIS.PHYS
{
    public partial class NewOrderINP : XForm
    {
        public NewOrderINP()
        {
            InitializeComponent();
        }

        private void pnlImage_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void NewOrder_MdiChildActivate(object sender, EventArgs XMessageBox4)
        {
            XMessageBox.Show(Resources.XMessageBox4);

        }

        private void NewOrder_Deactivate(object sender, EventArgs e)
        {
            //XMessageBox.Show("NewOrder_Deactivate");
            //this.BringToFront();
        }
    }
}