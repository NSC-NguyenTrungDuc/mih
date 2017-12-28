using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT0101U00GrdMcodeResult : AbstractContractResult
    {
        private List<XRT0101U00GrdMcodeInfo> _mcodeItem = new List<XRT0101U00GrdMcodeInfo>();

        public List<XRT0101U00GrdMcodeInfo> McodeItem
        {
            get { return this._mcodeItem; }
            set { this._mcodeItem = value; }
        }

        public XRT0101U00GrdMcodeResult() { }

    }
}