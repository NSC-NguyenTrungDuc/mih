using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0212U00TransactionalArgs : IContractArgs
    {
        protected bool Equals(BAS0212U00TransactionalArgs other)
        {
            return Equals(_grdInit, other._grdInit) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0212U00TransactionalArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_grdInit != null ? _grdInit.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            }
        }

        private List<BAS0212U00GrdItemInfo> _grdInit = new List<BAS0212U00GrdItemInfo>();
        private String _userId;

        public List<BAS0212U00GrdItemInfo> GrdInit
        {
            get { return this._grdInit; }
            set { this._grdInit = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public BAS0212U00TransactionalArgs() { }

        public BAS0212U00TransactionalArgs(List<BAS0212U00GrdItemInfo> grdInit, String userId)
        {
            this._grdInit = grdInit;
            this._userId = userId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0212U00TransactionalRequest();
        }
    }
}