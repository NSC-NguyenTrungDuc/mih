using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV2003U00CbxActorResult : AbstractContractResult
    {
        private String _userId;
        private String _userNm;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String UserNm
        {
            get { return this._userNm; }
            set { this._userNm = value; }
        }

        public INV2003U00CbxActorResult() { }

    }
}