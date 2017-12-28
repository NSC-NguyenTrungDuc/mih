using System;
using IHIS.CloudConnector.Contracts.Models.Pfes;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Pfes
{[Serializable]
    public class PFE0101U01SaveLayoutArgs : IContractArgs
    {
    protected bool Equals(PFE0101U01SaveLayoutArgs other)
    {
        return string.Equals(_userId, other._userId) && Equals(_grdDcodeItem, other._grdDcodeItem) && Equals(_grdMcodeItem, other._grdMcodeItem);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PFE0101U01SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdDcodeItem != null ? _grdDcodeItem.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdMcodeItem != null ? _grdMcodeItem.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _userId;
        private List<PFE0101U01GrdDCodeInfo> _grdDcodeItem = new List<PFE0101U01GrdDCodeInfo>();
        private List<PFE0101U01GrdMCodeInfo> _grdMcodeItem = new List<PFE0101U01GrdMCodeInfo>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<PFE0101U01GrdDCodeInfo> GrdDcodeItem
        {
            get { return this._grdDcodeItem; }
            set { this._grdDcodeItem = value; }
        }

        public List<PFE0101U01GrdMCodeInfo> GrdMcodeItem
        {
            get { return this._grdMcodeItem; }
            set { this._grdMcodeItem = value; }
        }

        public PFE0101U01SaveLayoutArgs() { }

        public PFE0101U01SaveLayoutArgs(String userId, List<PFE0101U01GrdDCodeInfo> grdDcodeItem, List<PFE0101U01GrdMCodeInfo> grdMcodeItem)
        {
            this._userId = userId;
            this._grdDcodeItem = grdDcodeItem;
            this._grdMcodeItem = grdMcodeItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PFE0101U01SaveLayoutRequest();
        }
    }
}