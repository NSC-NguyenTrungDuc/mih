using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0118U00CheckHangmogCodeResult : AbstractContractResult
    {
        private List<OCS0118U00CheckHangmogCodeInfo> _checkHangmocCodeInfo = new List<OCS0118U00CheckHangmogCodeInfo>();

        public List<OCS0118U00CheckHangmogCodeInfo> CheckHangmocCodeInfo
        {
            get { return this._checkHangmocCodeInfo; }
            set { this._checkHangmocCodeInfo = value; }
        }

        public OCS0118U00CheckHangmogCodeResult() { }

    }
}