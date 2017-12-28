using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0103U00LayCommonJaeryoCodeResult : AbstractContractResult
    {
        private List<OCS0103U00LayCommonInfo> _layCommonJearyoItem = new List<OCS0103U00LayCommonInfo>();

        public List<OCS0103U00LayCommonInfo> LayCommonJearyoItem
        {
            get { return this._layCommonJearyoItem; }
            set { this._layCommonJearyoItem = value; }
        }

        public OCS0103U00LayCommonJaeryoCodeResult() { }

    }
}