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
    public partial class CheckNurse : IHIS.Framework.XForm
    {
        public CheckNurse()
        {
            InitializeComponent();
        }

        string nurse_id = "";

        public string NurseID 
        {
            get
            {
                return this.nurse_id;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            nurse_id = this.txtNurseID.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            nurse_id = "";
            this.Close();
        }
    }



}