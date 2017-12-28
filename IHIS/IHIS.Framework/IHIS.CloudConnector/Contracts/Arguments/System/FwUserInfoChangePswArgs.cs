using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class FwUserInfoChangePswArgs : IContractArgs
    {
    protected bool Equals(FwUserInfoChangePswArgs other)
    {
        return string.Equals(_userId, other._userId) && string.Equals(_oldPassword, other._oldPassword) && string.Equals(_newPassword, other._newPassword) && string.Equals(_hospCode, other._hospCode) && _attempt == other._attempt && string.Equals(_pwdHistory, other._pwdHistory);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FwUserInfoChangePswArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_oldPassword != null ? _oldPassword.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_newPassword != null ? _newPassword.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ _attempt;
            hashCode = (hashCode*397) ^ (_pwdHistory != null ? _pwdHistory.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _userId;
        private String _oldPassword;
        private String _newPassword;
        private String _hospCode;
        private Int32 _attempt;
        private String _pwdHistory;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String OldPassword
        {
            get { return this._oldPassword; }
            set { this._oldPassword = value; }
        }

        public String NewPassword
        {
            get { return this._newPassword; }
            set { this._newPassword = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public Int32 Attempt
        {
            get { return this._attempt; }
            set { this._attempt = value; }
        }

        public String PwdHistory
        {
            get { return this._pwdHistory; }
            set { this._pwdHistory = value; }
        }

        public FwUserInfoChangePswArgs() { }

        public FwUserInfoChangePswArgs(String userId, String oldPassword, String newPassword, String hospCode, Int32 attempt, String pwdHistory)
        {
            this._userId = userId;
            this._oldPassword = oldPassword;
            this._newPassword = newPassword;
            this._hospCode = hospCode;
            this._attempt = attempt;
            this._pwdHistory = pwdHistory;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.FwUserInfoChangePswRequest();
        }
    }
}