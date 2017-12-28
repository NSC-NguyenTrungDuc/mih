using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL7001Q02LayMonthlyReportArgs : IContractArgs
    {
        protected bool Equals(CPL7001Q02LayMonthlyReportArgs other)
        {
            return string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_uitakCode, other._uitakCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL7001Q02LayMonthlyReportArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_fromDate != null ? _fromDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_uitakCode != null ? _uitakCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _fromDate;
        private String _toDate;
        private String _ioGubun;
        private String _uitakCode;

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

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public String UitakCode
        {
            get { return this._uitakCode; }
            set { this._uitakCode = value; }
        }

        public CPL7001Q02LayMonthlyReportArgs() { }

        public CPL7001Q02LayMonthlyReportArgs(String fromDate, String toDate, String ioGubun, String uitakCode)
        {
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._ioGubun = ioGubun;
            this._uitakCode = uitakCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL7001Q02LayMonthlyReportRequest();
        }
    }
}