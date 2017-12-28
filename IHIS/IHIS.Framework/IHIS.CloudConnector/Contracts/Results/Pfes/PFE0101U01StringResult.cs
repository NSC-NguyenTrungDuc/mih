using System;
using IHIS.CloudConnector.Contracts.Models.Pfes;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Pfes
{
    [Serializable]
    public class PFE0101U01StringResult : AbstractContractResult
    {
        private String _resStr;

        public String ResStr
        {
            get { return this._resStr; }
            set { this._resStr = value; }
        }

        public PFE0101U01StringResult() { }

    }
}