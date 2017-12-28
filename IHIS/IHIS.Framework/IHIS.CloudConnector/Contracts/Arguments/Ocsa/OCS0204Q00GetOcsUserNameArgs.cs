using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0204Q00GetOcsUserNameArgs : IContractArgs
	{
    protected bool Equals(OCS0204Q00GetOcsUserNameArgs other)
    {
        return string.Equals(_userId, other._userId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0204Q00GetOcsUserNameArgs) obj);
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

		public OCS0204Q00GetOcsUserNameArgs() { }

		public OCS0204Q00GetOcsUserNameArgs(String userId)
		{
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0204Q00GetOcsUserNameRequest();
		}
	}
}