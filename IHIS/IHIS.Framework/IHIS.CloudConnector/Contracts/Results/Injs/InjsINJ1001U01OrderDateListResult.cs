using System;
using IHIS.CloudConnector.Contracts.Models.Injs;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
    public class InjsINJ1001U01OrderDateListResult : AbstractContractResult
    {
        private List<DataStringListItemInfo> _orderDate = new List<DataStringListItemInfo>();

        public List<DataStringListItemInfo> OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public InjsINJ1001U01OrderDateListResult() { }

    }
}