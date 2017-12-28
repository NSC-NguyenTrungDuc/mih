using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
    public class SCH0201U10LayReserInfoQueryEndResult : AbstractContractResult
    {
        private String _reserMoveName;

        public String ReserMoveName
        {
            get { return this._reserMoveName; }
            set { this._reserMoveName = value; }
        }

        public SCH0201U10LayReserInfoQueryEndResult() { }

    }
}