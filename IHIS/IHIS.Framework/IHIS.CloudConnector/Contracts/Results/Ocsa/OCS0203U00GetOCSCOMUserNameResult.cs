using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0203U00GetOCSCOMUserNameResult : AbstractContractResult
    {
        private String _membName;

        public String MembName
        {
            get { return this._membName; }
            set { this._membName = value; }
        }

        public OCS0203U00GetOCSCOMUserNameResult() { }

    }
}