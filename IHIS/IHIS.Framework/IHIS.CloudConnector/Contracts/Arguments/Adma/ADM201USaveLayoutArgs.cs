using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using ADM201UGrdDicDetailItemInfo = IHIS.CloudConnector.Contracts.Models.Adma.ADM201UGrdDicDetailItemInfo;
using ADM201UGrdDicMasterItemInfo = IHIS.CloudConnector.Contracts.Models.Adma.ADM201UGrdDicMasterItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADM201USaveLayoutArgs : IContractArgs
	{
        protected bool Equals(ADM201USaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && Equals(_grdDicMasterItemInfo, other._grdDicMasterItemInfo) && Equals(_grdDicDetailItemInfo, other._grdDicDetailItemInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM201USaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grdDicMasterItemInfo != null ? _grdDicMasterItemInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grdDicDetailItemInfo != null ? _grdDicDetailItemInfo.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
		private List<ADM201UGrdDicMasterItemInfo> _grdDicMasterItemInfo = new List<ADM201UGrdDicMasterItemInfo>();
		private List<ADM201UGrdDicDetailItemInfo> _grdDicDetailItemInfo = new List<ADM201UGrdDicDetailItemInfo>();

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public List<ADM201UGrdDicMasterItemInfo> GrdDicMasterItemInfo
		{
			get { return this._grdDicMasterItemInfo; }
			set { this._grdDicMasterItemInfo = value; }
		}

		public List<ADM201UGrdDicDetailItemInfo> GrdDicDetailItemInfo
		{
			get { return this._grdDicDetailItemInfo; }
			set { this._grdDicDetailItemInfo = value; }
		}

		public ADM201USaveLayoutArgs() { }

		public ADM201USaveLayoutArgs(String userId, List<ADM201UGrdDicMasterItemInfo> grdDicMasterItemInfo, List<ADM201UGrdDicDetailItemInfo> grdDicDetailItemInfo)
		{
			this._userId = userId;
			this._grdDicMasterItemInfo = grdDicMasterItemInfo;
			this._grdDicDetailItemInfo = grdDicDetailItemInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADM201USaveLayoutRequest();
		}
	}
}