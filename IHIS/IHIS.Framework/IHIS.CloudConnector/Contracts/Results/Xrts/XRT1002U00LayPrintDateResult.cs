using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT1002U00LayPrintDateResult : AbstractContractResult
    {
        private List<XRT1002U00LayPrintDateInfo> _layPrintDateItem = new List<XRT1002U00LayPrintDateInfo>();

        public List<XRT1002U00LayPrintDateInfo> LayPrintDateItem
        {
            get { return this._layPrintDateItem; }
            set { this._layPrintDateItem = value; }
        }

        public XRT1002U00LayPrintDateResult() { }

    }
}