using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class RES1001U00CheckJinryoYnResult : AbstractContractResult
    {
        private String _jinryoYn;

        public String JinryoYn
        {
            get { return this._jinryoYn; }
            set { this._jinryoYn = value; }
        }

        public RES1001U00CheckJinryoYnResult() { }

    }
}