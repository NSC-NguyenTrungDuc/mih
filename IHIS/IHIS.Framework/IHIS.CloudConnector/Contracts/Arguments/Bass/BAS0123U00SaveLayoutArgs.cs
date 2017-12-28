using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using BAS0123U00GrdBAS0123Info = IHIS.CloudConnector.Contracts.Models.Bass.BAS0123U00GrdBAS0123Info;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0123U00SaveLayoutArgs : IContractArgs
	{
        protected bool Equals(BAS0123U00SaveLayoutArgs other)
        {
            return Equals(_itemInfo, other._itemInfo) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0123U00SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_itemInfo != null ? _itemInfo.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            }
        }

        private List<BAS0123U00GrdBAS0123Info> _itemInfo = new List<BAS0123U00GrdBAS0123Info>();
		private String _userId;

		public List<BAS0123U00GrdBAS0123Info> ItemInfo
		{
			get { return this._itemInfo; }
			set { this._itemInfo = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public BAS0123U00SaveLayoutArgs() { }

		public BAS0123U00SaveLayoutArgs(List<BAS0123U00GrdBAS0123Info> itemInfo, String userId)
		{
			this._itemInfo = itemInfo;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0123U00SaveLayoutRequest();
		}
	}
}