using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
    public class SCH0109U01SaveLayoutArgs : IContractArgs
    {
    protected bool Equals(SCH0109U01SaveLayoutArgs other)
    {
        return string.Equals(_userId, other._userId) && Equals(_grdMstItem, other._grdMstItem) && Equals(_grdDetailItem, other._grdDetailItem);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH0109U01SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdMstItem != null ? _grdMstItem.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdDetailItem != null ? _grdDetailItem.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _userId;
        private List<SCH0109U01GrdMasterInfo> _grdMstItem = new List<SCH0109U01GrdMasterInfo>();
        private List<SCH0109U01GrdDetailInfo> _grdDetailItem = new List<SCH0109U01GrdDetailInfo>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<SCH0109U01GrdMasterInfo> GrdMstItem
        {
            get { return this._grdMstItem; }
            set { this._grdMstItem = value; }
        }

        public List<SCH0109U01GrdDetailInfo> GrdDetailItem
        {
            get { return this._grdDetailItem; }
            set { this._grdDetailItem = value; }
        }

        public SCH0109U01SaveLayoutArgs() { }

        public SCH0109U01SaveLayoutArgs(String userId, List<SCH0109U01GrdMasterInfo> grdMstItem, List<SCH0109U01GrdDetailInfo> grdDetailItem)
        {
            this._userId = userId;
            this._grdMstItem = grdMstItem;
            this._grdDetailItem = grdDetailItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SCH0109U01SaveLayoutRequest();
        }
    }
}