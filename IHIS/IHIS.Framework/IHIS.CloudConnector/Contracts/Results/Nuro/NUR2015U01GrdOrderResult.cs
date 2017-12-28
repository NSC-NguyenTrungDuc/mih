using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class NUR2015U01GrdOrderResult : AbstractContractResult
    {
        private List<NUR2015U01GrdOrderInfo> _grdOrderList = new List<NUR2015U01GrdOrderInfo>();

        public List<NUR2015U01GrdOrderInfo> GrdOrderList
        {
            get { return this._grdOrderList; }
            set { this._grdOrderList = value; }
        }

        public NUR2015U01GrdOrderResult() { }

    }
}