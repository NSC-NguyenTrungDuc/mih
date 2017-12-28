using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.OCSO
{
    public partial class ChangeOrderCode : XForm
    {
        public ChangeOrderCode()
        {
            InitializeComponent();

            // updated by Cloud
            grdOrderList.ParamList = new List<string>(new string[] { "f_code_type" });
            grdOrderList.ExecuteQuery = GetGrdOrderList;
        }

        #region ÉVÉXÉeÉÄïœêî

        private string tempOrder = "";

        public string selectedOrder = null;
        public string selectedOrderName = null;

        #endregion

        public ChangeOrderCode(string p_tempOrder)
        {
            InitializeComponent();

            this.tempOrder = p_tempOrder;

            // updated by Cloud
            grdOrderList.ParamList = new List<string>(new string[] { "f_code_type" });
            grdOrderList.ExecuteQuery = GetGrdOrderList;
        }

        private void ChangeOrderCode_Load(object sender, EventArgs e)
        {
            this.grdOrderList.QueryLayout(false);
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;
                    this.grdOrderList.QueryLayout(true);

                    break;

                case FunctionType.Process:

                    e.IsBaseCall = false;

                    this.selectedOrder = this.grdOrderList.GetItemString(this.grdOrderList.CurrentRowNumber, "hangmog_code");
                    this.selectedOrderName = this.grdOrderList.GetItemString(this.grdOrderList.CurrentRowNumber, "hangmog_name"); 

                    this.Close();

                    break;

                case FunctionType.Close:
                    break;
            }
        }

        private void grdOrderList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOrderList.Reset();

            this.grdOrderList.SetBindVarValue("f_code_type", this.tempOrder);
        }

        private void grdOrderList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Process);
        }

        #region Cloud updated code

        #region GetGrdOrderList
        /// <summary>
        /// GetGrdOrderList
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOrderList(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCSACTChangeOrderCodeGrdOrderListArgs args = new OCSACTChangeOrderCodeGrdOrderListArgs();
            args.CodeType = bvc["f_code_type"].VarValue;
            ComboResult res = CloudService.Instance.Submit<ComboResult, OCSACTChangeOrderCodeGrdOrderListArgs>(args);

            if (res.ExecutionStatus == IHIS.CloudConnector.Contracts.Results.ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }
        #endregion

        #endregion
    }
}