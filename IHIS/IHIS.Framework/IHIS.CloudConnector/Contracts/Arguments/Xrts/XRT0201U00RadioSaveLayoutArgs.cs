using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using XRT0201U00GrdRadioListItemInfo = IHIS.CloudConnector.Contracts.Models.Xrts.XRT0201U00GrdRadioListItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
	public class XRT0201U00RadioSaveLayoutArgs : IContractArgs
	{
    protected bool Equals(XRT0201U00RadioSaveLayoutArgs other)
    {
        return Equals(_grdRadioListItemInfo, other._grdRadioListItemInfo) && string.Equals(_userId, other._userId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0201U00RadioSaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_grdRadioListItemInfo != null ? _grdRadioListItemInfo.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
        }
    }

    private List<XRT0201U00GrdRadioListItemInfo> _grdRadioListItemInfo = new List<XRT0201U00GrdRadioListItemInfo>();
		private String _userId;

		public List<XRT0201U00GrdRadioListItemInfo> GrdRadioListItemInfo
		{
			get { return this._grdRadioListItemInfo; }
			set { this._grdRadioListItemInfo = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public XRT0201U00RadioSaveLayoutArgs() { }

		public XRT0201U00RadioSaveLayoutArgs(List<XRT0201U00GrdRadioListItemInfo> grdRadioListItemInfo, String userId)
		{
			this._grdRadioListItemInfo = grdRadioListItemInfo;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new XRT0201U00RadioSaveLayoutRequest();
		}
	}
}