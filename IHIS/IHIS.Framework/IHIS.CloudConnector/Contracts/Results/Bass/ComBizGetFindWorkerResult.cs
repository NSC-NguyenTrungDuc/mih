using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class ComBizGetFindWorkerResult : AbstractContractResult
    {
        private List<ComBizGetFindWorkerInfo> _infoList = new List<ComBizGetFindWorkerInfo>();

        public List<ComBizGetFindWorkerInfo> InfoList
        {
            get { return this._infoList; }
            set { this._infoList = value; }
        }

        public ComBizGetFindWorkerResult() { }

    }
}