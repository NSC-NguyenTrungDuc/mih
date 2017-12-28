using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class DOC4003U00GetNextValResult : AbstractContractResult
    {
        private String _nextVal;

        public String NextVal
        {
            get { return this._nextVal; }
            set { this._nextVal = value; }
        }

        public DOC4003U00GetNextValResult() { }

    }
}