using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class RES1001U00PrIFSMakeYoyakuResult : AbstractContractResult
    {
        private String _pkifs1002;
        private String _errMsg;

        public String Pkifs1002
        {
            get { return this._pkifs1002; }
            set { this._pkifs1002 = value; }
        }

        public String ErrMsg
        {
            get { return this._errMsg; }
            set { this._errMsg = value; }
        }

        public RES1001U00PrIFSMakeYoyakuResult() { }

    }
}