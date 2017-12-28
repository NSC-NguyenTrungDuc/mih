using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT1002U00LayXRT0123Args : IContractArgs
    {
    protected bool Equals(XRT1002U00LayXRT0123Args other)
    {
        return string.Equals(_buwiCode, other._buwiCode) && string.Equals(_xrayGubun, other._xrayGubun);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT1002U00LayXRT0123Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_buwiCode != null ? _buwiCode.GetHashCode() : 0)*397) ^ (_xrayGubun != null ? _xrayGubun.GetHashCode() : 0);
        }
    }

    private String _buwiCode;
        private String _xrayGubun;

        public String BuwiCode
        {
            get { return this._buwiCode; }
            set { this._buwiCode = value; }
        }

        public String XrayGubun
        {
            get { return this._xrayGubun; }
            set { this._xrayGubun = value; }
        }

        public XRT1002U00LayXRT0123Args() { }

        public XRT1002U00LayXRT0123Args(String buwiCode, String xrayGubun)
        {
            this._buwiCode = buwiCode;
            this._xrayGubun = xrayGubun;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT1002U00LayXRT0123Request();
        }
    }
}