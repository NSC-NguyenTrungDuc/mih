using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT1002U00DsvXrayGubunArgs : IContractArgs
    {
    protected bool Equals(XRT1002U00DsvXrayGubunArgs other)
    {
        return string.Equals(_code, other._code);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT1002U00DsvXrayGubunArgs) obj);
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

        public XRT1002U00DsvXrayGubunArgs() { }

        public XRT1002U00DsvXrayGubunArgs(String code)
        {
            this._code = code;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT1002U00DsvXrayGubunRequest();
        }
    }
}