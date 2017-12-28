using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0203U00GetOCSCOMUserIDArgs : IContractArgs
    {
    protected bool Equals(OCS0203U00GetOCSCOMUserIDArgs other)
    {
        return string.Equals(_userGubun, other._userGubun) && string.Equals(_userId, other._userId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0203U00GetOCSCOMUserIDArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_userGubun != null ? _userGubun.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
        }
    }

    private String _userGubun;
        private String _userId;

        public String UserGubun
        {
            get { return this._userGubun; }
            set { this._userGubun = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public OCS0203U00GetOCSCOMUserIDArgs() { }

        public OCS0203U00GetOCSCOMUserIDArgs(String userGubun, String userId)
        {
            this._userGubun = userGubun;
            this._userId = userId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0203U00GetOCSCOMUserIDRequest();
        }
    }
}