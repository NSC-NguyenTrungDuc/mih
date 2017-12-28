using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0212U00LaydupCheckResult : AbstractContractResult
    {
        private String _layDupResult;

        public String LayDupResult
        {
            get { return this._layDupResult; }
            set { this._layDupResult = value; }
        }

        public BAS0212U00LaydupCheckResult() { }

    }
}