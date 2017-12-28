using System;
using IHIS.CloudConnector.Contracts.Models.Bass;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0101U00PrBasGridColumnChangedResult : AbstractContractResult
    {
        private BAS0101U00PrBasGridColumnChangedItemInfo _grdMaster;

        public BAS0101U00PrBasGridColumnChangedItemInfo GrdMaster
        {
            get { return this._grdMaster; }
            set { this._grdMaster = value; }
        }

        public BAS0101U00PrBasGridColumnChangedResult() { }

    }
}