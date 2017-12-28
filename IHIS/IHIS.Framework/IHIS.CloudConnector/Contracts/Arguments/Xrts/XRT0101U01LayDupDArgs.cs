using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT0101U01LayDupDArgs : IContractArgs
    {
    protected bool Equals(XRT0101U01LayDupDArgs other)
    {
        return string.Equals(_codeType, other._codeType) && string.Equals(_code, other._code);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0101U01LayDupDArgs) obj);
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

        public XRT0101U01LayDupDArgs() { }

        public XRT0101U01LayDupDArgs(String codeType, String code)
        {
            this._codeType = codeType;
            this._code = code;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT0101U01LayDupDRequest();
        }
    }
}