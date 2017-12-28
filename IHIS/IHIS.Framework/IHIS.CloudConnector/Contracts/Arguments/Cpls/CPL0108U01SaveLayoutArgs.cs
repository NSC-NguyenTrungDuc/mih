using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL0108U01SaveLayoutArgs : IContractArgs
    {
        protected bool Equals(CPL0108U01SaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && Equals(_grdMstItem, other._grdMstItem) && Equals(_grdDetailItem, other._grdDetailItem) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0108U01SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grdMstItem != null ? _grdMstItem.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grdDetailItem != null ? _grdDetailItem.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private List<CPL0108U01GrdMasterItemInfo> _grdMstItem = new List<CPL0108U01GrdMasterItemInfo>();
        private List<CPL0108U01GrdDetailInfo> _grdDetailItem = new List<CPL0108U01GrdDetailInfo>();
        private String _hospCode;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<CPL0108U01GrdMasterItemInfo> GrdMstItem
        {
            get { return this._grdMstItem; }
            set { this._grdMstItem = value; }
        }

        public List<CPL0108U01GrdDetailInfo> GrdDetailItem
        {
            get { return this._grdDetailItem; }
            set { this._grdDetailItem = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public CPL0108U01SaveLayoutArgs() { }

        public CPL0108U01SaveLayoutArgs(String userId, List<CPL0108U01GrdMasterItemInfo> grdMstItem, List<CPL0108U01GrdDetailInfo> grdDetailItem, String hospCode)
        {
            this._userId = userId;
            this._grdMstItem = grdMstItem;
            this._grdDetailItem = grdDetailItem;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL0108U01SaveLayoutRequest();
        }
    }
}