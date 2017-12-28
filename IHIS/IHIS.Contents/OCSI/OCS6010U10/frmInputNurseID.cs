using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

using IHIS.Framework;

namespace IHIS.OCSI
{
    public partial class frmInputNurseID : IHIS.Framework.XForm
    {
        public frmInputNurseID()
        {
            InitializeComponent();
        }

        private void txtNurseID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtNurseID.Text.Trim() != "")
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}