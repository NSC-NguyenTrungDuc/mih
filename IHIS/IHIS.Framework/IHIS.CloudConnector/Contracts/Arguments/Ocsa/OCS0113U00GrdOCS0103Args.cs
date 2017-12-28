using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0113U00GrdOCS0103Args : IContractArgs
	{
    protected bool Equals(OCS0113U00GrdOCS0103Args other)
    {
        return string.Equals(_slipCode, other._slipCode) && string.Equals(_hangmogNameInx, other._hangmogNameInx);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0113U00GrdOCS0103Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_slipCode != null ? _slipCode.GetHashCode() : 0)*397) ^ (_hangmogNameInx != null ? _hangmogNameInx.GetHashCode() : 0);
        }
    }

    private String _slipCode;
		private String _hangmogNameInx;

		public String SlipCode
		{
			get { return this._slipCode; }
			set { this._slipCode = value; }
		}

		public String HangmogNameInx
		{
			get { return this._hangmogNameInx; }
			set { this._hangmogNameInx = value; }
		}

		public OCS0113U00GrdOCS0103Args() { }

		public OCS0113U00GrdOCS0103Args(String slipCode, String hangmogNameInx)
		{
			this._slipCode = slipCode;
			this._hangmogNameInx = hangmogNameInx;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0113U00GrdOCS0103Request();
		}
	}
}