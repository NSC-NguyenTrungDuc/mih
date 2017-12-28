using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
    public class OCS2015U00GetDoctorPatientReportArgs : IContractArgs
    {
    protected bool Equals(OCS2015U00GetDoctorPatientReportArgs other)
    {
        return string.Equals(_doctor, other._doctor) && string.Equals(_bunho, other._bunho) && string.Equals(_pkout1001, other._pkout1001) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_gwa, other._gwa);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U00GetDoctorPatientReportArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _doctor;
        private String _bunho;
        private String _pkout1001;
        private String _naewonDate;
        private String _gwa;

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public OCS2015U00GetDoctorPatientReportArgs() { }

        public OCS2015U00GetDoctorPatientReportArgs(String doctor, String bunho, String pkout1001, String naewonDate, String gwa)
        {
            this._doctor = doctor;
            this._bunho = bunho;
            this._pkout1001 = pkout1001;
            this._naewonDate = naewonDate;
            this._gwa = gwa;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U00GetDoctorPatientReportRequest();
        }
    }
}