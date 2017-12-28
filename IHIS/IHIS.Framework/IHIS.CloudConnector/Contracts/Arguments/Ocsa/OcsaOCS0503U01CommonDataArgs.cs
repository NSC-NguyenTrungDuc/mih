using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    [Serializable]
	public class OcsaOCS0503U01CommonDataArgs : IContractArgs
	{
	    protected bool Equals(OcsaOCS0503U01CommonDataArgs other)
	    {
	        return string.Equals(_fCode, other._fCode);
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((OcsaOCS0503U01CommonDataArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return (_fCode != null ? _fCode.GetHashCode() : 0);
	    }

	    private String _fCode;

		public String FCode
		{
			get { return this._fCode; }
			set { this._fCode = value; }
		}

		public OcsaOCS0503U01CommonDataArgs() { }

		public OcsaOCS0503U01CommonDataArgs(String fCode)
		{
			this._fCode = fCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsaOCS0503U01CommonDataRequest();
		}
	}
}