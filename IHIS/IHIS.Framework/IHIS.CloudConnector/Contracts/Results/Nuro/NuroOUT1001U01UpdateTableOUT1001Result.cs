using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01UpdateTableOUT1001Result : AbstractContractResult
    {
        private Boolean _valueUpdateOut1001;

        public Boolean ValueUpdateOut1001
        {
            get { return this._valueUpdateOut1001; }
            set { this._valueUpdateOut1001 = value; }
        }

        public NuroOUT1001U01UpdateTableOUT1001Result() { }

    }
}