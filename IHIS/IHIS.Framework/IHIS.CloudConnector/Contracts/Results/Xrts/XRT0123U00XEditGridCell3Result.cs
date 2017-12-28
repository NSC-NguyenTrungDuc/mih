using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT0123U00XEditGridCell3Result : AbstractContractResult
    {
        private List<ComboListItemInfo> _cboCell = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> CboCell
        {
            get { return this._cboCell; }
            set { this._cboCell = value; }
        }

        public XRT0123U00XEditGridCell3Result() { }

    }
}