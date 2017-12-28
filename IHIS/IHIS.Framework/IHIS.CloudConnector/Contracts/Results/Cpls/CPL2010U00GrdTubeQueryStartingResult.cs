using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010U00GrdTubeQueryStartingResult : AbstractContractResult
    {
        private List<CPL2010U00GrdTubeListItemInfo> _grdTubeList = new List<CPL2010U00GrdTubeListItemInfo>();

        public List<CPL2010U00GrdTubeListItemInfo> GrdTubeList
        {
            get { return this._grdTubeList; }
            set { this._grdTubeList = value; }
        }

        public CPL2010U00GrdTubeQueryStartingResult() { }

    }
}