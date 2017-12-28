using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT1002U00DsvSideEffectResult : AbstractContractResult
    {
        private List<XRT1002U00DsvSideEffectInfo> _dsvSideEffectItem = new List<XRT1002U00DsvSideEffectInfo>();

        public List<XRT1002U00DsvSideEffectInfo> DsvSideEffectItem
        {
            get { return this._dsvSideEffectItem; }
            set { this._dsvSideEffectItem = value; }
        }

        public XRT1002U00DsvSideEffectResult() { }

    }
}