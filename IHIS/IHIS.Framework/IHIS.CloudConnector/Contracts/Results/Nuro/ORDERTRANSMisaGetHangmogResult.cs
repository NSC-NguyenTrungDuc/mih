using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSMisaGetHangmogResult : AbstractContractResult
    {
        private List<ORDERTRANSMisaGetHangmogInfo> _lst = new List<ORDERTRANSMisaGetHangmogInfo>();

        public List<ORDERTRANSMisaGetHangmogInfo> Lst
        {
            get { return this._lst; }
            set { this._lst = value; }
        }

        public ORDERTRANSMisaGetHangmogResult() { }

    }
}