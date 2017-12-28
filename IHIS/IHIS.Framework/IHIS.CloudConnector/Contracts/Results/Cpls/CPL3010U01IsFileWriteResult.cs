using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL3010U01IsFileWriteResult : AbstractContractResult
    {
        private String _retval;
        private Boolean _result;

        public String Retval
        {
            get { return this._retval; }
            set { this._retval = value; }
        }

        public Boolean Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public CPL3010U01IsFileWriteResult() { }

    }
}