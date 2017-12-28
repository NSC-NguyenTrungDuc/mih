using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class IFS0003U00LayDupCheckResult : AbstractContractResult
    {
        private String _yValue;

        public String YValue
        {
            get { return this._yValue; }
            set { this._yValue = value; }
        }

        public IFS0003U00LayDupCheckResult() { }

    }
}