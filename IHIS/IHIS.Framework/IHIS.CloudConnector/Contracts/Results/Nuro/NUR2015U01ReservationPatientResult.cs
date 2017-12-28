using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class NUR2015U01ReservationPatientResult : AbstractContractResult
    {
        private String _reservationId;

        public String ReservationId
        {
            get { return this._reservationId; }
            set { this._reservationId = value; }
        }

        public NUR2015U01ReservationPatientResult() { }

    }
}