using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class AdmLoginFormCheckLoginUserArgs : IContractArgs
    {
    protected bool Equals(AdmLoginFormCheckLoginUserArgs other)
    {
        return string.Equals(_user, other._user) && string.Equals(_password, other._password) && _attempt == other._attempt && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((AdmLoginFormCheckLoginUserArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_user != null ? _user.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_password != null ? _password.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ _attempt;
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _user;
        private String _password;
        private Int32 _attempt;
        private String _hospCode;

        public String User
        {
            get { return this._user; }
            set { this._user = value; }
        }

        public String Password
        {
            get { return this._password; }
            set { this._password = value; }
        }

        public Int32 Attempt
        {
            get { return this._attempt; }
            set { this._attempt = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public AdmLoginFormCheckLoginUserArgs() { }

        public AdmLoginFormCheckLoginUserArgs(String user, String password, Int32 attempt, String hospCode)
        {
            this._user = user;
            this._password = password;
            this._attempt = attempt;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.AdmLoginFormCheckLoginUserRequest();
        }
    }
}