using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using LoadConsultEndYNInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.LoadConsultEndYNInfo;
using NoConfirmConsultInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.NoConfirmConsultInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultArgs : IContractArgs
	{
    protected bool Equals(OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultArgs other)
    {
        return Equals(_itemInfo, other._itemInfo) && Equals(_confirmConsultInfo, other._confirmConsultInfo);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_itemInfo != null ? _itemInfo.GetHashCode() : 0)*397) ^ (_confirmConsultInfo != null ? _confirmConsultInfo.GetHashCode() : 0);
        }
    }

    private LoadConsultEndYNInfo _itemInfo;
		private NoConfirmConsultInfo _confirmConsultInfo;

		public LoadConsultEndYNInfo ItemInfo
		{
			get { return this._itemInfo; }
			set { this._itemInfo = value; }
		}

		public NoConfirmConsultInfo ConfirmConsultInfo
		{
			get { return this._confirmConsultInfo; }
			set { this._confirmConsultInfo = value; }
		}

		public OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultArgs() { }

		public OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultArgs(LoadConsultEndYNInfo itemInfo, NoConfirmConsultInfo confirmConsultInfo)
		{
			this._itemInfo = itemInfo;
			this._confirmConsultInfo = confirmConsultInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultRequest();
		}
	}
}