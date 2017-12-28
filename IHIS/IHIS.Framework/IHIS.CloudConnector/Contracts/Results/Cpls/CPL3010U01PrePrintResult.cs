using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL3010U01PrePrintResult : AbstractContractResult
    {
        private List<CPL3010U01PrePrintInfo> _prePrintLst = new List<CPL3010U01PrePrintInfo>();

        public List<CPL3010U01PrePrintInfo> PrePrintLst
        {
            get { return this._prePrintLst; }
            set { this._prePrintLst = value; }
        }

        public CPL3010U01PrePrintResult() { }

    }
}