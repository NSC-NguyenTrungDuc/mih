using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Clis;
using IHIS.CloudConnector.Contracts.Models.Clis;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Clis;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;

namespace IHIS.CLIS
{
    public partial class CLIS2015U13 : IHIS.Framework.XScreen
    {
        private string _clisProtocolId = "";
        public CLIS2015U13()
        {
            InitializeComponent();
        }

        private void CLIS2015U13_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            if (this.OpenParam != null)
            {
                _clisProtocolId = this.OpenParam["clis_protocol_id"].ToString();
            }
            else
            {
                _clisProtocolId = "";
            }
            this.grdCLIS2015U13.ExecuteQuery = ExecuteQueryGrdListItem;
            this.grdCLIS2015U13.QueryLayout(true);
        }

        private IList<object[]> ExecuteQueryGrdListItem(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            CLIS2015U13TrialItemListArgs args = new CLIS2015U13TrialItemListArgs();
            args.ClisProtocolId = _clisProtocolId;
            CLIS2015U13TrialItemListResult result = CloudService.Instance.Submit<CLIS2015U13TrialItemListResult, CLIS2015U13TrialItemListArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.TrialList)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeName,
                    };
                    res.Add(objects);
                }
            }
            return res;
        }


    }
}
