using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01GetDbMaxJubsuNoResult : AbstractContractResult
    {
        private String _maxJubsuNo;

        public String MaxJubsuNo
        {
            get { return this._maxJubsuNo; }
            set { this._maxJubsuNo = value; }
        }

        public NuroOUT1001U01GetDbMaxJubsuNoResult() { }

    }
}
