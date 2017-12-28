using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using OcsaOCS0304U00GrdOCS0305ListInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.OcsaOCS0304U00GrdOCS0305ListInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0304U00GrdOCS0305SaveLayoutArgs : IContractArgs
	{
    protected bool Equals(OCS0304U00GrdOCS0305SaveLayoutArgs other)
    {
        return string.Equals(_userId, other._userId) && Equals(_grdOcs0305List, other._grdOcs0305List);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0304U00GrdOCS0305SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_grdOcs0305List != null ? _grdOcs0305List.GetHashCode() : 0);
        }
    }

    private String _userId;
		private List<OcsaOCS0304U00GrdOCS0305ListInfo> _grdOcs0305List = new List<OcsaOCS0304U00GrdOCS0305ListInfo>();

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public List<OcsaOCS0304U00GrdOCS0305ListInfo> GrdOcs0305List
		{
			get { return this._grdOcs0305List; }
			set { this._grdOcs0305List = value; }
		}

		public OCS0304U00GrdOCS0305SaveLayoutArgs() { }

		public OCS0304U00GrdOCS0305SaveLayoutArgs(String userId, List<OcsaOCS0304U00GrdOCS0305ListInfo> grdOcs0305List)
		{
			this._userId = userId;
			this._grdOcs0305List = grdOcs0305List;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0304U00GrdOCS0305SaveLayoutRequest();
		}
	}
}