using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0301Q09CheckExistsYasokCodeArgs : IContractArgs
	{
    protected bool Equals(OCS0301Q09CheckExistsYasokCodeArgs other)
    {
        return string.Equals(_yaksokOpenId, other._yaksokOpenId) && string.Equals(_yasokCode, other._yasokCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0301Q09CheckExistsYasokCodeArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_yaksokOpenId != null ? _yaksokOpenId.GetHashCode() : 0)*397) ^ (_yasokCode != null ? _yasokCode.GetHashCode() : 0);
        }
    }

    private String _yaksokOpenId;
		private String _yasokCode;

		public String YaksokOpenId
		{
			get { return this._yaksokOpenId; }
			set { this._yaksokOpenId = value; }
		}

		public String YasokCode
		{
			get { return this._yasokCode; }
			set { this._yasokCode = value; }
		}

		public OCS0301Q09CheckExistsYasokCodeArgs() { }

		public OCS0301Q09CheckExistsYasokCodeArgs(String yaksokOpenId, String yasokCode)
		{
			this._yaksokOpenId = yaksokOpenId;
			this._yasokCode = yasokCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0301Q09CheckExistsYasokCodeRequest();
		}
	}
}