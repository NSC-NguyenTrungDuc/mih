using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT1002U00DsvRequestDataResult : AbstractContractResult
    {
        private List<XRT1002U00DsvRequestDataInfo> _dsvReqDataItem = new List<XRT1002U00DsvRequestDataInfo>();

        public List<XRT1002U00DsvRequestDataInfo> DsvReqDataItem
        {
            get { return this._dsvReqDataItem; }
            set { this._dsvReqDataItem = value; }
        }

        public XRT1002U00DsvRequestDataResult() { }

    }
}