using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OCS1003Q09CheckOrdDanuiArgs : IContractArgs
	{
    protected bool Equals(OCS1003Q09CheckOrdDanuiArgs other)
    {
        return string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_ordDanui, other._ordDanui);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS1003Q09CheckOrdDanuiArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_hangmogCode != null ? _hangmogCode.GetHashCode() : 0)*397) ^ (_ordDanui != null ? _ordDanui.GetHashCode() : 0);
        }
    }

    private String _hangmogCode;
		private String _ordDanui;

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String OrdDanui
		{
			get { return this._ordDanui; }
			set { this._ordDanui = value; }
		}

		public OCS1003Q09CheckOrdDanuiArgs() { }

		public OCS1003Q09CheckOrdDanuiArgs(String hangmogCode, String ordDanui)
		{
			this._hangmogCode = hangmogCode;
			this._ordDanui = ordDanui;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS1003Q09CheckOrdDanuiRequest();
		}
	}
}