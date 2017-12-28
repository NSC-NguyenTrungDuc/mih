using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Outs;
using IHIS.CloudConnector.Contracts.Models.Outs;
using IHIS.CloudConnector.Contracts.Results.Outs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.OCS.Properties;

namespace IHIS.OCSO
{
    public partial class OCS2015U05 : UserControl
    {
        public OCS2015U05()
        {
            InitializeComponent();
            this.grdList.ExecuteQuery = this.GetGridList;
        }

        string mbxMsg = string.Empty;
        string mbxCap = string.Empty;
        string mnaewon_date = string.Empty;
        private OUT0106U00GridListResult gridListResult;
        private bool mIsWarningForPastData = false;
        private OUT0106U00GridListResult GetGroupedGridListResult(String bunho, String naewonDate)
        {
            // set arguments
            OUT0106U00GridListArgs gridListArgs = new OUT0106U00GridListArgs();
            gridListArgs.Bunho = bunho;
            gridListArgs.NaewonDate = naewonDate;
            // get results
            OUT0106U00GridListResult result = CloudService.Instance.Submit<OUT0106U00GridListResult, OUT0106U00GridListArgs>(gridListArgs);
            return result;
        }

        private IList<object[]> GetGridList(BindVarCollection list)
        {
            List<object[]> gridList = null;
            if (gridListResult != null)
            {
                gridList = new List<object[]>();
                IList<OUT0106U00GridItemInfo> gridItemInfos = gridListResult.GridItemInfo;
                foreach (OUT0106U00GridItemInfo item in gridItemInfos)
                {
                    //MED-11462
                    if(item.DisplayYn == "N") continue;
                    gridList.Add(new object[]
                    {
                        item.Comments,
                        item.Ser.Substring(0,1),
                        item.Bunho,
                        item.DisplayYn
                    });
                }
            }
            return gridList;
        }

        /// <summary>
        /// 환자의 참고사항을 조회한다.
        /// </summary>
        /// <param name="codeMode"></param>
        /// <returns>void</returns>
        public void Comments_Query(string bunho, string naewonDate)
        {
            this.gridListResult = this.GetGroupedGridListResult(bunho, naewonDate);            
            this.grdList.QueryLayout(false);
        }

        public void Reset()
        {
            gridListResult = null;
            grdList.QueryLayout(false);
        }

    }
}
