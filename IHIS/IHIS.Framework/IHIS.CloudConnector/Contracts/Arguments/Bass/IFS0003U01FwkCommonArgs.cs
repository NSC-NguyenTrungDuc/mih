using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0003U01FwkCommonArgs : IContractArgs
    {
        protected bool Equals(IFS0003U01FwkCommonArgs other)
        {
            return string.Equals(_codeType, other._codeType) && string.Equals(_find1, other._find1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0003U01FwkCommonArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_codeType != null ? _codeType.GetHashCode() : 0)*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
            }
        }

        private String _codeType;
        private String _find1;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public IFS0003U01FwkCommonArgs() { }

        public IFS0003U01FwkCommonArgs(String codeType, String find1)
        {
            this._codeType = codeType;
            this._find1 = find1;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0003U01FwkCommonRequest();
        }
    }
}