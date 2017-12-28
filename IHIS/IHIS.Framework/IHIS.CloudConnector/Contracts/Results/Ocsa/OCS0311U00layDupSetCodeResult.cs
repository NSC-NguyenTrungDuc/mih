using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0311U00layDupSetCodeResult : AbstractContractResult
    {
        private String _layDupSetCode;

        public String LayDupSetCode
        {
            get { return this._layDupSetCode; }
            set { this._layDupSetCode = value; }
        }

        public OCS0311U00layDupSetCodeResult() { }

    }
}