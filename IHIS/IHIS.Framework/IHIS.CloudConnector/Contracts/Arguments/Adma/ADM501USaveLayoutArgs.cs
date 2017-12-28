using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using ADM501UListItemInfo = IHIS.CloudConnector.Contracts.Models.Adma.ADM501UListItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADM501USaveLayoutArgs : IContractArgs
	{
        protected bool Equals(ADM501USaveLayoutArgs other)
        {
            return string.Equals(_userInfo, other._userInfo) && Equals(_listItemInfo, other._listItemInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM501USaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_userInfo != null ? _userInfo.GetHashCode() : 0)*397) ^ (_listItemInfo != null ? _listItemInfo.GetHashCode() : 0);
            }
        }

        private String _userInfo;
		private List<ADM501UListItemInfo> _listItemInfo = new List<ADM501UListItemInfo>();

		public String UserInfo
		{
			get { return this._userInfo; }
			set { this._userInfo = value; }
		}

		public List<ADM501UListItemInfo> ListItemInfo
		{
			get { return this._listItemInfo; }
			set { this._listItemInfo = value; }
		}

		public ADM501USaveLayoutArgs() { }

		public ADM501USaveLayoutArgs(String userInfo, List<ADM501UListItemInfo> listItemInfo)
		{
			this._userInfo = userInfo;
			this._listItemInfo = listItemInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADM501USaveLayoutRequest();
		}
	}
}