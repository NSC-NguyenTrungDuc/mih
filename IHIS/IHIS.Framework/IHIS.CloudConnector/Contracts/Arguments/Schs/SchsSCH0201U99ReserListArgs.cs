using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SchsSCH0201U99ReserListArgs : IContractArgs
	{
    protected bool Equals(SchsSCH0201U99ReserListArgs other)
    {
        return string.Equals(_bunho, other._bunho);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201U99ReserListArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_bunho != null ? _bunho.GetHashCode() : 0);
    }

    private String _bunho;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public SchsSCH0201U99ReserListArgs() { }

		public SchsSCH0201U99ReserListArgs(String bunho)
		{
			this._bunho = bunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new SchsSCH0201U99ReserListRequest();
		}
	}
}