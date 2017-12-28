using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    public class OCS4001U00SaveResult : AbstractContractResult
    {
        private Boolean _result;

        public Boolean Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public OCS4001U00SaveResult() { }

    }
}