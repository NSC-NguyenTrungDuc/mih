using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class Xrt0122Q00GrdMCodeResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _infoList = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> InfoList
        {
            get { return this._infoList; }
            set { this._infoList = value; }
        }

        public Xrt0122Q00GrdMCodeResult() { }

    }
}