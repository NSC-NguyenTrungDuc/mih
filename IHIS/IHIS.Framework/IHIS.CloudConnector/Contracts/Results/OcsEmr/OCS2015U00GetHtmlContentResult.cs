using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class OCS2015U00GetHtmlContentResult : AbstractContractResult
    {
        private String _printContent;

        public String PrintContent
        {
            get { return this._printContent; }
            set { this._printContent = value; }
        }

        public OCS2015U00GetHtmlContentResult() { }

    }
}