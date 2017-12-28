using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using OCS0503U00gridOSC0503ListInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.OCS0503U00gridOSC0503ListInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0503U00SaveLayoutArgs : IContractArgs
	{
    protected bool Equals(OCS0503U00SaveLayoutArgs other)
    {
        return Equals(_grdOcs0503Item, other._grdOcs0503Item) && string.Equals(_userId, other._userId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0503U00SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_grdOcs0503Item != null ? _grdOcs0503Item.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
        }
    }

    private List<OCS0503U00gridOSC0503ListInfo> _grdOcs0503Item = new List<OCS0503U00gridOSC0503ListInfo>();
		private String _userId;

		public List<OCS0503U00gridOSC0503ListInfo> GrdOcs0503Item
		{
			get { return this._grdOcs0503Item; }
			set { this._grdOcs0503Item = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public OCS0503U00SaveLayoutArgs() { }

		public OCS0503U00SaveLayoutArgs(List<OCS0503U00gridOSC0503ListInfo> grdOcs0503Item, String userId)
		{
			this._grdOcs0503Item = grdOcs0503Item;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0503U00SaveLayoutRequest();
		}
	}
}