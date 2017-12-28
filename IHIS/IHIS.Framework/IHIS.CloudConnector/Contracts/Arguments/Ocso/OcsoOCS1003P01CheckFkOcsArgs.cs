using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OcsoOCS1003P01CheckFkOcsArgs : IContractArgs
	{
    protected bool Equals(OcsoOCS1003P01CheckFkOcsArgs other)
    {
        return string.Equals(_fkOcs, other._fkOcs);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsoOCS1003P01CheckFkOcsArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_fkOcs != null ? _fkOcs.GetHashCode() : 0);
    }

    private String _fkOcs;

		public String FkOcs
		{
			get { return this._fkOcs; }
			set { this._fkOcs = value; }
		}

		public OcsoOCS1003P01CheckFkOcsArgs() { }

		public OcsoOCS1003P01CheckFkOcsArgs(String fkOcs)
		{
			this._fkOcs = fkOcs;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsoOCS1003P01CheckFkOcsRequest();
		}
	}
}