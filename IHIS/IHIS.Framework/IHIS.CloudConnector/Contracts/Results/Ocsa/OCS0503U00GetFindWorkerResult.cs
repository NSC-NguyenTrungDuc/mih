using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0503U00GetFindWorkerResult : AbstractContractResult
    {
        private List<OCS0503U00GetFindWorkerConsultGwaInfo> _findWorker = new List<OCS0503U00GetFindWorkerConsultGwaInfo>();

        public List<OCS0503U00GetFindWorkerConsultGwaInfo> FindWorker
        {
            get { return this._findWorker; }
            set { this._findWorker = value; }
        }

        public OCS0503U00GetFindWorkerResult() { }

    }
}