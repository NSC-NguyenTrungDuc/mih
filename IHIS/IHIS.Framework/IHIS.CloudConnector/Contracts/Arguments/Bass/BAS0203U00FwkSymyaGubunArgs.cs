using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0203U00FwkSymyaGubunArgs : IContractArgs
    {
        protected bool Equals(BAS0203U00FwkSymyaGubunArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_find1, other._find1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0203U00FwkSymyaGubunArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_hospCode != null ? _hospCode.GetHashCode() : 0)*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
            }
        }

        private String _hospCode;
        private String _find1;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public BAS0203U00FwkSymyaGubunArgs() { }

        public BAS0203U00FwkSymyaGubunArgs(String hospCode, String find1)
        {
            this._hospCode = hospCode;
            this._find1 = find1;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0203U00FwkSymyaGubunRequest();
        }
    }
}