using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
    public class Schs0201U99BookingLabResult : AbstractContractResult
    {
        private String _errCode;

        public String ErrCode
        {
            get { return this._errCode; }
            set { this._errCode = value; }
        }

        public Schs0201U99BookingLabResult() { }

    }
}