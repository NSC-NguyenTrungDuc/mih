using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0301Q09TxtYaksokCodeDataValidatingArgs : IContractArgs
	{
    protected bool Equals(OCS0301Q09TxtYaksokCodeDataValidatingArgs other)
    {
        return string.Equals(_yaksokOpenId, other._yaksokOpenId) && string.Equals(_yaksokCode, other._yaksokCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0301Q09TxtYaksokCodeDataValidatingArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_yaksokOpenId != null ? _yaksokOpenId.GetHashCode() : 0)*397) ^ (_yaksokCode != null ? _yaksokCode.GetHashCode() : 0);
        }
    }

    private String _yaksokOpenId;
		private String _yaksokCode;

		public String YaksokOpenId
		{
			get { return this._yaksokOpenId; }
			set { this._yaksokOpenId = value; }
		}

		public String YaksokCode
		{
			get { return this._yaksokCode; }
			set { this._yaksokCode = value; }
		}

		public OCS0301Q09TxtYaksokCodeDataValidatingArgs() { }

		public OCS0301Q09TxtYaksokCodeDataValidatingArgs(String yaksokOpenId, String yaksokCode)
		{
			this._yaksokOpenId = yaksokOpenId;
			this._yaksokCode = yaksokCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0301Q09TxtYaksokCodeDataValidatingRequest();
		}
	}
}