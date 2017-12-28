using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0101U00TransactionalResult : AbstractContractResult
    {
        private Boolean _resultOcs0101;
        private Boolean _resultOcs0102;
        private String _msg;

        public Boolean ResultOcs0101
        {
            get { return this._resultOcs0101; }
            set { this._resultOcs0101 = value; }
        }

        public Boolean ResultOcs0102
        {
            get { return this._resultOcs0102; }
            set { this._resultOcs0102 = value; }
        }

        public String Msg
        {
            get { return this._msg; }
            set { this._msg = value; }
        }

        public OCS0101U00TransactionalResult() { }

    }
}