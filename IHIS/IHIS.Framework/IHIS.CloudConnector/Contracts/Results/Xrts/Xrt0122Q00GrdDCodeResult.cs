using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class Xrt0122Q00GrdDCodeResult : AbstractContractResult
    {
        private List<Xrt0122Q00GrdDCodeListItemInfo> _infoList = new List<Xrt0122Q00GrdDCodeListItemInfo>();

        public List<Xrt0122Q00GrdDCodeListItemInfo> InfoList
        {
            get { return this._infoList; }
            set { this._infoList = value; }
        }

        public Xrt0122Q00GrdDCodeResult() { }

    }
}