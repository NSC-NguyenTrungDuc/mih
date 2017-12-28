using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0003U00GrdIFS0003Args : IContractArgs
    {
        protected bool Equals(IFS0003U00GrdIFS0003Args other)
        {
            return string.Equals(_mapGubun, other._mapGubun) && string.Equals(_mapGubunYmd, other._mapGubunYmd) && string.Equals(_code, other._code) && string.Equals(_acctType, other._acctType) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0003U00GrdIFS0003Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_mapGubun != null ? _mapGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_mapGubunYmd != null ? _mapGubunYmd.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_code != null ? _code.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_acctType != null ? _acctType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _mapGubun;
        private String _mapGubunYmd;
        private String _code;
        private String _acctType;
        private String _pageNumber;
        private String _offset;

        public String MapGubun
        {
            get { return this._mapGubun; }
            set { this._mapGubun = value; }
        }

        public String MapGubunYmd
        {
            get { return this._mapGubunYmd; }
            set { this._mapGubunYmd = value; }
        }

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String AcctType
        {
            get { return this._acctType; }
            set { this._acctType = value; }
        }

        public String PageNumber
        {
            get { return this._pageNumber; }
            set { this._pageNumber = value; }
        }

        public String Offset
        {
            get { return this._offset; }
            set { this._offset = value; }
        }

        public IFS0003U00GrdIFS0003Args() { }

        public IFS0003U00GrdIFS0003Args(String mapGubun, String mapGubunYmd, String code, String acctType, String pageNumber, String offset)
        {
            this._mapGubun = mapGubun;
            this._mapGubunYmd = mapGubunYmd;
            this._code = code;
            this._acctType = acctType;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0003U00GrdIFS0003Request();
        }
    }
}