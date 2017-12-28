using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL2010U00GrdSpecimenArgs : IContractArgs
    {
        protected bool Equals(CPL2010U00GrdSpecimenArgs other)
        {
            return string.Equals(_mJubsuYn, other._mJubsuYn) && string.Equals(_orderDate, other._orderDate) && string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_orderTime, other._orderTime) && string.Equals(_doctor, other._doctor) && string.Equals(_reserDate, other._reserDate) && string.Equals(_jubsuDate, other._jubsuDate) && string.Equals(_jubsuTime, other._jubsuTime) && string.Equals(_jubsuja, other._jubsuja) && string.Equals(_groupSer, other._groupSer) && string.Equals(_reserYn, other._reserYn) && string.Equals(_emergencyYn, other._emergencyYn);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL2010U00GrdSpecimenArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_mJubsuYn != null ? _mJubsuYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_orderTime != null ? _orderTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuDate != null ? _jubsuDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuTime != null ? _jubsuTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuja != null ? _jubsuja.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_groupSer != null ? _groupSer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_reserYn != null ? _reserYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_emergencyYn != null ? _emergencyYn.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _mJubsuYn;
        private String _orderDate;
        private String _bunho;
        private String _gwa;
        private String _orderTime;
        private String _doctor;
        private String _reserDate;
        private String _jubsuDate;
        private String _jubsuTime;
        private String _jubsuja;
        private String _groupSer;
        private String _reserYn;
        private String _emergencyYn;

        public String MJubsuYn
        {
            get { return this._mJubsuYn; }
            set { this._mJubsuYn = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
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

        public String OrderTime
        {
            get { return this._orderTime; }
            set { this._orderTime = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String JubsuDate
        {
            get { return this._jubsuDate; }
            set { this._jubsuDate = value; }
        }

        public String JubsuTime
        {
            get { return this._jubsuTime; }
            set { this._jubsuTime = value; }
        }

        public String Jubsuja
        {
            get { return this._jubsuja; }
            set { this._jubsuja = value; }
        }

        public String GroupSer
        {
            get { return this._groupSer; }
            set { this._groupSer = value; }
        }

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
        }

        public String EmergencyYn
        {
            get { return this._emergencyYn; }
            set { this._emergencyYn = value; }
        }

        public CPL2010U00GrdSpecimenArgs() { }

        public CPL2010U00GrdSpecimenArgs(String mJubsuYn, String orderDate, String bunho, String gwa, String orderTime, String doctor, String reserDate, String jubsuDate, String jubsuTime, String jubsuja, String groupSer, String reserYn, String emergencyYn)
        {
            this._mJubsuYn = mJubsuYn;
            this._orderDate = orderDate;
            this._bunho = bunho;
            this._gwa = gwa;
            this._orderTime = orderTime;
            this._doctor = doctor;
            this._reserDate = reserDate;
            this._jubsuDate = jubsuDate;
            this._jubsuTime = jubsuTime;
            this._jubsuja = jubsuja;
            this._groupSer = groupSer;
            this._reserYn = reserYn;
            this._emergencyYn = emergencyYn;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010U00GrdSpecimenRequest();
        }
    }
}