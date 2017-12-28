using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class OCS2015U00GetLinkMISResult : AbstractContractResult
    {
        private String _linkMis;
        private String _token;

        public String LinkMis
        {
            get { return this._linkMis; }
            set { this._linkMis = value; }
        }

        public String Token
        {
            get { return this._token; }
            set { this._token = value; }
        }

        public OCS2015U00GetLinkMISResult() { }

    }
}