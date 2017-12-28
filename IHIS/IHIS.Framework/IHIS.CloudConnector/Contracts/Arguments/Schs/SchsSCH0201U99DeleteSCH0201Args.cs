using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SchsSCH0201U99DeleteSCH0201Args : IContractArgs
	{
    protected bool Equals(SchsSCH0201U99DeleteSCH0201Args other)
    {
        return string.Equals(_fPksch, other._fPksch);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201U99DeleteSCH0201Args) obj);
    }

    public override int GetHashCode()
    {
        return (_fPksch != null ? _fPksch.GetHashCode() : 0);
    }

    private String _fPksch;

		public String FPksch
		{
			get { return this._fPksch; }
			set { this._fPksch = value; }
		}

		public SchsSCH0201U99DeleteSCH0201Args() { }

		public SchsSCH0201U99DeleteSCH0201Args(String fPksch)
		{
			this._fPksch = fPksch;
		}

		public IExtensible GetRequestInstance()
		{
			return new SchsSCH0201U99DeleteSCH0201Request();
		}
	}
}