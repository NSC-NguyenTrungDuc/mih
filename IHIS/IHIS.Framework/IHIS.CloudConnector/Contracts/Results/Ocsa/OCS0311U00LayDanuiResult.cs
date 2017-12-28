using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0311U00LayDanuiResult : AbstractContractResult
    {
        private String _layDanui;

        public String LayDanui
        {
            get { return this._layDanui; }
            set { this._layDanui = value; }
        }

        public OCS0311U00LayDanuiResult() { }

    }
}