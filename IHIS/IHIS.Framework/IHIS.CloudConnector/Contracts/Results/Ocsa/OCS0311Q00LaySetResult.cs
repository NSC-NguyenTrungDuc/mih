using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0311Q00LaySetResult : AbstractContractResult
    {
        private List<OCS0311Q00LaySetInfo> _laySetItem = new List<OCS0311Q00LaySetInfo>();

        public List<OCS0311Q00LaySetInfo> LaySetItem
        {
            get { return this._laySetItem; }
            set { this._laySetItem = value; }
        }

        public OCS0311Q00LaySetResult() { }

    }
}