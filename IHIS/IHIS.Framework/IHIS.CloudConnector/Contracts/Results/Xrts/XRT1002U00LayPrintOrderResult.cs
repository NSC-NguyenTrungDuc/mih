using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT1002U00LayPrintOrderResult : AbstractContractResult
    {
        private List<XRT1002U00LayPrintOrderInfo> _layPrintOrderItem = new List<XRT1002U00LayPrintOrderInfo>();

        public List<XRT1002U00LayPrintOrderInfo> LayPrintOrderItem
        {
            get { return this._layPrintOrderItem; }
            set { this._layPrintOrderItem = value; }
        }

        public XRT1002U00LayPrintOrderResult() { }

    }
}