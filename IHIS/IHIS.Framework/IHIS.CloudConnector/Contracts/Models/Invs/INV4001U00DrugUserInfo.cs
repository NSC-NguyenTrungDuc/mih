using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV4001U00DrugUserInfo
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

        public INV4001U00DrugUserInfo() { }

        public INV4001U00DrugUserInfo(String userId, String userNm)
        {
            this._userId = userId;
            this._userNm = userNm;
        }

    }
}