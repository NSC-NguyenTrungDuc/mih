using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.NURI
{
    public partial class NewOrder : XForm
    {
        public NewOrder()
        {
            InitializeComponent();
        }

        private void pnlImage_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void NewOrder_MdiChildActivate(object sender, EventArgs e)
        {
            XMessageBox.Show("NewOrder_MdiChildActivate");

        }

        private void NewOrder_Deactivate(object sender, EventArgs e)
        {
            //XMessageBox.Show("NewOrder_Deactivate");
            //this.BringToFront();
        }
    }
}