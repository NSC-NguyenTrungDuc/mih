using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM106UFwkPgmIDArgs : IContractArgs
    {
        protected bool Equals(ADM106UFwkPgmIDArgs other)
        {
            return string.Equals(_pgmId, other._pgmId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM106UFwkPgmIDArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_pgmId != null ? _pgmId.GetHashCode() : 0);
        }

        private String _pgmId;

        public String PgmId
        {
            get { return this._pgmId; }
            set { this._pgmId = value; }
        }

        public ADM106UFwkPgmIDArgs() { }

        public ADM106UFwkPgmIDArgs(String pgmId)
        {
            this._pgmId = pgmId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM106UFwkPgmIDRequest();
        }
    }
}