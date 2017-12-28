using System;
using IHIS.CloudConnector.Contracts.Models.Pfes;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Pfes
{
    [Serializable]
    public class PFE0101U01GrdMCodeResult : AbstractContractResult
    {
        private List<PFE0101U01GrdMCodeInfo> _grdMcodeItem = new List<PFE0101U01GrdMCodeInfo>();

        public List<PFE0101U01GrdMCodeInfo> GrdMcodeItem
        {
            get { return this._grdMcodeItem; }
            set { this._grdMcodeItem = value; }
        }

        public PFE0101U01GrdMCodeResult() { }

    }
}