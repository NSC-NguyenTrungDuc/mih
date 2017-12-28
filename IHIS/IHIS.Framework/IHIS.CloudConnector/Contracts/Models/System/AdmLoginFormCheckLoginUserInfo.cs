using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    public class AdmLoginFormCheckLoginUserInfo
    {
        private String _userId;
        private String _userNm;
        private String _userGroup;
        private String _hospCode;
        private String _doctorDrugCheck;
        private String _checkKinki;
        private String _checkInteraction;
        private String _checkDosage;
        private String _revKinkiMessage;
        private String _revKinkiDisease;
        private String _revDosage;
        private String _revDrugChecking;
        private String _revInteraction;
        private String _revGenericName;
        private String _language;
        private String _changePwdFlg;
        private String _firstLoginFlg;
        private String _lastPwdChange;
        private String _pwdHistory;
        private String _currentTime;
        private String _endTime;
        private Int32 _clisSmoId;
        private String _certExpired;
        private String _invUsage;
        private String _usePhr;
        private String _timeZone;

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

        public String UserGroup
        {
            get { return this._userGroup; }
            set { this._userGroup = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String DoctorDrugCheck
        {
            get { return this._doctorDrugCheck; }
            set { this._doctorDrugCheck = value; }
        }

        public String CheckKinki
        {
            get { return this._checkKinki; }
            set { this._checkKinki = value; }
        }

        public String CheckInteraction
        {
            get { return this._checkInteraction; }
            set { this._checkInteraction = value; }
        }

        public String CheckDosage
        {
            get { return this._checkDosage; }
            set { this._checkDosage = value; }
        }

        public String RevKinkiMessage
        {
            get { return this._revKinkiMessage; }
            set { this._revKinkiMessage = value; }
        }

        public String RevKinkiDisease
        {
            get { return this._revKinkiDisease; }
            set { this._revKinkiDisease = value; }
        }

        public String RevDosage
        {
            get { return this._revDosage; }
            set { this._revDosage = value; }
        }

        public String RevDrugChecking
        {
            get { return this._revDrugChecking; }
            set { this._revDrugChecking = value; }
        }

        public String RevInteraction
        {
            get { return this._revInteraction; }
            set { this._revInteraction = value; }
        }

        public String RevGenericName
        {
            get { return this._revGenericName; }
            set { this._revGenericName = value; }
        }

        public String Language
        {
            get { return this._language; }
            set { this._language = value; }
        }

        public String ChangePwdFlg
        {
            get { return this._changePwdFlg; }
            set { this._changePwdFlg = value; }
        }

        public String FirstLoginFlg
        {
            get { return this._firstLoginFlg; }
            set { this._firstLoginFlg = value; }
        }

        public String LastPwdChange
        {
            get { return this._lastPwdChange; }
            set { this._lastPwdChange = value; }
        }

        public String PwdHistory
        {
            get { return this._pwdHistory; }
            set { this._pwdHistory = value; }
        }

        public String CurrentTime
        {
            get { return this._currentTime; }
            set { this._currentTime = value; }
        }

        public String EndTime
        {
            get { return this._endTime; }
            set { this._endTime = value; }
        }

        public Int32 ClisSmoId
        {
            get { return this._clisSmoId; }
            set { this._clisSmoId = value; }
        }

        public String CertExpired
        {
            get { return this._certExpired; }
            set { this._certExpired = value; }
        }

        public String InvUsage
        {
            get { return this._invUsage; }
            set { this._invUsage = value; }
        }

        public String UsePhr
        {
            get { return this._usePhr; }
            set { this._usePhr = value; }
        }

        public String TimeZone
        {
            get { return this._timeZone; }
            set { this._timeZone = value; }
        }

        public AdmLoginFormCheckLoginUserInfo() { }

        public AdmLoginFormCheckLoginUserInfo(String userId, String userNm, String userGroup, String hospCode, String doctorDrugCheck, String checkKinki, String checkInteraction, String checkDosage, String revKinkiMessage, String revKinkiDisease, String revDosage, String revDrugChecking, String revInteraction, String revGenericName, String language, String changePwdFlg, String firstLoginFlg, String lastPwdChange, String pwdHistory, String currentTime, String endTime, Int32 clisSmoId, String certExpired, String invUsage, String usePhr, String timeZone)
        {
            this._userId = userId;
            this._userNm = userNm;
            this._userGroup = userGroup;
            this._hospCode = hospCode;
            this._doctorDrugCheck = doctorDrugCheck;
            this._checkKinki = checkKinki;
            this._checkInteraction = checkInteraction;
            this._checkDosage = checkDosage;
            this._revKinkiMessage = revKinkiMessage;
            this._revKinkiDisease = revKinkiDisease;
            this._revDosage = revDosage;
            this._revDrugChecking = revDrugChecking;
            this._revInteraction = revInteraction;
            this._revGenericName = revGenericName;
            this._language = language;
            this._changePwdFlg = changePwdFlg;
            this._firstLoginFlg = firstLoginFlg;
            this._lastPwdChange = lastPwdChange;
            this._pwdHistory = pwdHistory;
            this._currentTime = currentTime;
            this._endTime = endTime;
            this._clisSmoId = clisSmoId;
            this._certExpired = certExpired;
            this._invUsage = invUsage;
            this._usePhr = usePhr;
            this._timeZone = timeZone;
        }

    }
}