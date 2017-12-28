using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class ORDERTRANSExecPrOutCheckOrderEndArgs : IContractArgs
    {
        protected bool Equals(ORDERTRANSExecPrOutCheckOrderEndArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_actingDate, other._actingDate) && string.Equals(_doctor, other._doctor) && string.Equals(_bunho, other._bunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ORDERTRANSExecPrOutCheckOrderEndArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_actingDate != null ? _actingDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
        private String _actingDate;
        private String _doctor;
        private String _bunho;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String ActingDate
        {
            get { return this._actingDate; }
            set { this._actingDate = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public ORDERTRANSExecPrOutCheckOrderEndArgs() { }

        public ORDERTRANSExecPrOutCheckOrderEndArgs(String hospCode, String actingDate, String doctor, String bunho)
        {
            this._hospCode = hospCode;
            this._actingDate = actingDate;
            this._doctor = doctor;
            this._bunho = bunho;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANSExecPrOutCheckOrderEndRequest();
        }
    }
}