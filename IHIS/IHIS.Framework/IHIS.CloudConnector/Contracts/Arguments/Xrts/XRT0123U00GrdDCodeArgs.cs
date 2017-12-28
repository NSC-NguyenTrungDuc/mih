using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT0123U00GrdDCodeArgs : IContractArgs
    {
    protected bool Equals(XRT0123U00GrdDCodeArgs other)
    {
        return string.Equals(_xrayGubun, other._xrayGubun) && string.Equals(_buwiCode, other._buwiCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0123U00GrdDCodeArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_xrayGubun != null ? _xrayGubun.GetHashCode() : 0)*397) ^ (_buwiCode != null ? _buwiCode.GetHashCode() : 0);
        }
    }

    private String _xrayGubun;
        private String _buwiCode;

        public String XrayGubun
        {
            get { return this._xrayGubun; }
            set { this._xrayGubun = value; }
        }

        public String BuwiCode
        {
            get { return this._buwiCode; }
            set { this._buwiCode = value; }
        }

        public XRT0123U00GrdDCodeArgs() { }

        public XRT0123U00GrdDCodeArgs(String xrayGubun, String buwiCode)
        {
            this._xrayGubun = xrayGubun;
            this._buwiCode = buwiCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT0123U00GrdDCodeRequest();
        }
    }
}