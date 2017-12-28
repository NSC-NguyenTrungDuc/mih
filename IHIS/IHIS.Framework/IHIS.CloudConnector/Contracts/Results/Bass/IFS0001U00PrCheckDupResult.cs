using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class IFS0001U00PrCheckDupResult : AbstractContractResult
    {
        private String _dupYn;

        public String DupYn
        {
            get { return this._dupYn; }
            set { this._dupYn = value; }
        }

        public IFS0001U00PrCheckDupResult() { }

    }
}