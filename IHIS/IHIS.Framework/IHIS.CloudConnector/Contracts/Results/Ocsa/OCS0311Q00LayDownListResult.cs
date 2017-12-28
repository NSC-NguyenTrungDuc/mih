using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0311Q00LayDownListResult : AbstractContractResult
    {
        private List<OCS0311Q00LayDownListInfo> _layDownListItem = new List<OCS0311Q00LayDownListInfo>();

        public List<OCS0311Q00LayDownListInfo> LayDownListItem
        {
            get { return this._layDownListItem; }
            set { this._layDownListItem = value; }
        }

        public OCS0311Q00LayDownListResult() { }

    }
}