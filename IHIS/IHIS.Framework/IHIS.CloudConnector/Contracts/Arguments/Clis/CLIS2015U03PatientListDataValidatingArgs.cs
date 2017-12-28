using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U03PatientListDataValidatingArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U03PatientListDataValidatingArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_bunho, other._bunho) && string.Equals(_protocolId, other._protocolId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U03PatientListDataValidatingArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_protocolId != null ? _protocolId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
        private String _bunho;
        private String _protocolId;

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

        public String ProtocolId
        {
            get { return this._protocolId; }
            set { this._protocolId = value; }
        }

        public CLIS2015U03PatientListDataValidatingArgs() { }

        public CLIS2015U03PatientListDataValidatingArgs(String hospCode, String bunho, String protocolId)
        {
            this._hospCode = hospCode;
            this._bunho = bunho;
            this._protocolId = protocolId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U03PatientListDataValidatingRequest();
        }
    }
}