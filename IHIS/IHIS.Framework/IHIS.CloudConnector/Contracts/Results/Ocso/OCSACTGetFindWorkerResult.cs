using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCSACTGetFindWorkerResult : AbstractContractResult
    {
        private List<OCSACTGetFindWorkerInfo> _fwItem = new List<OCSACTGetFindWorkerInfo>();

        public List<OCSACTGetFindWorkerInfo> FwItem
        {
            get { return this._fwItem; }
            set { this._fwItem = value; }
        }

        public OCSACTGetFindWorkerResult() { }

    }
}