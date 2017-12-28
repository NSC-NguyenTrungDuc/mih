using System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0110U00GrdJohapGubunResult : AbstractContractResult
    {
        private String _result;

        public String Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public BAS0110U00GrdJohapGubunResult() { }

    }
}