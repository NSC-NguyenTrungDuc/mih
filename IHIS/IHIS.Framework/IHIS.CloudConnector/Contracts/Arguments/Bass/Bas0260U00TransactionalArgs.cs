using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class Bas0260U00TransactionalArgs : IContractArgs
    {
        protected bool Equals(Bas0260U00TransactionalArgs other)
        {
            return Equals(_grdBuseoList, other._grdBuseoList) && string.Equals(_userId, other._userId) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Bas0260U00TransactionalArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_grdBuseoList != null ? _grdBuseoList.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private List<BAS0260GrdBuseoListItemInfo> _grdBuseoList = new List<BAS0260GrdBuseoListItemInfo>();
        private String _userId;
        private String _hospCode;

        public List<BAS0260GrdBuseoListItemInfo> GrdBuseoList
        {
            get { return this._grdBuseoList; }
            set { this._grdBuseoList = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public Bas0260U00TransactionalArgs() { }

        public Bas0260U00TransactionalArgs(List<BAS0260GrdBuseoListItemInfo> grdBuseoList, String userId, String hospCode)
        {
            this._grdBuseoList = grdBuseoList;
            this._userId = userId;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Bas0260U00TransactionalRequest();
        }
    }
}