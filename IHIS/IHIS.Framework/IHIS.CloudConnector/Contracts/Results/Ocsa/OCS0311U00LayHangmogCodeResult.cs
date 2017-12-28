using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0311U00LayHangmogCodeResult : AbstractContractResult
    {
        private String _hangmogCode;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public OCS0311U00LayHangmogCodeResult() { }

    }
}