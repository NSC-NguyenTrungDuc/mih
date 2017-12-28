using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using OcsaOCS0304U00GrdOCS0304ListInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.OcsaOCS0304U00GrdOCS0304ListInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0304U00GrdOCS0304SaveLayoutArgs : IContractArgs
	{
    protected bool Equals(OCS0304U00GrdOCS0304SaveLayoutArgs other)
    {
        return string.Equals(_userId, other._userId) && Equals(_grdOcs0304List, other._grdOcs0304List);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0304U00GrdOCS0304SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_grdOcs0304List != null ? _grdOcs0304List.GetHashCode() : 0);
        }
    }

    private String _userId;
		private List<OcsaOCS0304U00GrdOCS0304ListInfo> _grdOcs0304List = new List<OcsaOCS0304U00GrdOCS0304ListInfo>();

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

		public OCS0304U00GrdOCS0304SaveLayoutArgs() { }

		public OCS0304U00GrdOCS0304SaveLayoutArgs(String userId, List<OcsaOCS0304U00GrdOCS0304ListInfo> grdOcs0304List)
		{
			this._userId = userId;
			this._grdOcs0304List = grdOcs0304List;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0304U00GrdOCS0304SaveLayoutRequest();
		}
	}
}