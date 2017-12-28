using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01InsertTableOUT1002Result : AbstractContractResult
    {
        private Boolean _resultInsert;

        public Boolean ResultInsert
        {
            get { return this._resultInsert; }
            set { this._resultInsert = value; }
        }

        public NuroOUT1001U01InsertTableOUT1002Result() { }

    }
}
