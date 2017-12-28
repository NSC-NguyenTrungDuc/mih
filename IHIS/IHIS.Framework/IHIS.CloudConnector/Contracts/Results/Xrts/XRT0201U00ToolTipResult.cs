using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT0201U00ToolTipResult : AbstractContractResult
    {
        private List<XRT0201U00ToolTipInfo> _num = new List<XRT0201U00ToolTipInfo>();

        public List<XRT0201U00ToolTipInfo> Num
        {
            get { return this._num; }
            set { this._num = value; }
        }

        public XRT0201U00ToolTipResult() { }

    }
}