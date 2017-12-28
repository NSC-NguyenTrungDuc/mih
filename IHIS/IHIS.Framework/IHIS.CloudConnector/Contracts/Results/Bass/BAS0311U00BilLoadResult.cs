using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0311U00BilLoadResult : AbstractContractResult
    {
        private String _val;

        public String Val
        {
            get { return this._val; }
            set { this._val = value; }
        }

        public BAS0311U00BilLoadResult() { }

    }
}