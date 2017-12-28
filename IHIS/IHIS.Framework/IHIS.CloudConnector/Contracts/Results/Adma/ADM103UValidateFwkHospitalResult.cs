using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class ADM103UValidateFwkHospitalResult : AbstractContractResult
    {
        private String _hospName;

        public String HospName
        {
            get { return this._hospName; }
            set { this._hospName = value; }
        }

        public ADM103UValidateFwkHospitalResult() { }

    }
}