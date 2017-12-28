using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using NUR0101U01GrdDetailInfo = IHIS.CloudConnector.Contracts.Models.Nuri.NUR0101U01GrdDetailInfo;
using NUR0101U01GrdMasterInfo = IHIS.CloudConnector.Contracts.Models.Nuri.NUR0101U01GrdMasterInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuri
{
    [Serializable]
	public class NUR0101U01SaveLayoutArgs : IContractArgs
	{
        protected bool Equals(NUR0101U01SaveLayoutArgs other)
        {
            return Equals(_grdDetailInfo, other._grdDetailInfo) && Equals(_grdMasterInfo, other._grdMasterInfo) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUR0101U01SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_grdDetailInfo != null ? _grdDetailInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grdMasterInfo != null ? _grdMasterInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private List<NUR0101U01GrdDetailInfo> _grdDetailInfo = new List<NUR0101U01GrdDetailInfo>();
		private List<NUR0101U01GrdMasterInfo> _grdMasterInfo = new List<NUR0101U01GrdMasterInfo>();
		private String _userId;

		public List<NUR0101U01GrdDetailInfo> GrdDetailInfo
		{
			get { return this._grdDetailInfo; }
			set { this._grdDetailInfo = value; }
		}

		public List<NUR0101U01GrdMasterInfo> GrdMasterInfo
		{
			get { return this._grdMasterInfo; }
			set { this._grdMasterInfo = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public NUR0101U01SaveLayoutArgs() { }

		public NUR0101U01SaveLayoutArgs(List<NUR0101U01GrdDetailInfo> grdDetailInfo, List<NUR0101U01GrdMasterInfo> grdMasterInfo, String userId)
		{
			this._grdDetailInfo = grdDetailInfo;
			this._grdMasterInfo = grdMasterInfo;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new NUR0101U01SaveLayoutRequest();
		}
	}
}