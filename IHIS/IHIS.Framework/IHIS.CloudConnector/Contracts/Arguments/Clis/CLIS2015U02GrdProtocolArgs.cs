using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U02GrdProtocolArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U02GrdProtocolArgs other)
        {
            return string.Equals(_protocolCode, other._protocolCode) && string.Equals(_protocolName, other._protocolName) && string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate) && string.Equals(_protocolStatus, other._protocolStatus) && string.Equals(_patientCode, other._patientCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U02GrdProtocolArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_protocolCode != null ? _protocolCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_protocolName != null ? _protocolName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fromDate != null ? _fromDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_protocolStatus != null ? _protocolStatus.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_patientCode != null ? _patientCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _protocolCode;
        private String _protocolName;
        private String _fromDate;
        private String _toDate;
        private String _protocolStatus;
        private String _patientCode;

        public String ProtocolCode
        {
            get { return this._protocolCode; }
            set { this._protocolCode = value; }
        }

        public String ProtocolName
        {
            get { return this._protocolName; }
            set { this._protocolName = value; }
        }

        public String FromDate
        {
            get { return this._fromDate; }
            set { this._fromDate = value; }
        }

        public String ToDate
        {
            get { return this._toDate; }
            set { this._toDate = value; }
        }

        public String ProtocolStatus
        {
            get { return this._protocolStatus; }
            set { this._protocolStatus = value; }
        }

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public CLIS2015U02GrdProtocolArgs() { }

        public CLIS2015U02GrdProtocolArgs(String protocolCode, String protocolName, String fromDate, String toDate, String protocolStatus, String patientCode)
        {
            this._protocolCode = protocolCode;
            this._protocolName = protocolName;
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._protocolStatus = protocolStatus;
            this._patientCode = patientCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U02GrdProtocolRequest();
        }
    }
}