using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class IFS0003U01StringResult : AbstractContractResult
    {
        private String _strRes;

        public String StrRes
        {
            get { return this._strRes; }
            set { this._strRes = value; }
        }

        public IFS0003U01StringResult() { }

    }
}