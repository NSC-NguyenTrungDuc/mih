using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using InjsINJ1001U01DetailListItemInfo = IHIS.CloudConnector.Contracts.Models.Injs.InjsINJ1001U01DetailListItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class INJ1001U01GridDetailSaveLayoutArgs : IContractArgs
	{
        protected bool Equals(INJ1001U01GridDetailSaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_updId, other._updId) && Equals(_itemInfo, other._itemInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ1001U01GridDetailSaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_updId != null ? _updId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_itemInfo != null ? _itemInfo.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
		private String _updId;
		private List<InjsINJ1001U01DetailListItemInfo> _itemInfo = new List<InjsINJ1001U01DetailListItemInfo>();

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String UpdId
		{
			get { return this._updId; }
			set { this._updId = value; }
		}

		public List<InjsINJ1001U01DetailListItemInfo> ItemInfo
		{
			get { return this._itemInfo; }
			set { this._itemInfo = value; }
		}

		public INJ1001U01GridDetailSaveLayoutArgs() { }

		public INJ1001U01GridDetailSaveLayoutArgs(String userId, String updId, List<InjsINJ1001U01DetailListItemInfo> itemInfo)
		{
			this._userId = userId;
			this._updId = updId;
			this._itemInfo = itemInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new INJ1001U01GridDetailSaveLayoutRequest();
		}
	}
}