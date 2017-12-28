using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Xrts;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT0123U00GrdDCodeResult : AbstractContractResult
    {
        private List<XRT0123U00GrdDCodeItemInfo> _listInfo = new List<XRT0123U00GrdDCodeItemInfo>();

        public List<XRT0123U00GrdDCodeItemInfo> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public XRT0123U00GrdDCodeResult() { }

    }
}