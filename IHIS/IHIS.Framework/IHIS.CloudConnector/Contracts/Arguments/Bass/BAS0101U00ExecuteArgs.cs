using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0101U00ExecuteArgs : IContractArgs
    {
        protected bool Equals(BAS0101U00ExecuteArgs other)
        {
            return string.Equals(_userId, other._userId) && Equals(_masterInputList, other._masterInputList) && Equals(_detailInputList, other._detailInputList);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0101U00ExecuteArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_masterInputList != null ? _masterInputList.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_detailInputList != null ? _detailInputList.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private List<BAS0101U00GrdMasterItemInfo> _masterInputList = new List<BAS0101U00GrdMasterItemInfo>();
        private List<BAS0101U00grdDetailItemInfo> _detailInputList = new List<BAS0101U00grdDetailItemInfo>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<BAS0101U00GrdMasterItemInfo> MasterInputList
        {
            get { return this._masterInputList; }
            set { this._masterInputList = value; }
        }

        public List<BAS0101U00grdDetailItemInfo> DetailInputList
        {
            get { return this._detailInputList; }
            set { this._detailInputList = value; }
        }

        public BAS0101U00ExecuteArgs() { }

        public BAS0101U00ExecuteArgs(String userId, List<BAS0101U00GrdMasterItemInfo> masterInputList, List<BAS0101U00grdDetailItemInfo> detailInputList)
        {
            this._userId = userId;
            this._masterInputList = masterInputList;
            this._detailInputList = detailInputList;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0101U00ExecuteRequest();
        }
    }
}