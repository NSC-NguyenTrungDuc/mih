using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0311U00layDupHangmogCodeResult : AbstractContractResult
    {
        private String _layDupHangmogCode;

        public String LayDupHangmogCode
        {
            get { return this._layDupHangmogCode; }
            set { this._layDupHangmogCode = value; }
        }

        public OCS0311U00layDupHangmogCodeResult() { }

    }
}