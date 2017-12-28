using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U03SearchPatientArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U03SearchPatientArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_sex, other._sex) && string.Equals(_fromAge, other._fromAge) && string.Equals(_toAge, other._toAge) && string.Equals(_naewonDateFrom, other._naewonDateFrom) && string.Equals(_naewonDateTo, other._naewonDateTo) && string.Equals(_makerYn, other._makerYn) && string.Equals(_join, other._join) && string.Equals(_patientCode, other._patientCode) && string.Equals(_filterStringOutsang, other._filterStringOutsang) && string.Equals(_filterStringOcs1003, other._filterStringOcs1003) && string.Equals(_filterStringView, other._filterStringView) && string.Equals(_filterStringEmr, other._filterStringEmr) && string.Equals(_filterCommandOutsang, other._filterCommandOutsang) && string.Equals(_filterCommandOcs1003, other._filterCommandOcs1003) && string.Equals(_filterCommandView, other._filterCommandView);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U03SearchPatientArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sex != null ? _sex.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fromAge != null ? _fromAge.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toAge != null ? _toAge.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonDateFrom != null ? _naewonDateFrom.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonDateTo != null ? _naewonDateTo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_makerYn != null ? _makerYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_join != null ? _join.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_patientCode != null ? _patientCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_filterStringOutsang != null ? _filterStringOutsang.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_filterStringOcs1003 != null ? _filterStringOcs1003.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_filterStringView != null ? _filterStringView.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_filterStringEmr != null ? _filterStringEmr.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_filterCommandOutsang != null ? _filterCommandOutsang.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_filterCommandOcs1003 != null ? _filterCommandOcs1003.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_filterCommandView != null ? _filterCommandView.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
        private String _sex;
        private String _fromAge;
        private String _toAge;
        private String _naewonDateFrom;
        private String _naewonDateTo;
        private String _makerYn;
        private String _join;
        private String _patientCode;
        private String _filterStringOutsang;
        private String _filterStringOcs1003;
        private String _filterStringView;
        private String _filterStringEmr;
        private String _filterCommandOutsang;
        private String _filterCommandOcs1003;
        private String _filterCommandView;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String FromAge
        {
            get { return this._fromAge; }
            set { this._fromAge = value; }
        }

        public String ToAge
        {
            get { return this._toAge; }
            set { this._toAge = value; }
        }

        public String NaewonDateFrom
        {
            get { return this._naewonDateFrom; }
            set { this._naewonDateFrom = value; }
        }

        public String NaewonDateTo
        {
            get { return this._naewonDateTo; }
            set { this._naewonDateTo = value; }
        }

        public String MakerYn
        {
            get { return this._makerYn; }
            set { this._makerYn = value; }
        }

        public String Join
        {
            get { return this._join; }
            set { this._join = value; }
        }

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public String FilterStringOutsang
        {
            get { return this._filterStringOutsang; }
            set { this._filterStringOutsang = value; }
        }

        public String FilterStringOcs1003
        {
            get { return this._filterStringOcs1003; }
            set { this._filterStringOcs1003 = value; }
        }

        public String FilterStringView
        {
            get { return this._filterStringView; }
            set { this._filterStringView = value; }
        }

        public String FilterStringEmr
        {
            get { return this._filterStringEmr; }
            set { this._filterStringEmr = value; }
        }

        public String FilterCommandOutsang
        {
            get { return this._filterCommandOutsang; }
            set { this._filterCommandOutsang = value; }
        }

        public String FilterCommandOcs1003
        {
            get { return this._filterCommandOcs1003; }
            set { this._filterCommandOcs1003 = value; }
        }

        public String FilterCommandView
        {
            get { return this._filterCommandView; }
            set { this._filterCommandView = value; }
        }

        public CLIS2015U03SearchPatientArgs() { }

        public CLIS2015U03SearchPatientArgs(String hospCode, String sex, String fromAge, String toAge, String naewonDateFrom, String naewonDateTo, String makerYn, String join, String patientCode, String filterStringOutsang, String filterStringOcs1003, String filterStringView, String filterStringEmr, String filterCommandOutsang, String filterCommandOcs1003, String filterCommandView)
        {
            this._hospCode = hospCode;
            this._sex = sex;
            this._fromAge = fromAge;
            this._toAge = toAge;
            this._naewonDateFrom = naewonDateFrom;
            this._naewonDateTo = naewonDateTo;
            this._makerYn = makerYn;
            this._join = join;
            this._patientCode = patientCode;
            this._filterStringOutsang = filterStringOutsang;
            this._filterStringOcs1003 = filterStringOcs1003;
            this._filterStringView = filterStringView;
            this._filterStringEmr = filterStringEmr;
            this._filterCommandOutsang = filterCommandOutsang;
            this._filterCommandOcs1003 = filterCommandOcs1003;
            this._filterCommandView = filterCommandView;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U03SearchPatientRequest();
        }
    }
}