using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OcsEmrHistoryClinicReferResult : AbstractContractResult
    {
        private List<OcsEmrHistoryClinicReferItemInfo> _lst = new List<OcsEmrHistoryClinicReferItemInfo>();

        public List<OcsEmrHistoryClinicReferItemInfo> Lst
        {
            get { return this._lst; }
            set { this._lst = value; }
        }

        public OcsEmrHistoryClinicReferResult() { }

    }
}