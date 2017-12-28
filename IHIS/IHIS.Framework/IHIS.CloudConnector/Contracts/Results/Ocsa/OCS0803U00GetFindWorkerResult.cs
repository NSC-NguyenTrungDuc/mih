using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0803U00GetFindWorkerResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _findWorker = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> FindWorker
        {
            get { return this._findWorker; }
            set { this._findWorker = value; }
        }

        public OCS0803U00GetFindWorkerResult() { }

    }
}