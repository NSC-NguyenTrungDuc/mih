using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.NURO
{
    public partial class BunhoSelectForm : XForm
    {
        string mReturnBunho = "";
        public string ReturnBunho
        {
            get
            { return mReturnBunho; }
        }

        public BunhoSelectForm()
        {
            InitializeComponent();
        }


        private string mHospCode = "";
        private void BunhoSelectForm_Load(object sender, EventArgs e)
        {
            mHospCode = EnvironInfo.HospCode;

            this.grdPAList.QueryLayout(false);
        }

        private void grdPAList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPAList.SetBindVarValue("f_hosp_code", this.mHospCode);
            if (this.cbxQueryFlag.Checked)
                this.grdPAList.SetBindVarValue("f_query_flag", "ALL");
            else
                this.grdPAList.SetBindVarValue("f_query_flag", "NOTALL");

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.grdPAList.CurrentRowNumber < 0)
                return;

            this.mReturnBunho = this.grdPAList.GetItemString(this.grdPAList.CurrentRowNumber, "bunho");

            this.Close();
        }

        private void grdPAList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                int rowNum = this.grdPAList.GetHitRowNumber(e.Y);

                if (rowNum < 0)
                    return;
                
                this.mReturnBunho = this.grdPAList.GetItemString(rowNum, "bunho");
                this.Close();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.grdPAList.QueryLayout(false);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.mReturnBunho = "";
            this.Close();
        }
    }
}