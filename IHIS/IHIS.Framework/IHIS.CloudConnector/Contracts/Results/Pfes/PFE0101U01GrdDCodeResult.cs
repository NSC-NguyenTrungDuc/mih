using System;
using IHIS.CloudConnector.Contracts.Models.Pfes;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Pfes
{
    [Serializable]
    public class PFE0101U01GrdDCodeResult : AbstractContractResult
    {
        private List<PFE0101U01GrdDCodeInfo> _grdDcodeItem = new List<PFE0101U01GrdDCodeInfo>();

        public List<PFE0101U01GrdDCodeInfo> GrdDcodeItem
        {
            get { return this._grdDcodeItem; }
            set { this._grdDcodeItem = value; }
        }

        public PFE0101U01GrdDCodeResult() { }

    }
}