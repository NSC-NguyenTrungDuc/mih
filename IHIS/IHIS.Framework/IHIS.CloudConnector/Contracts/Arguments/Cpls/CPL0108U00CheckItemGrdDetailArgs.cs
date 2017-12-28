using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL0108U00CheckItemGrdDetailArgs : IContractArgs
    {
        protected bool Equals(CPL0108U00CheckItemGrdDetailArgs other)
        {
            return string.Equals(_code, other._code) && string.Equals(_codeType, other._codeType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0108U00CheckItemGrdDetailArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_code != null ? _code.GetHashCode() : 0)*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
            }
        }

        private String _code;
        private String _codeType;

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public CPL0108U00CheckItemGrdDetailArgs() { }

        public CPL0108U00CheckItemGrdDetailArgs(String code, String codeType)
        {
            this._code = code;
            this._codeType = codeType;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL0108U00CheckItemGrdDetailRequest();
        }
    }
}