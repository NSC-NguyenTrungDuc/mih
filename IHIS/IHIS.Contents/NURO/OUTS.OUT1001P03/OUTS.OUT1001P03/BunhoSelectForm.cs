using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Messaging;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Models.Nuro;

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
            this.grdPAList.ParamList = new List<String>(new String[] { "f_hosp_code"});
            //set ExecuteQuery
            grdPAList.ExecuteQuery = loadGrdPAList;
           
            
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
        //add Cloud
        private List<object[]> loadGrdPAList(BindVarCollection bc)
        {
            List<object[]> res= new List<object[]>();
            OUT1001P03BunhoListArgs args = new OUT1001P03BunhoListArgs();
            //args.HospCode = EnvironInfo.HospCode;
            OUT1001P03BunhoListResult result =
                CloudService.Instance.Submit<OUT1001P03BunhoListResult, OUT1001P03BunhoListArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (IHIS.CloudConnector.Contracts.Models.Nuro.OUT1001P03BunhoListItemInfo item in result.BunhoList)
                {
                    object[] objects =
                    {
                        item.Bunho,
                        item.Sex,
                        item.Suname
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

    }
}