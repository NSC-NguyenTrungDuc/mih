using System;
using IHIS.CloudConnector.Contracts.Models.Pfes;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Pfes
{[Serializable]
    public class PFE0101U01LayDupDArgs : IContractArgs
    {
    protected bool Equals(PFE0101U01LayDupDArgs other)
    {
        return string.Equals(_codeType, other._codeType) && string.Equals(_code, other._code);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PFE0101U01LayDupDArgs) obj);
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

        public PFE0101U01LayDupDArgs() { }

        public PFE0101U01LayDupDArgs(String codeType, String code)
        {
            this._codeType = codeType;
            this._code = code;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PFE0101U01LayDupDRequest();
        }
    }
}