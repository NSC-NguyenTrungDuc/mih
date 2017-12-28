using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class AdmLoginFormLockUserArgs : IContractArgs
    {
    protected bool Equals(AdmLoginFormLockUserArgs other)
    {
        return string.Equals(_userId, other._userId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((AdmLoginFormLockUserArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_userId != null ? _userId.GetHashCode() : 0);
    }

    private String _userId;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public AdmLoginFormLockUserArgs() { }

        public AdmLoginFormLockUserArgs(String userId)
        {
            this._userId = userId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.AdmLoginFormLockUserRequest();
        }
    }
}