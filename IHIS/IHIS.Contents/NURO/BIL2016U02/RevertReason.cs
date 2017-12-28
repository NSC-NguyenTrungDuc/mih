using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.NURO.Properties;

namespace IHIS.NURO
{
    public partial class RevertReason : Form
    {
        private string reasonDelete = "";
        private bool cancelDelete = false;
        public bool CancelDelete
        {
            get { return cancelDelete; }
            set { cancelDelete = value; }
        }
        public string ReasonDelete
        {
            get { return reasonDelete; }
            set { reasonDelete = value; }
        }
        public RevertReason()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelDelete = true;
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            cancelDelete = false;
             reasonDelete = txtReason.Text;
             if (reasonDelete == "")
            {
                XMessageBox.Show(Resources.MSG014, Resources.MSG001_CAP, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
             txtReason.Text = "";
             this.Close();
        }
    }
}