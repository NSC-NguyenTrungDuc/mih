using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0001U00GrdDetailArgs : IContractArgs
    {
        protected bool Equals(IFS0001U00GrdDetailArgs other)
        {
            return string.Equals(_codeType, other._codeType) && string.Equals(_acctType, other._acctType) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0001U00GrdDetailArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_codeType != null ? _codeType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_acctType != null ? _acctType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _codeType;
        private String _acctType;
        private String _pageNumber;
        private String _offset;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
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

        public IFS0001U00GrdDetailArgs() { }

        public IFS0001U00GrdDetailArgs(String codeType, String acctType, String pageNumber, String offset)
        {
            this._codeType = codeType;
            this._acctType = acctType;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0001U00GrdDetailRequest();
        }
    }
}