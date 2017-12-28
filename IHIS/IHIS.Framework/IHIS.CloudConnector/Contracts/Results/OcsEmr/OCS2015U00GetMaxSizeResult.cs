using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U00GetMaxSizeResult : AbstractContractResult
    {
        private String _maxSize;

        public String MaxSize
        {
            get { return this._maxSize; }
            set { this._maxSize = value; }
        }

        public OCS2015U00GetMaxSizeResult() { }

    }
}