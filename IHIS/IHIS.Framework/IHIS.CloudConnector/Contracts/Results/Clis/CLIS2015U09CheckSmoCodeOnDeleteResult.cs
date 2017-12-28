using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Clis
{
    [Serializable]
    public class CLIS2015U09CheckSmoCodeOnDeleteResult : AbstractContractResult
    {
        private String _cnt;

        public String Cnt
        {
            get { return this._cnt; }
            set { this._cnt = value; }
        }

        public CLIS2015U09CheckSmoCodeOnDeleteResult() { }

    }
}