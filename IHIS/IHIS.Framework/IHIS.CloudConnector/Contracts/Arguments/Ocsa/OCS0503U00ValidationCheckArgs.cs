using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0503U00ValidationCheckArgs : IContractArgs
	{
    protected bool Equals(OCS0503U00ValidationCheckArgs other)
    {
        return string.Equals(_fkout1001, other._fkout1001);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0503U00ValidationCheckArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_fkout1001 != null ? _fkout1001.GetHashCode() : 0);
    }

    private String _fkout1001;

		public String Fkout1001
		{
			get { return this._fkout1001; }
			set { this._fkout1001 = value; }
		}

		public OCS0503U00ValidationCheckArgs() { }

		public OCS0503U00ValidationCheckArgs(String fkout1001)
		{
			this._fkout1001 = fkout1001;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0503U00ValidationCheckRequest();
		}
	}
}