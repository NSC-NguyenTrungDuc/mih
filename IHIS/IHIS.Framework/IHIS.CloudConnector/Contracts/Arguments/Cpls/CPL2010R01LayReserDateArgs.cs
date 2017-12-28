using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL2010R01LayReserDateArgs : IContractArgs
    {
        protected bool Equals(CPL2010R01LayReserDateArgs other)
        {
            return string.Equals(_hoDong, other._hoDong) && string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL2010R01LayReserDateArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hoDong != null ? _hoDong.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fromDate != null ? _fromDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hoDong;
        private String _fromDate;
        private String _toDate;

        public String HoDong
        {
            get { return this._hoDong; }
            set { this._hoDong = value; }
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

        public CPL2010R01LayReserDateArgs() { }

        public CPL2010R01LayReserDateArgs(String hoDong, String fromDate, String toDate)
        {
            this._hoDong = hoDong;
            this._fromDate = fromDate;
            this._toDate = toDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010R01LayReserDateRequest();
        }
    }
}