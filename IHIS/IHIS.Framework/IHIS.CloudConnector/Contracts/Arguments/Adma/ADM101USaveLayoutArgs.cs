using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using ADM101UGrdGroupItemInfo = IHIS.CloudConnector.Contracts.Models.Adma.ADM101UGrdGroupItemInfo;
using ADM101UgrdSystemItemInfo = IHIS.CloudConnector.Contracts.Models.Adma.ADM101UgrdSystemItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADM101USaveLayoutArgs : IContractArgs
	{
        protected bool Equals(ADM101USaveLayoutArgs other)
        {
            return Equals(_grdGroupItem, other._grdGroupItem) && Equals(_grdSystemItem, other._grdSystemItem) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM101USaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_grdGroupItem != null ? _grdGroupItem.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grdSystemItem != null ? _grdSystemItem.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private List<ADM101UGrdGroupItemInfo> _grdGroupItem = new List<ADM101UGrdGroupItemInfo>();
		private List<ADM101UgrdSystemItemInfo> _grdSystemItem = new List<ADM101UgrdSystemItemInfo>();
		private String _userId;

		public List<ADM101UGrdGroupItemInfo> GrdGroupItem
		{
			get { return this._grdGroupItem; }
			set { this._grdGroupItem = value; }
		}

		public List<ADM101UgrdSystemItemInfo> GrdSystemItem
		{
			get { return this._grdSystemItem; }
			set { this._grdSystemItem = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public ADM101USaveLayoutArgs() { }

		public ADM101USaveLayoutArgs(List<ADM101UGrdGroupItemInfo> grdGroupItem, List<ADM101UgrdSystemItemInfo> grdSystemItem, String userId)
		{
			this._grdGroupItem = grdGroupItem;
			this._grdSystemItem = grdSystemItem;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADM101USaveLayoutRequest();
		}
	}
}