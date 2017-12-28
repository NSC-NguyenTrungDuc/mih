using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OcsoOCS1003P01GetGroupKeyArgs : IContractArgs
	{
    protected bool Equals(OcsoOCS1003P01GetGroupKeyArgs other)
    {
        return string.Equals(_pkout1001, other._pkout1001) && string.Equals(_codeType, other._codeType);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsoOCS1003P01GetGroupKeyArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_pkout1001 != null ? _pkout1001.GetHashCode() : 0)*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
        }
    }

    private String _pkout1001;
		private String _codeType;

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public OcsoOCS1003P01GetGroupKeyArgs() { }

		public OcsoOCS1003P01GetGroupKeyArgs(String pkout1001, String codeType)
		{
			this._pkout1001 = pkout1001;
			this._codeType = codeType;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsoOCS1003P01GetGroupKeyRequest();
		}
	}
}