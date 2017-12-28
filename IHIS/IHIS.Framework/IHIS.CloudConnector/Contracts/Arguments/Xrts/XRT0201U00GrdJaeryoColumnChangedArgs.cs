using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
	public class XRT0201U00GrdJaeryoColumnChangedArgs : IContractArgs
	{
    protected bool Equals(XRT0201U00GrdJaeryoColumnChangedArgs other)
    {
        return string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_sHangmogCode, other._sHangmogCode);

    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0201U00GrdJaeryoColumnChangedArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_hangmogCode != null ? _hangmogCode.GetHashCode() : 0)*397) ^ (_sHangmogCode != null ? _sHangmogCode.GetHashCode() : 0);
        }
    }

    private String _hangmogCode;
		private String _sHangmogCode;

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String SHangmogCode
		{
			get { return this._sHangmogCode; }
			set { this._sHangmogCode = value; }
		}

		public XRT0201U00GrdJaeryoColumnChangedArgs() { }

		public XRT0201U00GrdJaeryoColumnChangedArgs(String hangmogCode, String sHangmogCode)
		{
			this._hangmogCode = hangmogCode;
			this._sHangmogCode = sHangmogCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new XRT0201U00GrdJaeryoColumnChangedRequest();
		}
	}
}