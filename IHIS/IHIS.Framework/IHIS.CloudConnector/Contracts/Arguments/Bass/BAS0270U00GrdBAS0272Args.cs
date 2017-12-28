using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0270U00GrdBAS0272Args : IContractArgs
    {
        protected bool Equals(BAS0270U00GrdBAS0272Args other)
        {
            return string.Equals(_doctorYmd, other._doctorYmd) && string.Equals(_doctor, other._doctor) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0270U00GrdBAS0272Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_doctorYmd != null ? _doctorYmd.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _doctorYmd;
        private String _doctor;
        private String _hospCode;

        public String DoctorYmd
        {
            get { return this._doctorYmd; }
            set { this._doctorYmd = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public BAS0270U00GrdBAS0272Args() { }

        public BAS0270U00GrdBAS0272Args(String doctorYmd, String doctor, String hospCode)
        {
            this._doctorYmd = doctorYmd;
            this._doctor = doctor;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0270U00GrdBAS0272Request();
        }
    }
}