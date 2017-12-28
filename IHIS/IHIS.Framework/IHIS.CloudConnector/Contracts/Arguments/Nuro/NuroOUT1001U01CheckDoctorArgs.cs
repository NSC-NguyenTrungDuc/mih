using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT1001U01CheckDoctorArgs : IContractArgs
    {
        protected bool Equals(NuroOUT1001U01CheckDoctorArgs other)
        {
            return string.Equals(_gubun, other._gubun) && string.Equals(_date, other._date) && string.Equals(_time, other._time) && string.Equals(_doctor, other._doctor);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01CheckDoctorArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_date != null ? _date.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_time != null ? _time.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _gubun;
        private String _date;
        private String _time;
        private String _doctor;

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String Date
        {
            get { return this._date; }
            set { this._date = value; }
        }

        public String Time
        {
            get { return this._time; }
            set { this._time = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public NuroOUT1001U01CheckDoctorArgs() { }

        public NuroOUT1001U01CheckDoctorArgs(String gubun, String date, String time, String doctor)
        {
            this._gubun = gubun;
            this._date = date;
            this._time = time;
            this._doctor = doctor;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1001U01CheckDoctorRequest();
        }
    }
}
