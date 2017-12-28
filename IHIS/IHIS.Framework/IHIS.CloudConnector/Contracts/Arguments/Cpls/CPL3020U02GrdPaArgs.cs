using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL3020U02GrdPaArgs : IContractArgs
    {
        protected bool Equals(CPL3020U02GrdPaArgs other)
        {
            return string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate) && string.Equals(_jangbiCode, other._jangbiCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U02GrdPaArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_fromDate != null ? _fromDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jangbiCode != null ? _jangbiCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _fromDate;
        private String _toDate;
        private String _jangbiCode;

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

        public String JangbiCode
        {
            get { return this._jangbiCode; }
            set { this._jangbiCode = value; }
        }

        public CPL3020U02GrdPaArgs() { }

        public CPL3020U02GrdPaArgs(String fromDate, String toDate, String jangbiCode)
        {
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._jangbiCode = jangbiCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3020U02GrdPaRequest();
        }
    }
}