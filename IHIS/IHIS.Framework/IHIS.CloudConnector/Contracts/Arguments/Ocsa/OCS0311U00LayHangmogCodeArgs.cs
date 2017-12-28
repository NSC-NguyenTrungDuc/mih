using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0311U00LayHangmogCodeArgs : IContractArgs
    {
    protected bool Equals(OCS0311U00LayHangmogCodeArgs other)
    {
        return string.Equals(_code, other._code) && string.Equals(_code2, other._code2);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0311U00LayHangmogCodeArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_code != null ? _code.GetHashCode() : 0)*397) ^ (_code2 != null ? _code2.GetHashCode() : 0);
        }
    }

    private String _code;
        private String _code2;

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String Code2
        {
            get { return this._code2; }
            set { this._code2 = value; }
        }

        public OCS0311U00LayHangmogCodeArgs() { }

        public OCS0311U00LayHangmogCodeArgs(String code, String code2)
        {
            this._code = code;
            this._code2 = code2;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0311U00LayHangmogCodeRequest();
        }
    }
}