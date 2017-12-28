using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04PrOutMakeAutoJubsuArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04PrOutMakeAutoJubsuArgs other)
    {
        return string.Equals(_pkout1001, other._pkout1001) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_jubsuGubun, other._jubsuGubun) && string.Equals(_userId, other._userId) && string.Equals(_bunho, other._bunho) && string.Equals(_naewonDate, other._naewonDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04PrOutMakeAutoJubsuArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jubsuGubun != null ? _jubsuGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _pkout1001;
        private String _gwa;
        private String _doctor;
        private String _jubsuGubun;
        private String _userId;
        private String _bunho;
        private String _naewonDate;

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
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

        public String JubsuGubun
        {
            get { return this._jubsuGubun; }
            set { this._jubsuGubun = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public PHY2001U04PrOutMakeAutoJubsuArgs() { }

        public PHY2001U04PrOutMakeAutoJubsuArgs(String pkout1001, String gwa, String doctor, String jubsuGubun, String userId, String bunho, String naewonDate)
        {
            this._pkout1001 = pkout1001;
            this._gwa = gwa;
            this._doctor = doctor;
            this._jubsuGubun = jubsuGubun;
            this._userId = userId;
            this._bunho = bunho;
            this._naewonDate = naewonDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04PrOutMakeAutoJubsuRequest();
        }
    }
}