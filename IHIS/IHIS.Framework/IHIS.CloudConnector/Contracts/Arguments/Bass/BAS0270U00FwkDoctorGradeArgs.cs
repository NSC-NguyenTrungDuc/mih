using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0270U00FwkDoctorGradeArgs : IContractArgs
    {
        protected bool Equals(BAS0270U00FwkDoctorGradeArgs other)
        {
            return string.Equals(_find1, other._find1) && string.Equals(_code, other._code) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0270U00FwkDoctorGradeArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_find1 != null ? _find1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_code != null ? _code.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _find1;
        private String _code;
        private String _hospCode;

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public BAS0270U00FwkDoctorGradeArgs() { }

        public BAS0270U00FwkDoctorGradeArgs(String find1, String code, String hospCode)
        {
            this._find1 = find1;
            this._code = code;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0270U00FwkDoctorGradeRequest();
        }
    }
}