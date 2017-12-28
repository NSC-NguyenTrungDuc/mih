using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.PHYS;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Phys;
using IHIS.CloudConnector.Contracts.Results.Phys;
using IHIS.CloudConnector.Contracts.Models.Phys;
using IHIS.CloudConnector.Contracts.Results;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.PHYS
{
    public partial class RehaOptions :  XForm
    {
        public RehaOptions()
        {
            InitializeComponent();

            // updated by Cloud
            grdOCS0132.ParamList = new List<string>(new string[] { "f_code_type" });
            grdOCS0132.ExecuteQuery = GetGrdOCS0132;
        }

        private void grdOCS0132_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOCS0132.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS0132.SetBindVarValue("f_code_type", "REHA_AUTO_SINRYOURYOU");
        }

        private void RehaOptions_Load(object sender, EventArgs e)
        {
            this.grdOCS0132.QueryLayout(false);
        }

        #region updated by Cloud

        #region GetGrdOCS0132
        /// <summary>
        /// GetGrdOCS0132
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOCS0132(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            PHY2001U04GrdOCS0132Args args = new PHY2001U04GrdOCS0132Args();
            args.CodeType = bvc["f_code_type"].VarValue;
            ComboResult res = CloudService.Instance.Submit<ComboResult, PHY2001U04GrdOCS0132Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
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