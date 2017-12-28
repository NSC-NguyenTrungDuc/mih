using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using LoadColumnCodeNameInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.LoadColumnCodeNameInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U12LoadColumnNameArgs : IContractArgs
	{
	    protected bool Equals(OCS0103U12LoadColumnNameArgs other)
	    {
	        return Equals(_code, other._code);
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((OCS0103U12LoadColumnNameArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return (_code != null ? _code.GetHashCode() : 0);
	    }

	    private LoadColumnCodeNameInfo _code;

		public LoadColumnCodeNameInfo Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public OCS0103U12LoadColumnNameArgs() { }

		public OCS0103U12LoadColumnNameArgs(LoadColumnCodeNameInfo code)
		{
			this._code = code;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U12LoadColumnNameRequest();
		}
	}
}