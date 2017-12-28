using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class BAS0212U00UpdateRespone
    {
        private Boolean _result;

        public Boolean Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public BAS0212U00UpdateRespone() { }

        public BAS0212U00UpdateRespone(Boolean result)
        {
            this._result = result;
        }

    }
}