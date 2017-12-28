using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{
    [Serializable]
	public class OCS1003P01MakeInputGubunTabArgs : IContractArgs
	{
	    protected bool Equals(OCS1003P01MakeInputGubunTabArgs other)
	    {
	        return string.Equals(_code, other._code);
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((OCS1003P01MakeInputGubunTabArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return (_code != null ? _code.GetHashCode() : 0);
	    }

	    private String _code;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public OCS1003P01MakeInputGubunTabArgs() { }

		public OCS1003P01MakeInputGubunTabArgs(String code)
		{
			this._code = code;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS1003P01MakeInputGubunTabRequest();
		}
	}
}