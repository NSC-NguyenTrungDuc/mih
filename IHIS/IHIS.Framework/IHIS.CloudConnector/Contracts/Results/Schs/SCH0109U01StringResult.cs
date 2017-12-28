using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
    public class SCH0109U01StringResult : AbstractContractResult
    {
        private String _resStr;

        public String ResStr
        {
            get { return this._resStr; }
            set { this._resStr = value; }
        }

        public SCH0109U01StringResult() { }

    }
}