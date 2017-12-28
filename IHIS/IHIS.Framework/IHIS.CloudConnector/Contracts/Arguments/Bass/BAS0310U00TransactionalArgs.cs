using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using BAS0310U00GrdListItemInfo = IHIS.CloudConnector.Contracts.Models.Bass.BAS0310U00GrdListItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0310U00TransactionalArgs : IContractArgs
	{
        protected bool Equals(BAS0310U00TransactionalArgs other)
        {
            return Equals(_listInputInfo, other._listInputInfo) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0310U00TransactionalArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_listInputInfo != null ? _listInputInfo.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            }
        }

        private List<BAS0310U00GrdListItemInfo> _listInputInfo = new List<BAS0310U00GrdListItemInfo>();
		private String _userId;

		public List<BAS0310U00GrdListItemInfo> ListInputInfo
		{
			get { return this._listInputInfo; }
			set { this._listInputInfo = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public BAS0310U00TransactionalArgs() { }

		public BAS0310U00TransactionalArgs(List<BAS0310U00GrdListItemInfo> listInputInfo, String userId)
		{
			this._listInputInfo = listInputInfo;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0310U00TransactionalRequest();
		}
	}
}