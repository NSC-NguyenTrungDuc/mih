using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCSACTBtnReserViewerClickArgs : IContractArgs
    {
    protected bool Equals(OCSACTBtnReserViewerClickArgs other)
    {
        return string.Equals(_code, other._code);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSACTBtnReserViewerClickArgs) obj);
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

        public OCSACTBtnReserViewerClickArgs() { }

        public OCSACTBtnReserViewerClickArgs(String code)
        {
            this._code = code;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACTBtnReserViewerClickRequest();
        }
    }
}