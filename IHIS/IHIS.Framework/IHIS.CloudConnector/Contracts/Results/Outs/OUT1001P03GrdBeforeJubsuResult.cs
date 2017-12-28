using System;
using IHIS.CloudConnector.Contracts.Models.Outs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Outs
{
    [Serializable]
    public class OUT1001P03GrdBeforeJubsuResult : AbstractContractResult
    {
        private List<OUT1001P03GrdBeforeJubsuInfo> _grdBeforeJubsuInfo = new List<OUT1001P03GrdBeforeJubsuInfo>();

        public List<OUT1001P03GrdBeforeJubsuInfo> GrdBeforeJubsuInfo
        {
            get { return this._grdBeforeJubsuInfo; }
            set { this._grdBeforeJubsuInfo = value; }
        }

        public OUT1001P03GrdBeforeJubsuResult() { }

    }
}