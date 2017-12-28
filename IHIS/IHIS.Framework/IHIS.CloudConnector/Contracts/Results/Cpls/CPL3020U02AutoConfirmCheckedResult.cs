using System;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL3020U02AutoConfirmCheckedResult : AbstractContractResult
    {
        private String _codeValue;

        public String CodeValue
        {
            get { return this._codeValue; }
            set { this._codeValue = value; }
        }

        public CPL3020U02AutoConfirmCheckedResult() { }

    }
}