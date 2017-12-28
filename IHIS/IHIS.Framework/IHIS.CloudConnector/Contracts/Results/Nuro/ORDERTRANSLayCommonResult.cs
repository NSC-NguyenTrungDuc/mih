using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSLayCommonResult : AbstractContractResult
    {
        private List<ORDERTRANSLayCommonInfo> _layCommonItem = new List<ORDERTRANSLayCommonInfo>();

        public List<ORDERTRANSLayCommonInfo> LayCommonItem
        {
            get { return this._layCommonItem; }
            set { this._layCommonItem = value; }
        }

        public ORDERTRANSLayCommonResult() { }

    }
}