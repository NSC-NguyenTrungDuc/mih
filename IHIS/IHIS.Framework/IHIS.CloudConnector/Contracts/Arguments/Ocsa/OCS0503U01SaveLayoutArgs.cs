using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using OcsaOCS0503U01GrdOCS0503ListInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.OcsaOCS0503U01GrdOCS0503ListInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]

	public class OCS0503U01SaveLayoutArgs : IContractArgs
	{
    protected bool Equals(OCS0503U01SaveLayoutArgs other)
    {
        return Equals(_saveList, other._saveList) && string.Equals(_userId, other._userId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0503U01SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_saveList != null ? _saveList.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
        }
    }

    private List<OcsaOCS0503U01GrdOCS0503ListInfo> _saveList = new List<OcsaOCS0503U01GrdOCS0503ListInfo>();
		private String _userId;

		public List<OcsaOCS0503U01GrdOCS0503ListInfo> SaveList
		{
			get { return this._saveList; }
			set { this._saveList = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public OCS0503U01SaveLayoutArgs() { }

		public OCS0503U01SaveLayoutArgs(List<OcsaOCS0503U01GrdOCS0503ListInfo> saveList, String userId)
		{
			this._saveList = saveList;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0503U01SaveLayoutRequest();
		}
	}
}