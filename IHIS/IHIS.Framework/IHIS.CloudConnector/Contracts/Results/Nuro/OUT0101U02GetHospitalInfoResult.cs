using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class OUT0101U02GetHospitalInfoResult : AbstractContractResult
    {
        private List<OUT0101U02HospitalItemInfo> _hospList = new List<OUT0101U02HospitalItemInfo>();

        public List<OUT0101U02HospitalItemInfo> HospList
        {
            get { return this._hospList; }
            set { this._hospList = value; }
        }

        public OUT0101U02GetHospitalInfoResult() { }

    }
}