using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
    public class SCH0201U10GrdOrderListResult : AbstractContractResult
    {
        private List<SCH0201U10GrdOrderListInfo> _grdOrderList = new List<SCH0201U10GrdOrderListInfo>();

        public List<SCH0201U10GrdOrderListInfo> GrdOrderList
        {
            get { return this._grdOrderList; }
            set { this._grdOrderList = value; }
        }

        public SCH0201U10GrdOrderListResult() { }

    }
}