using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0203U00LaySymyaGubunArgs : IContractArgs
    {
        protected bool Equals(BAS0203U00LaySymyaGubunArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_code, other._code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0203U00LaySymyaGubunArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_hospCode != null ? _hospCode.GetHashCode() : 0)*397) ^ (_code != null ? _code.GetHashCode() : 0);
            }
        }

        private String _hospCode;
        private String _code;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public BAS0203U00LaySymyaGubunArgs() { }

        public BAS0203U00LaySymyaGubunArgs(String hospCode, String code)
        {
            this._hospCode = hospCode;
            this._code = code;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0203U00LaySymyaGubunRequest();
        }
    }
}