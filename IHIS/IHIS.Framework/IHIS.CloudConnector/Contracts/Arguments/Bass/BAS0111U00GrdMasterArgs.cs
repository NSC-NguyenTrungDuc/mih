using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0111U00GrdMasterArgs : IContractArgs
    {
        protected bool Equals(BAS0111U00GrdMasterArgs other)
        {
            return string.Equals(_fHospCode, other._fHospCode) && string.Equals(_fJohapGubun, other._fJohapGubun) && string.Equals(_fJohap, other._fJohap) && string.Equals(_fNaewonDate, other._fNaewonDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0111U00GrdMasterArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_fHospCode != null ? _fHospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fJohapGubun != null ? _fJohapGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fJohap != null ? _fJohap.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fNaewonDate != null ? _fNaewonDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _fHospCode;
        private String _fJohapGubun;
        private String _fJohap;
        private String _fNaewonDate;

        public String FHospCode
        {
            get { return this._fHospCode; }
            set { this._fHospCode = value; }
        }

        public String FJohapGubun
        {
            get { return this._fJohapGubun; }
            set { this._fJohapGubun = value; }
        }

        public String FJohap
        {
            get { return this._fJohap; }
            set { this._fJohap = value; }
        }

        public String FNaewonDate
        {
            get { return this._fNaewonDate; }
            set { this._fNaewonDate = value; }
        }

        public BAS0111U00GrdMasterArgs() { }

        public BAS0111U00GrdMasterArgs(String fHospCode, String fJohapGubun, String fJohap, String fNaewonDate)
        {
            this._fHospCode = fHospCode;
            this._fJohapGubun = fJohapGubun;
            this._fJohap = fJohap;
            this._fNaewonDate = fNaewonDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0111U00GrdMasterRequest();
        }
    }
}