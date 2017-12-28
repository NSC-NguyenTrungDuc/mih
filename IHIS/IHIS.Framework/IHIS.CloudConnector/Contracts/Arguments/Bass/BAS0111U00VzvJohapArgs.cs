using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0111U00VzvJohapArgs : IContractArgs
    {
        protected bool Equals(BAS0111U00VzvJohapArgs other)
        {
            return string.Equals(_fHospCode, other._fHospCode) && string.Equals(_fJohap, other._fJohap) && string.Equals(_fStartDate, other._fStartDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0111U00VzvJohapArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_fHospCode != null ? _fHospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fJohap != null ? _fJohap.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fStartDate != null ? _fStartDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _fHospCode;
        private String _fJohap;
        private String _fStartDate;

        public String FHospCode
        {
            get { return this._fHospCode; }
            set { this._fHospCode = value; }
        }

        public String FJohap
        {
            get { return this._fJohap; }
            set { this._fJohap = value; }
        }

        public String FStartDate
        {
            get { return this._fStartDate; }
            set { this._fStartDate = value; }
        }

        public BAS0111U00VzvJohapArgs() { }

        public BAS0111U00VzvJohapArgs(String fHospCode, String fJohap, String fStartDate)
        {
            this._fHospCode = fHospCode;
            this._fJohap = fJohap;
            this._fStartDate = fStartDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0111U00VzvJohapRequest();
        }
    }
}