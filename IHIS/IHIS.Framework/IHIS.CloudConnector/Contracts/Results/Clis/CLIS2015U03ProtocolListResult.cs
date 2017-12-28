using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Clis
{
    [Serializable]
    public class CLIS2015U03ProtocolListResult : AbstractContractResult
    {
        private List<CLIS2015U03ProtocolListInfo> _protocolListItem = new List<CLIS2015U03ProtocolListInfo>();

        public List<CLIS2015U03ProtocolListInfo> ProtocolListItem
        {
            get { return this._protocolListItem; }
            set { this._protocolListItem = value; }
        }

        public CLIS2015U03ProtocolListResult() { }

    }
}