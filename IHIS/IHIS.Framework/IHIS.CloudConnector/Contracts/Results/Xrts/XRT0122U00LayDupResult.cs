using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT0122U00LayDupResult : AbstractContractResult
    {
        private String _dupYn;

        public String DupYn
        {
            get { return this._dupYn; }
            set { this._dupYn = value; }
        }

        public XRT0122U00LayDupResult() { }

    }
}