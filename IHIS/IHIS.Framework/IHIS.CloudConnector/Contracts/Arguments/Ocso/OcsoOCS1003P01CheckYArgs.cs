using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OcsoOCS1003P01CheckYArgs : IContractArgs
	{
    protected bool Equals(OcsoOCS1003P01CheckYArgs other)
    {
        return string.Equals(_naewonKey, other._naewonKey);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsoOCS1003P01CheckYArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_naewonKey != null ? _naewonKey.GetHashCode() : 0);
    }

    private String _naewonKey;

		public String NaewonKey
		{
			get { return this._naewonKey; }
			set { this._naewonKey = value; }
		}

		public OcsoOCS1003P01CheckYArgs() { }

		public OcsoOCS1003P01CheckYArgs(String naewonKey)
		{
			this._naewonKey = naewonKey;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsoOCS1003P01CheckYRequest();
		}
	}
}