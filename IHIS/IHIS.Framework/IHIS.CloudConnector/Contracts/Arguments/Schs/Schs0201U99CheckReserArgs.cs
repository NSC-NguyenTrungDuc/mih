using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
    public class Schs0201U99CheckReserArgs : IContractArgs
    {
    protected bool Equals(Schs0201U99CheckReserArgs other)
    {
        return string.Equals(_doctor, other._doctor) && string.Equals(_gwa, other._gwa) && string.Equals(_bunhoLink, other._bunhoLink) && string.Equals(_hospCode, other._hospCode) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_fksch0201, other._fksch0201) && string.Equals(_pkout1001, other._pkout1001);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Schs0201U99CheckReserArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunhoLink != null ? _bunhoLink.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fksch0201 != null ? _fksch0201.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _doctor;
        private String _gwa;
        private String _bunhoLink;
        private String _hospCode;
        private String _naewonDate;
        private String _fksch0201;
        private String _pkout1001;

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String BunhoLink
        {
            get { return this._bunhoLink; }
            set { this._bunhoLink = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String Fksch0201
        {
            get { return this._fksch0201; }
            set { this._fksch0201 = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public Schs0201U99CheckReserArgs() { }

        public Schs0201U99CheckReserArgs(String doctor, String gwa, String bunhoLink, String hospCode, String naewonDate, String fksch0201, String pkout1001)
        {
            this._doctor = doctor;
            this._gwa = gwa;
            this._bunhoLink = bunhoLink;
            this._hospCode = hospCode;
            this._naewonDate = naewonDate;
            this._fksch0201 = fksch0201;
            this._pkout1001 = pkout1001;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Schs0201U99CheckReserRequest();
        }
    }
}