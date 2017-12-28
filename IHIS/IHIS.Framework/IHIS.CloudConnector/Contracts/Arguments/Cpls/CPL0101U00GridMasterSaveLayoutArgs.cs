using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using CPL0101U00InitListItemInfo = IHIS.CloudConnector.Contracts.Models.Cpls.CPL0101U00InitListItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0101U00GridMasterSaveLayoutArgs : IContractArgs
	{
        protected bool Equals(CPL0101U00GridMasterSaveLayoutArgs other)
        {
            return Equals(_itemInfo, other._itemInfo) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0101U00GridMasterSaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_itemInfo != null ? _itemInfo.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            }
        }

        private List<CPL0101U00InitListItemInfo> _itemInfo = new List<CPL0101U00InitListItemInfo>();
		private String _userId;

		public List<CPL0101U00InitListItemInfo> ItemInfo
		{
			get { return this._itemInfo; }
			set { this._itemInfo = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public CPL0101U00GridMasterSaveLayoutArgs() { }

		public CPL0101U00GridMasterSaveLayoutArgs(List<CPL0101U00InitListItemInfo> itemInfo, String userId)
		{
			this._itemInfo = itemInfo;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0101U00GridMasterSaveLayoutRequest();
		}
	}
}