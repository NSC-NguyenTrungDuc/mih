using System;
using IHIS.CloudConnector.Contracts.Models.Pfes;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Pfes
{[Serializable]
    public class PFE0101U01LayUserNameArgs : IContractArgs
    {
    protected bool Equals(PFE0101U01LayUserNameArgs other)
    {
        return string.Equals(_code, other._code);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PFE0101U01LayUserNameArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_code != null ? _code.GetHashCode() : 0);
    }

    private String _code;

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public PFE0101U01LayUserNameArgs() { }

        public PFE0101U01LayUserNameArgs(String code)
        {
            this._code = code;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PFE0101U01LayUserNameRequest();
        }
    }
}