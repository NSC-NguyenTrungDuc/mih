using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT1001U01CheckNaewonYnArgs : IContractArgs
    {
        protected bool Equals(NuroOUT1001U01CheckNaewonYnArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_naewonType, other._naewonType) && string.Equals(_oldJubsuNo, other._oldJubsuNo) && string.Equals(_chojae, other._chojae);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01CheckNaewonYnArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonType != null ? _naewonType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_oldJubsuNo != null ? _oldJubsuNo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_chojae != null ? _chojae.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
        private String _naewonDate;
        private String _gwa;
        private String _doctor;
        private String _naewonType;
        private String _oldJubsuNo;
        private String _chojae;

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

        public String NaewonType
        {
            get { return this._naewonType; }
            set { this._naewonType = value; }
        }

        public String OldJubsuNo
        {
            get { return this._oldJubsuNo; }
            set { this._oldJubsuNo = value; }
        }

        public String Chojae
        {
            get { return this._chojae; }
            set { this._chojae = value; }
        }

        public NuroOUT1001U01CheckNaewonYnArgs() { }

        public NuroOUT1001U01CheckNaewonYnArgs(String bunho, String naewonDate, String gwa, String doctor, String naewonType, String oldJubsuNo, String chojae)
        {
            this._bunho = bunho;
            this._naewonDate = naewonDate;
            this._gwa = gwa;
            this._doctor = doctor;
            this._naewonType = naewonType;
            this._oldJubsuNo = oldJubsuNo;
            this._chojae = chojae;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1001U01CheckNaewonYnRequest();
        }
    }
}
