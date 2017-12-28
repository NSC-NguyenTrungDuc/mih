using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    public class XRT0201U00LoadLinkResult : AbstractContractResult
    {
        private String _link;

        public String Link
        {
            get { return this._link; }
            set { this._link = value; }
        }

        public XRT0201U00LoadLinkResult() { }

    }
}