using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Clis
{
    [Serializable]
    public class CLIS2015U04GetProtocolItemResult : AbstractContractResult
    {
        private List<CLIS2015U04GetProtocolItemInfo> _num = new List<CLIS2015U04GetProtocolItemInfo>();

        public List<CLIS2015U04GetProtocolItemInfo> Num
        {
            get { return this._num; }
            set { this._num = value; }
        }

        public CLIS2015U04GetProtocolItemResult() { }

    }
}