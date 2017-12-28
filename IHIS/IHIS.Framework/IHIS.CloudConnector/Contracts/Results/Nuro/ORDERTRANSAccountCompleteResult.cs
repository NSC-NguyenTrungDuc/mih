using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSAccountCompleteResult : AbstractContractResult
    {
        private String _errCode;
        private String _sangCnt;
        private String _orderCnt;

        public String ErrCode
        {
            get { return this._errCode; }
            set { this._errCode = value; }
        }

        public String SangCnt
        {
            get { return this._sangCnt; }
            set { this._sangCnt = value; }
        }

        public String OrderCnt
        {
            get { return this._orderCnt; }
            set { this._orderCnt = value; }
        }

        public ORDERTRANSAccountCompleteResult() { }

    }
}