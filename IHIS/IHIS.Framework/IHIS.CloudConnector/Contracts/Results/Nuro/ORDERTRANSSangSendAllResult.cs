using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSSangSendAllResult : AbstractContractResult
    {
        private List<ORDERTRANSSangSendAllInfo> _sangInfoItem = new List<ORDERTRANSSangSendAllInfo>();

        public List<ORDERTRANSSangSendAllInfo> SangInfoItem
        {
            get { return this._sangInfoItem; }
            set { this._sangInfoItem = value; }
        }

        public ORDERTRANSSangSendAllResult() { }

    }
}