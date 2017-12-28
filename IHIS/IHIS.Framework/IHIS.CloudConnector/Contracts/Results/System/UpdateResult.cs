using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable ]
    public class UpdateResult : AbstractContractResult
    {
        private bool _result;
        private String _msg;

        public bool Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public String Msg
        {
            get { return this._msg; }
            set { this._msg = value; }
        }

        public UpdateResult() { }

    }
}
