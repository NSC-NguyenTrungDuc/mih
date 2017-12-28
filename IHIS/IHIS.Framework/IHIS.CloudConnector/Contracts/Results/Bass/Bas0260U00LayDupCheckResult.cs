using System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class Bas0260U00LayDupCheckResult : AbstractContractResult
    {
        private String _layDupResult;

        public String LayDupResult
        {
            get { return this._layDupResult; }
            set { this._layDupResult = value; }
        }

        public Bas0260U00LayDupCheckResult() { }

    }
}