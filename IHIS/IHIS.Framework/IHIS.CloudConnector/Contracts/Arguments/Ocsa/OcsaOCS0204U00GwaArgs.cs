using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using LoadColumnCodeNameInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.LoadColumnCodeNameInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OcsaOCS0204U00GwaArgs : IContractArgs
	{
    protected bool Equals(OcsaOCS0204U00GwaArgs other)
    {
        return Equals(_requestValue, other._requestValue) && string.Equals(_sabun, other._sabun);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsaOCS0204U00GwaArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_requestValue != null ? _requestValue.GetHashCode() : 0)*397) ^ (_sabun != null ? _sabun.GetHashCode() : 0);
        }
    }

    private LoadColumnCodeNameInfo _requestValue;
		private String _sabun;

		public LoadColumnCodeNameInfo RequestValue
		{
			get { return this._requestValue; }
			set { this._requestValue = value; }
		}

		public String Sabun
		{
			get { return this._sabun; }
			set { this._sabun = value; }
		}

		public OcsaOCS0204U00GwaArgs() { }

		public OcsaOCS0204U00GwaArgs(LoadColumnCodeNameInfo requestValue, String sabun)
		{
			this._requestValue = requestValue;
			this._sabun = sabun;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsaOCS0204U00GwaRequest();
		}
	}
}