using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0103U00GetNameProtocolResult : AbstractContractResult
    {
        private String _protocolName;

        public String ProtocolName
        {
            get { return this._protocolName; }
            set { this._protocolName = value; }
        }

        public OCS0103U00GetNameProtocolResult() { }

    }
}