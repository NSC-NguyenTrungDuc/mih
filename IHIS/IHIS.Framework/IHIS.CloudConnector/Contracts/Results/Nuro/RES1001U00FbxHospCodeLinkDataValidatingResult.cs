using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class RES1001U00FbxHospCodeLinkDataValidatingResult : AbstractContractResult
    {
        private String _hospName;
        private String _bunhoLink;

        public String HospName
        {
            get { return this._hospName; }
            set { this._hospName = value; }
        }

        public String BunhoLink
        {
            get { return this._bunhoLink; }
            set { this._bunhoLink = value; }
        }

        public RES1001U00FbxHospCodeLinkDataValidatingResult() { }

    }
}