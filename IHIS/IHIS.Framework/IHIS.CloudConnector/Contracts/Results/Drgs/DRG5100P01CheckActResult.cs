using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
    public class DRG5100P01CheckActResult : AbstractContractResult
    {
        private String _code;

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public DRG5100P01CheckActResult() { }

    }
}