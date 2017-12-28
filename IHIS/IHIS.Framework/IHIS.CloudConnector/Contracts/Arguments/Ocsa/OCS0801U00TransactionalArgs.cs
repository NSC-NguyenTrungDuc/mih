using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0801U00TransactionalArgs : IContractArgs
    {
    protected bool Equals(OCS0801U00TransactionalArgs other)
    {
        return Equals(_listInfo1, other._listInfo1) && Equals(_listInfo2, other._listInfo2) && string.Equals(_userId, other._userId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0801U00TransactionalArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_listInfo1 != null ? _listInfo1.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_listInfo2 != null ? _listInfo2.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private List<OCS0801U00GrdOCS0801ListItemInfo> _listInfo1 = new List<OCS0801U00GrdOCS0801ListItemInfo>();
        private List<OCS0801U00GrdOCS0802ListItemInfo> _listInfo2 = new List<OCS0801U00GrdOCS0802ListItemInfo>();
        private String _userId;

        public List<OCS0801U00GrdOCS0801ListItemInfo> ListInfo1
        {
            get { return this._listInfo1; }
            set { this._listInfo1 = value; }
        }

        public List<OCS0801U00GrdOCS0802ListItemInfo> ListInfo2
        {
            get { return this._listInfo2; }
            set { this._listInfo2 = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public OCS0801U00TransactionalArgs() { }

        public OCS0801U00TransactionalArgs(List<OCS0801U00GrdOCS0801ListItemInfo> listInfo1, List<OCS0801U00GrdOCS0802ListItemInfo> listInfo2, String userId)
        {
            this._listInfo1 = listInfo1;
            this._listInfo2 = listInfo2;
            this._userId = userId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0801U00TransactionalRequest();
        }
    }
}