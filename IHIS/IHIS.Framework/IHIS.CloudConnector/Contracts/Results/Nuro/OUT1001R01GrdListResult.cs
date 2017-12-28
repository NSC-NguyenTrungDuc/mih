using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class OUT1001R01GrdListResult : AbstractContractResult
    {
        private List<OUT1001R01GrdListInfo> _gridList = new List<OUT1001R01GrdListInfo>();

        public List<OUT1001R01GrdListInfo> GridList
        {
            get { return this._gridList; }
            set { this._gridList = value; }
        }

        public OUT1001R01GrdListResult() { }

    }
}