using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdEditIGubunArgs : IContractArgs
    {
        protected bool Equals(ORDERTRANSGrdEditIGubunArgs other)
        {
            return string.Equals(_pk1001, other._pk1001) && string.Equals(_sendYn, other._sendYn) && string.Equals(_hospCode, other._hospCode) && string.Equals(_bunho, other._bunho) && string.Equals(_orderDate, other._orderDate) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ORDERTRANSGrdEditIGubunArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_pk1001 != null ? _pk1001.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sendYn != null ? _sendYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _pk1001;
        private String _sendYn;
        private String _hospCode;
        private String _bunho;
        private String _orderDate;
        private String _gwa;
        private String _doctor;

        public String Pk1001
        {
            get { return this._pk1001; }
            set { this._pk1001 = value; }
        }

        public String SendYn
        {
            get { return this._sendYn; }
            set { this._sendYn = value; }
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

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public ORDERTRANSGrdEditIGubunArgs() { }

        public ORDERTRANSGrdEditIGubunArgs(String pk1001, String sendYn, String hospCode, String bunho, String orderDate, String gwa, String doctor)
        {
            this._pk1001 = pk1001;
            this._sendYn = sendYn;
            this._hospCode = hospCode;
            this._bunho = bunho;
            this._orderDate = orderDate;
            this._gwa = gwa;
            this._doctor = doctor;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANSGrdEditIGubunRequest();
        }
    }
}