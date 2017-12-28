using System;
using IHIS.CloudConnector.Contracts.Models.Outs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Outs
{
    [Serializable]
    public class OUT1001P03GrdBeforeOrderResult : AbstractContractResult
    {
        private List<OUT1001P03GrdOrderInfo> _grdOrderInfo = new List<OUT1001P03GrdOrderInfo>();

        public List<OUT1001P03GrdOrderInfo> GrdOrderInfo
        {
            get { return this._grdOrderInfo; }
            set { this._grdOrderInfo = value; }
        }

        public OUT1001P03GrdBeforeOrderResult() { }

    }
}