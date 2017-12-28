using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01GetOut1001SeqResult : AbstractContractResult
    {
        private String _out1001SeqValue;

        public String Out1001SeqValue
        {
            get { return this._out1001SeqValue; }
            set { this._out1001SeqValue = value; }
        }

        public NuroOUT1001U01GetOut1001SeqResult() { }

    }
}
