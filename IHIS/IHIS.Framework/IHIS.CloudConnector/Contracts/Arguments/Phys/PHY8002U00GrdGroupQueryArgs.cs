using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{
    [Serializable]
	public class PHY8002U00GrdGroupQueryArgs : IContractArgs
	{
	    protected bool Equals(PHY8002U00GrdGroupQueryArgs other)
	    {
	        return string.Equals(_codeType, other._codeType);
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((PHY8002U00GrdGroupQueryArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return (_codeType != null ? _codeType.GetHashCode() : 0);
	    }

	    private String _codeType;

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public PHY8002U00GrdGroupQueryArgs() { }

		public PHY8002U00GrdGroupQueryArgs(String codeType)
		{
			this._codeType = codeType;
		}

		public IExtensible GetRequestInstance()
		{
			return new PHY8002U00GrdGroupQueryRequest();
		}
	}
}