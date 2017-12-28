using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class RES1001U00CheckJinryoYnArgs : IContractArgs
    {
        protected bool Equals(RES1001U00CheckJinryoYnArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_doctor, other._doctor) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_jubsuTime, other._jubsuTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RES1001U00CheckJinryoYnArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuTime != null ? _jubsuTime.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
        private String _doctor;
        private String _naewonDate;
        private String _jubsuTime;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
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

        public RES1001U00CheckJinryoYnArgs() { }

        public RES1001U00CheckJinryoYnArgs(String hospCode, String doctor, String naewonDate, String jubsuTime)
        {
            this._hospCode = hospCode;
            this._doctor = doctor;
            this._naewonDate = naewonDate;
            this._jubsuTime = jubsuTime;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.RES1001U00CheckJinryoYnRequest();
        }
    }
}