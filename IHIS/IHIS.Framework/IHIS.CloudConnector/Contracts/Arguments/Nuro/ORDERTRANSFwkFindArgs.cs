using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class ORDERTRANSFwkFindArgs : IContractArgs
    {
        protected bool Equals(ORDERTRANSFwkFindArgs other)
        {
            return string.Equals(_actingDate, other._actingDate) && string.Equals(_hospCode, other._hospCode) && string.Equals(_bunho, other._bunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ORDERTRANSFwkFindArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_actingDate != null ? _actingDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _actingDate;
        private String _hospCode;
        private String _bunho;

        public String ActingDate
        {
            get { return this._actingDate; }
            set { this._actingDate = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public ORDERTRANSFwkFindArgs() { }

        public ORDERTRANSFwkFindArgs(String actingDate, String hospCode, String bunho)
        {
            this._actingDate = actingDate;
            this._hospCode = hospCode;
            this._bunho = bunho;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANSFwkFindRequest();
        }
    }
}