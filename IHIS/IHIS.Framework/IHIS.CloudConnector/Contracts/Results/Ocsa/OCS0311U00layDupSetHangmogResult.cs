using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0311U00layDupSetHangmogResult : AbstractContractResult
    {
        private String _layDupSetHangmog;

        public String LayDupSetHangmog
        {
            get { return this._layDupSetHangmog; }
            set { this._layDupSetHangmog = value; }
        }

        public OCS0311U00layDupSetHangmogResult() { }

    }
}