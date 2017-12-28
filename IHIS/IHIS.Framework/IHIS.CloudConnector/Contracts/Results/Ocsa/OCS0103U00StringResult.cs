using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0103U00StringResult : AbstractContractResult
    {
        private String _resStr;

        public String ResStr
        {
            get { return this._resStr; }
            set { this._resStr = value; }
        }

        public OCS0103U00StringResult() { }

    }
}