using System;
using IHIS.CloudConnector.Contracts.Models.Chts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    [Serializable]
    public class CHT0115Q01TransactionalArgs : IContractArgs
    {
        protected bool Equals(CHT0115Q01TransactionalArgs other)
        {
            return Equals(_listInfo, other._listInfo) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CHT0115Q01TransactionalArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_listInfo != null ? _listInfo.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            }
        }

        private List<CHT0115Q01grdCHT0115Info> _listInfo = new List<CHT0115Q01grdCHT0115Info>();
        private String _userId;

        public List<CHT0115Q01grdCHT0115Info> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public CHT0115Q01TransactionalArgs() { }

        public CHT0115Q01TransactionalArgs(List<CHT0115Q01grdCHT0115Info> listInfo, String userId)
        {
            this._listInfo = listInfo;
            this._userId = userId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CHT0115Q01TransactionalRequest();
        }
    }
}