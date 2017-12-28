using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    public class AdmLoginFormCheckLoginUserResult : AbstractContractResult
    {
        private List<AdmLoginFormCheckLoginUserInfo> _userInfoItem = new List<AdmLoginFormCheckLoginUserInfo>();
        private String _sessionId;
        private OrcaInfo _orcaInfo;
        private MisaInfo _misaInfo;
        private List<NewMstDataListInfo> _newMstDataListItem = new List<NewMstDataListInfo>();
        private List<CacheRevisionInfo> _cacheRevItem = new List<CacheRevisionInfo>();
        private String _msg;
        private String _vpnYn;
        private CPLIntergrationInfo _cplItgItem;

        public List<AdmLoginFormCheckLoginUserInfo> UserInfoItem
        {
            get { return this._userInfoItem; }
            set { this._userInfoItem = value; }
        }

        public String SessionId
        {
            get { return this._sessionId; }
            set { this._sessionId = value; }
        }

        public OrcaInfo OrcaInfo
        {
            get { return this._orcaInfo; }
            set { this._orcaInfo = value; }
        }

        public MisaInfo MisaInfo
        {
            get { return this._misaInfo; }
            set { this._misaInfo = value; }
        }

        public List<NewMstDataListInfo> NewMstDataListItem
        {
            get { return this._newMstDataListItem; }
            set { this._newMstDataListItem = value; }
        }

        public List<CacheRevisionInfo> CacheRevItem
        {
            get { return this._cacheRevItem; }
            set { this._cacheRevItem = value; }
        }

        public String Msg
        {
            get { return this._msg; }
            set { this._msg = value; }
        }

        public String VpnYn
        {
            get { return this._vpnYn; }
            set { this._vpnYn = value; }
        }

        public CPLIntergrationInfo CplItgItem
        {
            get { return this._cplItgItem; }
            set { this._cplItgItem = value; }
        }

        public AdmLoginFormCheckLoginUserResult() { }

    }
}