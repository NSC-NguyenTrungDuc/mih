using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
    public class Schs0201U99CheckInsertArgs : IContractArgs
    {
    protected bool Equals(Schs0201U99CheckInsertArgs other)
    {
        return string.Equals(_doctor, other._doctor) && string.Equals(_gwa, other._gwa) && string.Equals(_bunho, other._bunho) && string.Equals(_hospCode, other._hospCode) && string.Equals(_naewonDate, other._naewonDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Schs0201U99CheckInsertArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _doctor;
        private String _gwa;
        private String _bunho;
        private String _hospCode;
        private String _naewonDate;

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

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
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

        public Schs0201U99CheckInsertArgs() { }

        public Schs0201U99CheckInsertArgs(String doctor, String gwa, String bunho, String hospCode, String naewonDate)
        {
            this._doctor = doctor;
            this._gwa = gwa;
            this._bunho = bunho;
            this._hospCode = hospCode;
            this._naewonDate = naewonDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Schs0201U99CheckInsertRequest();
        }
    }
}