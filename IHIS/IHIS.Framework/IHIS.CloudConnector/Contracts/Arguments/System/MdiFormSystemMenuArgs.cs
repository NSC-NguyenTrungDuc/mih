using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
	public class MdiFormSystemMenuArgs : IContractArgs
	{
    protected bool Equals(MdiFormSystemMenuArgs other)
    {
        return string.Equals(_userId, other._userId) && string.Equals(_systemId, other._systemId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((MdiFormSystemMenuArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_systemId != null ? _systemId.GetHashCode() : 0);
        }
    }

    private String _userId;
		private String _systemId;

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

		public MdiFormSystemMenuArgs() { }

		public MdiFormSystemMenuArgs(String userId, String systemId)
		{
			this._userId = userId;
			this._systemId = systemId;
		}

		public IExtensible GetRequestInstance()
		{
			return new MdiFormSystemMenuRequest();
		}
	}
}