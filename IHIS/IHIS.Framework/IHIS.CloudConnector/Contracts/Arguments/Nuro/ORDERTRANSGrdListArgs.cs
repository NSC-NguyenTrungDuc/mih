using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdListArgs : IContractArgs
    {
        protected bool Equals(ORDERTRANSGrdListArgs other)
        {
            return string.Equals(_ioGubun, other._ioGubun) && string.Equals(_sendYn, other._sendYn) && string.Equals(_hospCode, other._hospCode) && string.Equals(_actingDate, other._actingDate) && string.Equals(_pk1001, other._pk1001) && string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_orderDate, other._orderDate) && string.Equals(_str, other._str) && string.Equals(_mSendYn, other._mSendYn);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ORDERTRANSGrdListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sendYn != null ? _sendYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_actingDate != null ? _actingDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pk1001 != null ? _pk1001.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_str != null ? _str.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_mSendYn != null ? _mSendYn.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _ioGubun;
        private String _sendYn;
        private String _hospCode;
        private String _actingDate;
        private String _pk1001;
        private String _bunho;
        private String _gwa;
        private String _doctor;
        private String _orderDate;
        private String _str;
        private String _mSendYn;

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
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

        public String ActingDate
        {
            get { return this._actingDate; }
            set { this._actingDate = value; }
        }

        public String Pk1001
        {
            get { return this._pk1001; }
            set { this._pk1001 = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
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

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String Str
        {
            get { return this._str; }
            set { this._str = value; }
        }

        public String MSendYn
        {
            get { return this._mSendYn; }
            set { this._mSendYn = value; }
        }

        public ORDERTRANSGrdListArgs() { }

        public ORDERTRANSGrdListArgs(String ioGubun, String sendYn, String hospCode, String actingDate, String pk1001, String bunho, String gwa, String doctor, String orderDate, String str, String mSendYn)
        {
            this._ioGubun = ioGubun;
            this._sendYn = sendYn;
            this._hospCode = hospCode;
            this._actingDate = actingDate;
            this._pk1001 = pk1001;
            this._bunho = bunho;
            this._gwa = gwa;
            this._doctor = doctor;
            this._orderDate = orderDate;
            this._str = str;
            this._mSendYn = mSendYn;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANSGrdListRequest();
        }
    }
}