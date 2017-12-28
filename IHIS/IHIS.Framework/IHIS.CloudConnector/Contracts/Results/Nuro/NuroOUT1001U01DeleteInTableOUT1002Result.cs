using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01DeleteInTableOUT1002Result : AbstractContractResult
    {
        private Boolean _resultDelete;

        public Boolean ResultDelete
        {
            get { return this._resultDelete; }
            set { this._resultDelete = value; }
        }

        public NuroOUT1001U01DeleteInTableOUT1002Result() { }

    }
}