using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT1002U00LayCPLResult : AbstractContractResult
    {
        private List<XRT1002U00LayCPLInfo> _layCplItem = new List<XRT1002U00LayCPLInfo>();

        public List<XRT1002U00LayCPLInfo> LayCplItem
        {
            get { return this._layCplItem; }
            set { this._layCplItem = value; }
        }

        public XRT1002U00LayCPLResult() { }

    }
}