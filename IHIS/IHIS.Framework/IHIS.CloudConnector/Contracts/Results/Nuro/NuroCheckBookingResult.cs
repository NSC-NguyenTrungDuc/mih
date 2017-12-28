using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;


namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroCheckBookingResult : AbstractContractResult
    {
        private List<NuroCheckBookingInfo> _checkBookingInfo = new List<NuroCheckBookingInfo>();

        public List<NuroCheckBookingInfo> CheckBookingInfo
        {
            get { return this._checkBookingInfo; }
            set { this._checkBookingInfo = value; }
        }

        public NuroCheckBookingResult() { }

    }
}
