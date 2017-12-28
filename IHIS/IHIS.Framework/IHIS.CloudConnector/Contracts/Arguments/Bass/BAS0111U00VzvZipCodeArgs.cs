using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0111U00VzvZipCodeArgs : IContractArgs
    {
        protected bool Equals(BAS0111U00VzvZipCodeArgs other)
        {
            return string.Equals(_fHospCode, other._fHospCode) && string.Equals(_fZip1, other._fZip1) && string.Equals(_fZip2, other._fZip2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0111U00VzvZipCodeArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_fHospCode != null ? _fHospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fZip1 != null ? _fZip1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fZip2 != null ? _fZip2.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _fHospCode;
        private String _fZip1;
        private String _fZip2;

        public String FHospCode
        {
            get { return this._fHospCode; }
            set { this._fHospCode = value; }
        }

        public String FZip1
        {
            get { return this._fZip1; }
            set { this._fZip1 = value; }
        }

        public String FZip2
        {
            get { return this._fZip2; }
            set { this._fZip2 = value; }
        }

        public BAS0111U00VzvZipCodeArgs() { }

        public BAS0111U00VzvZipCodeArgs(String fHospCode, String fZip1, String fZip2)
        {
            this._fHospCode = fHospCode;
            this._fZip1 = fZip1;
            this._fZip2 = fZip2;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0111U00VzvZipCodeRequest();
        }
    }
}