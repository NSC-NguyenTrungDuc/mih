using System;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT0123U00LayDupDResult : AbstractContractResult
    {
        private String _ynValue;

        public String YnValue
        {
            get { return this._ynValue; }
            set { this._ynValue = value; }
        }

        public XRT0123U00LayDupDResult() { }

    }
}