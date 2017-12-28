using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class ADM103UgrdUserGrpResult : AbstractContractResult
    {
        private List<ADM103UgrdUserGrpInfo> _userList = new List<ADM103UgrdUserGrpInfo>();

        public List<ADM103UgrdUserGrpInfo> UserList
        {
            get { return this._userList; }
            set { this._userList = value; }
        }

        public ADM103UgrdUserGrpResult() { }

    }
}