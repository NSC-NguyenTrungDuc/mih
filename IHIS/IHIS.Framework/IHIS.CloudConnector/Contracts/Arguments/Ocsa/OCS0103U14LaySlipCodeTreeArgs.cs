using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U14LaySlipCodeTreeArgs : IContractArgs
	{
    protected bool Equals(OCS0103U14LaySlipCodeTreeArgs other)
    {
        return string.Equals(_user, other._user);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U14LaySlipCodeTreeArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_user != null ? _user.GetHashCode() : 0);
    }

    private String _user;

		public String User
		{
			get { return this._user; }
			set { this._user = value; }
		}

		public OCS0103U14LaySlipCodeTreeArgs() { }

		public OCS0103U14LaySlipCodeTreeArgs(String user)
		{
			this._user = user;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U14LaySlipCodeTreeRequest();
		}
	}
}