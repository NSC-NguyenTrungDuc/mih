using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT1002U00LayOrderByJundalPartResult : AbstractContractResult
    {
        private List<XRT1002U00LayOrderByJundalPartInfo> _layOrderByJundItem = new List<XRT1002U00LayOrderByJundalPartInfo>();

        public List<XRT1002U00LayOrderByJundalPartInfo> LayOrderByJundItem
        {
            get { return this._layOrderByJundItem; }
            set { this._layOrderByJundItem = value; }
        }

        public XRT1002U00LayOrderByJundalPartResult() { }

    }
}