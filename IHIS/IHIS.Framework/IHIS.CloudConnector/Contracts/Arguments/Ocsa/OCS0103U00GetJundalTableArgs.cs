using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U00GetJundalTableArgs : IContractArgs
    {
    protected bool Equals(OCS0103U00GetJundalTableArgs other)
    {
        return string.Equals(_jundalPart, other._jundalPart) && string.Equals(_startDate, other._startDate) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U00GetJundalTableArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _jundalPart;
        private String _startDate;
        private String _ioGubun;
        private String _hospCode;

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0103U00GetJundalTableArgs() { }

        public OCS0103U00GetJundalTableArgs(String jundalPart, String startDate, String ioGubun, String hospCode)
        {
            this._jundalPart = jundalPart;
            this._startDate = startDate;
            this._ioGubun = ioGubun;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U00GetJundalTableRequest();
        }
    }
}