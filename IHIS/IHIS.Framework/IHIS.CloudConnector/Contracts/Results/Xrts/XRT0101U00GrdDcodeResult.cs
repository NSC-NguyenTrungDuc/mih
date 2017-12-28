using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT0101U00GrdDcodeResult : AbstractContractResult
    {
        private List<XRT0101U00GrdDcodeInfo> _dcodeItem = new List<XRT0101U00GrdDcodeInfo>();

        public List<XRT0101U00GrdDcodeInfo> DcodeItem
        {
            get { return this._dcodeItem; }
            set { this._dcodeItem = value; }
        }

        public XRT0101U00GrdDcodeResult() { }

    }
}