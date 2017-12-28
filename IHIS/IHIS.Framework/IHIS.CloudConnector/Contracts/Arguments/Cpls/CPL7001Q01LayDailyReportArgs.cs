using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL7001Q01LayDailyReportArgs : IContractArgs
    {
        protected bool Equals(CPL7001Q01LayDailyReportArgs other)
        {
            return string.Equals(_kensaDate, other._kensaDate) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_uitakCode, other._uitakCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL7001Q01LayDailyReportArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_kensaDate != null ? _kensaDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_uitakCode != null ? _uitakCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _kensaDate;
        private String _ioGubun;
        private String _uitakCode;

        public String KensaDate
        {
            get { return this._kensaDate; }
            set { this._kensaDate = value; }
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

        public CPL7001Q01LayDailyReportArgs() { }

        public CPL7001Q01LayDailyReportArgs(String kensaDate, String ioGubun, String uitakCode)
        {
            this._kensaDate = kensaDate;
            this._ioGubun = ioGubun;
            this._uitakCode = uitakCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL7001Q01LayDailyReportRequest();
        }
    }
}