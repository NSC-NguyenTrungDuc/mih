using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT0123U00grdMCodeResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _listGrd = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> ListGrd
        {
            get { return this._listGrd; }
            set { this._listGrd = value; }
        }

        public XRT0123U00grdMCodeResult() { }

    }
}