using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0103U00LayCommonSgCodeResult : AbstractContractResult
    {
        private List<OCS0103U00LayCommonInfo> _layCommonSgItem = new List<OCS0103U00LayCommonInfo>();

        public List<OCS0103U00LayCommonInfo> LayCommonSgItem
        {
            get { return this._layCommonSgItem; }
            set { this._layCommonSgItem = value; }
        }

        public OCS0103U00LayCommonSgCodeResult() { }

    }
}