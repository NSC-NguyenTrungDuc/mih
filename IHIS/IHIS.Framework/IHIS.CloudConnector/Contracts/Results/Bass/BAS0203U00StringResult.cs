using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0203U00StringResult : AbstractContractResult
    {
        private String _resStr;

        public String ResStr
        {
            get { return this._resStr; }
            set { this._resStr = value; }
        }

        public BAS0203U00StringResult() { }

    }
}