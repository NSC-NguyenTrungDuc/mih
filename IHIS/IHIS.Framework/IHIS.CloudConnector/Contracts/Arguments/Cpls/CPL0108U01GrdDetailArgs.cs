using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL0108U01GrdDetailArgs : IContractArgs
    {
        protected bool Equals(CPL0108U01GrdDetailArgs other)
        {
            return string.Equals(_codeType, other._codeType) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0108U01GrdDetailArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_codeType != null ? _codeType.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            }
        }

        private String _codeType;
        private String _hospCode;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public CPL0108U01GrdDetailArgs() { }

        public CPL0108U01GrdDetailArgs(String codeType, String hospCode)
        {
            this._codeType = codeType;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL0108U01GrdDetailRequest();
        }
    }
}