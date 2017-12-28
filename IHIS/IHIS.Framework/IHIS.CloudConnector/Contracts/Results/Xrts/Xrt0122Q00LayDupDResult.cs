using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class Xrt0122Q00LayDupDResult : AbstractContractResult
    {
        private String _yValue;

        public String YValue
        {
            get { return this._yValue; }
            set { this._yValue = value; }
        }

        public Xrt0122Q00LayDupDResult() { }

    }
}