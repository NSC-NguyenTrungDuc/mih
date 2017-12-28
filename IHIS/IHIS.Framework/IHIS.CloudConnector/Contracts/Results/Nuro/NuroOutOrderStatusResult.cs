using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOutOrderStatusResult : AbstractContractResult
    {
        private List<NuroOutOrderStatusInfo> _lstOrderStatusInfos = new List<NuroOutOrderStatusInfo>();

        public List<NuroOutOrderStatusInfo> LstOrderStatusInfos
        {
            get { return _lstOrderStatusInfos; }
            set { _lstOrderStatusInfos = value; }
        }

        public NuroOutOrderStatusResult()
        {
        }

        public NuroOutOrderStatusResult(List<NuroOutOrderStatusInfo> lstOrderStatusInfos)
        {
            LstOrderStatusInfos = lstOrderStatusInfos;
        }
    }
}
