using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0270U00GrdBAS0271Args : IContractArgs
    {
        protected bool Equals(BAS0270U00GrdBAS0271Args other)
        {
            return string.Equals(_doctorYmd, other._doctorYmd) && string.Equals(_doctorName, other._doctorName) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0270U00GrdBAS0271Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_doctorYmd != null ? _doctorYmd.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctorName != null ? _doctorName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _doctorYmd;
        private String _doctorName;
        private String _hospCode;

        public String DoctorYmd
        {
            get { return this._doctorYmd; }
            set { this._doctorYmd = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public BAS0270U00GrdBAS0271Args() { }

        public BAS0270U00GrdBAS0271Args(String doctorYmd, String doctorName, String hospCode)
        {
            this._doctorYmd = doctorYmd;
            this._doctorName = doctorName;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0270U00GrdBAS0271Request();
        }
    }
}