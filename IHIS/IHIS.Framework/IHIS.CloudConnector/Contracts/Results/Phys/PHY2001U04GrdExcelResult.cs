using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY2001U04GrdExcelResult : AbstractContractResult
    {
        private List<PHY2001U04GrdExcelInfo> _grdExcelItem = new List<PHY2001U04GrdExcelInfo>();

        public List<PHY2001U04GrdExcelInfo> GrdExcelItem
        {
            get { return this._grdExcelItem; }
            set { this._grdExcelItem = value; }
        }

        public PHY2001U04GrdExcelResult() { }

    }
}