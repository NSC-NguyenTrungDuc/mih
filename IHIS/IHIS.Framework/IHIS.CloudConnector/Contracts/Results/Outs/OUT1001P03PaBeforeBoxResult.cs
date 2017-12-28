using System;
using IHIS.CloudConnector.Contracts.Models.Outs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Outs
{
    [Serializable]
    public class OUT1001P03PaBeforeBoxResult : AbstractContractResult
    {
        private String _bunhoType;

        public String BunhoType
        {
            get { return this._bunhoType; }
            set { this._bunhoType = value; }
        }

        public OUT1001P03PaBeforeBoxResult() { }

    }
}