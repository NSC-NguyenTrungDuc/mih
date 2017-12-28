using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class BIL0102U00GetPatientEmailResult : AbstractContractResult
    {
        private String _email;

        public String Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        public BIL0102U00GetPatientEmailResult() { }

    }
}