using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroInspectionOrderGetMaxCodeNameResult : AbstractContractResult
    {
        private List<String> _codeNameItem = new List<String>();

        public List<String> CodeNameItem
        {
            get { return this._codeNameItem; }
            set { this._codeNameItem = value; }
        }

        public NuroInspectionOrderGetMaxCodeNameResult() { }

    }
}