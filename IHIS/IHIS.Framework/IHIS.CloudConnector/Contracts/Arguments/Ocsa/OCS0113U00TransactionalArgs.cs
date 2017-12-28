using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using OCS0113U00GrdOCS0113ListItemInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.OCS0113U00GrdOCS0113ListItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0113U00TransactionalArgs : IContractArgs
	{
    protected bool Equals(OCS0113U00TransactionalArgs other)
    {
        return Equals(_listItem, other._listItem) && string.Equals(_userId, other._userId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0113U00TransactionalArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_listItem != null ? _listItem.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
        }
    }

    private List<OCS0113U00GrdOCS0113ListItemInfo> _listItem = new List<OCS0113U00GrdOCS0113ListItemInfo>();
		private String _userId;

		public List<OCS0113U00GrdOCS0113ListItemInfo> ListItem
		{
			get { return this._listItem; }
			set { this._listItem = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public OCS0113U00TransactionalArgs() { }

		public OCS0113U00TransactionalArgs(List<OCS0113U00GrdOCS0113ListItemInfo> listItem, String userId)
		{
			this._listItem = listItem;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0113U00TransactionalRequest();
		}
	}
}