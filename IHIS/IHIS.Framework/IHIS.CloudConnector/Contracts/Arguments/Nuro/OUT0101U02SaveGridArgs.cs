using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class OUT0101U02SaveGridArgs : IContractArgs
    {
        protected bool Equals(OUT0101U02SaveGridArgs other)
        {
            return Equals(_patientList, other._patientList) && Equals(_boheomList, other._boheomList) && Equals(_gongbiList, other._gongbiList) && string.Equals(_userId, other._userId) && string.Equals(_patientCode, other._patientCode) && string.Equals(_hospCode, other._hospCode) && string.Equals(_autoBunhoFlg, other._autoBunhoFlg) && string.Equals(_orcaRequest, other._orcaRequest) && string.Equals(_orcaGigwanCode, other._orcaGigwanCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OUT0101U02SaveGridArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_patientList != null ? _patientList.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_boheomList != null ? _boheomList.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gongbiList != null ? _gongbiList.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_patientCode != null ? _patientCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_autoBunhoFlg != null ? _autoBunhoFlg.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_orcaRequest != null ? _orcaRequest.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_orcaGigwanCode != null ? _orcaGigwanCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private List<NuroOUT0101U02GridPatientInfo> _patientList = new List<NuroOUT0101U02GridPatientInfo>();
        private List<NuroOUT0101U02GridBoheomInfo> _boheomList = new List<NuroOUT0101U02GridBoheomInfo>();
        private List<NuroOUT0101U02GridGongbiListInfo> _gongbiList = new List<NuroOUT0101U02GridGongbiListInfo>();
        private String _userId;
        private String _patientCode;
        private String _hospCode;
        private String _autoBunhoFlg;
        private String _orcaRequest;
        private String _orcaGigwanCode;

        public List<NuroOUT0101U02GridPatientInfo> PatientList
        {
            get { return this._patientList; }
            set { this._patientList = value; }
        }

        public List<NuroOUT0101U02GridBoheomInfo> BoheomList
        {
            get { return this._boheomList; }
            set { this._boheomList = value; }
        }

        public List<NuroOUT0101U02GridGongbiListInfo> GongbiList
        {
            get { return this._gongbiList; }
            set { this._gongbiList = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String AutoBunhoFlg
        {
            get { return this._autoBunhoFlg; }
            set { this._autoBunhoFlg = value; }
        }

        public String OrcaRequest
        {
            get { return this._orcaRequest; }
            set { this._orcaRequest = value; }
        }

        public String OrcaGigwanCode
        {
            get { return this._orcaGigwanCode; }
            set { this._orcaGigwanCode = value; }
        }

        public OUT0101U02SaveGridArgs() { }

        public OUT0101U02SaveGridArgs(List<NuroOUT0101U02GridPatientInfo> patientList, List<NuroOUT0101U02GridBoheomInfo> boheomList, List<NuroOUT0101U02GridGongbiListInfo> gongbiList, String userId, String patientCode, String hospCode, String autoBunhoFlg, String orcaRequest, String orcaGigwanCode)
        {
            this._patientList = patientList;
            this._boheomList = boheomList;
            this._gongbiList = gongbiList;
            this._userId = userId;
            this._patientCode = patientCode;
            this._hospCode = hospCode;
            this._autoBunhoFlg = autoBunhoFlg;
            this._orcaRequest = orcaRequest;
            this._orcaGigwanCode = orcaGigwanCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OUT0101U02SaveGridRequest();
        }
    }
}