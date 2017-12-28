using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01DeleteJubsuDataResult : AbstractContractResult
    {
        private bool _resultDelete;

        public bool ResultDelete
        {
            get { return this._resultDelete; }
            set { this._resultDelete = value; }
        }

        public NuroOUT1001U01DeleteJubsuDataResult() { }

    }
}
