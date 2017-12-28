using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0311Q00LayRootListResult : AbstractContractResult
    {
        private List<OCS0311Q00LayRootListInfo> _layRootListItem = new List<OCS0311Q00LayRootListInfo>();

        public List<OCS0311Q00LayRootListInfo> LayRootListItem
        {
            get { return this._layRootListItem; }
            set { this._layRootListItem = value; }
        }

        public OCS0311Q00LayRootListResult() { }

    }
}