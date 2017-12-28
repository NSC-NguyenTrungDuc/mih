using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class ADM104UGridUserResult : AbstractContractResult
    {
        private List<ADM104UGridUserInfo> _gridUserInfo = new List<ADM104UGridUserInfo>();

        public List<ADM104UGridUserInfo> GridUserInfo
        {
            get { return this._gridUserInfo; }
            set { this._gridUserInfo = value; }
        }

        public ADM104UGridUserResult() { }

    }
}