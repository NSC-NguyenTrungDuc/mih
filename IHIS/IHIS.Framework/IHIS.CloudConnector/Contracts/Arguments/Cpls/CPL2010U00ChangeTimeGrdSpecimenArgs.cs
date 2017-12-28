using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL2010U00ChangeTimeGrdSpecimenArgs : IContractArgs
    {
        protected bool Equals(CPL2010U00ChangeTimeGrdSpecimenArgs other)
        {
            return string.Equals(_orderDate, other._orderDate) && string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_gubun, other._gubun) && string.Equals(_doctor, other._doctor) && string.Equals(_inOutGubun, other._inOutGubun);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL2010U00ChangeTimeGrdSpecimenArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_orderDate != null ? _orderDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_inOutGubun != null ? _inOutGubun.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _orderDate;
        private String _bunho;
        private String _gwa;
        private String _gubun;
        private String _doctor;
        private String _inOutGubun;

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

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public CPL2010U00ChangeTimeGrdSpecimenArgs() { }

        public CPL2010U00ChangeTimeGrdSpecimenArgs(String orderDate, String bunho, String gwa, String gubun, String doctor, String inOutGubun)
        {
            this._orderDate = orderDate;
            this._bunho = bunho;
            this._gwa = gwa;
            this._gubun = gubun;
            this._doctor = doctor;
            this._inOutGubun = inOutGubun;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010U00ChangeTimeGrdSpecimenRequest();
        }
    }
}