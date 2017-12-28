using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0203U00LaySlipResult : AbstractContractResult
    {
        private List<OCS0203U00LaySlipInfo> _infoList = new List<OCS0203U00LaySlipInfo>();

        public List<OCS0203U00LaySlipInfo> InfoList
        {
            get { return this._infoList; }
            set { this._infoList = value; }
        }

        public OCS0203U00LaySlipResult() { }

    }
}