using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Clis
{
    [Serializable]
    public class CLIS2015U09GrdResult : AbstractContractResult
    {
        private List<CLIS2015U09ItemInfo> _dt = new List<CLIS2015U09ItemInfo>();

        public List<CLIS2015U09ItemInfo> Dt
        {
            get { return this._dt; }
            set { this._dt = value; }
        }

        public CLIS2015U09GrdResult() { }

    }
}