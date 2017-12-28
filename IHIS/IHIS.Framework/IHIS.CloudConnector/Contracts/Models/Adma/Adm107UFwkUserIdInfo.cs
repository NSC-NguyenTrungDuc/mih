using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    public class Adm107UFwkUserIdInfo
    {
        private String _userId;
        private String _userNm;
        private String _groupUser;

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

        public String GroupUser
        {
            get { return this._groupUser; }
            set { this._groupUser = value; }
        }

        public Adm107UFwkUserIdInfo() { }

        public Adm107UFwkUserIdInfo(String userId, String userNm, String groupUser)
        {
            this._userId = userId;
            this._userNm = userNm;
            this._groupUser = groupUser;
        }

    }
}