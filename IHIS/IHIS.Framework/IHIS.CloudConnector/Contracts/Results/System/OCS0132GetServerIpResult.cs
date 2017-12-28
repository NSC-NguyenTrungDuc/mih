using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class OCS0132GetServerIpResult : AbstractContractResult
    {
        private String _serverIp;

        public String ServerIp
        {
            get { return this._serverIp; }
            set { this._serverIp = value; }
        }

        public OCS0132GetServerIpResult() { }

    }
}