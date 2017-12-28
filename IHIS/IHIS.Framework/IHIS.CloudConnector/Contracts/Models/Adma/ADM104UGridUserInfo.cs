using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    public class ADM104UGridUserInfo
    {
        private String _userId;
        private String _userNm;
        private String _userScrt;
        private String _deptCode;
        private String _buseoName;
        private String _userGroup;
        private String _groupNm;
        private String _userLevel;
        private String _userEndYmd;
        private String _userGubun;
        private String _nurseConfirmEnableYn;
        private String _coId;
        private String _email;
        private String _clisSmoId;
        private String _loginFlg;
        private String _dataRowState;
        private String _changePwdFlg;
        private String _pwdHistory;
        private String _ischangePwd;
        private String _plainPwd;
        private String _userLastName;
        private String _userFirstName;

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

        public String UserScrt
        {
            get { return this._userScrt; }
            set { this._userScrt = value; }
        }

        public String DeptCode
        {
            get { return this._deptCode; }
            set { this._deptCode = value; }
        }

        public String BuseoName
        {
            get { return this._buseoName; }
            set { this._buseoName = value; }
        }

        public String UserGroup
        {
            get { return this._userGroup; }
            set { this._userGroup = value; }
        }

        public String GroupNm
        {
            get { return this._groupNm; }
            set { this._groupNm = value; }
        }

        public String UserLevel
        {
            get { return this._userLevel; }
            set { this._userLevel = value; }
        }

        public String UserEndYmd
        {
            get { return this._userEndYmd; }
            set { this._userEndYmd = value; }
        }

        public String UserGubun
        {
            get { return this._userGubun; }
            set { this._userGubun = value; }
        }

        public String NurseConfirmEnableYn
        {
            get { return this._nurseConfirmEnableYn; }
            set { this._nurseConfirmEnableYn = value; }
        }

        public String CoId
        {
            get { return this._coId; }
            set { this._coId = value; }
        }

        public String Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        public String ClisSmoId
        {
            get { return this._clisSmoId; }
            set { this._clisSmoId = value; }
        }

        public String LoginFlg
        {
            get { return this._loginFlg; }
            set { this._loginFlg = value; }
        }

        public String DataRowState
        {
            get { return this._dataRowState; }
            set { this._dataRowState = value; }
        }

        public String ChangePwdFlg
        {
            get { return this._changePwdFlg; }
            set { this._changePwdFlg = value; }
        }

        public String PwdHistory
        {
            get { return this._pwdHistory; }
            set { this._pwdHistory = value; }
        }

        public String IschangePwd
        {
            get { return this._ischangePwd; }
            set { this._ischangePwd = value; }
        }

        public String PlainPwd
        {
            get { return this._plainPwd; }
            set { this._plainPwd = value; }
        }

        public String UserLastName
        {
            get { return this._userLastName; }
            set { this._userLastName = value; }
        }

        public String UserFirstName
        {
            get { return this._userFirstName; }
            set { this._userFirstName = value; }
        }

        public ADM104UGridUserInfo() { }

        public ADM104UGridUserInfo(String userId, String userNm, String userScrt, String deptCode, String buseoName, String userGroup, String groupNm, String userLevel, String userEndYmd, String userGubun, String nurseConfirmEnableYn, String coId, String email, String clisSmoId, String loginFlg, String dataRowState, String changePwdFlg, String pwdHistory, String ischangePwd, String plainPwd, String userLastName, String userFirstName)
        {
            this._userId = userId;
            this._userNm = userNm;
            this._userScrt = userScrt;
            this._deptCode = deptCode;
            this._buseoName = buseoName;
            this._userGroup = userGroup;
            this._groupNm = groupNm;
            this._userLevel = userLevel;
            this._userEndYmd = userEndYmd;
            this._userGubun = userGubun;
            this._nurseConfirmEnableYn = nurseConfirmEnableYn;
            this._coId = coId;
            this._email = email;
            this._clisSmoId = clisSmoId;
            this._loginFlg = loginFlg;
            this._dataRowState = dataRowState;
            this._changePwdFlg = changePwdFlg;
            this._pwdHistory = pwdHistory;
            this._ischangePwd = ischangePwd;
            this._plainPwd = plainPwd;
            this._userLastName = userLastName;
            this._userFirstName = userFirstName;
        }

    }
}