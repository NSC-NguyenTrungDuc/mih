using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
    public class Schs0201U99CheckInsertResult : AbstractContractResult
    {
        private String _chkResult;

        public String ChkResult
        {
            get { return this._chkResult; }
            set { this._chkResult = value; }
        }

        public Schs0201U99CheckInsertResult() { }

    }
}