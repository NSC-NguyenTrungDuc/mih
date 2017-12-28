using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

using IHIS.Framework;

namespace IHIS.OCSI
{
    public partial class frmInsulinLog : IHIS.Framework.XForm
    {
        #region [Instance Variable]
        //Message
        private string mbxMsg = "", mbxCap = "";
        private string mFkinp1001 = "";
        private string mBUNHO = "";
        private string mSUNAME = "";

        //Hospital Code
        private string mHospCode = EnvironInfo.HospCode;
        #endregion

        public frmInsulinLog()
        {
            InitializeComponent();
        }

        #region [properties]
        public string FKINP1001
        {
            get
            {
                return mFkinp1001;
            }
            set
            {
                mFkinp1001 = value;
            }
        }
        public string BUNHO
        {
            get
            {
                return mBUNHO;
            }
            set
            {
                mBUNHO = value;
            }
        }
        public string SUNAME
        {
            get
            {
                return mSUNAME;
            }
            set
            {
                mSUNAME = value;
            }
        }

        #endregion

        private void grdOCS2016_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOCS2016.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS2016.SetBindVarValue("f_fkinp1001", this.mFkinp1001);
            this.grdOCS2016.SetBindVarValue("f_bunho", this.paBox.BunHo);

            if(this.cbxLimit7.Checked == true)
                this.grdOCS2016.SetBindVarValue("f_limit7", "Y");
            else
                this.grdOCS2016.SetBindVarValue("f_limit7", "N");
        }

        private void grdOCS2016_Load(object sender, EventArgs e)
        {
            this.paBox.SetPatientID(this.mBUNHO);
            //this.dpxSuname.Text = this.mSUNAME;

            btnList.PerformClick(FunctionType.Query);
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    this.grdOCS2016.QueryLayout(false);
                    break;
                case FunctionType.Close:
                    e.IsBaseCall = true;
                    break;
            }
        }

        private void cbxLimit7_CheckedChanged(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void grdOCS2016_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.grdOCS2016.SetFocusToItem(this.grdOCS2016.RowCount - 1, "act_date");
        }

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }
    }
}