using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
	public class FormUserInfoUnRegisterSystemUserArgs : IContractArgs
	{
    protected bool Equals(FormUserInfoUnRegisterSystemUserArgs other)
    {
        return string.Equals(_userId, other._userId) && string.Equals(_systemId, other._systemId) && string.Equals(_ipAddr, other._ipAddr);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FormUserInfoUnRegisterSystemUserArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_systemId != null ? _systemId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ipAddr != null ? _ipAddr.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _userId;
		private String _systemId;
		private String _ipAddr;

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
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

		public FormUserInfoUnRegisterSystemUserArgs() { }

		public FormUserInfoUnRegisterSystemUserArgs(String userId, String systemId, String ipAddr)
		{
			this._userId = userId;
			this._systemId = systemId;
			this._ipAddr = ipAddr;
		}

		public IExtensible GetRequestInstance()
		{
			return new FormUserInfoUnRegisterSystemUserRequest();
		}
	}
}