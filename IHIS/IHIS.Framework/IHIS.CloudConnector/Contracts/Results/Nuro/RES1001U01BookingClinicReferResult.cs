using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class RES1001U01BookingClinicReferResult : AbstractContractResult
    {
        private List<RES1001U01BookingClinicReferInfo> _lst = new List<RES1001U01BookingClinicReferInfo>();

        public List<RES1001U01BookingClinicReferInfo> Lst
        {
            get { return this._lst; }
            set { this._lst = value; }
        }

        public RES1001U01BookingClinicReferResult() { }

    }
}