using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using INJ0101U01GrdDetailItemInfo = IHIS.CloudConnector.Contracts.Models.Injs.INJ0101U01GrdDetailItemInfo;
using INJ0101U01GrdMasterItemInfo = IHIS.CloudConnector.Contracts.Models.Injs.INJ0101U01GrdMasterItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class INJ0101U01SaveLayoutArgs : IContractArgs
	{
        protected bool Equals(INJ0101U01SaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && Equals(_grdMasterItemInfo, other._grdMasterItemInfo) && Equals(_grdDetailItemInfo, other._grdDetailItemInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ0101U01SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grdMasterItemInfo != null ? _grdMasterItemInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grdDetailItemInfo != null ? _grdDetailItemInfo.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
		private List<INJ0101U01GrdMasterItemInfo> _grdMasterItemInfo = new List<INJ0101U01GrdMasterItemInfo>();
		private List<INJ0101U01GrdDetailItemInfo> _grdDetailItemInfo = new List<INJ0101U01GrdDetailItemInfo>();

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public List<INJ0101U01GrdMasterItemInfo> GrdMasterItemInfo
		{
			get { return this._grdMasterItemInfo; }
			set { this._grdMasterItemInfo = value; }
		}

		public List<INJ0101U01GrdDetailItemInfo> GrdDetailItemInfo
		{
			get { return this._grdDetailItemInfo; }
			set { this._grdDetailItemInfo = value; }
		}

		public INJ0101U01SaveLayoutArgs() { }

		public INJ0101U01SaveLayoutArgs(String userId, List<INJ0101U01GrdMasterItemInfo> grdMasterItemInfo, List<INJ0101U01GrdDetailItemInfo> grdDetailItemInfo)
		{
			this._userId = userId;
			this._grdMasterItemInfo = grdMasterItemInfo;
			this._grdDetailItemInfo = grdDetailItemInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new INJ0101U01SaveLayoutRequest();
		}
	}
}