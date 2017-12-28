using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SCH0201Q12UpdateKensaYnArgs : IContractArgs
	{
    protected bool Equals(SCH0201Q12UpdateKensaYnArgs other)
    {
        return string.Equals(_pkout1001, other._pkout1001);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH0201Q12UpdateKensaYnArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
    }

    private String _pkout1001;

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public SCH0201Q12UpdateKensaYnArgs() { }

		public SCH0201Q12UpdateKensaYnArgs(String pkout1001)
		{
			this._pkout1001 = pkout1001;
		}

		public IExtensible GetRequestInstance()
		{
			return new SCH0201Q12UpdateKensaYnRequest();
		}
	}
}