using System;

namespace IHIS.CloudConnector.Contracts.Models.INVS
{
    public class INV6002U00GrdINV6002LoadcbxActorInfo
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

        public INV6002U00GrdINV6002LoadcbxActorInfo() { }

        public INV6002U00GrdINV6002LoadcbxActorInfo(String userId, String userNm)
        {
            this._userId = userId;
            this._userNm = userNm;
        }

    }
}