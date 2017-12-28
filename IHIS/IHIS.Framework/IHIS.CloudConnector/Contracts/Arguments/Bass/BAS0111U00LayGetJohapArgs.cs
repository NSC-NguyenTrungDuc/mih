using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0111U00LayGetJohapArgs : IContractArgs
    {
        protected bool Equals(BAS0111U00LayGetJohapArgs other)
        {
            return string.Equals(_fHospCode, other._fHospCode) && string.Equals(_fGubun, other._fGubun) && string.Equals(_fNaewonDate, other._fNaewonDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0111U00LayGetJohapArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_fHospCode != null ? _fHospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fGubun != null ? _fGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fNaewonDate != null ? _fNaewonDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _fHospCode;
        private String _fGubun;
        private String _fNaewonDate;

        public String FHospCode
        {
            get { return this._fHospCode; }
            set { this._fHospCode = value; }
        }

        public String FGubun
        {
            get { return this._fGubun; }
            set { this._fGubun = value; }
        }

        public String FNaewonDate
        {
            get { return this._fNaewonDate; }
            set { this._fNaewonDate = value; }
        }

        public BAS0111U00LayGetJohapArgs() { }

        public BAS0111U00LayGetJohapArgs(String fHospCode, String fGubun, String fNaewonDate)
        {
            this._fHospCode = fHospCode;
            this._fGubun = fGubun;
            this._fNaewonDate = fNaewonDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0111U00LayGetJohapRequest();
        }
    }
}