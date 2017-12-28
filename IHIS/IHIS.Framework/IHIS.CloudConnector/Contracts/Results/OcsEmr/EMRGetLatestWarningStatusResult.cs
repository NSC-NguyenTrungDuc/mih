using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class EMRGetLatestWarningStatusResult : AbstractContractResult
    {
        private EMRGetLatestWarningStatusInfo _warningStatusInfo;

        public EMRGetLatestWarningStatusInfo WarningStatusInfo
        {
            get { return this._warningStatusInfo; }
            set { this._warningStatusInfo = value; }
        }

        public EMRGetLatestWarningStatusResult() { }

    }
}