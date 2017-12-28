using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    public class DRG0120U00GrdDrg0120Result : AbstractContractResult
    {
        private List<DRG0120U00GrdDrg0120ItemInfo> _listInfo = new List<DRG0120U00GrdDrg0120ItemInfo>();

        public List<DRG0120U00GrdDrg0120ItemInfo> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public DRG0120U00GrdDrg0120Result() { }

    }
}