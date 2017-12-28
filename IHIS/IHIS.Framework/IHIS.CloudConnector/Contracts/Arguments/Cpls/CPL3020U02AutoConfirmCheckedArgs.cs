using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL3020U02AutoConfirmCheckedArgs : IContractArgs
    {
        protected bool Equals(CPL3020U02AutoConfirmCheckedArgs other)
        {
            return string.Equals(_codeType, other._codeType) && string.Equals(_jangbiCode, other._jangbiCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U02AutoConfirmCheckedArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_codeType != null ? _codeType.GetHashCode() : 0)*397) ^ (_jangbiCode != null ? _jangbiCode.GetHashCode() : 0);
            }
        }

        private String _codeType;
        private String _jangbiCode;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String JangbiCode
        {
            get { return this._jangbiCode; }
            set { this._jangbiCode = value; }
        }

        public CPL3020U02AutoConfirmCheckedArgs() { }

        public CPL3020U02AutoConfirmCheckedArgs(String codeType, String jangbiCode)
        {
            this._codeType = codeType;
            this._jangbiCode = jangbiCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3020U02AutoConfirmCheckedRequest();
        }
    }
}