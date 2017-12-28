using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
    public class OCS2015U31GetADM3200UserInfo
    {
        private String _userId;
        private String _sysId;
        private String _userGroup;
        private String _userNm;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String UserGroup
        {
            get { return this._userGroup; }
            set { this._userGroup = value; }
        }

        public String UserNm
        {
            get { return this._userNm; }
            set { this._userNm = value; }
        }

        public OCS2015U31GetADM3200UserInfo() { }

        public OCS2015U31GetADM3200UserInfo(String userId, String sysId, String userGroup, String userNm)
        {
            this._userId = userId;
            this._sysId = sysId;
            this._userGroup = userGroup;
            this._userNm = userNm;
        }

    }
}