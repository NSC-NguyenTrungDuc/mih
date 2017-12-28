using System;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010U00OrderCancelGetYNResult : AbstractContractResult
    {
        private String _ynValue;

        public String YnValue
        {
            get { return this._ynValue; }
            set { this._ynValue = value; }
        }

        public CPL2010U00OrderCancelGetYNResult() { }

    }
}