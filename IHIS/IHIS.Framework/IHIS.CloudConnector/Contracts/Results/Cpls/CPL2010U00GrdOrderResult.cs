using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010U00GrdOrderResult : AbstractContractResult
    {
        private List<CPL2010U00GrdOrderListItemInfo> _grdOrderList = new List<CPL2010U00GrdOrderListItemInfo>();

        public List<CPL2010U00GrdOrderListItemInfo> GrdOrderList
        {
            get { return this._grdOrderList; }
            set { this._grdOrderList = value; }
        }

        public CPL2010U00GrdOrderResult() { }

    }
}