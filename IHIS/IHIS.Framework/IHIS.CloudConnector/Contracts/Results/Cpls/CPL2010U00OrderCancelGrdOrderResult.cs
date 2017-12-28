using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010U00OrderCancelGrdOrderResult : AbstractContractResult
    {
        private List<CPL2010U00OrderCancelGrdOrderListItemInfo> _grdOrderList = new List<CPL2010U00OrderCancelGrdOrderListItemInfo>();

        public List<CPL2010U00OrderCancelGrdOrderListItemInfo> GrdOrderList
        {
            get { return this._grdOrderList; }
            set { this._grdOrderList = value; }
        }

        public CPL2010U00OrderCancelGrdOrderResult() { }

    }
}