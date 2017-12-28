using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using OCS0301U00MembGrdInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.OCS0301U00MembGrdInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
	public class OCS0301U00SaveGrdOCS0300Args : IContractArgs
	{
    protected bool Equals(OCS0301U00SaveGrdOCS0300Args other)
    {
        return Equals(_grdOCS0300Info, other._grdOCS0300Info) && string.Equals(_userId, other._userId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0301U00SaveGrdOCS0300Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_grdOCS0300Info != null ? _grdOCS0300Info.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
        }
    }

    private List<OCS0301U00MembGrdInfo> _grdOCS0300Info = new List<OCS0301U00MembGrdInfo>();
		private String _userId;

		public List<OCS0301U00MembGrdInfo> GrdOCS0300Info
		{
			get { return this._grdOCS0300Info; }
			set { this._grdOCS0300Info = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public OCS0301U00SaveGrdOCS0300Args() { }

		public OCS0301U00SaveGrdOCS0300Args(List<OCS0301U00MembGrdInfo> grdOCS0300Info, String userId)
		{
			this._grdOCS0300Info = grdOCS0300Info;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0301U00SaveGrdOCS0300Request();
		}
	}
}