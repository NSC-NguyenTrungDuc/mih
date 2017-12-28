using System;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010U00LayPrintNameResult : AbstractContractResult
    {
        private String _printName;

        public String PrintName
        {
            get { return this._printName; }
            set { this._printName = value; }
        }

        public CPL2010U00LayPrintNameResult() { }

    }
}