using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using OcsaOCS0304U00GrdOCS0304ListInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.OcsaOCS0304U00GrdOCS0304ListInfo;
using OcsaOCS0304U00GrdOCS0305ListInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.OcsaOCS0304U00GrdOCS0305ListInfo;
using OcsaOCS0304U00GrdOCS0306ListInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.OcsaOCS0304U00GrdOCS0306ListInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0304U00SaveLayoutArgs : IContractArgs
	{
    protected bool Equals(OCS0304U00SaveLayoutArgs other)
    {
        return string.Equals(_userId, other._userId) && Equals(_grdOcs0304List, other._grdOcs0304List) && Equals(_grdOcs0305List, other._grdOcs0305List) && Equals(_grdOcs0306List, other._grdOcs0306List);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0304U00SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdOcs0304List != null ? _grdOcs0304List.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdOcs0305List != null ? _grdOcs0305List.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdOcs0306List != null ? _grdOcs0306List.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _userId;
		private List<OcsaOCS0304U00GrdOCS0304ListInfo> _grdOcs0304List = new List<OcsaOCS0304U00GrdOCS0304ListInfo>();
		private List<OcsaOCS0304U00GrdOCS0305ListInfo> _grdOcs0305List = new List<OcsaOCS0304U00GrdOCS0305ListInfo>();
		private List<OcsaOCS0304U00GrdOCS0306ListInfo> _grdOcs0306List = new List<OcsaOCS0304U00GrdOCS0306ListInfo>();

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public List<OcsaOCS0304U00GrdOCS0304ListInfo> GrdOcs0304List
		{
			get { return this._grdOcs0304List; }
			set { this._grdOcs0304List = value; }
		}

		public List<OcsaOCS0304U00GrdOCS0305ListInfo> GrdOcs0305List
		{
			get { return this._grdOcs0305List; }
			set { this._grdOcs0305List = value; }
		}

		public List<OcsaOCS0304U00GrdOCS0306ListInfo> GrdOcs0306List
		{
			get { return this._grdOcs0306List; }
			set { this._grdOcs0306List = value; }
		}

		public OCS0304U00SaveLayoutArgs() { }

		public OCS0304U00SaveLayoutArgs(String userId, List<OcsaOCS0304U00GrdOCS0304ListInfo> grdOcs0304List, List<OcsaOCS0304U00GrdOCS0305ListInfo> grdOcs0305List, List<OcsaOCS0304U00GrdOCS0306ListInfo> grdOcs0306List)
		{
			this._userId = userId;
			this._grdOcs0304List = grdOcs0304List;
			this._grdOcs0305List = grdOcs0305List;
			this._grdOcs0306List = grdOcs0306List;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0304U00SaveLayoutRequest();
		}
	}
}