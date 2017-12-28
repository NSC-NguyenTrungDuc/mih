using System;
using IHIS.CloudConnector.Contracts.Models.Pfes;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Pfes
{[Serializable]
    public class PFE7001Q01LayDailyReportArgs : IContractArgs
    {
    protected bool Equals(PFE7001Q01LayDailyReportArgs other)
    {
        return string.Equals(_kensaDate, other._kensaDate) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_partCode, other._partCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PFE7001Q01LayDailyReportArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_kensaDate != null ? _kensaDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_partCode != null ? _partCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _kensaDate;
        private String _ioGubun;
        private String _partCode;

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

        public String PartCode
        {
            get { return this._partCode; }
            set { this._partCode = value; }
        }

        public PFE7001Q01LayDailyReportArgs() { }

        public PFE7001Q01LayDailyReportArgs(String kensaDate, String ioGubun, String partCode)
        {
            this._kensaDate = kensaDate;
            this._ioGubun = ioGubun;
            this._partCode = partCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PFE7001Q01LayDailyReportRequest();
        }
    }
}