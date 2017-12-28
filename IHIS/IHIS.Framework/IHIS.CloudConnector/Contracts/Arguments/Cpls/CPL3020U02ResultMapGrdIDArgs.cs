using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL3020U02ResultMapGrdIDArgs : IContractArgs
    {
        protected bool Equals(CPL3020U02ResultMapGrdIDArgs other)
        {
            return string.Equals(_jangbiCode, other._jangbiCode) && string.Equals(_specimenSer, other._specimenSer) && string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate) && string.Equals(_allYn, other._allYn);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U02ResultMapGrdIDArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_jangbiCode != null ? _jangbiCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_specimenSer != null ? _specimenSer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fromDate != null ? _fromDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_allYn != null ? _allYn.GetHashCode() : 0);
                return hashCode;
            }
        }        

        private String _jangbiCode;
        private String _specimenSer;
        private String _fromDate;
        private String _toDate;
        private String _allYn;

        public String JangbiCode
        {
            get { return this._jangbiCode; }
            set { this._jangbiCode = value; }
        }

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public String FromDate
        {
            get { return this._fromDate; }
            set { this._fromDate = value; }
        }

        public String ToDate
        {
            get { return this._toDate; }
            set { this._toDate = value; }
        }

        public String AllYn
        {
            get { return this._allYn; }
            set { this._allYn = value; }
        }

        public CPL3020U02ResultMapGrdIDArgs() { }

        public CPL3020U02ResultMapGrdIDArgs(String jangbiCode, String specimenSer, String fromDate, String toDate, String allYn)
        {
            this._jangbiCode = jangbiCode;
            this._specimenSer = specimenSer;
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._allYn = allYn;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3020U02ResultMapGrdIDRequest();
        }
    }
}