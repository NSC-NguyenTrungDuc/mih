using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT0101U01LayDupMResult : AbstractContractResult
    {
        private String _yValue;

        public String YValue
        {
            get { return this._yValue; }
            set { this._yValue = value; }
        }

        public XRT0101U01LayDupMResult() { }

    }
}