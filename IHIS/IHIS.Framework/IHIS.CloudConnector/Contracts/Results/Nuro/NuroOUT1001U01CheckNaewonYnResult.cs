using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01CheckNaewonYnResult : AbstractContractResult
    {
        private String _valueCheckNaewon;

        public String ValueCheckNaewon
        {
            get { return this._valueCheckNaewon; }
            set { this._valueCheckNaewon = value; }
        }

        public NuroOUT1001U01CheckNaewonYnResult() { }

    }
}
