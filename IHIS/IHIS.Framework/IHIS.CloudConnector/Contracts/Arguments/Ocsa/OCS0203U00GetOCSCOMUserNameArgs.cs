using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0203U00GetOCSCOMUserNameArgs : IContractArgs
    {
    protected bool Equals(OCS0203U00GetOCSCOMUserNameArgs other)
    {
        return string.Equals(_hospCode, other._hospCode) && string.Equals(_userId, other._userId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0203U00GetOCSCOMUserNameArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_hospCode != null ? _hospCode.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
        }
    }

    private String _hospCode;
        private String _userId;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public OCS0203U00GetOCSCOMUserNameArgs() { }

        public OCS0203U00GetOCSCOMUserNameArgs(String hospCode, String userId)
        {
            this._hospCode = hospCode;
            this._userId = userId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0203U00GetOCSCOMUserNameRequest();
        }
    }
}