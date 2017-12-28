using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsemr
{
    [Serializable]
    public class OCS2015U00GetDiscussNotifyResult : AbstractContractResult
    {
        private String _req;
        private String _consult;

        public String Req
        {
            get { return this._req; }
            set { this._req = value; }
        }

        public String Consult
        {
            get { return this._consult; }
            set { this._consult = value; }
        }

        public OCS2015U00GetDiscussNotifyResult() { }

    }
}