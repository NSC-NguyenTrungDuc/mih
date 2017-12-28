using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL2010U00GrdOrderArgs : IContractArgs
    {
        protected bool Equals(CPL2010U00GrdOrderArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_mijubsu, other._mijubsu) && string.Equals(_fromDate, other._fromDate) && string.Equals(_reserYn, other._reserYn) && string.Equals(_toDate, other._toDate) && string.Equals(_doctor, other._doctor) && string.Equals(_emergencyYn, other._emergencyYn);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL2010U00GrdOrderArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_mijubsu != null ? _mijubsu.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fromDate != null ? _fromDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_reserYn != null ? _reserYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_emergencyYn != null ? _emergencyYn.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
        private String _mijubsu;
        private String _reserYn;
        private String _fromDate;
        private String _toDate;
        private String _doctor;
        private String _emergencyYn;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Mijubsu
        {
            get { return this._mijubsu; }
            set { this._mijubsu = value; }
        }

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
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

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String EmergencyYn
        {
            get { return this._emergencyYn; }
            set { this._emergencyYn = value; }
        }

        public CPL2010U00GrdOrderArgs() { }

        public CPL2010U00GrdOrderArgs(String bunho, String mijubsu, String reserYn, String fromDate, String toDate, String doctor, String emergencyYn)
        {
            this._bunho = bunho;
            this._mijubsu = mijubsu;
            this._reserYn = reserYn;
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._doctor = doctor;
            this._emergencyYn = emergencyYn;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010U00GrdOrderRequest();
        }
    }
}