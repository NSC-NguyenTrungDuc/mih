using System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0110U00LayDupCheckResult : AbstractContractResult
    {
        private String _layChk;

        public String LayChk
        {
            get { return this._layChk; }
            set { this._layChk = value; }
        }

        public BAS0110U00LayDupCheckResult() { }

    }
}