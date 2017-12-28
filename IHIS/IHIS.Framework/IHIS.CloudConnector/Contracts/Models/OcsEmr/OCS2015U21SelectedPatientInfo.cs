using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
    public class OCS2015U21SelectedPatientInfo
    {
        protected bool Equals(OCS2015U21SelectedPatientInfo other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_naewonKey, other._naewonKey) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_approveDoctor, other._approveDoctor);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OCS2015U21SelectedPatientInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonKey != null ? _naewonKey.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_approveDoctor != null ? _approveDoctor.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
        private String _naewonKey;
        private String _naewonDate;
        private String _gwa;
        private String _doctor;
        private String _approveDoctor;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String NaewonKey
        {
            get { return this._naewonKey; }
            set { this._naewonKey = value; }
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

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String ApproveDoctor
        {
            get { return this._approveDoctor; }
            set { this._approveDoctor = value; }
        }

        public OCS2015U21SelectedPatientInfo() { }

        public OCS2015U21SelectedPatientInfo(String bunho, String naewonKey, String naewonDate, String gwa, String doctor, String approveDoctor)
        {
            this._bunho = bunho;
            this._naewonKey = naewonKey;
            this._naewonDate = naewonDate;
            this._gwa = gwa;
            this._doctor = doctor;
            this._approveDoctor = approveDoctor;
        }

    }
}