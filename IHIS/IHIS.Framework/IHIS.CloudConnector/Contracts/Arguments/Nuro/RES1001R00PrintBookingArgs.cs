using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class RES1001R00PrintBookingArgs : IContractArgs
    {
        protected bool Equals(RES1001R00PrintBookingArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_hospCodeLink, other._hospCodeLink) && string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_jubsuTime, other._jubsuTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RES1001R00PrintBookingArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuTime != null ? _jubsuTime.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
        private String _hospCodeLink;
        private String _bunho;
        private String _gwa;
        private String _doctor;
        private String _naewonDate;
        private String _jubsuTime;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
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

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String JubsuTime
        {
            get { return this._jubsuTime; }
            set { this._jubsuTime = value; }
        }

        public RES1001R00PrintBookingArgs() { }

        public RES1001R00PrintBookingArgs(String hospCode, String hospCodeLink, String bunho, String gwa, String doctor, String naewonDate, String jubsuTime)
        {
            this._hospCode = hospCode;
            this._hospCodeLink = hospCodeLink;
            this._bunho = bunho;
            this._gwa = gwa;
            this._doctor = doctor;
            this._naewonDate = naewonDate;
            this._jubsuTime = jubsuTime;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.RES1001R00PrintBookingRequest();
        }
    }
}