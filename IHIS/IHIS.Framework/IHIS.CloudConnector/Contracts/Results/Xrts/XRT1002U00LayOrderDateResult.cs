using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT1002U00LayOrderDateResult : AbstractContractResult
    {
        private List<XRT1002U00LayOrderDateInfo> _layOrderDateItem = new List<XRT1002U00LayOrderDateInfo>();

        public List<XRT1002U00LayOrderDateInfo> LayOrderDateItem
        {
            get { return this._layOrderDateItem; }
            set { this._layOrderDateItem = value; }
        }

        public XRT1002U00LayOrderDateResult() { }

    }
}