using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0001U00PrCheckDupArgs : IContractArgs
    {
        protected bool Equals(IFS0001U00PrCheckDupArgs other)
        {
            return string.Equals(_masterCheck, other._masterCheck) && string.Equals(_codeType, other._codeType) && string.Equals(_code, other._code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0001U00PrCheckDupArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_masterCheck != null ? _masterCheck.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_code != null ? _code.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _masterCheck;
        private String _codeType;
        private String _code;

        public String MasterCheck
        {
            get { return this._masterCheck; }
            set { this._masterCheck = value; }
        }

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public IFS0001U00PrCheckDupArgs() { }

        public IFS0001U00PrCheckDupArgs(String masterCheck, String codeType, String code)
        {
            this._masterCheck = masterCheck;
            this._codeType = codeType;
            this._code = code;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0001U00PrCheckDupRequest();
        }
    }
}