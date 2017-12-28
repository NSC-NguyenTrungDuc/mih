using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    public class CPL0000Q00GrdOrderListResult : AbstractContractResult
    {
        private List<CPL0000Q00GrdOrderListInfo> _orderListItem = new List<CPL0000Q00GrdOrderListInfo>();

        public List<CPL0000Q00GrdOrderListInfo> OrderListItem
        {
            get { return this._orderListItem; }
            set { this._orderListItem = value; }
        }

        public CPL0000Q00GrdOrderListResult() { }

    }
}