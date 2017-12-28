using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0003U01FbxSearchGubunDataValidatingArgs : IContractArgs
    {
        protected bool Equals(IFS0003U01FbxSearchGubunDataValidatingArgs other)
        {
            return string.Equals(_codeType, other._codeType) && string.Equals(_code, other._code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0003U01FbxSearchGubunDataValidatingArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_codeType != null ? _codeType.GetHashCode() : 0)*397) ^ (_code != null ? _code.GetHashCode() : 0);
            }
        }

        private String _codeType;
        private String _code;

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

        public IFS0003U01FbxSearchGubunDataValidatingArgs() { }

        public IFS0003U01FbxSearchGubunDataValidatingArgs(String codeType, String code)
        {
            this._codeType = codeType;
            this._code = code;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0003U01FbxSearchGubunDataValidatingRequest();
        }
    }
}