using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV4001NextSeqResult : AbstractContractResult
    {
        private String _nextVal;

        public String NextVal
        {
            get { return this._nextVal; }
            set { this._nextVal = value; }
        }

        public INV4001NextSeqResult() { }

    }
}