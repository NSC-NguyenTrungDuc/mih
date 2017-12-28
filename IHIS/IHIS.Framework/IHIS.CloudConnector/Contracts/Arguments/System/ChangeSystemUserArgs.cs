using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class ChangeSystemUserArgs : IContractArgs
    {
    protected bool Equals(ChangeSystemUserArgs other)
    {
        return string.Equals(_afUserId, other._afUserId) && string.Equals(_bfUserId, other._bfUserId) && string.Equals(_systemId, other._systemId) && string.Equals(_ipAddr, other._ipAddr);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ChangeSystemUserArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_afUserId != null ? _afUserId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bfUserId != null ? _bfUserId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_systemId != null ? _systemId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ipAddr != null ? _ipAddr.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _afUserId;
        private String _bfUserId;
        private String _systemId;
        private String _ipAddr;

        public String AfUserId
        {
            get { return this._afUserId; }
            set { this._afUserId = value; }
        }

        public String BfUserId
        {
            get { return this._bfUserId; }
            set { this._bfUserId = value; }
        }

        public String SystemId
        {
            get { return this._systemId; }
            set { this._systemId = value; }
        }

        public String IpAddr
        {
            get { return this._ipAddr; }
            set { this._ipAddr = value; }
        }

        public ChangeSystemUserArgs() { }

        public ChangeSystemUserArgs(String afUserId, String bfUserId, String systemId, String ipAddr)
        {
            this._afUserId = afUserId;
            this._bfUserId = bfUserId;
            this._systemId = systemId;
            this._ipAddr = ipAddr;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ChangeSystemUserRequest();
        }
    }
}