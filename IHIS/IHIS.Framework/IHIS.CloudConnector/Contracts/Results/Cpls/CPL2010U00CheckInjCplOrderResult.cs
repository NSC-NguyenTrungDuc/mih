using System;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010U00CheckInjCplOrderResult : AbstractContractResult
    {
        private String _fnInjCplChkYn;

        public String FnInjCplChkYn
        {
            get { return this._fnInjCplChkYn; }
            set { this._fnInjCplChkYn = value; }
        }

        public CPL2010U00CheckInjCplOrderResult() { }

    }
}