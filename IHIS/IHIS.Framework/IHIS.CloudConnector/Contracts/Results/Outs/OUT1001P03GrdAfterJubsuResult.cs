using System;
using IHIS.CloudConnector.Contracts.Models.Outs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Outs
{
    [Serializable]
    public class OUT1001P03GrdAfterJubsuResult : AbstractContractResult
    {
        private List<OUT1001P03GrdAfterJubsuInfo> _grdAfterJubsuInfo = new List<OUT1001P03GrdAfterJubsuInfo>();

        public List<OUT1001P03GrdAfterJubsuInfo> GrdAfterJubsuInfo
        {
            get { return this._grdAfterJubsuInfo; }
            set { this._grdAfterJubsuInfo = value; }
        }

        public OUT1001P03GrdAfterJubsuResult() { }

    }
}