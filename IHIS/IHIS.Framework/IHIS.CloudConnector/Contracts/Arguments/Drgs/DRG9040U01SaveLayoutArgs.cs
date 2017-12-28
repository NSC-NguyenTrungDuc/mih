using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using DRG9040U01GrdJUSAOrderListInfo = IHIS.CloudConnector.Contracts.Models.Drgs.DRG9040U01GrdJUSAOrderListInfo;
using DRG9040U01GrdOrderInfo = IHIS.CloudConnector.Contracts.Models.Drgs.DRG9040U01GrdOrderInfo;
using DRG9040U01GrdOrderListInfo = IHIS.CloudConnector.Contracts.Models.Drgs.DRG9040U01GrdOrderListInfo;
using DRG9040U01GrdOrderListOutInfo = IHIS.CloudConnector.Contracts.Models.Drgs.DRG9040U01GrdOrderListOutInfo;
using DRG9040U01GrdOrderOutInfo = IHIS.CloudConnector.Contracts.Models.Drgs.DRG9040U01GrdOrderOutInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG9040U01SaveLayoutArgs : IContractArgs
	{
        protected bool Equals(DRG9040U01SaveLayoutArgs other)
        {
            return Equals(_grdOrderInfo, other._grdOrderInfo) && Equals(_grdJusaOrderInfo, other._grdJusaOrderInfo) && Equals(_grdOrderListInfo, other._grdOrderListInfo) && Equals(_grdOrderOutInfo, other._grdOrderOutInfo) && Equals(_grdOrderListOutInfo, other._grdOrderListOutInfo) && string.Equals(_bunho, other._bunho) && string.Equals(_drg9041OcsRemark, other._drg9041OcsRemark) && string.Equals(_drg9041DrgRemark, other._drg9041DrgRemark) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG9040U01SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_grdOrderInfo != null ? _grdOrderInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grdJusaOrderInfo != null ? _grdJusaOrderInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grdOrderListInfo != null ? _grdOrderListInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grdOrderOutInfo != null ? _grdOrderOutInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grdOrderListOutInfo != null ? _grdOrderListOutInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_drg9041OcsRemark != null ? _drg9041OcsRemark.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_drg9041DrgRemark != null ? _drg9041DrgRemark.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private List<DRG9040U01GrdOrderInfo> _grdOrderInfo = new List<DRG9040U01GrdOrderInfo>();
		private List<DRG9040U01GrdJUSAOrderListInfo> _grdJusaOrderInfo = new List<DRG9040U01GrdJUSAOrderListInfo>();
		private List<DRG9040U01GrdOrderListInfo> _grdOrderListInfo = new List<DRG9040U01GrdOrderListInfo>();
		private List<DRG9040U01GrdOrderOutInfo> _grdOrderOutInfo = new List<DRG9040U01GrdOrderOutInfo>();
		private List<DRG9040U01GrdOrderListOutInfo> _grdOrderListOutInfo = new List<DRG9040U01GrdOrderListOutInfo>();
		private String _bunho;
		private String _drg9041OcsRemark;
		private String _drg9041DrgRemark;
		private String _userId;

		public List<DRG9040U01GrdOrderInfo> GrdOrderInfo
		{
			get { return this._grdOrderInfo; }
			set { this._grdOrderInfo = value; }
		}

		public List<DRG9040U01GrdJUSAOrderListInfo> GrdJusaOrderInfo
		{
			get { return this._grdJusaOrderInfo; }
			set { this._grdJusaOrderInfo = value; }
		}

		public List<DRG9040U01GrdOrderListInfo> GrdOrderListInfo
		{
			get { return this._grdOrderListInfo; }
			set { this._grdOrderListInfo = value; }
		}

		public List<DRG9040U01GrdOrderOutInfo> GrdOrderOutInfo
		{
			get { return this._grdOrderOutInfo; }
			set { this._grdOrderOutInfo = value; }
		}

		public List<DRG9040U01GrdOrderListOutInfo> GrdOrderListOutInfo
		{
			get { return this._grdOrderListOutInfo; }
			set { this._grdOrderListOutInfo = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Drg9041OcsRemark
		{
			get { return this._drg9041OcsRemark; }
			set { this._drg9041OcsRemark = value; }
		}

		public String Drg9041DrgRemark
		{
			get { return this._drg9041DrgRemark; }
			set { this._drg9041DrgRemark = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public DRG9040U01SaveLayoutArgs() { }

		public DRG9040U01SaveLayoutArgs(List<DRG9040U01GrdOrderInfo> grdOrderInfo, List<DRG9040U01GrdJUSAOrderListInfo> grdJusaOrderInfo, List<DRG9040U01GrdOrderListInfo> grdOrderListInfo, List<DRG9040U01GrdOrderOutInfo> grdOrderOutInfo, List<DRG9040U01GrdOrderListOutInfo> grdOrderListOutInfo, String bunho, String drg9041OcsRemark, String drg9041DrgRemark, String userId)
		{
			this._grdOrderInfo = grdOrderInfo;
			this._grdJusaOrderInfo = grdJusaOrderInfo;
			this._grdOrderListInfo = grdOrderListInfo;
			this._grdOrderOutInfo = grdOrderOutInfo;
			this._grdOrderListOutInfo = grdOrderListOutInfo;
			this._bunho = bunho;
			this._drg9041OcsRemark = drg9041OcsRemark;
			this._drg9041DrgRemark = drg9041DrgRemark;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRG9040U01SaveLayoutRequest();
		}
	}
}