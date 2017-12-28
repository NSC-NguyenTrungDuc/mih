using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class RES1001U00FbxHospCodeLinkResult : AbstractContractResult
    {
        private List<RES1001U00FbxHospCodeLinkListItemInfo> _fbxHospCodeList = new List<RES1001U00FbxHospCodeLinkListItemInfo>();

        public List<RES1001U00FbxHospCodeLinkListItemInfo> FbxHospCodeList
        {
            get { return this._fbxHospCodeList; }
            set { this._fbxHospCodeList = value; }
        }

        public RES1001U00FbxHospCodeLinkResult() { }

    }
}