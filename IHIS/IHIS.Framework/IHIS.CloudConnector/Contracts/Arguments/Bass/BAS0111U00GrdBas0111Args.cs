using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0111U00GrdBas0111Args : IContractArgs
    {
        protected bool Equals(BAS0111U00GrdBas0111Args other)
        {
            return string.Equals(_fHospCode, other._fHospCode) && string.Equals(_fJohapGubun, other._fJohapGubun) && string.Equals(_fJohap, other._fJohap);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0111U00GrdBas0111Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_fHospCode != null ? _fHospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fJohapGubun != null ? _fJohapGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fJohap != null ? _fJohap.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _fHospCode;
        private String _fJohapGubun;
        private String _fJohap;

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

        public BAS0111U00GrdBas0111Args() { }

        public BAS0111U00GrdBas0111Args(String fHospCode, String fJohapGubun, String fJohap)
        {
            this._fHospCode = fHospCode;
            this._fJohapGubun = fJohapGubun;
            this._fJohap = fJohap;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0111U00GrdBas0111Request();
        }
    }
}